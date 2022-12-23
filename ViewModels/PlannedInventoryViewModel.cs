using System.Collections.Generic;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class PlannedInventoryViewModel
    {

        public int Id { get; set; }
        public int? EventId { get; set; }
        public EventViewModel Event { get; set; }
        public int? RentRequestId { get; set; }
        public RentRequestViewModel RentRequest { get; set; }
        public IEnumerable<AllocatedInventoryViewModel> AllocatedInventories { get; set; }
        public int? InventoryId { get; set; }
        public InventoryViewModel Inventory { get; set; }
        public float Amount { get; set; }

    }
}
