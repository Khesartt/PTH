using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTH.services.DTO_s;
namespace PTH.services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseDto<UserDTO>> GetUserById(long idUser);
        Task<ResponseDto<bool>> CreateUser(UserCreateDTO userCreateDTO);
        Task<ResponseDto<bool>> UpdateUser(long id, UserUpdateDTO userUpdateDTO);
        Task<ResponseDto<bool>> DeleteRoom(long idUser);

    }
}
