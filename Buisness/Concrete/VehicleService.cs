using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Buisness.Abastraction;
using Core.Models;
using DataAccess.Context;
using DataAccess.Domain;
using Microsoft.EntityFrameworkCore;

namespace Buisness.Concrete
{
    public class VehicleService : IVehicleService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ApiResponse _response;

        public VehicleService(ApiResponse response,ApplicationDbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _response = response;
        }

        public Task<ApiResponse> ChangeStatus(int VehicleId)
        {
            return null;
        }

        public async Task<ApiResponse> CreateVehicle(CreateVehicleDto model)
        {
           if (model != null)
            {
                var vehicle = _mapper.Map<Vehicle>(model);
              await  _context.Vehicles.AddAsync(vehicle);
                if( await _context.SaveChangesAsync() > 0)
                {
                  _response.IsSuccess = true;
                    _response.StatusCode = System.Net.HttpStatusCode.Created;
                    _response.Result = vehicle;
                    return _response;
                }

            }            
          _response.IsSuccess = false;
            _response.StatusCode= System.Net.HttpStatusCode.BadRequest;
            _response.ErrorMessages.Add("Opps ");
            return _response;
        }

        public async Task<ApiResponse> DeleteVehicle(int vehicleId)
        {
var vehiclefromDb=_context.Vehicles.SingleOrDefault(v=>v.VehicleId == vehicleId);
            if(vehiclefromDb != null)
            {
                _context.Vehicles.Remove(vehiclefromDb);
                if (await _context.SaveChangesAsync() > 0) {

                    _response.IsSuccess = true;
                    _response.StatusCode = System.Net.HttpStatusCode.OK;
                    return _response;
                }
               
            }
            _response.IsSuccess= false;
            _response.ErrorMessages.Add("vehicle is null");
            return _response;
        }

        public async Task<ApiResponse> GetAllVehicles()
        {
            
            _response.IsSuccess = true;
_response.Result=            await _context.Vehicles.ToListAsync();
            return _response;
        }

        public async Task<ApiResponse> GetVehicleDeatils(int vehicleId)
        {
            var vehicleFromDb = await _context.Vehicles.SingleAsync(v => v.VehicleId == vehicleId);
            if (vehicleFromDb != null) { 
            
                _response.IsSuccess= true;
                _response.Result = vehicleFromDb;
                return _response;

            }
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("error ,not found");

            return _response;
        }

        public async Task<ApiResponse> UpdateVehicle(int vehicleId, UpdateVehicleDto model)
        {
           var vehicleFromDb= await _context.Vehicles.SingleOrDefaultAsync(v => v.VehicleId == vehicleId);
            if (vehicleFromDb != null) { 
            var vehicleUpdate=_mapper.Map<Vehicle>(vehicleFromDb);
                _context.Vehicles.Update(vehicleUpdate);
                if (await _context.SaveChangesAsync() > 0) { 
                _response.IsSuccess= true;
                    _response.Result= vehicleUpdate;

                }
            
            }
            
                _response.IsSuccess=false;
            return _response;
        }
    }
}
