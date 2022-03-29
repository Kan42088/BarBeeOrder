using System.ComponentModel.DataAnnotations;

namespace BarBeeOrder.ModelView
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
