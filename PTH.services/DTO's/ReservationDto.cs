using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTH.services.DTO_s
{
    public class ReservationDTO
    {
        public long Id { get; set; }
        public long IdRoom { get; set; }
        public long IdUser { get; set; }
        public long IdGender { get; set; }
        public long IdTypeDocument { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
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

    public class ReservationCreateDTO
    {
        public long IdRoom { get; set; }
        public long IdUser { get; set; }
        public long IdGender { get; set; }
        public long IdTypeDocument { get; set; }
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

    public class ReservationUpdateDTO
    {
        public long IdRoom { get; set; }
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
