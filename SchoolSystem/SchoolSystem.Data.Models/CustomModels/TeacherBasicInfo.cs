namespace SchoolSystem.Data.Models.CustomModels
{
    public class TeacherBasicInfo
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName} ({this.UserName})";
            }
        }
    }
}
