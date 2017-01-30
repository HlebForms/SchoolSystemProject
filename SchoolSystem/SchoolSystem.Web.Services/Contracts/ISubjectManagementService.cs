using SchoolSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface ISubjectManagementService
    {
        void CreateSubject(string subjectName);

        IEnumerable<Subject> GetAllSubjects();
    }
}
