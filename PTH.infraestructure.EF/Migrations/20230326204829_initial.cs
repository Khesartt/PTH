using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTH.infraestructure.EF.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idCity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    Abbreviation = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idGender", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Parametric",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key = table.Column<string>(type: "varchar(200)", nullable: true),
                    value = table.Column<string>(type: "varchar(200)", nullable: true),
                    description = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idParametric", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idRole", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: true),
                    description = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idRoomType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: true),
                    description = table.Column<string>(type: "varchar(500)", nullable: true),
                    icon = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idService", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TypeDocument",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    Abbreviation = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idTypeDocument", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idRole = table.Column<long>(type: "bigint", nullable: false),
                    userLogin = table.Column<string>(type: "varchar(20)", nullable: true),
                    password = table.Column<string>(type: "varchar(20)", nullable: true),
                    email = table.Column<string>(type: "varchar(100)", nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    token = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tokenDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idUser", x => x.id);
                    table.ForeignKey(
                        name: "FK_idUserRol",
                        column: x => x.idRole,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<long>(type: "bigint", nullable: false),
                    idCity = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: true),
                    description = table.Column<string>(type: "varchar(100)", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "varchar(100)", nullable: true),
                    services = table.Column<string>(type: "varchar(100)", nullable: true),
                    checkIn = table.Column<TimeSpan>(type: "time", nullable: false),
                    checkOut = table.Column<TimeSpan>(type: "time", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idHotel", x => x.id);
                    table.ForeignKey(
                        name: "FK_idHotelCity",
                        column: x => x.idCity,
                        principalTable: "City",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_idHotelUser",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idRoomType = table.Column<long>(type: "bigint", nullable: false),
                    idHotel = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: true),
                    description = table.Column<string>(type: "varchar(500)", nullable: true),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    image = table.Column<string>(type: "text", nullable: true),
                    location = table.Column<string>(type: "varchar(200)", nullable: true),
                    quota = table.Column<int>(type: "int", nullable: false),
                    baseCost = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    taxes = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    occupied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idRoom", x => x.id);
                    table.ForeignKey(
                        name: "FK_idRoomByRoomType",
                        column: x => x.idRoomType,
                        principalTable: "RoomType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_idRoomHotel",
                        column: x => x.idHotel,
                        principalTable: "Hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idRoom = table.Column<long>(type: "bigint", nullable: false),
                    idUser = table.Column<long>(type: "bigint", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    inDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    outDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idReservation", x => x.id);
                    table.ForeignKey(
                        name: "FK_idReservationRoom",
                        column: x => x.idRoom,
                        principalTable: "Room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_idReservationUser",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationInfo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idReservation = table.Column<long>(type: "bigint", nullable: false),
                    idGender = table.Column<long>(type: "bigint", nullable: false),
                    idTypeDocument = table.Column<long>(type: "bigint", nullable: false),
                    names = table.Column<string>(type: "varchar(100)", nullable: true),
                    lastNames = table.Column<string>(type: "varchar(100)", nullable: true),
                    identification = table.Column<string>(type: "varchar(30)", nullable: true),
                    phone = table.Column<string>(type: "varchar(20)", nullable: true),
                    birthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: true),
                    namesEContact = table.Column<string>(type: "varchar(100)", nullable: true),
                    lastNamesEContact = table.Column<string>(type: "varchar(100)", nullable: true),
                    phoneEContact = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idReservationInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_idReservationInfoByReservation",
                        column: x => x.idReservation,
                        principalTable: "Reservation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_idReservationInfoGender",
                        column: x => x.idGender,
                        principalTable: "Gender",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_idReservationInfoTypeDocument",
                        column: x => x.idTypeDocument,
                        principalTable: "TypeDocument",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.Sql(@"


                    INSERT INTO City (name)
                    VALUES ('Armenia'),
                           ('Armenia'),
                           ('Barichara'),
                           ('Barranquilla'),
                           ('Bogota'),
                           ('Bucaramanga'),
                           ('Cajica'),
                           ('Cali'),
                           ('Cartagena'),
                           ('Chia'),
                           ('Chinacota'),
                           ('Cucuta'),
                           ('El Penol'),
                           ('Florencia'),
                           ('Fusagasuga'),
                           ('Genova'),
                           ('Girardot'),
                           ('Giron'),
                           ('Honda'),
                           ('Ibague'),
                           ('Jerico'),
                           ('La Tebaida'),
                           ('La Vega'),
                           ('Lebrija'),
                           ('Lorica'),
                           ('Mariquita'),
                           ('Manizales'),
                           ('Mitú'),
                           ('Mocoa'),
                           ('Mompos'),
                           ('Monteria'),
                           ('Neiva'),
                           ('Pasto'),
                           ('Pamplona'),
                           ('Pereira'),
                           ('Piedecuesta'),
                           ('Popayan'),
                           ('Puerto Carreno'),
                           ('Quibdo'),
                           ('Riohacha'),
                           ('Salento'),
                           ('San Gil'),
                           ('San Jose del Guaviare'),
                           ('San Juan de Nepomuceno'),
                           ('Santa Marta'),
                           ('Santa Rosa de Cabal'),
                           ('Sincelejo'),
                           ('Soledad'),
                           ('Sopo'),
                           ('Tunja'),
                           ('Valledupar'),
                           ('Velez'),
                           ('Villa de Leyva'),
                           ('Villavicencio'),
                           ('Villeta'),
                           ('Yopal');


                    INSERT INTO Gender (name, active, Abbreviation) VALUES ('Masculino', 1, 'Ma');
                    INSERT INTO Gender (name, active, Abbreviation) VALUES ('Femenino', 1, 'Fe');
                    INSERT INTO Gender (name, active, Abbreviation) VALUES ('Indefinido', 1, 'In');
                    INSERT INTO Gender (name, active, Abbreviation) VALUES ('N/A', 1, 'N/A');


                    INSERT INTO Role (name, active) VALUES ('usuario', 1);
                    INSERT INTO Role (name, active) VALUES ('administradorHoteles',1);


                    INSERT INTO RoomType (name, description) VALUES ('regular', 'habitacion de 2 camas, tipo estandar');
                    INSERT INTO RoomType (name, description) VALUES ('familiar','habitacion de 4 camas tipo familiar');
                    INSERT INTO RoomType (name, description) VALUES ('basica','habitacion de una cama sencilla');
                    INSERT INTO RoomType (name, description) VALUES ('deluxe','habitacion de 2 camas, ideal para viaje de negocios');


                    INSERT INTO Service (name, description, icon) VALUES ('Servicio de habitaciones', 'Servicio para solicitar comida y bebidas en la habitación', '<svg>...</svg>');
                    INSERT INTO Service (name, description, icon) VALUES ('Spa', 'Servicio de masajes y tratamientos de belleza', '<svg>...</svg>');
                    INSERT INTO Service (name, description, icon) VALUES ('Gimnasio', 'Área para hacer ejercicio', '<svg>...</svg>');
                    INSERT INTO Service (name, description, icon) VALUES ('Piscina', 'Piscina para nadar y tomar el sol', '<svg>...</svg>');
                    INSERT INTO Service (name, description, icon) VALUES ('Bar', 'Lugar para tomar bebidas y cócteles', '<svg>...</svg>');
                    INSERT INTO Service (name, description, icon) VALUES ('Restaurante', 'Lugar para comer', '<svg>...</svg>');
                    INSERT INTO Service (name, description, icon) VALUES ('Aparcamiento', 'Lugar para aparcar el coche', '<svg>...</svg>');
                    INSERT INTO Service (name, description, icon) VALUES ('Servicio de lavandería', 'Servicio para lavar la ropa', '<svg>...</svg>');
                    INSERT INTO Service (name, description, icon) VALUES ('Salón de eventos', 'Salón para reuniones y celebraciones', '<svg>...</svg>');
                    INSERT INTO Service (name, description, icon) VALUES ('Recepción 24 horas', 'Servicio de atención al cliente las 24 horas', '<svg>...</svg>');

                    INSERT INTO TypeDocument (name, active, Abbreviation)
                    VALUES ('Cedula de Ciudadania', 1, 'CC'),
                           ('Cedula de Extranjeria', 1, 'CE'),
                           ('Pasaporte', 1, 'P'),
                           ('Nit', 1, 'NIT'),
                           ('Tarjeta de Identidad', 1, 'TI'),
                           ('N/A', 1, 'NA');
");



            migrationBuilder.CreateIndex(
                name: "IX_Hotel_idCity",
                table: "Hotel",
                column: "idCity");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_idUser",
                table: "Hotel",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_idRoom",
                table: "Reservation",
                column: "idRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_idUser",
                table: "Reservation",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationInfo_idGender",
                table: "ReservationInfo",
                column: "idGender");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationInfo_idReservation",
                table: "ReservationInfo",
                column: "idReservation");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationInfo_idTypeDocument",
                table: "ReservationInfo",
                column: "idTypeDocument");

            migrationBuilder.CreateIndex(
                name: "IX_Room_idHotel",
                table: "Room",
                column: "idHotel");

            migrationBuilder.CreateIndex(
                name: "IX_Room_idRoomType",
                table: "Room",
                column: "idRoomType");

            migrationBuilder.CreateIndex(
                name: "IX_User_idRole",
                table: "User",
                column: "idRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parametric");

            migrationBuilder.DropTable(
                name: "ReservationInfo");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "TypeDocument");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "RoomType");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
