using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTH.services.DTO_s
{
    public class RoomDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Image { get; set; }
        public string? Location { get; set; }
        public long IdRoomType { get; set; }
        public long IdHotel { get; set; }
        public decimal? BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public bool Active { get; set; }
    }

    public class RoomCreateDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Location { get; set; }
        public long IdRoomType { get; set; }
        public long IdHotel { get; set; }
        public decimal? BaseCost { get; set; }
        public decimal Taxes { get; set; }
    }

    public class RoomUpdateDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Location { get; set; }
        public long? IdRoomType { get; set; }
        public long? IdHotel { get; set; }
        public decimal? BaseCost { get; set; }
        public decimal? Taxes { get; set; }
        public bool? Active { get; set; }
    }
}
