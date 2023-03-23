namespace PTH.domain.models
{
    public class User
    {
        public long id { get; set; }
        public long idRole { get; set; }

        public string? userLogin { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public bool activo { get; set; }
        public DateTime creationDate { get; set; }
        public Guid token { get; set; }
        public DateTime tokenDate { get; set; }

    }
}
