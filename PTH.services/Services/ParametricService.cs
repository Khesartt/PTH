using PTH.aplications.Interfaces;
using PTH.aplications.Interfaces.Repositories;
using PTH.domain.models;
using PTH.domain.modelsDomain;
using PTH.services.DTO_s;

namespace PTH.aplications.Services
{
    public class ParametricService : IParametricService
    {
        private readonly IParametricRepository parametricRepository;

        public ParametricService(IParametricRepository _parametricRepository)
        {
            parametricRepository = _parametricRepository;
        }

        public Task<ResponseDto<City>> getCities()
        {
            try
            {
                return Task.FromResult(parametricRepository.getCities().Result);
            }
            catch (Exception ex)
            {
                ResponseDto<City> response = new ResponseDto<City>();
                response.error = ex.Message;
                response.message = "there are unhandled exception with the parametrics(getCities)";
                response.existError = true;
                response.results = null;
                return Task.FromResult(response);
            }
        }

        public Task<ResponseDto<Gender>> getGenders()
        {
            try
            {
                return Task.FromResult(parametricRepository.getGenders().Result);
            }
            catch (Exception ex)
            {
                ResponseDto<Gender> response = new ResponseDto<Gender>();
                response.error = ex.Message;
                response.message = "there are unhandled exception with the parametrics(getGenders)";
                response.existError = true;
                response.results = null;
                return Task.FromResult(response);
            }
        }

        public Task<ResponseDto<Parametric>> getParametrics()
        {
            try
            {
                return Task.FromResult(parametricRepository.getParametrics().Result);
            }
            catch (Exception ex)
            {
                ResponseDto<Parametric> response = new ResponseDto<Parametric>();
                response.error = ex.Message;
                response.message = "there are unhandled exception with the parametrics(getParametrics)";
                response.existError = true;
                response.results = null;
                return Task.FromResult(response);
            }
        }

        public Task<ResponseDto<Role>> getRoles()
        {
            try
            {
                return Task.FromResult(parametricRepository.getRoles().Result);
            }
            catch (Exception ex)
            {
                ResponseDto<Role> response = new ResponseDto<Role>();
                response.error = ex.Message;
                response.message = "there are unhandled exception with the parametrics(getRoles)";
                response.existError = true;
                response.results = null;
                return Task.FromResult(response);
            }
        }

        public Task<ResponseDto<RoomType>> getRoomType()
        {
            try
            {
                return Task.FromResult(parametricRepository.getRoomType().Result);
            }
            catch (Exception ex)
            {
                ResponseDto<RoomType> response = new ResponseDto<RoomType>();
                response.error = ex.Message;
                response.message = "there are unhandled exception with the parametrics(getRoomType)";
                response.existError = true;
                response.results = null;
                return Task.FromResult(response);
            }
        }

        public Task<ResponseDto<Service>> getServices()
        {
            try
            {
                return Task.FromResult(parametricRepository.getServices().Result);
            }
            catch (Exception ex)
            {
                ResponseDto<Service> response = new ResponseDto<Service>();
                response.error = ex.Message;
                response.message = "there are unhandled exception with the parametrics(getServices)";
                response.existError = true;
                response.results = null;
                return Task.FromResult(response);
            }
        }

        public Task<ResponseDto<TypeDocument>> getTypeDocument()
        {
            try
            {
                return Task.FromResult(parametricRepository.getTypeDocument().Result);
            }
            catch (Exception ex)
            {
                ResponseDto<TypeDocument> response = new ResponseDto<TypeDocument>();
                response.error = ex.Message;
                response.message = "there are unhandled exception with the parametrics(getCities)";
                response.existError = true;
                response.results = null;
                return Task.FromResult(response);
            }
        }
    }
}
