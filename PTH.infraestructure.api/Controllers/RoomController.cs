using Microsoft.AspNetCore.Mvc;
using PTH.aplications.Services;
using PTH.domain.models;
using PTH.infraestructure.EF.Context;
using PTH.infraestructure.EF.Repositories;
using PTH.services.DTO_s;

namespace PTH.infraestructure.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        RoomService CrearServicio()
        {
            ApiContext db = new ApiContext();
            RoomRepository repo = new RoomRepository(db);
            RoomService servicio = new RoomService(repo);
            return servicio;
        }
        [HttpPost("CreateRoom")]
        public ResponseDto<bool> CreateRoom([FromBody] RoomCreateDTO createRoomDto)
        {
            var servicio = CrearServicio();
            return servicio.CreateRoom(createRoomDto).Result;
        }
        [HttpDelete("DeleteRoom")]
        public ResponseDto<bool> DeleteRoom(long idRoom)
        {
            var servicio = CrearServicio();
            return servicio.DeleteRoom(idRoom).Result;
        }
        [HttpGet("GetAllRooms")]
        public ResponseDto<Room> GetAllRooms()
        {
            var servicio = CrearServicio();
            return servicio.GetAllRooms().Result;
        }
        [HttpGet("GetRoomById")]
        public ResponseDto<Room> GetRoomById(long idRoom)
        {
            var servicio = CrearServicio();
            return servicio.GetRoomById(idRoom).Result;
        }

        [HttpGet("searchAvailableRooms")]
        public ResponseDto<AvailableRoom> searchAvailableRooms(int quota, long idCity)
        {
            var servicio = CrearServicio();
            return servicio.searchAvailableRooms(quota, idCity).Result;
        }

        [HttpPost("UpdateRoom")]
        public ResponseDto<bool> UpdateRoom([FromBody] RoomUpdateDTO updateRoomDto)
        {
            var servicio = CrearServicio();
            return servicio.UpdateRoom(updateRoomDto).Result;

        }

        [HttpPost("UpdateRoomState")]
        public ResponseDto<bool> UpdateRoomState(bool isActive, long idRoom)
        {
            var servicio = CrearServicio();
            return servicio.UpdateRoomState(isActive, idRoom).Result;
        }

    }
}
