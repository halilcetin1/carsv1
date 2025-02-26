using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Buisness.Abastraction;
using Buisness.Dtos;
using Core.Models;
using DataAccess.Context;
using DataAccess.Domain;
using Microsoft.EntityFrameworkCore;

namespace Buisness.Concrete
{
    public class BidService : IBidService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly ApiResponse response;

        public BidService(ApplicationDbContext context,IMapper mapper,ApiResponse response)
        {
            this.context = context;
            this.mapper = mapper;
            this.response = response;
        }


        public async Task<ApiResponse> AutomaticAllyCreateBid(CreateBidDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> CancelBid(int bidId)
        {
            var bidFromDb = await context.Bids.SingleOrDefaultAsync(b=>b.BidId==bidId);
            if (bidFromDb != null) { 
            
       
            
            
            
            
            }
            return null;
        }

        public async Task<ApiResponse> CreateBid(CreateBidDto model)
        {
            var IsPaid = await CheckIsPaidAuction(model.VehicleId, model.UserId);
            var IsActive = await CheckIsAcive(model.VehicleId);
            if (!IsPaid) { 
            response.IsSuccess = false;
                response.ErrorMessages.Add("please before pay auction price.");
                return response;
            }
            if (IsActive==null) {
                response.IsSuccess = false;
                response.ErrorMessages.Add("this car is not active.");
                return response;
            }
            if (IsActive.Price  >= model.BidAmount){ 
            response.IsSuccess = false;
                response.ErrorMessages.Add(" The bids entered cannot be less than or equal to the bids previously placed.");
                return response;
            }
            var topPrice= await context.Bids.Where(b=>b.VehicleId==model.VehicleId).OrderByDescending(b=>b.BidAmount).ToListAsync();

            if (topPrice != null && topPrice.Count!=0) {
                if (topPrice[0].BidAmount >= model.BidAmount) {
                response.IsSuccess= false;
                    response.ErrorMessages.Add("The bids entered cannot be less than or equal to the bids previously placed.");
                    return response;
                }

                Bid bid = mapper.Map<Bid>(model);
                bid.BidDate=DateTime.Now;
               await context.Bids.AddAsync(bid);

                if( await context.SaveChangesAsync() > 0)
                {
                    response.IsSuccess = true;
                    return response;
                }

            }
            response.IsSuccess = false;
            response.ErrorMessages.Add("An unexpected error occurred, please try again later.");
            return response;
        }

        public async Task<ApiResponse> DeleteBid(int bidId)
        {
            var bidFromDb = await context.Bids.SingleOrDefaultAsync(b => b.BidId == bidId);
            if (bidFromDb != null) { 
            context.Bids.Remove(bidFromDb);
                if( await context.SaveChangesAsync() > 0)
                {
                    response.IsSuccess = true;
                    return response;
                }
            }
            response.IsSuccess = false;
            response.ErrorMessages.Add("this bid is null");
            return response;
        }

        public async Task<ApiResponse> GetBid(int bidId)
        {
            var bidFromDb= await context.Bids.SingleOrDefaultAsync(b=>b.BidId == bidId);
            if (bidFromDb != null) { 
            response.IsSuccess = true;
                response.Result = bidFromDb;
            }
            response.IsSuccess = false;
            response.ErrorMessages.Add("this bid is null");
            return response;
        }

        public async Task<ApiResponse> GetBidByVehicleId(int vehicleId)
        {
            var bidFromDb= await context.Bids.SingleOrDefaultAsync(b=>b.VehicleId== vehicleId);
            if (bidFromDb != null) { 
            response.IsSuccess= true;
                response.Result = bidFromDb;
                return response;

            }
            response.IsSuccess = false;
            response.ErrorMessages.Add("this bid is null");
            return response;



        }

        public Task<ApiResponse> UpdateBid(UpdateBidDto model)
        {
            throw new NotImplementedException();
        }






        private async Task<Vehicle> CheckIsAcive(int vehicleId)
        {
            var vehiclefromDb = await context.Vehicles.SingleOrDefaultAsync(v=>v.VehicleId==vehicleId && v.IsActive &&v.EndTime>=DateTime.Now);
            if (vehiclefromDb != null)
            {
                return vehiclefromDb;  
            }

            return null;
        }

        private async Task<bool> CheckIsPaidAuction(int vehicleId,string userId)
        {
            var isPaid = await context.PaymentHistories.Where(p => p.UserId == userId && p.VehicleId == vehicleId && p.IsActive).SingleOrDefaultAsync();
            if (isPaid != null)
            {
                return true; 
            }
            return false;
                

        }

    }
}
