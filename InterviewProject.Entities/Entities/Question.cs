using System;
using System.Collections.Generic;

#nullable disable

namespace InterviewProject.Entities.Entities
{
    public partial class Question
    {
        public long Id { get; set; }
        public string CreateDate { get; set; }
        public string Title { get; set; }
        public string Avariant { get; set; }
        public string Bvariant { get; set; }
        public string Cvariant { get; set; }
        public string Dvariant { get; set; }
        public string CorrectAnswer { get; set; }
        public long? ArticleId { get; set; }
        public long? ExamId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
