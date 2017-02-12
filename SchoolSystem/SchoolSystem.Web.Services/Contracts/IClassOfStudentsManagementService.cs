using System.Collections.Generic;

using SchoolSystem.Data.Models;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IClassOfStudentsManagementService
    {
        bool AddClass(string name, IEnumerable<string> subjecIds);

        void AddSubjectsToClass(int classId, int subjectId);

        IEnumerable<ClassOfStudents> GetAllClasses();

        IEnumerable<ClassOfStudents> GetAllClassesWithSpecifiedSubject(int subjectId);
    }
}
