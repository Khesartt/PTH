using PTH.domain.models;
using PTH.domain.modelsDomain;
using PTH.services.DTO_s;

namespace PTH.aplications.Interfaces.Repositories
{
    public interface IParametricRepository
    {
        Task<ResponseDto<City>> getCities();
        Task<ResponseDto<Gender>> getGenders();
        Task<ResponseDto<Parametric>> getParametrics();
        Task<ResponseDto<Role>> getRoles();
        Task<ResponseDto<RoomType>> getRoomType();
        Task<ResponseDto<Service>> getServices();
        Task<ResponseDto<TypeDocument>> getTypeDocument();
    }
}
