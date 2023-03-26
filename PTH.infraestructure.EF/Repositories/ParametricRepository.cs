using PTH.aplications.Interfaces.Repositories;
using PTH.domain.models;
using PTH.domain.modelsDomain;
using PTH.infraestructure.EF.Context;
using PTH.services.DTO_s;

namespace PTH.infraestructure.EF.Repositories
{
    public class ParametricRepository : IParametricRepository
    {
        private ApiContext dbContext;

        public ParametricRepository(ApiContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public Task<ResponseDto<City>> getCities()
        {
            ResponseDto<City> response = new();
            List<City> cities = dbContext.cities.ToList();
            if (cities.Count > 0 || cities != null)
            {
                response.results = cities;
            }
            else
            {
                response.results = null;
                response.message = "something was wrong with the cities or not exist any city";
                response.existError = true;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<Gender>> getGenders()
        {
            ResponseDto<Gender> response = new();
            List<Gender> genders = dbContext.genders.ToList();
            if (genders.Count > 0 || genders != null)
            {
                response.results = genders;
            }
            else
            {
                response.results = null;
                response.message = "something was wrong with the Genders or not exist any Gender";
                response.existError = true;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<Parametric>> getParametrics()
        {
            ResponseDto<Parametric> response = new();
            List<Parametric> parametrics = dbContext.parametrics.ToList();
            if (parametrics.Count > 0 || parametrics != null)
            {
                response.results = parametrics;
            }
            else
            {
                response.results = null;
                response.message = "something was wrong with the Parametric or not exist any Parametric";
                response.existError = true;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<Role>> getRoles()
        {
            ResponseDto<Role> response = new();
            List<Role> roles = dbContext.roles.ToList();
            if (roles.Count > 0 || roles != null)
            {
                response.results = roles;
            }
            else
            {
                response.results = null;
                response.message = "something was wrong with the Roles or not exist any Role";
                response.existError = true;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<RoomType>> getRoomType()
        {
            ResponseDto<RoomType> response = new();
            List<RoomType> roomsType = dbContext.roomsType.ToList();
            if (roomsType.Count > 0 || roomsType != null)
            {
                response.results = roomsType;
            }
            else
            {
                response.results = null;
                response.message = "something was wrong with the roomsType or not exist any roomType";
                response.existError = true;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<Service>> getServices()
        {
            ResponseDto<Service> response = new();
            List<Service> services = dbContext.services.ToList();
            if (services.Count > 0 || services != null)
            {
                response.results = services;
            }
            else
            {
                response.results = null;
                response.message = "something was wrong with the services or not exist any service";
                response.existError = true;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<TypeDocument>> getTypeDocument()
        {
            ResponseDto<TypeDocument> response = new();
            List<TypeDocument> typedocuments = dbContext.typedocuments.ToList();
            if (typedocuments.Count > 0 || typedocuments != null)
            {
                response.results = typedocuments;
            }
            else
            {
                response.results = null;
                response.message = "something was wrong with the typedocuments or not exist any typedocument";
                response.existError = true;
            }
            return Task.FromResult(response);
        }
    }
}
