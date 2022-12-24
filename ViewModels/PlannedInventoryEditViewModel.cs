using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class PlannedInventoryEditViewModel
    {
        public int Id { get; set; }

        public int? RentRequestId { get; set; }
        public int? EventId { get; set; }
        public RentRequestViewModel RentRequest { get; set; }
        public IEnumerable<AllocatedInventoryViewModel> AllocatedInventories { get; set; }
        public int? InventoryTypeId { get; set; }
        public InventoryTypeViewModel InventoryType { get; set; }
        [Required(ErrorMessage = "Select amount of inventory to plan.")]
        [Display(Name = "Inventory Amount")]
        public float Amount { get; set; }
    }
}
