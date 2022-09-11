using System.ComponentModel.DataAnnotations;

namespace Talabat.API.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; } 
        [Required]
        public string FirstName { get; set; }  
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } 
       
        public string PhoneNumber { get; set; }

        public string Password { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }


    }
}
