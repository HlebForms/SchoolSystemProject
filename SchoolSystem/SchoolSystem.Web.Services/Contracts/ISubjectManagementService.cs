using System.Collections.Generic;
using SchoolSystem.Data.Models;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface ISubjectManagementService
    {
        bool CreateSubject(string subjectName);

        IEnumerable<Subject> GetAllSubjects();

    }
}
