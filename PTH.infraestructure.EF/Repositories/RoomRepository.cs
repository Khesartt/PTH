using PTH.domain.models;
using PTH.infraestructure.EF.Context;
using PTH.services.DTO_s;
using PTH.services.Interfaces.Repositories;

namespace PTH.infraestructure.EF.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private ApiContext dbContext;

        public RoomRepository(ApiContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Task<ResponseDto<bool>> CreateRoom(Room room)
        {
            ResponseDto<bool> response = new();
            dbContext.Add(room);
            dbContext.SaveChanges();
            response.result = true;
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> DeleteRoom(long id)
        {
            ResponseDto<bool> response = new();

            Room? room = dbContext.rooms.Where(x => x.id == id).FirstOrDefault();

            if (room != null)
            {
                dbContext.Remove(room);
                dbContext.SaveChanges();
                response.result = true;
            }
            else
            {
                response.result = false;
                response.message = "there is not exists one room with that id";
                response.existError = true;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<Room>> GetAllRooms()
        {
            ResponseDto<Room> response = new();
            List<Room> rooms = dbContext.rooms.ToList();
            response.results = rooms;
            return Task.FromResult(response);
        }

        public Task<ResponseDto<Room>> GetRoomById(long id)
        {
            ResponseDto<Room> response = new();
            Room? room = dbContext.rooms.Where(x => x.id == id).FirstOrDefault();
            response.result = room;
            return Task.FromResult(response);
        }

        public Task<ResponseDto<AvailableRoom>> searchAvailableRooms(int quota, long idCity)
        {
            ResponseDto<AvailableRoom> response = new();
            List<Hotel> hotels = dbContext.hotels.Where(x => x.idCity == idCity).ToList();

            List<AvailableRoom> availableRooms = new();
            foreach (var item in hotels)
            {
                AvailableRoom availableRoom = new();
                availableRoom.id = item.id;
                availableRoom.name = item.name;
                availableRoom.idUser = item.idUser;
                availableRoom.description = item.description;
                availableRoom.image = item.image;
                availableRoom.idCity = item.idCity;
                availableRoom.address = item.address;
                availableRoom.services = item.services;
                availableRoom.checkIn = item.checkIn;
                availableRoom.checkOut = item.checkOut;
                availableRoom.roomsAvailable = dbContext.rooms.Where(x => x.idHotel == item.id && quota <= x.quota && x.occupied == false).ToList();
                availableRooms.Add(availableRoom);
            }
            response.results = availableRooms;
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> UpdateRoom(RoomUpdateDTO room)
        {
            ResponseDto<bool> response = new();
            Room? roomToUpdate = dbContext.rooms.Where(x => x.id == room.id).FirstOrDefault();

            if (roomToUpdate != null)
            {
                roomToUpdate.id = roomToUpdate.id;
                roomToUpdate.creationDate = roomToUpdate.creationDate;
                roomToUpdate.name = (string.IsNullOrEmpty(room.name) ? roomToUpdate.name : room.name);
                roomToUpdate.description = (string.IsNullOrEmpty(room.description) ? roomToUpdate.description : room.description);
                roomToUpdate.image = (string.IsNullOrEmpty(room.image) ? roomToUpdate.image : room.image);
                roomToUpdate.location = (string.IsNullOrEmpty(room.location) ? roomToUpdate.location : room.location);
                roomToUpdate.idRoomType = (room.idRoomType == -1 ? roomToUpdate.idRoomType : room.idRoomType);
                roomToUpdate.idHotel = (room.idHotel == -1 ? roomToUpdate.idHotel : room.idHotel);
                roomToUpdate.quota = (room.quota == -1 ? roomToUpdate.quota : room.quota);
                roomToUpdate.baseCost = (room.baseCost == -1 ? roomToUpdate.baseCost : room.baseCost);
                roomToUpdate.taxes = (room.taxes == -1 ? roomToUpdate.taxes : room.taxes);
                roomToUpdate.active = (string.IsNullOrEmpty(room.active.ToString()) ? roomToUpdate.active : room.active);
                roomToUpdate.occupied = (string.IsNullOrEmpty(room.occupied.ToString()) ? roomToUpdate.occupied : room.occupied);
                dbContext.Update(roomToUpdate);
                dbContext.SaveChanges();
                response.result = true;
            }
            else
            {
                response.result = false;
                response.message = "there is not exists one room with that id";
                response.existError = true;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> UpdateRoomState(bool isActive, long idRoom)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();

            Room? roomToUpdate = dbContext.rooms.Where(x => x.id == idRoom).FirstOrDefault();
            if (roomToUpdate != null)
            {
                roomToUpdate.active = isActive;
                dbContext.Entry(roomToUpdate).Property(p => p.active).IsModified = true;
                dbContext.SaveChanges();
            }
            else
            {
                response.result = false;
                response.message = "there is not exist one room with that id.";
                response.existError = true;

            }

            return Task.FromResult(response);
        }

        public Task<bool> validateHotel(long idHotel)
        {
            bool check = dbContext.hotels.Where(x => x.id == idHotel).Select(x => x.active).FirstOrDefault();
            return Task.FromResult(check);
        }
    }
}
