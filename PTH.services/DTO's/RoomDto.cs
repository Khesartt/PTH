using PTH.domain.models;

namespace PTH.services.DTO_s
{
    public class RoomCreateDTO
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public string? location { get; set; }
        public long idRoomType { get; set; }
        public long idHotel { get; set; }
        public int quota { get; set; }
        public decimal baseCost { get; set; }
        public decimal taxes { get; set; }
    }

    public class RoomUpdateDTO
    {
        public long id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public string? location { get; set; }
        public long idRoomType { get; set; }
        public long idHotel { get; set; }
        public int quota { get; set; }
        public decimal baseCost { get; set; }
        public decimal taxes { get; set; }
        public bool active { get; set; }
        public bool occupied { get; set; }

    }
    public class AvailableRoom
    {
        public long id { get; set; }
        public string? name { get; set; }
        public long idUser { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public long idCity { get; set; }
        public string? address { get; set; }
        public string? services { get; set; }
        public TimeSpan checkIn { get; set; }
        public TimeSpan checkOut { get; set; }
        public IEnumerable<Room> roomsAvailable { get; set; }

    }
}
