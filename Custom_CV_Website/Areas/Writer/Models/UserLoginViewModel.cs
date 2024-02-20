using System.ComponentModel.DataAnnotations;

namespace Custom_CV_Website.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı adını giriniz")]
        public string Username { get; set; }

        [Display(Name ="Şifre")]
        [Required(ErrorMessage ="Şifreyi giriniz")]
        public string Password { get; set; }
    }
}
