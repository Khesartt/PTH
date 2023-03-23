using PTH.domain.models;
using PTH.services.DTO_s;
namespace PTH.services.Interfaces
{
    public interface IHotelService
    {
        Task<ResponseDto<bool>> CreateHotel(HotelCreateDTO createHotelDto);
        Task<ResponseDto<Hotel>> GetHotelById(long id);
        Task<ResponseDto<Hotel>> GetAllHotels();
        Task<ResponseDto<bool>> UpdateHotel(HotelUpdateDTO updateHotelDto);
        Task<ResponseDto<bool>> DeleteHotel(long id);
        Task<ResponseDto<bool>> UpdateHotelState(bool isActive,long idHotel);
    }
}
