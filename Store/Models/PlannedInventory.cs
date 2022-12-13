using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.Store.Models
{
    public class PlannedInventory
    {
        [Key]
        public int Id { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; set; }
        public int? RentRequestId { get; set; }
        public RentRequest RentRequest { get; set; }

        [Required]
        public string Name { get; set; }
        public string MeasurementUnit { get; set; } //enum
        public float Amount { get; set; }
        public float Rented { get; set; }
        public float Missing { get; set; }
        public bool Analogous { get; set; }
    }
}
