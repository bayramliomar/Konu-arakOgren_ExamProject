using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.MVCWebUI.Models
{
    public class RegisterViewModel
    {
        public string Name{ get; set; }
        public string Surname{ get; set; }

        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez")]
        public string Username{ get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Password{ get; set; }

        [Required(ErrorMessage = "Şifre tekrarı boş geçilemez")]
        
        [Compare("Password",ErrorMessage ="Şifre tekrarı şifre ile aynı deyil !")]
        public string RePassword{ get; set; }
    }
}
