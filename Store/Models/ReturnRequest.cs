using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.Store.Models
{
    public class ReturnRequest : Request
    {
        public IEnumerable<AllocatedInventory> AllocatedInventories { get; set; }
        public RentRequest RentRequest { get; set; }
    }
}
