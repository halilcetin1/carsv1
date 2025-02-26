using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace Buisness.Dtos
{
    public class CreateBidDto
    {
      
        public double BidAmount { get; set; }
        public DateTime BidDate { get; set; }
        public string BidStatus { get; set; } 
        public string UserId { get; set; }
   
        public int VehicleId { get; set; }
    }
}
