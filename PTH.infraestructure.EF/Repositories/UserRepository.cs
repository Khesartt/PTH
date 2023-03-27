using PTH.domain.models;
using PTH.infraestructure.EF.Context;
using PTH.services.DTO_s;
using PTH.services.Interfaces.Repositories;

namespace PTH.infraestructure.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApiContext dbContext;

        public UserRepository(ApiContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Task<ResponseDto<bool>> CreateUser(UserCreateDTO user)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            User userToCreate = new User();
            userToCreate.idRole = user.idRole;
            userToCreate.userLogin = user.userLogin;
            userToCreate.password = user.password;
            userToCreate.email = user.email;
            userToCreate.activo = true;
            userToCreate.creationDate = DateTime.Now;
            userToCreate.token = Guid.NewGuid();
            userToCreate.tokenDate = DateTime.Now;
            dbContext.Add(userToCreate);
            dbContext.SaveChanges();
            response.result = true;
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> DeleteRoom(long idUser)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            User? user = dbContext.users.Where(x => x.id == idUser).FirstOrDefault();
            if (user != null)
            {
                dbContext.Remove(user);
                dbContext.SaveChanges();
                response.result = true;
            }
            else
            {
                response.result = false;
                response.message = "there is not exists one user with that id";
                response.existError = true;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<UserDTO>> GetUserById(long idUser)
        {
            ResponseDto<UserDTO> response = new ResponseDto<UserDTO>();

            User? user = dbContext.users.Where(x => x.id == idUser).FirstOrDefault();

            if (user != null)
            {
                UserDTO userDTO = new();
                userDTO.id = user.id;
                userDTO.idRole = user.idRole;
                userDTO.userLogin = user.userLogin;
                userDTO.password = user.password;
                userDTO.email = user.email;
                userDTO.activo = user.activo;
                userDTO.token = user.token;
                userDTO.tokenDate = user.tokenDate;
                response.result = userDTO;
            }
            else
            {
                response.result = null;
                response.message = "there is not exists one user with that id";
                response.existError = true;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> UpdateUser(UserUpdateDTO user)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            User? userToUpdate = dbContext.users.Where(x => x.id == user.id).FirstOrDefault();
            if (userToUpdate != null)
            {
                userToUpdate.id = userToUpdate.id;
                userToUpdate.idRole = userToUpdate.idRole;
                userToUpdate.creationDate = userToUpdate.creationDate;
                userToUpdate.token = userToUpdate.token;
                userToUpdate.tokenDate = userToUpdate.tokenDate;
                userToUpdate.userLogin = string.IsNullOrEmpty(user.userLogin) ? userToUpdate.userLogin : user.userLogin;
                userToUpdate.password = string.IsNullOrEmpty(user.password) ? userToUpdate.password : user.password;
                userToUpdate.email = string.IsNullOrEmpty(user.email) ? userToUpdate.email : user.email;
                userToUpdate.activo = string.IsNullOrEmpty(user.activo.ToString()) ? userToUpdate.activo : user.activo;

                dbContext.Update(userToUpdate);
                dbContext.SaveChanges();
                response.result = true;
            }
            else
            {
                response.result = false;
                response.message = "there is not exists one user with that id";
                response.existError = true;
            }
            return Task.FromResult(response);
        }
    }
}
