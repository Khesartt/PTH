using PTH.domain.models;
using PTH.infraestructure.EF.Context;
using PTH.services.DTO_s;
using PTH.services.Interfaces.Repositories;


namespace PTH.infraestructure.EF.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private ApiContext dbContext;

        public HotelRepository(ApiContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Task<ResponseDto<bool>> CreateHotel(Hotel hotel)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            dbContext.Add(hotel);
            dbContext.SaveChanges();
            response.result = true;
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> DeleteHotel(long id)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            Hotel hotelToDelete = dbContext.hotels.Where(x => x.id == id).FirstOrDefault();
            if (hotelToDelete != null)
            {
                dbContext.Remove(hotelToDelete);
                dbContext.SaveChanges();
                response.result = true;
            }
            else
            {
                response.result = false;
                response.message = "there is not exist one hotel with that id.";
                response.existError = true;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<Hotel>> GetAllHotels()
        {
            ResponseDto<Hotel> response = new ResponseDto<Hotel>();
            List<Hotel> hotels = dbContext.hotels.ToList();
            response.results = hotels;
            return Task.FromResult(response);
        }

        public Task<ResponseDto<Hotel>> GetHotelById(long id)
        {
            ResponseDto<Hotel> response = new ResponseDto<Hotel>();
            Hotel? hotel = dbContext.hotels.Where(x => x.id == id).FirstOrDefault();
            if (hotel != null)
            {
                response.result = hotel;
            }
            else
            {
                response.result = null;
                response.message = "there is not exist one hotel with that id.";
                response.existError = true;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> UpdateHotel(HotelUpdateDTO hotel)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            Hotel hotelToUpdate = dbContext.hotels.Where(x => x.id == hotel.id).FirstOrDefault();
            if (hotelToUpdate != null)
            {
                hotelToUpdate.name = (string.IsNullOrEmpty(hotel.name) ? hotelToUpdate.name : hotel.name);
                hotelToUpdate.description = (string.IsNullOrEmpty(hotel.description) ? hotelToUpdate.description : hotel.description);
                hotelToUpdate.image = (string.IsNullOrEmpty(hotel.image) ? hotelToUpdate.image : hotel.image);
                hotelToUpdate.idCity = hotel.idCity;
                hotelToUpdate.address = (string.IsNullOrEmpty(hotel.address) ? hotelToUpdate.address : hotel.address);
                hotelToUpdate.services = (string.IsNullOrEmpty(hotel.services) ? hotelToUpdate.services : hotel.services);
                hotelToUpdate.checkIn = (string.IsNullOrEmpty(hotel.checkIn.ToString()) ? hotelToUpdate.checkIn : hotel.checkIn);
                hotelToUpdate.checkOut = (string.IsNullOrEmpty(hotel.checkOut.ToString()) ? hotelToUpdate.checkOut : hotel.checkOut);
                hotelToUpdate.active = (string.IsNullOrEmpty(hotel.active.ToString()) ? hotelToUpdate.active : hotel.active);
                hotelToUpdate.creationDate = hotelToUpdate.creationDate;
                hotelToUpdate.idUser = hotelToUpdate.idUser;

                dbContext.Update(hotelToUpdate);
                dbContext.SaveChanges();

                response.result = true;
            }
            else
            {
                response.result = false;
                response.message = "there is not exist one hotel with that id.";
                response.existError = true;
            }
            return Task.FromResult(response);



        }

        public Task<ResponseDto<bool>> UpdateHotelState(bool isActive, long idHotel)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();

            Hotel hotelToUpdate = dbContext.hotels.Where(x => x.id == idHotel).FirstOrDefault();

            return Task.FromResult(response);

        }

        public Task<bool> validateCity(long idCity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> validateUser(long idUser)
        {
            throw new NotImplementedException();
        }
    }
}
