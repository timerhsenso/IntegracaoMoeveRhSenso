using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegracaoCepsaBrasil.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatosSindicales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cust_CodigoDoSindicato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cust_IndicadorDeSindicalizado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    externalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosSindicales", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmpJob",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customString160 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customString151 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customString150 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customString153 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customString152 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customString155 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contractType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    costCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customString154 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastModifiedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    workerCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customString157 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customString156 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customString159 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpJob", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FiscalData",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cust_NTituloDeEleitor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cust_DTEmissaoDoTitulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cust_SecaoDoTituloDeEleitor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cust_ZonaDoTituloDeEleitor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cust_UFDoTituloDeEleitor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastModifiedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    externalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalData", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PerAddress",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    personIdExternal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customString2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerAddress", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PerEmail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    personIdExternal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerEmail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PerPerson",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personIdExternal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customString4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    endDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastModifiedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerPerson", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PerPersonal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    personIdExternal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customString2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customString7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    maritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerPersonal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PerPhone",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personIdExernal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    businessPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    personalPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerPhone", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatosSindicales");

            migrationBuilder.DropTable(
                name: "EmpJob");

            migrationBuilder.DropTable(
                name: "FiscalData");

            migrationBuilder.DropTable(
                name: "PerAddress");

            migrationBuilder.DropTable(
                name: "PerEmail");

            migrationBuilder.DropTable(
                name: "PerPerson");

            migrationBuilder.DropTable(
                name: "PerPersonal");

            migrationBuilder.DropTable(
                name: "PerPhone");
        }
    }
}
