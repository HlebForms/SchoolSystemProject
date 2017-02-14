using System.Collections.Generic;

using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IRegistrationService
    {
        void CreateStudent(string studentId, int classOfStudentId);

        void CreateTeacher(string teacherId, IEnumerable<int> subjectId);

        IEnumerable<IdentityRole> GetAllUserRoles();
    }
}
