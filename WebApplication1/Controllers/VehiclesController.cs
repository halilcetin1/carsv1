using Buisness.Abastraction;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost("create")]

        public async Task<IActionResult> CreateVehicle([FromForm]CreateVehicleDto model)
        {
            if (ModelState.IsValid) {
                if (model.File != null && model.File.Length > 0) {
                 var imageName=await   ReadImage.ReadImage.readImage(model.File);
                    if (imageName == null) {
                        return BadRequest("image dont save");
                    }
                    model.Image = imageName;
                }

             var res= await  _vehicleService.CreateVehicle(model);
                if (res.IsSuccess)
                {
                    return Ok(res);
                }
                return BadRequest(res);
            }
            return BadRequest();
        }
        [Authorize]
        [HttpGet("getAllVehicles")]
        public async Task<IActionResult> GetAllVehicles()
        {
            var res = await _vehicleService.GetAllVehicles();
            if (res.IsSuccess) { 
            
            return Ok(res.Result);

            }
            return BadRequest(res);
        }
        [HttpDelete("{vehicleId}")]
public async Task<IActionResult> DeleteVehicle([FromRoute]int vehicleId)
    { 
            var res= await _vehicleService.DeleteVehicle(vehicleId);
            if (res.IsSuccess) {

                return Ok();
            }
            return BadRequest(); 
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateVehicles([FromForm]int vehicleId, UpdateVehicleDto model)
        {
            var res= await _vehicleService.UpdateVehicle(vehicleId,model);
            if (res.IsSuccess) {
                return Ok(res.Result);
            }
            return BadRequest();
        }

    }


}
