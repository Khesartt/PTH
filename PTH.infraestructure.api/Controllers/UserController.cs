using Microsoft.AspNetCore.Mvc;
using PTH.aplications.Services;
using PTH.infraestructure.EF.Context;
using PTH.infraestructure.EF.Repositories;
using PTH.services.DTO_s;


namespace PTH.infraestructure.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        UserService CrearServicio()
        {
            ApiContext db = new ApiContext();
            UserRepository repo = new UserRepository(db);
            UserService servicio = new UserService(repo);
            return servicio;
        }
        [HttpPost("CreateUser")]
        public ResponseDto<bool> CreateUser([FromBody] UserCreateDTO userCreateDTO)
        {
            var servicio = CrearServicio();
            return servicio.CreateUser(userCreateDTO).Result;
        }
        [HttpDelete("DeleteRoom")]
        public ResponseDto<bool> DeleteRoom([FromBody] long idUser)
        {
            var servicio = CrearServicio();
            return servicio.DeleteRoom(idUser).Result;
        }
        [HttpGet("GetUserById")]
        public ResponseDto<UserDTO> GetUserById(long idUser)
        {
            var servicio = CrearServicio();
            return servicio.GetUserById(idUser).Result;
        }
        [HttpPost("UpdateUser")]
        public ResponseDto<bool> UpdateUser([FromBody] UserUpdateDTO userUpdateDTO)
        {
            var servicio = CrearServicio();
            return servicio.UpdateUser(userUpdateDTO).Result;
        }
    }
}
