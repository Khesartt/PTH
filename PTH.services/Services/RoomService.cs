using PTH.domain.models;
using PTH.services.DTO_s;
using PTH.services.Interfaces;
using PTH.services.Interfaces.Repositories;


namespace PTH.aplications.Services
{
    public class RoomService : IRoomService
    {
        private IRoomRepository roomRepository;

        public RoomService(IRoomRepository _roomRepository)
        {
            roomRepository = _roomRepository;
        }
        public Task<ResponseDto<bool>> CreateRoom(RoomCreateDTO createRoomDto)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            //check city and user
            try
            {
                if (!checkHotel(createRoomDto.idHotel))
                {
                    response.message = "The hotel doesn't exist.";
                    response.error = "no Exception Error";
                    response.existError = true;
                    response.result = false;
                    return Task.FromResult(response);
                }
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to find the hotel";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            try
            {
                #region createRoom
                Room room = new Room();
                room.name = createRoomDto.name;
                room.descripcion = createRoomDto.descripcion;
                room.image = createRoomDto.image;
                room.location = createRoomDto.location;
                room.idRoomType = createRoomDto.idRoomType;
                room.idHotel = createRoomDto.idHotel;
                room.quota = createRoomDto.quota;
                room.baseCost = createRoomDto.baseCost;
                room.taxes = createRoomDto.taxes;
                #endregion
                response = roomRepository.CreateRoom(room).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to created the room";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> DeleteRoom(long idRoom)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();

            try
            {
                response = roomRepository.DeleteRoom(idRoom).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to delete the room";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<Room>> GetAllRooms()
        {
            ResponseDto<Room> response = new ResponseDto<Room>();

            try
            {
                response = roomRepository.GetAllRooms().Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to get all the rooms";
                response.error = ex.Message;
                response.existError = true;
                response.results = null;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<Room>> GetRoomById(long idRoom)
        {
            ResponseDto<Room> response = new ResponseDto<Room>();

            try
            {
                response = roomRepository.GetRoomById(idRoom).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to get the rooms";
                response.error = ex.Message;
                response.existError = true;
                response.result = null;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<AvailableRoom>> searchAvailableRooms(int quota, long idCity)
        {
            ResponseDto<AvailableRoom> response = new ResponseDto<AvailableRoom>();
            try
            {
                response = roomRepository.searchAvailableRooms(quota, idCity).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to get the rooms";
                response.error = ex.Message;
                response.existError = true;
                response.results = null;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> UpdateRoom(RoomUpdateDTO updateRoomDto)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();

            try
            {
                response = roomRepository.UpdateRoom(updateRoomDto).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to update the room";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> UpdateRoomState(bool isActive, long idRoom)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();

            try
            {
                response = roomRepository.UpdateRoomState(isActive, idRoom).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to find the room";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            return Task.FromResult(response);
        }
        private bool checkHotel(long idHotel)
        {
            bool checkHotel = roomRepository.validateHotel(idHotel).Result;
            if (!checkHotel)
            {
                return false;
            }
            return true;
        }


    }
}
