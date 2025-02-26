using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buisness.Dtos;
using Core.Models;

namespace Buisness.Abastraction
{
    public interface IBidService
    {
        Task<ApiResponse> CreateBid(CreateBidDto model);
        Task<ApiResponse> UpdateBid(UpdateBidDto model);
        Task<ApiResponse> DeleteBid(int bidId);
        Task<ApiResponse> GetBid(int bidId);
        Task<ApiResponse> CancelBid(int bidId);
        Task<ApiResponse> AutomaticAllyCreateBid(CreateBidDto model);
        Task<ApiResponse> GetBidByVehicleId(int vehicleId);
    }
}
