using PTH.domain.modelsDomain;

namespace PTH.services.DTO_s
{
    public class ReservationDTO
    {
        public long id { get; set; }
        public long idRoom { get; set; }
        public long idUser { get; set; }
        public bool active { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime inDate { get; set; }
        public DateTime outDate { get; set; }
        public int amount { get; set; }
        public IEnumerable<ReservationInfo> reservationInfos { get; set; }
    }

    public class ReservationCreateDTO
    {
        public long id { get; set; }
        public long idRoom { get; set; }
        public long idUser { get; set; }
        public bool active { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime inDate { get; set; }
        public DateTime outDate { get; set; }
        public int amount { get; set; }
        public IEnumerable<ReservationCreateInfoDTO> reservationInfos { get; set; }

    }
    public class ReservationCreateInfoDTO
    {
        public string? names { get; set; }
        public string? lastNames { get; set; }
        public long idGender { get; set; }
        public long idTypeDocument { get; set; }
        public string? identification { get; set; }
        public string? phone { get; set; }
        public DateTime birthDate { get; set; }
        public string? document { get; set; }
        public string? email { get; set; }
        public string? namesEContact { get; set; }
        public string? lastNamesEContact { get; set; }
        public string? phoneEContact { get; set; }
    }
    public class ReservationUpdateDTO
    {
        public long IdUser { get; set; }
        public long IdGender { get; set; }
        public long IdTypeDocument { get; set; }
        public bool Active { get; set; }
        public string? Names { get; set; }
        public string? LastNames { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Document { get; set; }
        public string? Email { get; set; }
        public string? NamesEContact { get; set; }
        public string? LastNamesEContact { get; set; }
        public string? PhoneEContact { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public decimal? Amount { get; set; }
    }

}
