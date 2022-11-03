using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class CustomerModel
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name="Enter  name")]
        [MinLength(3)]
        [StringLength(15, ErrorMessage = "Maximum 15 characters allowed")]
        [Required(ErrorMessage ="First name is required!")]
        public string FirstName { get; set; }

        [Display(Name="Enter last name ")]
        [MinLength(3)]
        [StringLength(15, ErrorMessage = "Maximum 15 characters allowed")]
        [Required(ErrorMessage ="Last name is required")]
        public string LastName { get; set; }

        [Required]
        public string Status { get; set; }

        
    }
}
