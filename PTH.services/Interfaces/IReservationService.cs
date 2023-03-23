using PTH.services.DTO_s;
namespace PTH.services.Interfaces
{
    public interface IReservationService
    {
        Task<ResponseDto<bool>> CreateReservation(ReservationCreateDTO createReservationDto);
        Task<ResponseDto<ReservationDTO>> GetReservationById(long idReservation);
        Task<ResponseDto<ReservationDTO>> GetAllReservations();
        Task<ResponseDto<bool>> UpdateReservation(IEnumerable<ReservationUpdateInfoDTO> updateReservationDto);
        Task<ResponseDto<bool>> UpdateReservationState(bool isActive, long idReservation);
        Task<ResponseDto<bool>> DeleteReservation(long idReservation);
        Task<ResponseDto<ReservationDTO>> GetAllReservationsByHotel(long idHotel);
        Task<ResponseDto<ReservationDTO>> GetAllReservationsByUser(long idUser);
    }
}

