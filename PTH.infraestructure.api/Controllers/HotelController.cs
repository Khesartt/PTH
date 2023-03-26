using Microsoft.AspNetCore.Mvc;
using PTH.domain.models;
using PTH.infraestructure.EF.Context;
using PTH.infraestructure.EF.Repositories;
using PTH.services.DTO_s;
using PTH.services.Services;

namespace PTH.infraestructure.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        HotelService CrearServicio()
        {
            ApiContext db = new ApiContext();
            HotelRepository repo = new HotelRepository(db);
            HotelService servicio = new HotelService(repo);
            return servicio;
        }


        [HttpPost("CreateHotel")]
        public ResponseDto<bool> CreateHotel([FromBody] HotelCreateDTO createHotelDto)
        {
            var servicio = CrearServicio();
            return servicio.CreateHotel(createHotelDto).Result;
        }
        [HttpDelete("DeleteHotel")]
        public ResponseDto<bool> DeleteHotel([FromBody] long idHotel)
        {
            var servicio = CrearServicio();
            return servicio.DeleteHotel(idHotel).Result;
        }
        [HttpGet("GetAllHotels")]
        public ResponseDto<Hotel> GetAllHotels()
        {
            var servicio = CrearServicio();
            return servicio.GetAllHotels().Result;
        }
        [HttpGet("GetHotelById")]
        public ResponseDto<Hotel> GetHotelById(long idHotel)
        {
            var servicio = CrearServicio();
            return servicio.GetHotelById(idHotel).Result;
        }
        [HttpPost("UpdateHotel")]
        public ResponseDto<bool> UpdateHotel([FromBody] HotelUpdateDTO updateHotelDto)
        {
            var servicio = CrearServicio();
            return servicio.UpdateHotel(updateHotelDto).Result;

        }

        [HttpPost("UpdateHotelState")]
        public ResponseDto<bool> UpdateHotelState([FromBody] bool isActive, long idHotel)
        {
            var servicio = CrearServicio();
            return servicio.UpdateHotelState(isActive, idHotel).Result;
        }



    }
}
