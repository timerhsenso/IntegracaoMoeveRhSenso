using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegracaoCepsaBrasil.Data.Migrations
{
    /// <inheritdoc />
    public partial class MudancaNoNomeDasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PerPhone",
                table: "PerPhone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerPersonal",
                table: "PerPersonal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerPerson",
                table: "PerPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerEmail",
                table: "PerEmail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerAddress",
                table: "PerAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FiscalData",
                table: "FiscalData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpJob",
                table: "EmpJob");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DatosSindicales",
                table: "DatosSindicales");

            migrationBuilder.RenameTable(
                name: "PerPhone",
                newName: "sapsf_PerPhone");

            migrationBuilder.RenameTable(
                name: "PerPersonal",
                newName: "sapsf_PerPersonal");

            migrationBuilder.RenameTable(
                name: "PerPerson",
                newName: "sapsf_PerPerson");

            migrationBuilder.RenameTable(
                name: "PerEmail",
                newName: "sapsf_PerEmail");

            migrationBuilder.RenameTable(
                name: "PerAddress",
                newName: "sapsf_PerAddress");

            migrationBuilder.RenameTable(
                name: "FiscalData",
                newName: "sapsf_FiscalData");

            migrationBuilder.RenameTable(
                name: "EmpJob",
                newName: "sapsf_EmpJob");

            migrationBuilder.RenameTable(
                name: "DatosSindicales",
                newName: "sapsf_DatosSindicales");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sapsf_PerPhone",
                table: "sapsf_PerPhone",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sapsf_PerPersonal",
                table: "sapsf_PerPersonal",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sapsf_PerPerson",
                table: "sapsf_PerPerson",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sapsf_PerEmail",
                table: "sapsf_PerEmail",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sapsf_PerAddress",
                table: "sapsf_PerAddress",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sapsf_FiscalData",
                table: "sapsf_FiscalData",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sapsf_EmpJob",
                table: "sapsf_EmpJob",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sapsf_DatosSindicales",
                table: "sapsf_DatosSindicales",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sapsf_PerPhone",
                table: "sapsf_PerPhone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sapsf_PerPersonal",
                table: "sapsf_PerPersonal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sapsf_PerPerson",
                table: "sapsf_PerPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sapsf_PerEmail",
                table: "sapsf_PerEmail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sapsf_PerAddress",
                table: "sapsf_PerAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sapsf_FiscalData",
                table: "sapsf_FiscalData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sapsf_EmpJob",
                table: "sapsf_EmpJob");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sapsf_DatosSindicales",
                table: "sapsf_DatosSindicales");

            migrationBuilder.RenameTable(
                name: "sapsf_PerPhone",
                newName: "PerPhone");

            migrationBuilder.RenameTable(
                name: "sapsf_PerPersonal",
                newName: "PerPersonal");

            migrationBuilder.RenameTable(
                name: "sapsf_PerPerson",
                newName: "PerPerson");

            migrationBuilder.RenameTable(
                name: "sapsf_PerEmail",
                newName: "PerEmail");

            migrationBuilder.RenameTable(
                name: "sapsf_PerAddress",
                newName: "PerAddress");

            migrationBuilder.RenameTable(
                name: "sapsf_FiscalData",
                newName: "FiscalData");

            migrationBuilder.RenameTable(
                name: "sapsf_EmpJob",
                newName: "EmpJob");

            migrationBuilder.RenameTable(
                name: "sapsf_DatosSindicales",
                newName: "DatosSindicales");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerPhone",
                table: "PerPhone",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerPersonal",
                table: "PerPersonal",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerPerson",
                table: "PerPerson",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerEmail",
                table: "PerEmail",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerAddress",
                table: "PerAddress",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FiscalData",
                table: "FiscalData",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpJob",
                table: "EmpJob",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DatosSindicales",
                table: "DatosSindicales",
                column: "id");
        }
    }
}
