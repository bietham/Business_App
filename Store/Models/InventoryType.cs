using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task3.Store.Models
{
    public class InventoryType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Inventory> Inventories { get; set; }
        public IEnumerable<PlannedInventory> PlannedInventories { get; set; }
        public IEnumerable<RequestedInventory> RequestedInventories { get; set; }
    }
}
