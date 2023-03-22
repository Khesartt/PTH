using PTH.domain.models;
using PTH.services.DTO_s;
using PTH.services.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTH.infraestructure.EF.Repositories
{
    internal class ReservationRepository : IReservationRepository
    {
        public Task<ResponseDto<bool>> CreateReservation(Reservation createReservationDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> DeleteReservation(long idReservation)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<Reservation>> GetAllReservations()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<Reservation>> GetAllReservationsByHotel(long idHotel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<Reservation>> GetAllReservationsByUser(long idUser)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<Reservation>> GetReservationById(long idReservation)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> UpdateReservation(long idReservation, Reservation updateReservationDto)
        {
            throw new NotImplementedException();
        }
    }
}
