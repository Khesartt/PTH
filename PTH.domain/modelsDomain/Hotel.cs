using PTH.domain.modelsDomain;

namespace PTH.domain.models
{
    public class Hotel
    {
        public Hotel()
        {
            creationDate = DateTime.Now;
            active = true;
        }
        public long id { get; set; }
        public string? name { get; set; }
        public long idUser { get; set; }
        public string? descripcion { get; set; }
        public string? image { get; set; }
        public long idCity { get; set; }
        public string? address { get; set; }
        public string? services { get; set; }
        public TimeSpan checkIn { get; set; }
        public TimeSpan checkOut { get; set; }
        public DateTime creationDate { get; set; }
        public bool active { get; set; }
    }
}
