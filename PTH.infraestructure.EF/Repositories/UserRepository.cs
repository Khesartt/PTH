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
    internal class UserRepository : IUserRepository
    {
        public Task<ResponseDto<bool>> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> DeleteRoom(long idUser)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<User>> GetUserById(long idUser)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> UpdateUser(long id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
