using SchoolSystem.Data.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IMarksManagementService
    {
        IEnumerable<SchoolReportCard> GetMarks(int subjectId, int classOfStudentsId);
        void AddMark(string studentId, int subjectId, int markId);
    }
}
