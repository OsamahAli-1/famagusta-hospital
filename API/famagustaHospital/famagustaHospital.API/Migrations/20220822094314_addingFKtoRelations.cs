using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace famagustaHospital.API.Migrations
{
    public partial class addingFKtoRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chronic_PatientUser_PatientUserId",
                table: "Chronic");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAvailablability_DoctorUser_DoctorUserId",
                table: "DoctorAvailablability");

            migrationBuilder.DropForeignKey(
                name: "FK_Experience_DoctorUser_DoctorUserId",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_Session_SessionId",
                table: "Medicine");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualification_DoctorUser_DoctorUserId",
                table: "Qualification");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_DoctorUser_DoctorUserId",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_PatientUser_PatientUserId",
                table: "Session");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ac9496c-12fb-424e-9d57-313e5df74447");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fbcedb3-a430-409f-84df-9a9d4f209a09");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientUserId",
                table: "Session",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorUserId",
                table: "Session",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorUserId",
                table: "Qualification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "Medicine",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorUserId",
                table: "Experience",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorUserId",
                table: "DoctorAvailablability",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientUserId",
                table: "Chronic",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85c1a84e-41ef-4b86-9b87-09c0580dda25", "8a6148e0-98f9-4b3d-9ae7-b4425442e19c", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a66b87b2-7382-4b30-8b97-4c09795e079a", "06a4ba84-bdeb-4d67-bdf8-13a613b8cdfb", "Patient", "PATIENT" });

            migrationBuilder.AddForeignKey(
                name: "FK_Chronic_PatientUser_PatientUserId",
                table: "Chronic",
                column: "PatientUserId",
                principalTable: "PatientUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAvailablability_DoctorUser_DoctorUserId",
                table: "DoctorAvailablability",
                column: "DoctorUserId",
                principalTable: "DoctorUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_DoctorUser_DoctorUserId",
                table: "Experience",
                column: "DoctorUserId",
                principalTable: "DoctorUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_Session_SessionId",
                table: "Medicine",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Qualification_DoctorUser_DoctorUserId",
                table: "Qualification",
                column: "DoctorUserId",
                principalTable: "DoctorUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Session_DoctorUser_DoctorUserId",
                table: "Session",
                column: "DoctorUserId",
                principalTable: "DoctorUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Session_PatientUser_PatientUserId",
                table: "Session",
                column: "PatientUserId",
                principalTable: "PatientUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chronic_PatientUser_PatientUserId",
                table: "Chronic");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAvailablability_DoctorUser_DoctorUserId",
                table: "DoctorAvailablability");

            migrationBuilder.DropForeignKey(
                name: "FK_Experience_DoctorUser_DoctorUserId",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_Session_SessionId",
                table: "Medicine");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualification_DoctorUser_DoctorUserId",
                table: "Qualification");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_DoctorUser_DoctorUserId",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_PatientUser_PatientUserId",
                table: "Session");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85c1a84e-41ef-4b86-9b87-09c0580dda25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a66b87b2-7382-4b30-8b97-4c09795e079a");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientUserId",
                table: "Session",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorUserId",
                table: "Session",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorUserId",
                table: "Qualification",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "Medicine",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorUserId",
                table: "Experience",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorUserId",
                table: "DoctorAvailablability",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientUserId",
                table: "Chronic",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ac9496c-12fb-424e-9d57-313e5df74447", "03df811b-29a0-4fd8-9592-268703207de2", "Patient", "PATIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5fbcedb3-a430-409f-84df-9a9d4f209a09", "5a883f9f-b44f-4519-a3e9-3c1333e354a7", "Doctor", "DOCTOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Chronic_PatientUser_PatientUserId",
                table: "Chronic",
                column: "PatientUserId",
                principalTable: "PatientUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAvailablability_DoctorUser_DoctorUserId",
                table: "DoctorAvailablability",
                column: "DoctorUserId",
                principalTable: "DoctorUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_DoctorUser_DoctorUserId",
                table: "Experience",
                column: "DoctorUserId",
                principalTable: "DoctorUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_Session_SessionId",
                table: "Medicine",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Qualification_DoctorUser_DoctorUserId",
                table: "Qualification",
                column: "DoctorUserId",
                principalTable: "DoctorUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_DoctorUser_DoctorUserId",
                table: "Session",
                column: "DoctorUserId",
                principalTable: "DoctorUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_PatientUser_PatientUserId",
                table: "Session",
                column: "PatientUserId",
                principalTable: "PatientUser",
                principalColumn: "Id");
        }
    }
}
