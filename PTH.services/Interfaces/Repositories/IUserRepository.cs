using PTH.domain.models;
using PTH.services.DTO_s;


namespace PTH.services.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<ResponseDto<User>> GetUserById(long idUser);
        Task<ResponseDto<bool>> CreateUser(User user);
        Task<ResponseDto<bool>> UpdateUser(long id, User user);
        Task<ResponseDto<bool>> DeleteRoom(long idUser);

    }
}
