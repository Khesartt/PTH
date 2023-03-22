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
    internal class RoomRepository : IRoomRepository
    {
        public Task<ResponseDto<bool>> CreateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> DeleteRoom(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<Room>> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<Room>> GetRoomById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> searchAvailableRooms(DateTime startDate, DateTime endDate, int quota, long idCity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> UpdateRoom(long id, Room room)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> UpdateRoomState(bool isActive)
        {
            throw new NotImplementedException();
        }
    }
}
