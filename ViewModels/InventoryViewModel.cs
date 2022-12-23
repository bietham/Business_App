using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Task3.Store.Models;

namespace Task3.ViewModels
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        public int? SchoolId { get; set; }
        public SchoolViewModel School { get; set; }
        public string Name { get; set; }
        public int? TypeId { get; set; }
        public InventoryTypeViewModel InventoryType { get; set; }
        public string MeasurementUnit { get; set; }
        public float Amount { get; set; }
        public float Rented { get; set; }
        public float Missing { get; set; }
        public bool Analogous { get; set; }
        public List<AllocatedInventoryViewModel> AllocatedInventories { get; set; }
        public List<RequestedInventoryViewModel> RequestedInventories { get; set; }
    }
}
