using System.Collections.Generic;

using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface ISubjectManagementService
    {
        bool CreateSubject(string subjectName, string subjectPictureUrl);

        IEnumerable<Subject> GetAllSubjects();

        IEnumerable<Subject> GetSubjectsForSpecificClass(int classId);

        IEnumerable<SubjectBasicInfo> GetSubjectsPerTeacher(string teacherName, bool isAdmin);

        /// <summary>
        /// Gets the subjects with no assigned teacher
        /// </summary>
        /// <returns> IEnumerable<Subject> </returns>
        IEnumerable<SubjectBasicInfo> GetAllAvailableSubjects();
    }
}
