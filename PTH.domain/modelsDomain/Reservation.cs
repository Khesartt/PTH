namespace PTH.domain.models
{
    public class Reservation
    {
        public Reservation()
        {
            active = true;
            creationDate = DateTime.Now;
        }
        public long id { get; set; }
        public long idRoom { get; set; }
        public long idUser { get; set; }
        public bool active { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime inDate { get; set; }
        public DateTime outDate { get; set; }
        public int amount { get; set; }

    }
}
