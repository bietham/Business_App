using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.Store.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public DateTime PickupTime { get; set; }
        public bool Approved { get; set; }
        public IdentityUser Deliveryman { get; set; }
    }
}
