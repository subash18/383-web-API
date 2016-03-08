using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIPhase_2.Models
{
  public  class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [Index(IsUnique = true)]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string ApiKey { get; set; }

       public Role Role { get; set; }

    }
}
