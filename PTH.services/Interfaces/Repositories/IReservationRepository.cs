using PTH.domain.models;
using PTH.domain.modelsDomain;
using PTH.services.DTO_s;

namespace PTH.services.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        Task<long> CreateReservation(Reservation reservation);
        Task<bool> CreateReservationInfo(IEnumerable<ReservationInfo> reservationsInfo);
        Task<ResponseDto<ReservationDTO>> GetReservationById(long idReservation);
        Task<ResponseDto<ReservationDTO>> GetAllReservations();
        Task<ResponseDto<ReservationDTO>> GetAllReservationsByHotel(long idHotel);
        Task<ResponseDto<ReservationDTO>> GetAllReservationsByUser(long idUser);
        Task<ResponseDto<bool>> UpdateReservation(long idReservation, Reservation updateReservationDto);
        Task<bool> DeleteReservation(long idReservation);
        Task<bool> validateUser(long idUser);
        Task<bool> validateRoom(long idRoom);
        Task<bool> validateAmount(long amount);


    }
}
