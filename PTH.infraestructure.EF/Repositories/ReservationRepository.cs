﻿using Microsoft.EntityFrameworkCore;
using PTH.domain.models;
using PTH.domain.modelsDomain;
using PTH.infraestructure.EF.Context;
using PTH.services.DTO_s;
using PTH.services.Interfaces.Repositories;

namespace PTH.infraestructure.EF.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private ApiContext dbContext;

        public ReservationRepository(ApiContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Task<long> CreateReservation(Reservation reservation)
        {

            dbContext.Add(reservation);
            dbContext.SaveChanges();
            return Task.FromResult(reservation.id);

        }

        public Task<bool> CreateReservationInfo(IEnumerable<ReservationInfo> reservationsInfo)
        {
            bool check = false;
            foreach (var reservationInfo in reservationsInfo)
            {
                dbContext.Add(reservationInfo);
                dbContext.SaveChanges();
                check = true;
            }
            return Task.FromResult(check);
        }

        public Task<bool> DeleteReservation(long idReservation)
        {
            List<ReservationInfo> reservationsInfo = dbContext.reservationsInfo.Where(x => x.idReservation == idReservation).ToList();
            Reservation? reservation = dbContext.reservations.Where(x => x.id == idReservation).FirstOrDefault();
            if ((reservationsInfo != null || reservationsInfo.Count > 0) && reservation != null)
            {
                foreach (var item in reservationsInfo)
                {
                    dbContext.Remove(item);
                    dbContext.SaveChanges();
                }
                dbContext.Remove(reservation);
                dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);

        }

        public Task<ResponseDto<ReservationDTO>> GetAllReservations()
        {
            ResponseDto<ReservationDTO> response = new();

            List<Reservation> reservations = dbContext.reservations.ToList();
            List<ReservationDTO> reservationsDTO = new();
            foreach (var item in reservations)
            {
                ReservationDTO reservationDTO = new ReservationDTO();
                reservationDTO.id = item.id;
                reservationDTO.idRoom = item.idRoom;
                reservationDTO.idUser = item.idUser;
                reservationDTO.creationDate = item.creationDate;
                reservationDTO.inDate = item.inDate;
                reservationDTO.outDate = item.outDate;
                reservationDTO.amount = item.amount;
                reservationDTO.reservationInfos = dbContext.reservationsInfo.Where(x => x.idReservation == item.id).ToList();
                reservationsDTO.Add(reservationDTO);
            }
            response.results = reservationsDTO;
            return Task.FromResult(response);
        }

        public Task<ResponseDto<ReservationDTO>> GetAllReservationsByHotel(long idHotel)
        {
            ResponseDto<ReservationDTO> response = new();

            List<long> idRooms = dbContext.rooms.Where(x => x.idHotel == idHotel).Select(x => x.id).ToList();
            List<Reservation> reservations = new();
            foreach (var idRoom in idRooms)
            {
                Reservation? reservation = dbContext.reservations.Where(x => x.idRoom == idRoom).FirstOrDefault();
                if (reservation != null)
                {
                    reservations.Add(reservation);
                }
            }

            List<ReservationDTO> reservationsDTO = new();
            foreach (var item in reservations)
            {
                ReservationDTO reservationDTO = new ReservationDTO();
                reservationDTO.id = item.id;
                reservationDTO.idRoom = item.idRoom;
                reservationDTO.idUser = item.idUser;
                reservationDTO.creationDate = item.creationDate;
                reservationDTO.inDate = item.inDate;
                reservationDTO.outDate = item.outDate;
                reservationDTO.amount = item.amount;
                reservationDTO.reservationInfos = dbContext.reservationsInfo.Where(x => x.idReservation == item.id).ToList();
                reservationsDTO.Add(reservationDTO);
            }
            response.results = reservationsDTO;
            return Task.FromResult(response);
        }

        public Task<ResponseDto<ReservationDTO>> GetAllReservationsByUser(long idUser)
        {
            ResponseDto<ReservationDTO> response = new();

            List<Reservation> reservations = dbContext.reservations.Where(x => x.idUser == idUser).ToList();

            List<ReservationDTO> reservationsDTO = new();
            foreach (var item in reservations)
            {
                ReservationDTO reservationDTO = new ReservationDTO();
                reservationDTO.id = item.id;
                reservationDTO.idRoom = item.idRoom;
                reservationDTO.idUser = item.idUser;
                reservationDTO.creationDate = item.creationDate;
                reservationDTO.inDate = item.inDate;
                reservationDTO.outDate = item.outDate;
                reservationDTO.amount = item.amount;
                reservationDTO.reservationInfos = dbContext.reservationsInfo.Where(x => x.idReservation == item.id).ToList();
                reservationsDTO.Add(reservationDTO);
            }
            response.results = reservationsDTO;
            return Task.FromResult(response);
        }

        public Task<ResponseDto<ReservationDTO>> GetReservationById(long idReservation)
        {
            ResponseDto<ReservationDTO> response = new();

            Reservation? reservation = dbContext.reservations.Where(x => x.id == idReservation).FirstOrDefault();
            if (reservation != null)
            {
                ReservationDTO reservationDTO = new ReservationDTO();
                reservationDTO.id = reservation.id;
                reservationDTO.idRoom = reservation.idRoom;
                reservationDTO.idUser = reservation.idUser;
                reservationDTO.creationDate = reservation.creationDate;
                reservationDTO.inDate = reservation.inDate;
                reservationDTO.outDate = reservation.outDate;
                reservationDTO.amount = reservation.amount;
                reservationDTO.reservationInfos = dbContext.reservationsInfo.Where(x => x.idReservation == reservation.id).ToList();
                response.result = reservationDTO;
            }

            return Task.FromResult(response);

        }

        public Task<bool> UpdateReservation(ReservationUpdateInfoDTO updateReservationDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateReservationState(bool isActive, long idReservation)
        {
            bool check = false;

            Reservation? reservation = dbContext.reservations.Where(x => x.id == idReservation).FirstOrDefault();

            if (reservation != null)
            {
                reservation.active = isActive;
                dbContext.Entry(reservation).Property(p => p.active).IsModified = true;
                dbContext.SaveChanges();
                check = true;
            }
            else
            {
                check = false;

            }

            return Task.FromResult(check);
        }

        public Task<bool> validateAmount(long amount, long idRoom)
        {
            int amountTocompare = dbContext.rooms.Where(x => x.id == idRoom).Select(x => x.quota).FirstOrDefault();

            if (amountTocompare >= amount)
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> validateReservation(long idReservation)
        {
            bool isActive = dbContext.reservations.Where(x => x.id == idReservation).Select(x => x.active).FirstOrDefault();
            return Task.FromResult(isActive);
        }

        public Task<bool> validateRoom(long idRoom)
        {
            throw new NotImplementedException();
        }

        public Task<bool> validateUser(long idUser)
        {
            throw new NotImplementedException();
        }
    }
}
