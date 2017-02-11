using Ninject.Modules;
using SchoolSystem.Web.Services;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.WebForms.App_Start.Bindings
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRegistrationService>().To<RegistrationService>();
            this.Bind<ISubjectManagementService>().To<SubjectManagementService>();
            this.Bind<IScheduleDataService>().To<ScheduleDataService>();
            this.Bind<IClassOfStudentsManagementService>().To<ClassOfStudentsManagementService>();
            this.Bind<IAccountManagementService>().To<AccountManagementService>();
            this.Bind<INewsDataService>().To<NewsDataService>();
            this.Bind<IMarksManagementService>().To<MarksManagementService>();
            this.Bind<IStudentManagementService>().To<StudentManagementService>();
        }
    }
}