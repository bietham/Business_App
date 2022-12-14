using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.Store.Models
{
    public class RequestedInventory
    {
        [Key]
        public int Id { get; set; }
        public int? RentRequestId { get; set; }
        public RentRequest RentRequest { get; set; }
        public int? InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public float Amount { get; set; }
    }
}
