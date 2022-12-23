using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task3.ViewModels
{
    public class ReturnRequestViewModel
    {
        public IEnumerable<AllocatedInventoryViewModel> AllocatedInventories { get; set; }
        public int? RentRequestId { get; set; }
        public RentRequestViewModel RentRequest { get; set; }
    }
}
