using System.ComponentModel.DataAnnotations;

namespace BarBeeOrder.ModelView
{
    public class LoginViewModel
    {
        [Key]
        [Required(ErrorMessage ="Vui lòng không để trống tên tài khoản!")]
        [Display(Name ="Địa chỉ Email")]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng không để trống mật khẩu!")]
        [MinLength(5,ErrorMessage ="Mật khẩu cần tối thiểu 5 kí tự!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
