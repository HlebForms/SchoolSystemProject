using System.Collections.Generic;

using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.MVP.Admin.Models
{
    public class CreatingClassOfStudentsModel
    {
        public IEnumerable<SubjectBasicInfoModel> Subjects { get; set; }

        public bool IsSuccesfull { get; set; }
    }
}