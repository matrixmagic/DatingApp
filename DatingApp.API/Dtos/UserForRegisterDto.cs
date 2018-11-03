using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {   [Required]
        public string Username{set;get;}
        [Required]
        [StringLength(8,MinimumLength=4, ErrorMessage="you must specify password betwwen 4 8 characters!!")]
        public string Password{get;set;}
    }
}