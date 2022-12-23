using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class SchoolEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "School name cannot be empty.")]
        [Display(Name = "Inventory Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location name cannot be empty.")]
        [Display(Name = "Inventory Name")]
        public string Location { get; set; }
        public List<InventoryViewModel> Inventories { get; set; }


    }
}
