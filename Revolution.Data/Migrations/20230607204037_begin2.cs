using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Revolution.Data.Migrations
{
    public partial class begin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EventsData",
                table: "Events",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "EventsData",
                table: "Events",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
