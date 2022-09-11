using System.ComponentModel.DataAnnotations;

namespace Talabat.DAL.Entities.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        [Required]
        public string AppUserId { get; set; }
        public AppUser User { get; set; }
    }
}