using System.Collections.Generic;

using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IStudentManagementService
    {
        IEnumerable<StudentInfoModel> GetAllStudentsFromClass(int classId);
    }
}
