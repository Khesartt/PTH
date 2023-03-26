using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PTH.domain.models;
using PTH.domain.modelsDomain;
using PTH.infraestructure.EF.Configs;

namespace PTH.infraestructure.EF.Context
{
    public class ApiContext : DbContext
    {
        public DbSet<City> cities { get; set; }
        public DbSet<Gender> genders { get; set; }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Parametric> parametrics { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<ReservationInfo> reservationsInfo { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<RoomType> roomsType { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<TypeDocument> typedocuments { get; set; }
        public DbSet<User> users { get; set; }

        private IConfiguration _configuration;
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("connection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CityConfig());
            builder.ApplyConfiguration(new GenderConfig());
            builder.ApplyConfiguration(new HotelConfig());
            builder.ApplyConfiguration(new ParametricConfig());
            builder.ApplyConfiguration(new ReservationConfig());
            builder.ApplyConfiguration(new ReservationInfoConfig());
            builder.ApplyConfiguration(new RoleConfig());
            builder.ApplyConfiguration(new RoomConfig());
            builder.ApplyConfiguration(new RoomTypeConfig());
            builder.ApplyConfiguration(new ServiceConfig());
            builder.ApplyConfiguration(new TypeDocumentConfig());
            builder.ApplyConfiguration(new UserConfig());
        }
    }
}
