using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Domain;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime DateOffBirth { get; set; }
        public ICollection<PaymentHistory> PaymentHistories  { get; set; }
        public ICollection<Bid> Bids { get; set; }
        public List<Vehicle>  Vehicles { get; set; }

    }
}
