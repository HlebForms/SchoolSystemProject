using System;
using System.Collections.Generic;
using System.Linq;

using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Web.Services.Contracts;

using Bytes2you.Validation;

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

        public IEnumerable<StudentSchedule> GetStudentScheduleForTheDay(DayOfWeek dayOfWeek, string username)
        {
            var user = this.userRepo.GetFirst(x => x.UserName == username);
            Guard.WhenArgument(user, "user").IsNull().Throw();
            var userId = user.Id;

            var userClassOfStudents = this.studentRepo.GetFirst(x => x.Id == userId);
            Guard.WhenArgument(userClassOfStudents, "userClassOfStudents").IsNull().Throw();
            var userClassOfStudentsId = userClassOfStudents.ClassOfStudentsId;

            var daySchedule = this.subjectClassOfStudentsDaysOfWeekRepo
                .GetAll(x => x.ClassOfStudentsId == userClassOfStudentsId && x.DaysOfWeek.Id == (int)dayOfWeek, y => y);

            Guard.WhenArgument(daySchedule, "daySchedule").IsNull().Throw();

            var result = new List<StudentSchedule>();

            foreach (var schedule in daySchedule)
            {
                var teacherName = subjectRepo
                    .GetFirst(x => x.Id == schedule.SubjectId, x => x.Teacher, x => x.Teacher.User)
                    .Teacher
                    .User
                    .LastName;

                result.Add(
                        new StudentSchedule()
                        {
                            SubjectId = schedule.SubjectId,
                            SubjectName = schedule.SubjectClassOfStudents.Subject.Name,
                            ImageUrl = schedule.SubjectClassOfStudents.Subject.ImageUrl,
                            TeacherName = teacherName,
                            StartHour = schedule.StartHour,
                            EndHour = schedule.EndHour
                        }
                    );
            }

            return result;
        }

        public IEnumerable<DaysOfWeek> GetAllDaysOfWeek()
        {
            return this.daysOfWeekRepo.GetAll();
        }

        public IEnumerable<ManagingScheduleModel> GetTodaysSchedule(int dayOfWeekId, int classId)
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
                });

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
                    // nqma da se dobavi - pk confilct
                }
            }

            return false;
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
