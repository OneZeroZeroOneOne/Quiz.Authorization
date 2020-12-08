using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Authorization.Dal.Models
{
    public partial class Employee
    {
        public Employee()
        {
            UserAnswers = new HashSet<UserAnswer>();
            UserEmployees = new HashSet<UserEmployee>();
            UserQuizzes = new HashSet<UserQuiz>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Soname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }

        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
        public virtual ICollection<UserEmployee> UserEmployees { get; set; }
        public virtual ICollection<UserQuiz> UserQuizzes { get; set; }
    }
}
