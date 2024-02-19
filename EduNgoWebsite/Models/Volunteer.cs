using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduNgoWebsite.Models
{
    public class Volunteer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 99, ErrorMessage = "Age must be between 1 and 99")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Please enter a valid 10-digit mobile number")]
        public string? MobileNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? EmailAddress { get; set; }

        public string? Address { get; set; }

        [Required(ErrorMessage = "State is required")]
        //[ForeignKey("tbl_state")]
        public int StateId { get; set; }
        //public virtual State tbl_state { get; set; }

        [ForeignKey("StateId")] // Specify the foreign key property
        public virtual State? States { get; set; } // Navigation property to State

        [Required(ErrorMessage = "City is required")]
        public string? City { get; set; }

        [Required(ErrorMessage = "PIN code is required")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Please enter a valid 6-digit PIN code")]
        public string? PINCode { get; set; }

        public DateTime? CreatedDate { get; set; }


    }
}
