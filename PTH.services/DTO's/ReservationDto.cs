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
    public class ReservationUpdateInfoDTO
    {
        public long id { get; set; }
        public bool toUpdate { get; set; }
        public long idReservation { get; set; }
        public string? names { get; set; }
        public string? lastNames { get; set; }
        public long idGender { get; set; }
        public long idTypeDocument { get; set; }
        public string? identification { get; set; }
        public string? phone { get; set; }
        public DateTime birthDate { get; set; }
        public string? email { get; set; }
        public string? namesEContact { get; set; }
        public string? lastNamesEContact { get; set; }
        public string? phoneEContact { get; set; }
    }


}
