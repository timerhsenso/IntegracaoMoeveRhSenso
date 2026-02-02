using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegracaoCepsaBrasil.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjusteCamposStringParaVarchar5000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "personalPhone",
                table: "PerPhone",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "personIdExernal",
                table: "PerPhone",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "businessPhone",
                table: "PerPhone",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                table: "PerPhone",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AreaCode",
                table: "PerPhone",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "PerPersonal",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "personIdExternal",
                table: "PerPersonal",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nationality",
                table: "PerPersonal",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "maritalStatus",
                table: "PerPersonal",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "PerPersonal",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString7",
                table: "PerPersonal",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString2",
                table: "PerPersonal",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "company",
                table: "PerPersonal",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "startDate",
                table: "PerPerson",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "personIdExternal",
                table: "PerPerson",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastModifiedOn",
                table: "PerPerson",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "endDate",
                table: "PerPerson",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "dateOfBirth",
                table: "PerPerson",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString4",
                table: "PerPerson",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "company",
                table: "PerPerson",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "PerEmail",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "personIdExternal",
                table: "PerEmail",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "emailType",
                table: "PerEmail",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "emailAddress",
                table: "PerEmail",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "company",
                table: "PerEmail",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "zipCode",
                table: "PerAddress",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "PerAddress",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "personIdExternal",
                table: "PerAddress",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString2",
                table: "PerAddress",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "company",
                table: "PerAddress",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address4",
                table: "PerAddress",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address3",
                table: "PerAddress",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address2",
                table: "PerAddress",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address1",
                table: "PerAddress",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastModifiedDateTime",
                table: "FiscalData",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "externalCode",
                table: "FiscalData",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_ZonaDoTituloDeEleitor",
                table: "FiscalData",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_UFDoTituloDeEleitor",
                table: "FiscalData",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_SecaoDoTituloDeEleitor",
                table: "FiscalData",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_NTituloDeEleitor",
                table: "FiscalData",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_DTEmissaoDoTitulo",
                table: "FiscalData",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "workerCategory",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastModifiedOn",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString160",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString159",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString157",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString156",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString155",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString154",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString153",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString152",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString151",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString150",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "costCenter",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "contractType",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "company",
                table: "EmpJob",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "externalCode",
                table: "DatosSindicales",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_IndicadorDeSindicalizado",
                table: "DatosSindicales",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_CodigoDoSindicato",
                table: "DatosSindicales",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "personalPhone",
                table: "PerPhone",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "personIdExernal",
                table: "PerPhone",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "businessPhone",
                table: "PerPhone",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                table: "PerPhone",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AreaCode",
                table: "PerPhone",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "PerPersonal",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "personIdExternal",
                table: "PerPersonal",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nationality",
                table: "PerPersonal",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "maritalStatus",
                table: "PerPersonal",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "PerPersonal",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString7",
                table: "PerPersonal",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString2",
                table: "PerPersonal",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "company",
                table: "PerPersonal",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "startDate",
                table: "PerPerson",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "personIdExternal",
                table: "PerPerson",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastModifiedOn",
                table: "PerPerson",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "endDate",
                table: "PerPerson",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "dateOfBirth",
                table: "PerPerson",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString4",
                table: "PerPerson",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "company",
                table: "PerPerson",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "PerEmail",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "personIdExternal",
                table: "PerEmail",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "emailType",
                table: "PerEmail",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "emailAddress",
                table: "PerEmail",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "company",
                table: "PerEmail",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "zipCode",
                table: "PerAddress",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "PerAddress",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "personIdExternal",
                table: "PerAddress",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString2",
                table: "PerAddress",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "company",
                table: "PerAddress",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address4",
                table: "PerAddress",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address3",
                table: "PerAddress",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address2",
                table: "PerAddress",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address1",
                table: "PerAddress",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastModifiedDateTime",
                table: "FiscalData",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "externalCode",
                table: "FiscalData",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_ZonaDoTituloDeEleitor",
                table: "FiscalData",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_UFDoTituloDeEleitor",
                table: "FiscalData",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_SecaoDoTituloDeEleitor",
                table: "FiscalData",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_NTituloDeEleitor",
                table: "FiscalData",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_DTEmissaoDoTitulo",
                table: "FiscalData",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "workerCategory",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastModifiedOn",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString160",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString159",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString157",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString156",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString155",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString154",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString153",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString152",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString151",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customString150",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "costCenter",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "contractType",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "company",
                table: "EmpJob",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "externalCode",
                table: "DatosSindicales",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_IndicadorDeSindicalizado",
                table: "DatosSindicales",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_CodigoDoSindicato",
                table: "DatosSindicales",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);
        }
    }
}
