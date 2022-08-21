using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace famagustaHospital.API.Migrations
{
    public partial class roleAttrDeletedFromDoctorAndPatientClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb1d60e2-fa7f-48e0-aa02-628b507cc771");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7c4e14c-85e6-4c5a-b0ad-43a685bb6ca5");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "PatientUser");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "DoctorUser");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ac9496c-12fb-424e-9d57-313e5df74447", "03df811b-29a0-4fd8-9592-268703207de2", "Patient", "PATIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5fbcedb3-a430-409f-84df-9a9d4f209a09", "5a883f9f-b44f-4519-a3e9-3c1333e354a7", "Doctor", "DOCTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ac9496c-12fb-424e-9d57-313e5df74447");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fbcedb3-a430-409f-84df-9a9d4f209a09");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "PatientUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "DoctorUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb1d60e2-fa7f-48e0-aa02-628b507cc771", "f5e1dfe3-b3b4-45e2-9a00-fd5138201ad2", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7c4e14c-85e6-4c5a-b0ad-43a685bb6ca5", "973cf628-a033-482c-925b-82396d9bdd1f", "Patient", "PATIENT" });
        }
    }
}
