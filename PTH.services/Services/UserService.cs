using PTH.domain.models;
using PTH.services.DTO_s;
using PTH.services.Interfaces;
using PTH.services.Interfaces.Repositories;

namespace PTH.aplications.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public Task<ResponseDto<bool>> CreateUser(UserCreateDTO userCreateDTO)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            try
            {
                response = userRepository.CreateUser(userCreateDTO).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to create user";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> DeleteRoom(long idUser)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            try
            {
                response = userRepository.DeleteRoom(idUser).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to delete the user";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<UserDTO>> GetUserById(long idUser)
        {
            ResponseDto<UserDTO> response = new ResponseDto<UserDTO>();
            try
            {
                response = userRepository.GetUserById(idUser).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to get the user";
                response.error = ex.Message;
                response.existError = true;
                response.result = null;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            try
            {
                response = userRepository.UpdateUser(userUpdateDTO).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to update the user";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            return Task.FromResult(response);
        }
    }
}
