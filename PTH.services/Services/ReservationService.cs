using PTH.domain.models;
using PTH.domain.modelsDomain;
using PTH.services.DTO_s;
using PTH.services.Interfaces;
using PTH.services.Interfaces.Repositories;

namespace PTH.aplications.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository reservationRepository;
        public ReservationService(IReservationRepository _reservationRepository)
        {
            reservationRepository = _reservationRepository;
        }
        public Task<ResponseDto<bool>> CreateReservation(ReservationCreateDTO createReservationDto)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();

            #region ValidateFields
            try
            {
                if (!checkRoom(createReservationDto.idRoom))
                {
                    response.message = "The room doesn't exist or it has already been taken";
                    response.existError = true;
                    response.result = false;
                    return Task.FromResult(response);
                }
                if (!checkUser(createReservationDto.idUser))
                {
                    response.message = "The user doesn't exist. or is inactive";
                    response.existError = true;
                    response.result = false;
                    return Task.FromResult(response);
                }
                if (!checkAmount(createReservationDto.amount,createReservationDto.idRoom))
                {
                    response.message = "The number of people is greater than those allowed for the room";
                    response.existError = true;
                    response.result = false;
                    return Task.FromResult(response);
                }
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to find the room or user in CreateReservation";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
                return Task.FromResult(response);
            }
            #endregion

            #region createReservation
            Reservation reservation = new Reservation();

            reservation.idRoom = createReservationDto.idRoom;
            reservation.idUser = createReservationDto.idUser;
            reservation.inDate = createReservationDto.inDate;
            reservation.outDate = createReservationDto.outDate;
            reservation.amount = createReservationDto.amount;
            #endregion

            long idRservation = -1;

            try
            {
                idRservation = reservationRepository.CreateReservation(reservation).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to create the reservation";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
                return Task.FromResult(response);
            }

            if (idRservation != -1)
            {
                List<ReservationInfo> reservationsInfo = new List<ReservationInfo>();
                foreach (var reservationInfoDto in createReservationDto.reservationInfos)
                {
                    ReservationInfo reservationInfo = new ReservationInfo();
                    reservationInfo.names = reservationInfoDto.names;
                    reservationInfo.lastNames = reservationInfoDto.lastNames;
                    reservationInfo.idGender = reservationInfoDto.idGender;
                    reservationInfo.idTypeDocument = reservationInfoDto.idTypeDocument;
                    reservationInfo.identification = reservationInfoDto.identification;
                    reservationInfo.phone = reservationInfoDto.phone;
                    reservationInfo.birthDate = reservationInfoDto.birthDate;
                    reservationInfo.email = reservationInfoDto.email;
                    reservationInfo.namesEContact = reservationInfoDto.namesEContact;
                    reservationInfo.lastNamesEContact = reservationInfoDto.lastNamesEContact;
                    reservationInfo.phoneEContact = reservationInfoDto.phoneEContact;
                    reservationInfo.idReservation = idRservation;
                    reservationsInfo.Add(reservationInfo);
                }
                try
                {
                    bool resposeReservationInfo = reservationRepository.CreateReservationInfo(reservationsInfo).Result;
                    if (resposeReservationInfo) response.result = true;
                }
                catch (Exception ex)
                {
                    response.message = "There are unhandled errors trying to fill the information for the reservation";
                    response.error = ex.Message;
                    response.existError = true;
                    response.result = false;
                }
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> DeleteReservation(long idReservation)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();

            try
            {
                bool isDelete = reservationRepository.DeleteReservation(idReservation).Result;
                if (isDelete) response.result = true;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to delete the reservation";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<ReservationDTO>> GetAllReservations()
        {
            ResponseDto<ReservationDTO> response = new ResponseDto<ReservationDTO>();

            try
            {
                response = reservationRepository.GetAllReservations().Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to get all reservatios in reservationService";
                response.error = ex.Message;
                response.existError = true;
                response.results = null;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<ReservationDTO>> GetAllReservationsByHotel(long idHotel)
        {
            ResponseDto<ReservationDTO> response = new ResponseDto<ReservationDTO>();

            try
            {
                response = reservationRepository.GetAllReservationsByHotel(idHotel).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to solve GetAllReservationsByHotel in reservationService";
                response.error = ex.Message;
                response.existError = true;
                response.results = null;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<ReservationDTO>> GetAllReservationsByUser(long idUser)
        {
            ResponseDto<ReservationDTO> response = new ResponseDto<ReservationDTO>();

            try
            {
                response = reservationRepository.GetAllReservationsByUser(idUser).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to solve GetAllReservationsByUser in reservationService";
                response.error = ex.Message;
                response.existError = true;
                response.results = null;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<ReservationDTO>> GetReservationById(long idReservation)
        {
            ResponseDto<ReservationDTO> response = new ResponseDto<ReservationDTO>();

            try
            {
                response = reservationRepository.GetReservationById(idReservation).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to solve GetReservationById in reservationService";
                response.error = ex.Message;
                response.existError = true;
                response.results = null;
            }
            return Task.FromResult(response);
        }
        public Task<ResponseDto<bool>> UpdateReservationState(bool isActive, long idReservation)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();

            try
            {
                bool isUpdate = reservationRepository.UpdateReservationState(isActive, idReservation).Result;
                if (isUpdate) response.result = true;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to solve UpdateReservationState in reservationService";
                response.error = ex.Message;
                response.existError = true;
                response.results = null;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> UpdateReservation(IEnumerable<ReservationUpdateInfoDTO> updateReservationDto)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();

            try
            {
                response.message = "";
                foreach (var item in updateReservationDto)
                {
                    if (reservationRepository.validateReservation(item.idReservation).Result)
                    {
                        bool isUpdate = reservationRepository.UpdateReservation(item).Result;
                        if (isUpdate) response.result = true;
                    }
                    else
                    {
                        response.message = response.message + " |-the reservation with id: " + item.id + " is no active-| ";
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to solve UpdateReservation in reservationService";
                response.error = ex.Message;
                response.existError = true;
                response.results = null;
            }
            return Task.FromResult(response);
        }



        private bool checkUser(long idUser)
        {
            bool checkUser = reservationRepository.validateUser(idUser).Result;
            if (!checkUser)
            {
                return false;
            }
            return true;
        }
        private bool checkRoom(long idRoom)
        {
            bool checkUser = reservationRepository.validateRoom(idRoom).Result;
            if (!checkUser)
            {
                return false;
            }
            return true;
        }
        private bool checkAmount(int amount,long idRoom)
        {
            bool checkUser = reservationRepository.validateAmount(amount,idRoom).Result;
            if (!checkUser)
            {
                return false;
            }
            return true;
        }
    }
}
