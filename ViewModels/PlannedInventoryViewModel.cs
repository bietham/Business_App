using System.Collections.Generic;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class PlannedInventoryViewModel
    {

        public int Id { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; set; }
        public int? RentRequestId { get; set; }
        public RentRequest RentRequest { get; set; }
        public IEnumerable<AllocatedInventory> AllocatedInventories { get; set; }
        public int? InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public float Amount { get; set; }

    }
}
