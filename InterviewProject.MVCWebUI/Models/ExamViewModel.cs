using InterviewProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.MVCWebUI.Models
{
    public class ExamViewModel
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public long ArticleID { get; set; }

        [Required(ErrorMessage ="Soru 1 boş geçilemez")]
        public string Question1 { get; set; }
        
        [Required(ErrorMessage = "Soru 2 boş geçilemez")]
        public string Question2 { get; set; }
        
        [Required(ErrorMessage = "Soru 3 boş geçilemez")]
        public string Question3 { get; set; }
        
        [Required(ErrorMessage = "Soru 4 boş geçilemez")]
        public string Question4 { get; set; }
        
        [Required(ErrorMessage = "Soru 1 A şıkkı boş geçilemez")]
        public string AVRT1 { get; set; }

        [Required(ErrorMessage = "Soru 2 A şıkkı boş geçilemez")]
        public string AVRT2 { get; set; }

        [Required(ErrorMessage = "Soru 3 A şıkkı boş geçilemez")]
        public string AVRT3 { get; set; }

        [Required(ErrorMessage = "Soru 4 A şıkkı boş geçilemez")]
        public string AVRT4 { get; set; }

        [Required(ErrorMessage = "Soru 1 B şıkkı boş geçilemez")]
        public string BVRT1 { get; set; }

        [Required(ErrorMessage = "Soru 2 B şıkkı boş geçilemez")]
        public string BVRT2 { get; set; }

        [Required(ErrorMessage = "Soru 3 B şıkkı boş geçilemez")]
        public string BVRT3 { get; set; }

        [Required(ErrorMessage = "Soru 4 B şıkkı boş geçilemez")]
        public string BVRT4 { get; set; }

        [Required(ErrorMessage = "Soru 1 C şıkkı boş geçilemez")]
        public string CVRT1 { get; set; }

        [Required(ErrorMessage = "Soru 2 C şıkkı boş geçilemez")]
        public string CVRT2 { get; set; }

        [Required(ErrorMessage = "Soru 3 C şıkkı boş geçilemez")]
        public string CVRT3 { get; set; }

        [Required(ErrorMessage = "Soru 4 C şıkkı boş geçilemez")]
        public string CVRT4 { get; set; }

        [Required(ErrorMessage = "Soru 1 D şıkkı boş geçilemez")]
        public string DVRT1 { get; set; }

        [Required(ErrorMessage = "Soru 2 D şıkkı boş geçilemez")]
        public string DVRT2 { get; set; }

        [Required(ErrorMessage = "Soru 3 D şıkkı boş geçilemez")]
        public string DVRT3 { get; set; }

        [Required(ErrorMessage = "Soru 4 D şıkkı boş geçilemez")]
        public string DVRT4 { get; set; }

        [Required(ErrorMessage = "Soru 1 doğru cevap boş geçilemez")]
        public string CA1 { get; set; }

        [Required(ErrorMessage = "Soru 2 doğru cevap boş geçilemez")]
        public string CA2 { get; set; }

        [Required(ErrorMessage = "Soru 3 doğru cevap boş geçilemez")]
        public string CA3 { get; set; }

        [Required(ErrorMessage = "Soru 4 doğru cevap boş geçilemez")]
        public string CA4 { get; set; }

        public string CreateDate { get; set; }

        [Required(ErrorMessage = "Başlık boş geçilemez")]
        public long ArticleTitle { get; set; }

        public List<ArticleViewModel> Articles { get; set; }
    }
}
