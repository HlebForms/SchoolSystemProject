using SchoolSystem.Data.Models;
using System.Collections.Generic;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IClassOfStudentsManagementService
    {
        bool AddClass(string name, IEnumerable<string> subjecIds);

        void AddSubjectsToClass();

        IEnumerable<Subject> GetAllSubjects();
    }
}
