using PTH.domain.models;
using PTH.services.DTO_s;
using PTH.services.Interfaces;
using PTH.services.Interfaces.Repositories;


namespace PTH.services.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository hotelRepository;

        public HotelService(IHotelRepository _hotelRepository)
        {
            hotelRepository = _hotelRepository;
        }

        public Task<ResponseDto<bool>> CreateHotel(HotelCreateDTO createHotelDto)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            //check city and user
            try
            {
                if (!checkCity(createHotelDto.idCity))
                {
                    response.message = "The city doesn't exist.";
                    response.error = "no Exception Error";
                    response.existError = true;
                    response.result = false;
                    return Task.FromResult(response);
                }
                if (!checkUser(createHotelDto.idUser))
                {
                    response.message = "The user doesn't exist.";
                    response.error = "no Exception Error";
                    response.existError = true;
                    response.result = false;
                    return Task.FromResult(response);
                }
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to find the city or user";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            try
            {
                Hotel hotelToCreate = new Hotel();
                hotelToCreate.name = createHotelDto.name;
                hotelToCreate.idUser = createHotelDto.idUser;
                hotelToCreate.descripcion = createHotelDto.description;
                hotelToCreate.descripcion = createHotelDto.description;
                hotelToCreate.image = createHotelDto.image;
                hotelToCreate.idCity = createHotelDto.idCity;
                hotelToCreate.address = createHotelDto.address;
                hotelToCreate.services = createHotelDto.services;
                hotelToCreate.checkIn = createHotelDto.checkIn;
                hotelToCreate.checkOut = createHotelDto.checkOut;
                hotelToCreate.creationDate = createHotelDto.creationDate;
                response = hotelRepository.CreateHotel(hotelToCreate).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to created the hotel";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> DeleteHotel(long idHotel)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();

            try
            {
                response = hotelRepository.DeleteHotel(idHotel).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to delete the hotel";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            return Task.FromResult(response);

        }

        public Task<ResponseDto<Hotel>> GetAllHotels()
        {
            ResponseDto<Hotel> response = new ResponseDto<Hotel>();

            try
            {
                response = hotelRepository.GetAllHotels().Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to get all the hotels";
                response.error = ex.Message;
                response.existError = true;
                response.results = null;
            }
            return Task.FromResult(response);

        }

        public Task<ResponseDto<Hotel>> GetHotelById(long idHotel)
        {
            ResponseDto<Hotel> response = new ResponseDto<Hotel>();

            try
            {
                response = hotelRepository.GetHotelById(idHotel).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to find the hotel";
                response.error = ex.Message;
                response.existError = true;
                response.result = null;
            }
            return Task.FromResult(response);

        }

        public Task<ResponseDto<bool>> UpdateHotel(HotelUpdateDTO updateHotelDto)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            //check city
            try
            {
                if (!checkCity(updateHotelDto.idCity))
                {
                    response.message = "The city doesn't exist.";
                    response.error = "no Exception Error";
                    response.existError = true;
                    response.result = false;
                    return Task.FromResult(response);
                }
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to find the city";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            try
            {
                response = hotelRepository.UpdateHotel(updateHotelDto).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to update the hotel";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            return Task.FromResult(response);
        }

        public Task<ResponseDto<bool>> UpdateHotelState(bool isActive)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();

            try
            {
                response = hotelRepository.UpdateHotelState(isActive).Result;
            }
            catch (Exception ex)
            {
                response.message = "There are unhandled errors trying to find the hotel";
                response.error = ex.Message;
                response.existError = true;
                response.result = false;
            }
            return Task.FromResult(response);
        }

        private bool checkCity(long idCity)
        {
            bool checkCity = hotelRepository.validateCity(idCity).Result;
            if (!checkCity)
            {
                return false;
            }
            return true;
        }
        private bool checkUser(long idUser)
        {
            bool checkUser = hotelRepository.validateUser(idUser).Result;
            if (!checkUser)
            {
                return false;
            }
            return true;
        }
    }
}
