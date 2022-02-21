using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace asmfinal.Models
{
    public class Login : ASMContext
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Phải nhập")]
        [Display(Name = "Tên")]
        [Column(TypeName = "nvarchar(100)")]
        public string name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "{0} Phải nhập")]
        [Display(Name = "Email của bạn")]
        public string email { get; set; }

        [Required(ErrorMessage = "{0} Phải nhập")]
        [Display(Name = "Mật khẩu")]
        [Column(TypeName = "varchar(100)")]
        public string password { get; set; }
    }
}
