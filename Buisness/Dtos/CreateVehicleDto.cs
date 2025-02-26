using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Models
{
    public class CreateVehicleDto
    {
        public string BrandAndModel { get; set; }
        public int ManifacturingYear { get; set; }
        public string Color { get; set; }
        public double EngineCapacity { get; set; }
        public double Price { get; set; }
        public int Millage { get; set; }
        public string PlateNumber { get; set; }
        public double AuctionPrice { get; set; }
        public string AdditionalInformation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string SellerId { get; set; }
        public IFormFile     File { get; set; }
    }
}
