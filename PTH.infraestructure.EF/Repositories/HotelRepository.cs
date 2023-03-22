using PTH.domain.models;
using PTH.services.DTO_s;
using PTH.services.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTH.infraestructure.EF.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        public Task<ResponseDto<bool>> CreateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> DeleteHotel(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<Hotel>> GetAllHotels()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<Hotel>> GetHotelById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> UpdateHotel(long id, Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> UpdateHotelState(bool isActive)
        {
            throw new NotImplementedException();
        }
    }
}
