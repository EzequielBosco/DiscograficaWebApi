using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiscograficaWebApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discograficas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FechaFundacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discograficas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Nacionalidad = table.Column<int>(type: "int", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreArtistico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneroMusical = table.Column<int>(type: "int", nullable: true),
                    Biografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscograficaId = table.Column<long>(type: "bigint", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Nacionalidad = table.Column<int>(type: "int", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artistas_Discograficas_DiscograficaId",
                        column: x => x.DiscograficaId,
                        principalTable: "Discograficas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Discos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneroMusical = table.Column<int>(type: "int", nullable: false),
                    FechaLanzamiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnidadesVendidas = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArtistaId = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discos_Artistas_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cancions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneroMusical = table.Column<int>(type: "int", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    FechaLanzamiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscoId = table.Column<long>(type: "bigint", nullable: true),
                    ArtistaId = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cancions_Artistas_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cancions_Discos_DiscoId",
                        column: x => x.DiscoId,
                        principalTable: "Discos",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Artistas",
                columns: new[] { "Id", "Apellido", "Biografia", "CreatedTime", "DeletedTime", "DiscograficaId", "Email", "FechaNacimiento", "GeneroMusical", "IsDeleted", "Nacionalidad", "Nombre", "NombreArtistico", "Telefono" },
                values: new object[,]
                {
                    { 1L, null, null, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2148), null, null, "pinkfloyd@gmail.com", new DateTime(1965, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 42, "Pink Floyd", "Pink Floyd", null },
                    { 2L, null, null, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2153), null, null, "queen@gmail.com", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 42, "Queen", "Queen", null },
                    { 3L, null, null, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2155), null, null, "beatles@gmail.com", new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 42, "The Beatles", "The Beatles", null }
                });

            migrationBuilder.InsertData(
                table: "Discograficas",
                columns: new[] { "Id", "CreatedTime", "DeletedTime", "Direccion", "Email", "FechaFundacion", "IsDeleted", "Nombre", "Telefono", "WebSite" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(1990), null, "Av. Corrientes 1234", "info@sonymusic.com", new DateTime(1929, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Sony Music", "123456789", "www.sonymusic.com" },
                    { 2L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(1997), null, "Av. Rivadavia 1234", "info@universal.com", new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Universal Music", "987654321", "www.universalmusic.com" },
                    { 3L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(1998), null, "Av. Santa Fe 1234", "info@warner.com", new DateTime(1958, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Warner Music", "456789123", "www.warnermusic.com" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "CreatedTime", "DeletedTime", "Email", "FechaNacimiento", "IsDeleted", "Nacionalidad", "Nombre", "Password", "Rol", "Telefono", "UserName" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2486), null, "emiliano@gmail.com", new DateTime(1997, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Emiliano", "123456", 2, null, "Emiliano1" },
                    { 2L, null, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2488), null, "ezequiel@gmail.com", new DateTime(1998, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Ezequiel", "123456", 2, null, "EzequielTomas" },
                    { 3L, null, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2489), null, "julieta@gmail.com", new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Julieta", "123456", 2, null, "Juli123" }
                });

            migrationBuilder.InsertData(
                table: "Discos",
                columns: new[] { "Id", "ArtistaId", "CreatedTime", "DeletedTime", "FechaLanzamiento", "GeneroMusical", "IsDeleted", "Nombre", "SKU", "UnidadesVendidas" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2237), null, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "The Dark Side of the Moon", "DSM", 4500000 },
                    { 2L, 2L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2239), null, new DateTime(1982, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Thriller", "THR", 70000000 },
                    { 3L, 3L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2240), null, new DateTime(1980, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Back in Black", "BIA", 50000000 }
                });

            migrationBuilder.InsertData(
                table: "Cancions",
                columns: new[] { "Id", "ArtistaId", "CreatedTime", "DeletedTime", "DiscoId", "Duracion", "FechaLanzamiento", "GeneroMusical", "IsDeleted", "Nombre" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2377), null, 1L, 420, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Time" },
                    { 2L, 1L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2382), null, 1L, 382, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Money" },
                    { 3L, 1L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2383), null, 1L, 462, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Us and Them" },
                    { 4L, 2L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2385), null, 2L, 300, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Bohemian Rhapsody" },
                    { 5L, 2L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2386), null, 2L, 180, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Killer Queen" },
                    { 6L, 2L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2387), null, 2L, 240, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Somebody to Love" },
                    { 7L, 2L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2388), null, 2L, 240, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Another One Bites the Dust" },
                    { 8L, 3L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2389), null, 3L, 480, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Stairway to Heaven" },
                    { 9L, 3L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2390), null, 3L, 240, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Black Dog" },
                    { 10L, 3L, new DateTime(2024, 6, 16, 21, 29, 43, 337, DateTimeKind.Utc).AddTicks(2391), null, 3L, 240, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Rock and Roll" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_DiscograficaId",
                table: "Artistas",
                column: "DiscograficaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cancions_ArtistaId",
                table: "Cancions",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cancions_DiscoId",
                table: "Cancions",
                column: "DiscoId");

            migrationBuilder.CreateIndex(
                name: "IX_Discos_ArtistaId",
                table: "Discos",
                column: "ArtistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cancions");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Discos");

            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Discograficas");
        }
    }
}
