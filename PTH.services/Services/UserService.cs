using PTH.services.DTO_s;
using PTH.services.Interfaces;
using PTH.services.Interfaces.Repositories;
using System.Net.Mail;
using System.Net;
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
                sendEmail(userCreateDTO.email);
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to create the user";
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

        private void sendEmail(string correoToSend)
        {

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("cuentagenericacesar@gmail.com");
                mail.To.Add(correoToSend);
                mail.Subject = "Aplicacion de Hotel";
                mail.Body = "<h1>tu Usuario ha sido Creado con exito!</h1>";
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("cuentagenericacesar@gmail.com", "aexvvihnzjmcngoc");
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(mail);
                }
            }
        }
    }
}
