using PTH.domain.models;
using PTH.services.DTO_s;
namespace PTH.services.Interfaces
{
    public interface IRoomService
    {
        Task<ResponseDto<bool>> CreateRoom(RoomCreateDTO createRoomDto);
        Task<ResponseDto<Room>> GetRoomById(long id);
        Task<ResponseDto<Room>> GetAllRooms();
        Task<ResponseDto<bool>> UpdateRoom(RoomUpdateDTO updateRoomDto);
        Task<ResponseDto<bool>> DeleteRoom(long id);
        Task<ResponseDto<bool>> UpdateRoomState(bool isActive);
        Task<ResponseDto<AvailableRoom>> searchAvailableRooms(DateTime startDate, DateTime endDate, int quota, long idCity);


    }
}
