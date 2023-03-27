using Microsoft.AspNetCore.Mvc;
using PTH.aplications.Services;
using PTH.domain.models;
using PTH.infraestructure.EF.Context;
using PTH.infraestructure.EF.Repositories;
using PTH.services.DTO_s;
using PTH.services.Services;

namespace PTH.infraestructure.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        ReservationService CrearServicio()
        {
            ApiContext db = new ApiContext();
            ReservationRepository repo = new ReservationRepository(db);
            ReservationService servicio = new ReservationService(repo);
            return servicio;
        }

        [HttpPost("CreateReservation")]
        public ResponseDto<bool> CreateReservation([FromBody] ReservationCreateDTO createReservationDto)
        {
            var servicio = CrearServicio();
            return servicio.CreateReservation(createReservationDto).Result;
        }
        [HttpDelete("DeleteReservation")]
        public ResponseDto<bool> DeleteReservation(long idReservation)
        {
            var servicio = CrearServicio();
            return servicio.DeleteReservation(idReservation).Result;
        }
        [HttpGet("GetAllReservations")]
        public ResponseDto<ReservationDTO> GetAllReservations()
        {
            var servicio = CrearServicio();
            return servicio.GetAllReservations().Result;
        }
        [HttpGet("GetAllReservationsByHotel")]
        public ResponseDto<ReservationDTO> GetAllReservationsByHotel(long idHotel)
        {
            var servicio = CrearServicio();
            return servicio.GetAllReservationsByHotel(idHotel).Result;
        }
        [HttpGet("GetAllReservationsByUser")]
        public ResponseDto<ReservationDTO> GetAllReservationsByUser(long idUser)
        {
            var servicio = CrearServicio();
            return servicio.GetAllReservationsByUser(idUser).Result;
        }
        [HttpGet("GetReservationById")]
        public ResponseDto<ReservationDTO> GetReservationById(long idReservation)
        {
            var servicio = CrearServicio();
            return servicio.GetReservationById(idReservation).Result;
        }
        [HttpPost("UpdateReservationState")]
        public ResponseDto<bool> UpdateReservationState(bool isActive, long idReservation)
        {
            var servicio = CrearServicio();
            return servicio.UpdateReservationState(isActive, idReservation).Result;
        }
        [HttpPost("UpdateReservation")]
        public ResponseDto<bool> UpdateReservation([FromBody] IEnumerable<ReservationUpdateInfoDTO> updateReservationDto)
        {
            var servicio = CrearServicio();
            return servicio.UpdateReservation(updateReservationDto).Result;

        }
    }
}
