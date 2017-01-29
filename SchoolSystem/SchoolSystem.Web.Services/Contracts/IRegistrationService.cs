using System.Collections.Generic;

using SchoolSystem.Data.Models;

using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IRegistrationService
    {
        void CreateStudent(string studentId, int classOfStudentId);
        void CreateTeacher(string teacherId, int subjectId);
        IEnumerable<Subject> GetAllSubjects();
        IEnumerable<IdentityRole> GetAllUserRoles();
        IEnumerable<ClassOfStudents> GetClassOfStudents();
    }
}
