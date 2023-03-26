using Microsoft.AspNetCore.Mvc;
using PTH.aplications.Services;
using PTH.domain.models;
using PTH.domain.modelsDomain;
using PTH.infraestructure.EF.Context;
using PTH.infraestructure.EF.Repositories;
using PTH.services.DTO_s;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PTH.infraestructure.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametricController : ControllerBase
    {

        ParametricService CrearServicio()
        {
            ApiContext db = new ApiContext();
            ParametricRepository repo = new ParametricRepository(db);
            ParametricService servicio = new ParametricService(repo);
            return servicio;
        }
        [HttpGet("getCities")]
        public ResponseDto<City> getCities()
        {
            var servicio = CrearServicio();
            return servicio.getCities().Result;
        }
        [HttpGet("getGenders")]
        public ResponseDto<Gender> getGenders()
        {
            var servicio = CrearServicio();
            return servicio.getGenders().Result;
        }
        [HttpGet("getParametrics")]
        public ResponseDto<Parametric> getParametrics()
        {
            var servicio = CrearServicio();
            return servicio.getParametrics().Result;
        }
        [HttpGet("getRoles")]
        public ResponseDto<Role> getRoles()
        {
            var servicio = CrearServicio();
            return servicio.getRoles().Result;
        }
        [HttpGet("getRoomType")]
        public ResponseDto<RoomType> getRoomType()
        {
            var servicio = CrearServicio();
            return servicio.getRoomType().Result;
        }
        [HttpGet("getServices")]
        public ResponseDto<Service> getServices()
        {
            var servicio = CrearServicio();
            return servicio.getServices().Result;
        }
        [HttpGet("getTypeDocument")]
        public ResponseDto<TypeDocument> getTypeDocument()
        {
            var servicio = CrearServicio();
            return servicio.getTypeDocument().Result;
        }
    }
}
