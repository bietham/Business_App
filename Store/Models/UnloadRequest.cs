using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.Store.Models
{
    public class UnloadRequest : Request
    {
        public int? RentRequestId { get; set; }
        public RentRequest RentRequest { get; set; }
    }
}
