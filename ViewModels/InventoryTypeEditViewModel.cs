using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Task3.ViewModels
{
    public class InventoryTypeEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Inventory type name cannot be empty.")]
        [Display(Name = "Inventory type name")]
        public string Name { get; set; }
    }
}
