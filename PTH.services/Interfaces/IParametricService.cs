using PTH.domain.models;
using PTH.domain.modelsDomain;
using PTH.services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTH.aplications.Interfaces
{
    public interface IParametricService
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
