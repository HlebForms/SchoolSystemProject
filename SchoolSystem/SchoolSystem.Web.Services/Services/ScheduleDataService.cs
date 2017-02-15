using System;
using System.Collections.Generic;
using System.Linq;

using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Web.Services.Contracts;

using Bytes2you.Validation;
using SchoolSystem.Data;
using System.Data.Entity;

namespace SchoolSystem.Web.Services
{
    public class ScheduleDataService : IScheduleDataService
    {
        private readonly IRepository<Student> studentRepo;
        private readonly IRepository<SubjectClassOfStudentsDaysOfWeek> subjectClassOfStudentsDaysOfWeekRepo;
        private readonly IRepository<Subject> subjectRepo;
        private readonly IRepository<Teacher> teacherRepo;
        private readonly IRepository<User> userRepo;
        private readonly IRepository<DaysOfWeek> daysOfWeekRepo;
        private readonly Func<IUnitOfWork> unitOfWork;

        public ScheduleDataService(
            IRepository<Subject> subjectRepo,
            IRepository<User> userRepo,
            IRepository<Teacher> teacherRepo,
            IRepository<SubjectClassOfStudentsDaysOfWeek> subjectClassOfStudentsDaysOfWeekRepo,
            IRepository<DaysOfWeek> daysOfWeekRepo,
            IRepository<Student> studentRepo,
            Func<IUnitOfWork> unitOfWork
            )
        {
            Guard.WhenArgument(subjectRepo, "subjectRepo").IsNull().Throw();
            Guard.WhenArgument(userRepo, "userRepo").IsNull().Throw();
            Guard.WhenArgument(teacherRepo, "teacherRepo").IsNull().Throw();
            Guard.WhenArgument(subjectClassOfStudentsDaysOfWeekRepo, "subjectClassOfStudentsDaysOfWeekRepo").IsNull().Throw();
            Guard.WhenArgument(daysOfWeekRepo, "daysOfWeekRepo").IsNull().Throw();
            Guard.WhenArgument(studentRepo, "studentRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.studentRepo = studentRepo;
            this.subjectRepo = subjectRepo;
            this.userRepo = userRepo;
            this.teacherRepo = teacherRepo;
            this.subjectClassOfStudentsDaysOfWeekRepo = subjectClassOfStudentsDaysOfWeekRepo;
            this.daysOfWeekRepo = daysOfWeekRepo;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ScheduleModel> GetStudentScheduleForTheDay(DayOfWeek dayOfWeek, string username)
        {
            Guard.WhenArgument(username, "username").IsNullOrEmpty().Throw();

            var user = this.userRepo.GetFirst(x => x.UserName == username);

            if (user == null)
            {
                return new List<ScheduleModel>();
            }

            var userId = user.Id;

            var userClassOfStudents = this.studentRepo.GetFirst(x => x.Id == userId);

            if (userClassOfStudents == null)
            {
                return new List<ScheduleModel>();
            }

            var userClassOfStudentsId = userClassOfStudents.ClassOfStudentsId;

            var daySchedule = this.subjectClassOfStudentsDaysOfWeekRepo
                .GetAll(x => x.ClassOfStudentsId == userClassOfStudentsId
                        && x.DaysOfWeek.Id == (int)dayOfWeek,
                        x => new ScheduleModel()
                        {
                            SubjectId = x.SubjectId,
                            SubjectName = x.SubjectClassOfStudents.Subject.Name,
                            ImageUrl = x.SubjectClassOfStudents.Subject.ImageUrl,
                            TeacherName = x.SubjectClassOfStudents.Subject.Teacher.User.LastName,
                            StartHour = x.StartHour,
                            EndHour = x.EndHour
                        },
                        x => x.SubjectClassOfStudents.Subject,
                        x => x.SubjectClassOfStudents.Subject.Teacher.User);

            return daySchedule.OrderBy(x => x.StartHour);
        }

        public IEnumerable<ScheduleModel> GetTeacherScheduleForTheDay(DayOfWeek dayOfWeek, string username)
        {
            Guard.WhenArgument(username, "username").IsNullOrEmpty().Throw();

            var user = this.userRepo.GetFirst(x => x.UserName == username);
            if (user == null)
            {
                return new List<ScheduleModel>();
            }

            var userId = user.Id;

            var subjectIds = this.subjectRepo.GetAll(x => x.TeacherId == userId, y => y.Id);

            if (subjectIds.Count() == 0)
            {
                return new List<ScheduleModel>();
            }

            var subjects =
                this.subjectClassOfStudentsDaysOfWeekRepo
                .GetAll(x => x.DaysOfWeekId == (int)dayOfWeek &&
                        subjectIds.Contains(x.SubjectId),
                        x => new ScheduleModel
                        {
                            SubjectId = x.SubjectId,
                            SubjectName = x.SubjectClassOfStudents.Subject.Name,
                            ClassName = x.SubjectClassOfStudents.ClassOfStudents.Name,
                            ImageUrl = x.SubjectClassOfStudents.Subject.ImageUrl,
                            StartHour = x.StartHour,
                            EndHour = x.EndHour
                        },
                        x => x.SubjectClassOfStudents,
                        x => x.SubjectClassOfStudents.Subject,
                        x => x.SubjectClassOfStudents.ClassOfStudents
                        );

            return subjects.OrderBy(x => x.StartHour);
        }

        public IEnumerable<DaysOfWeek> GetAllDaysOfWeek()
        {
            return this.daysOfWeekRepo.GetAll();
        }

        public IEnumerable<ManagingScheduleModel> GetSchedulePerDay(int dayOfWeekId, int classId)
        {
            var data = new List<ManagingScheduleModel>();

            var content = this.subjectClassOfStudentsDaysOfWeekRepo.GetAll(
                x => x.DaysOfWeekId == dayOfWeekId
                && x.ClassOfStudentsId == classId
                , x => new ManagingScheduleModel()
                {
                    DaysOfWeek = x.DaysOfWeek,
                    Subject = x.SubjectClassOfStudents.Subject,
                    StartHour = x.StartHour,
                    EndHour = x.EndHour
                },
                i => i.SubjectClassOfStudents,
                i => i.SubjectClassOfStudents.Subject);

            return content;
        }

        public bool AddSubjectToSchedule(int classId, int subjectId, int dayOfWeekId, DateTime startHour, DateTime endHour)
        {
            using (var uow = this.unitOfWork())
            {
                this.subjectClassOfStudentsDaysOfWeekRepo.Add(new SubjectClassOfStudentsDaysOfWeek()
                {
                    ClassOfStudentsId = classId,
                    SubjectId = subjectId,
                    DaysOfWeekId = dayOfWeekId,
                    StartHour = startHour,
                    EndHour = endHour
                });

                try
                {
                    return uow.Commit();

                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public void RemoveSubjectFromSchedule(int classId, int daysOfWeekId, int subjectId)
        {
            var entity = this.subjectClassOfStudentsDaysOfWeekRepo
                .GetFirst(x => x.ClassOfStudentsId == classId
                                && x.DaysOfWeekId == daysOfWeekId
                                && x.SubjectId == subjectId);

            using (var uow = this.unitOfWork())
            {
                this.subjectClassOfStudentsDaysOfWeekRepo.Delete(entity);
                uow.Commit();
            }
        }
    }
}