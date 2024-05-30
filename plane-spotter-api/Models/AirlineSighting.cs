using System;
using System.ComponentModel.DataAnnotations;

namespace PlaneSpotterApi.Models
{
    public class AirlineSighting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(5)]
        public string ShortName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{3}-[A-Z0-9]{4}$", ErrorMessage = "Invalid Airline Code format. Expected format: 'ABC-1234'")]
        public string AirlineCode { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [PastDate(ErrorMessage = "Created Date must be a valid datetime in the past")]
        public DateTime CreatedDate { get; set; }

        public bool Active { get; set; } = true;

        public bool Delete { get; set; } = false;

        public int? CreatedUserId { get; set; }

        public int? ModifiedUserId { get; set; }

        public User? CreatedUser { get; set; }

        public User? ModifiedUser { get; set; }
    }

    public class PastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime < DateTime.Now;
            }
            return false;
        }
    }
}
