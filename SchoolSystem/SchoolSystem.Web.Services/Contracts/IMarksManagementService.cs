using System.Collections.Generic;

using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IMarksManagementService
    {
        IEnumerable<SchoolReportCard> GetMarks(int subjectId, int classOfStudentsId);

        void AddMark(string studentId, int subjectId, int markId);

        IEnumerable<Mark> GetAllMarks();
    }
}
