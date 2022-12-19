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
        public School School { get; set; }
        public string Name { get; set; }
        public string MeasurementUnit { get; set; }
        public float Amount { get; set; }
        public float Rented { get; set; }
        public float Missing { get; set; }
        public bool Analogous { get; set; }
        public List<AllocatedInventory> AllocatedInventories { get; set; }
        public List<RequestedInventory> RequestedInventories { get; set; }
    }
}
