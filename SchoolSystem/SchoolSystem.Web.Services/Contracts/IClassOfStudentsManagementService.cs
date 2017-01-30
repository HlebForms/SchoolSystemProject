using SchoolSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IClassOfStudentsManagementService
    {
        bool AddClass(string name, IEnumerable<Subject> subjects);

        void AddSubjectsToClass();

        IEnumerable<Subject> GetAllSubjects()
    }
}
