using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewTestDB.Migrations
{
    /// <inheritdoc />
    public partial class Add_Manufacturer_To_Car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Salary",
                table: "JobPersonModel",
                type: "integer",
                maxLength: 30,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "CarModel",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "CarModel");

            migrationBuilder.AlterColumn<int>(
                name: "Salary",
                table: "JobPersonModel",
                type: "integer",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 30);
        }
    }
}
