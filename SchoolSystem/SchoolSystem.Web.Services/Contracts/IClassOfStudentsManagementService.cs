using System.Collections.Generic;

using SchoolSystem.Data.Models;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IClassOfStudentsManagementService
    {
        bool AddClass(string name, IEnumerable<string> subjecIds);

        bool AddSubjectsToClass(int classId, IEnumerable<int> subjectIds);

        IEnumerable<ClassOfStudents> GetAllClasses();

        IEnumerable<ClassOfStudents> GetAllClassesWithSpecifiedSubject(int subjectId);
    }
}
