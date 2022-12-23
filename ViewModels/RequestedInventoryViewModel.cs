using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.ViewModels
{
    public class RequestedInventoryViewModel
    {
        [Key]
        public int Id { get; set; }
        public int? RentRequestId { get; set; }
        public RentRequestViewModel RentRequest { get; set; }
        public int? InventoryTypeId { get; set; }
        public InventoryTypeViewModel InventoryType { get; set; }
        public float Amount { get; set; }
    }
}
