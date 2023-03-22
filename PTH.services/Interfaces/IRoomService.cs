using PTH.services.DTO_s;
namespace PTH.services.Interfaces
{
    public interface IRoomService
    {
        Task<ResponseDto<bool>> CreateRoom(RoomCreateDTO createRoomDto);
        Task<ResponseDto<RoomDTO>> GetRoomById(long id);
        Task<ResponseDto<RoomDTO>> GetAllRooms();
        Task<ResponseDto<bool>> UpdateRoom(long id, RoomUpdateDTO updateRoomDto);
        Task<ResponseDto<bool>> DeleteRoom(long id);
        Task<ResponseDto<bool>> UpdateRoomState(bool isActive);
        Task<ResponseDto<bool>> searchAvailableRooms(DateTime startDate, DateTime endDate, int quota, long idCity);


    }
}
