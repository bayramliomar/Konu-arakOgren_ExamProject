using System;
using System.Collections.Generic;

#nullable disable

namespace InterviewProject.Entities.Entities
{
    public partial class Exam
    {
        public Exam()
        {
            Questions = new HashSet<Question>();
        }

        public long Id { get; set; }
        public string CreateDate { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUser User { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
