using PTH.domain.models;
using PTH.services.DTO_s;

namespace PTH.services.Interfaces.Repositories
{
    public interface IRoomRepository
    {
        Task<ResponseDto<bool>> CreateRoom(Room room);
        Task<ResponseDto<Room>> GetRoomById(long id);
        Task<ResponseDto<Room>> GetAllRooms();
        Task<ResponseDto<bool>> UpdateRoom(RoomUpdateDTO room);
        Task<ResponseDto<bool>> DeleteRoom(long id);
        Task<ResponseDto<bool>> UpdateRoomState(bool isActive);
        Task<ResponseDto<AvailableRoom>> searchAvailableRooms(DateTime startDate, DateTime endDate, int quota, long idCity);
        Task<bool> validateHotel(long idHotel);

    }
}
