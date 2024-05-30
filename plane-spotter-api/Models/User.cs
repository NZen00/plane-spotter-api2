using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaneSpotterApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<AirlineSighting> CreatedSightings { get; set; }

        public ICollection<AirlineSighting> ModifiedSightings { get; set; }
    }
}
