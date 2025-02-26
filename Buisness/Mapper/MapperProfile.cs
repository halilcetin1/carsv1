using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Buisness.Dtos;
using Core.Models;
using DataAccess.Domain;
using DataAccess.Models;

namespace Core.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<ApplicationUser, RegisterRequestDto>().ReverseMap();
            CreateMap<Vehicle, CreateVehicleDto>().ReverseMap();
            CreateMap<Vehicle, UpdateVehicleDto>().ReverseMap();
            CreateMap<Bid, CreateBidDto>().ReverseMap();
            CreateMap<Bid, UpdateBidDto>().ReverseMap();


        }
    }
}
