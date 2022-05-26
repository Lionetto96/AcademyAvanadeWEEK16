using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgenziaConsulenzaAMM.EF.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dimensione = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dipendenti",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataAssunzione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mansione = table.Column<int>(type: "int", nullable: false),
                    CostoOrarioAzienda = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dipendenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commesse",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commesse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Commesse_Clienti_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "Clienti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attivities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OreAllocate = table.Column<int>(type: "int", nullable: false),
                    CostoSingolaOra = table.Column<double>(type: "float", nullable: false),
                    IdCommessa = table.Column<int>(type: "int", nullable: false),
                    IdDipendente = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attivities_Commesse_IdCommessa",
                        column: x => x.IdCommessa,
                        principalTable: "Commesse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attivities_Dipendenti_IdDipendente",
                        column: x => x.IdDipendente,
                        principalTable: "Dipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroOre = table.Column<double>(type: "float", nullable: false),
                    DataTimesheet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAttivita = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdDipendente = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timesheets_Attivities_IdAttivita",
                        column: x => x.IdAttivita,
                        principalTable: "Attivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timesheets_Dipendenti_IdDipendente",
                        column: x => x.IdDipendente,
                        principalTable: "Dipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clienti",
                columns: new[] { "ID", "Citta", "Dimensione", "Nome", "Provincia", "Regione" },
                values: new object[,]
                {
                    { 1, "Roma", 1, "Vodafone", "RM", "Lazio" },
                    { 2, "Milano", 2, "Bcc", "MI", "Lombardia" },
                    { 3, "Roma", 3, "Telecom", "RM", "Lazio" }
                });

            migrationBuilder.InsertData(
                table: "Dipendenti",
                columns: new[] { "Id", "Cognome", "CostoOrarioAzienda", "DataAssunzione", "DataNascita", "Email", "Mansione", "Nome" },
                values: new object[,]
                {
                    { "dip1", "Lionetto", 8.5m, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "ale.lio@gmail.com", 2, "Alessia" },
                    { "dip2", "De Stefano", 9m, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mari.ds12@gmail.com", 4, "Maria" },
                    { "dip3", "Tiso", 9.5m, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "marti.tiso@gmail.com", 3, "Martina" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Academy2022", 1, "martina.tiso" },
                    { 2, "novembre2022", 1, "alessia.lionetto" },
                    { 3, "forGirls2022", 1, "maria.de.stefano" },
                    { 4, "Pippo123", 0, "diego.angelino" }
                });

            migrationBuilder.InsertData(
                table: "Commesse",
                columns: new[] { "ID", "DataFine", "DataInizio", "Descrizione", "IDCliente", "Nome" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2004), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2020), "Descrizione del portale pubblico", 1, "Portale pubblico" });

            migrationBuilder.InsertData(
                table: "Commesse",
                columns: new[] { "ID", "DataFine", "DataInizio", "Descrizione", "IDCliente", "Nome" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2006), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2008), "Descrizione dell'applicazione mobile", 2, "Applicazione Mobile" });

            migrationBuilder.InsertData(
                table: "Commesse",
                columns: new[] { "ID", "DataFine", "DataInizio", "Descrizione", "IDCliente", "Nome" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2004), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2019), "Descrizione del portale privato", 3, "Portale privato" });

            migrationBuilder.InsertData(
                table: "Attivities",
                columns: new[] { "Id", "CostoSingolaOra", "IdCommessa", "IdDipendente", "Nome", "OreAllocate" },
                values: new object[] { "A1", 8.0, 1, "dip3", "sviluppo frontend ", 4 });

            migrationBuilder.InsertData(
                table: "Attivities",
                columns: new[] { "Id", "CostoSingolaOra", "IdCommessa", "IdDipendente", "Nome", "OreAllocate" },
                values: new object[] { "A2", 9.0, 2, "dip2", "sviluppo frontend ", 6 });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "Id", "DataTimesheet", "IdAttivita", "IdDipendente", "NumeroOre" },
                values: new object[] { "TS1", new DateTime(2022, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "A1", "dip2", 25.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Attivities_IdCommessa",
                table: "Attivities",
                column: "IdCommessa");

            migrationBuilder.CreateIndex(
                name: "IX_Attivities_IdDipendente",
                table: "Attivities",
                column: "IdDipendente");

            migrationBuilder.CreateIndex(
                name: "IX_Commesse_IDCliente",
                table: "Commesse",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_IdAttivita",
                table: "Timesheets",
                column: "IdAttivita");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_IdDipendente",
                table: "Timesheets",
                column: "IdDipendente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timesheets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Attivities");

            migrationBuilder.DropTable(
                name: "Commesse");

            migrationBuilder.DropTable(
                name: "Dipendenti");

            migrationBuilder.DropTable(
                name: "Clienti");
        }
    }
}
