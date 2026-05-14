using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hms.Repo.Migrations
{
    /// <inheritdoc />
    public partial class FixApplicationUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Rooms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "PatientReports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Hospital",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ApplicationUserId",
                table: "Rooms",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReports_ApplicationUserId",
                table: "PatientReports",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_ApplicationUserId",
                table: "Hospital",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ApplicationUserId",
                table: "Contacts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_ApplicationUserId",
                table: "Contacts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospital_AspNetUsers_ApplicationUserId",
                table: "Hospital",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_ApplicationUserId",
                table: "PatientReports",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AspNetUsers_ApplicationUserId",
                table: "Rooms",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_ApplicationUserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospital_AspNetUsers_ApplicationUserId",
                table: "Hospital");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_ApplicationUserId",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AspNetUsers_ApplicationUserId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ApplicationUserId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_PatientReports_ApplicationUserId",
                table: "PatientReports");

            migrationBuilder.DropIndex(
                name: "IX_Hospital_ApplicationUserId",
                table: "Hospital");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ApplicationUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "PatientReports");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Hospital");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "AspNetUsers");
        }
    }
}
