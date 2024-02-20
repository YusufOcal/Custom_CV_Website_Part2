using System.ComponentModel.DataAnnotations;

namespace Custom_CV_Website.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen soyadını giriniz.")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi giriniz.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz.")]
        [Compare("Password",ErrorMessage ="Şifreler uyumlu değil.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Lütfen bir mail girin.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Lütfen bir resim yolu giriniz.")]
        public string ImageUrl { get; set; }
    }
}
