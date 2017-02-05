using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using SchoolSystem.Data.Models.CustomModels;

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
            this.studentRepo = studentRepo;
            this.subjectRepo = subjectRepo;
            this.userRepo = userRepo;
            this.teacherRepo = teacherRepo;
            this.subjectClassOfStudentsDaysOfWeekRepo = subjectClassOfStudentsDaysOfWeekRepo;
            this.daysOfWeekRepo = daysOfWeekRepo;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<StudentSchedule> GetTodaysSchedule(DayOfWeek dayOfWeek, string username)
        {
            //var userId = this.userRepo.GetFirst(x => x.UserName == username).Id;
            // STOQN
            //var userId = "8c8a33cb-ae6e-453c-aae6-fef949a3c370"; 
            // KIRO

            var userId = this.userRepo.GetFirst(x => x.UserName == username).Id;

            var userClassId = this.studentRepo.GetFirst(x => x.Id == userId).ClassOfStudentsId;
            var daySchedule = this.subjectClassOfStudentsDaysOfWeekRepo
                .GetAll(x => x.ClassOfStudentsId == userClassId && x.DaysOfWeek.Id == (int)dayOfWeek, y => y)
                .ToList();

            var result = new List<StudentSchedule>();

            foreach (var schedule in daySchedule)
            {
                var teacherId = teacherRepo.GetFirst(x => x.SubjectId == schedule.SubjectId).Id;
                var teacherName = userRepo.GetFirst(x => x.Id == teacherId).LastName;

                result.Add(
                    new StudentSchedule()
                    {
                        SubjectId = schedule.SubjectId,
                        SubjectName = schedule.SubjectClassOfStudents.Subject.Name,
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

        public void AddSubjectToSchedule(int classId, int subjectId, int dayOfWeekId, DateTime startHour, DateTime endHour)
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
                    uow.Commit();

                }
                catch (Exception e)
                {
                    // nqma da se dobavi - pk confilct
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
