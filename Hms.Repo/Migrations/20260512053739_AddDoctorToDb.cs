using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hms.Repo.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDoctor",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDoctor",
                table: "AspNetUsers");
        }
    }
}
