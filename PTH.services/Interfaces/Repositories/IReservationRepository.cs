using PTH.domain.models;
using PTH.services.DTO_s;

namespace PTH.services.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        Task<ResponseDto<bool>> CreateReservation(Reservation createReservationDto);
        Task<ResponseDto<Reservation>> GetReservationById(long idReservation);
        Task<ResponseDto<Reservation>> GetAllReservations();
        Task<ResponseDto<bool>> UpdateReservation(long idReservation, Reservation updateReservationDto);
        Task<ResponseDto<bool>> DeleteReservation(long idReservation);
        Task<ResponseDto<Reservation>> GetAllReservationsByHotel(long idHotel);
        Task<ResponseDto<Reservation>> GetAllReservationsByUser(long idUser);

    }
}
