namespace PTH.domain.models
{
    public class Room
    {
        public Room()
        {
            active = true;
            occupied = false;
            creationDate = DateTime.Now;
            baseCost = 0.00m;
            taxes = 0.00m;
        }
        public long id { get; set; }
        public string? name { get; set; }
        public string? descripcion { get; set; }
        public DateTime creationDate { get; set; }
        public string? image { get; set; }
        public string? location { get; set; }
        public long idRoomType { get; set; }
        public long idHotel { get; set; }
        public int quota { get; set; }
        public decimal? baseCost { get; set; }
        public decimal taxes { get; set; }
        public bool active { get; set; }
        public bool occupied { get; set; }
    }
}
