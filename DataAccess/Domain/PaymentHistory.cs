﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Domain
{
    public class PaymentHistory
    {
        [Key]
        public int PaymentId { get; set; }
        public bool IsActive { get; set; }
        public DateTime PayDate { get; set; }
        public int UserId { get; set; }
        public ApplicationUser  User{ get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
