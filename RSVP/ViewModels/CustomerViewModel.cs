using System.ComponentModel.DataAnnotations;

namespace RSVP.ViewModels
{
    public class CustomerViewModel
    {
        [Display(Name = "Enter  name")]
        [MinLength(3, ErrorMessage = "The first name must be at least 3 characters long")]
        [StringLength(15, ErrorMessage = "Maximum 15 characters allowed")]
        [Required(ErrorMessage = "First name is required!")]
        public string FirstName { get; set; }

        [Display(Name = "Enter last name ")]
        [MinLength(3, ErrorMessage = "The last name must be at least 3 characters long")]
        [StringLength(25, ErrorMessage = "Maximum 15 characters allowed")]
        [Required(ErrorMessage = "Last name is required")]

        public string? LastName { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
