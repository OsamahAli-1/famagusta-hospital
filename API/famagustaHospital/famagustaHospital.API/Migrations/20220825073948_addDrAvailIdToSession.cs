using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace famagustaHospital.API.Migrations
{
    public partial class addDrAvailIdToSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3efd35ae-732f-458f-b04e-8c51de2d1376");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f4e3eea-42b1-47f7-b676-b7daf218a886");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorAvailabilityId",
                table: "Session",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4a9003e6-312f-40bc-8fb3-e65b553e1c6f", "62a13979-3cb8-4423-8ec7-1d3878cc5db1", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51bbd9a0-6157-4d05-b892-b1ecacf35372", "715f9e60-f3fc-4383-a641-9d6e29248ed7", "Patient", "PATIENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a9003e6-312f-40bc-8fb3-e65b553e1c6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51bbd9a0-6157-4d05-b892-b1ecacf35372");

            migrationBuilder.DropColumn(
                name: "DoctorAvailabilityId",
                table: "Session");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3efd35ae-732f-458f-b04e-8c51de2d1376", "740236fa-09a8-482b-89ba-6b170b0b90a3", "Patient", "PATIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f4e3eea-42b1-47f7-b676-b7daf218a886", "9db0c0cd-9de1-4982-8862-7a5c8659cc6f", "Doctor", "DOCTOR" });
        }
    }
}
