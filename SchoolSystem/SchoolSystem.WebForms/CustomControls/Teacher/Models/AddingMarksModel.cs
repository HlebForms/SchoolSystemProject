using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Teacher.Models
{
    public class AddingMarksModel
    {
        public IEnumerable<ClassOfStudents> StudentClasses { get; internal set; }
        public IEnumerable<SubjectBasicInfo> Subjects { get; set; }

    }
}