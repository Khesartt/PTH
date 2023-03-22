using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTH.domain.models
{
    public class Reservation
    {
        public long id { get; set; }
        public long idRoom { get; set; }
        public long idUser { get; set; }
        public long idGender { get; set; }
        public long idTypeDocument { get; set; }
        public bool active { get; set; }
        public DateTime creationDate { get; set; }
        public string? names { get; set; }
        public string? lastNames { get; set; }
        public string? phone { get; set; }
        public DateTime birthDate { get; set; }
        public string? document { get; set; }
        public string? email { get; set; }
        public string? namesEContact { get; set; }
        public string? lastNamesEContact { get; set; }
        public string? phoneEContact { get; set; }
        public DateTime inDate { get; set; }
        public DateTime outDate { get; set; }
        public decimal? amount { get; set; }
        public Room? room { get; set; }
        public User? user { get; set; }
        public Gender? gender { get; set; }
        public TypeDocument? typeDocument { get; set; }

    }
}
