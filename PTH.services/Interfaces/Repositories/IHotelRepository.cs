using PTH.domain.models;
using PTH.services.DTO_s;

namespace PTH.services.Interfaces.Repositories
{
    public interface IHotelRepository
    {
        Task<ResponseDto<bool>> CreateHotel(Hotel hotel);
        Task<ResponseDto<Hotel>> GetHotelById(long id);
        Task<ResponseDto<Hotel>> GetAllHotels();
        Task<ResponseDto<bool>> UpdateHotel(HotelUpdateDTO hotel);
        Task<ResponseDto<bool>> DeleteHotel(long id);
        Task<ResponseDto<bool>> UpdateHotelState(bool isActive,long idHotel);
        Task<bool> validateCity(long idCity);
        Task<bool> validateUser(long idUser);
    }
}
