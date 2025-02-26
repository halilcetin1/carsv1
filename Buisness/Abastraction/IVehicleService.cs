using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Buisness.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Buisness.Abastraction
{
    public interface IVehicleService
    {
        Task<ApiResponse> CreateVehicle(CreateVehicleDto model);

        Task<ApiResponse> UpdateVehicle(int vehicleId, UpdateVehicleDto model);
        Task<ApiResponse> DeleteVehicle(int vehicleId);
        Task<ApiResponse> GetVehicleDeatils(int vehicleId);
        Task<ApiResponse> ChangeStatus(int VehicleId);
        Task<ApiResponse> GetAllVehicles();

    }
}
