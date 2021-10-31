using System;
using System.Collections.Generic;

#nullable disable

namespace InterviewProject.Entities.Models
{
    public partial class Article
    {
        public Article()
        {
            Questions = new HashSet<Question>();
        }

        public long Id { get; set; }
        public string CreateDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
