using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTH.services.DTO_s
{
    public class HotelCreateDTO
    {
        public string? name { get; set; }
        public long idUser { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public long idCity { get; set; }
        public string? address { get; set; }
        public string? services { get; set; }
        public TimeSpan checkIn { get; set; }
        public TimeSpan checkOut { get; set; }
    }

    public class HotelUpdateDTO
    {
        public long id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public long idCity { get; set; }
        public string? address { get; set; }
        public string? services { get; set; }
        public TimeSpan checkIn { get; set; }
        public TimeSpan checkOut { get; set; }
        public bool active { get; set; }
    }
}
