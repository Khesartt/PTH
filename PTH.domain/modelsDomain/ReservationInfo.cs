namespace PTH.domain.modelsDomain
{
    public class ReservationInfo
    {
        public long id { get; set; }
        public long idReservation { get; set; }
        public long idGender { get; set; }
        public long idTypeDocument { get; set; }
        public string? names { get; set; }
        public string? lastNames { get; set; }
        public string? identification { get; set; }
        public string? phone { get; set; }
        public DateTime birthDate { get; set; }
        public string? email { get; set; }
        public string? namesEContact { get; set; }
        public string? lastNamesEContact { get; set; }
        public string? phoneEContact { get; set; }

    }
}
