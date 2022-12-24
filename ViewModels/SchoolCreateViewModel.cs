using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class SchoolCreateViewModel
    {


        [Required(ErrorMessage = "School name cannot be empty.")]
        [Display(Name = "School Name")]
        public string Name { get; set; }

        public IdentityUser Storekeeper { get; set; }

        [Required(ErrorMessage = "Location name cannot be empty.")]
        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}
