using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task3.ViewModels
{
    public class InventoryTypeViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<InventoryViewModel> Inventories { get; set; }
    }
}
