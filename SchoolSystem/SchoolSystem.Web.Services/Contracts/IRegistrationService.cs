using System.Collections.Generic;

using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IRegistrationService
    {
        void RegisterStudent(string studentId, int classOfStudentId);

        void RegisterTeacher(string teacherId, IEnumerable<int> subjectId);

        IEnumerable<IdentityRole> GetAllUserRoles();
    }
}
