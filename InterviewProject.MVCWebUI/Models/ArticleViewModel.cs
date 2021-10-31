using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.MVCWebUI.Models
{
    public class ArticleViewModel
    {
        public long ID { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
