using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models.CustomModels
{
    public class ManagingScheduleModel
    {
        public DaysOfWeek DaysOfWeek { get; set; }

        public DateTime StartHour { get; set; }

        public Subject Subject { get; set; }

        public DateTime EndHour { get; set; }
    }
}
