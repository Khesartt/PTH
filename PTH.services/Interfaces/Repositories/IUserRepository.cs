using PTH.domain.models;
using PTH.services.DTO_s;


namespace PTH.services.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<ResponseDto<UserDTO>> GetUserById(long idUser);
        Task<ResponseDto<bool>> CreateUser(UserCreateDTO user);
        Task<ResponseDto<bool>> UpdateUser(UserUpdateDTO user);
        Task<ResponseDto<bool>> DeleteRoom(long idUser);

    }
}
