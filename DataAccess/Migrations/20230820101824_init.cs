using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heartbeats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WakatimeId = table.Column<string>(type: "TEXT", nullable: true),
                    Branch = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<string>(type: "TEXT", nullable: true),
                    Cursorpos = table.Column<int>(type: "INTEGER", nullable: false),
                    Entity = table.Column<string>(type: "TEXT", nullable: true),
                    IsWrite = table.Column<bool>(type: "INTEGER", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Lineno = table.Column<int>(type: "INTEGER", nullable: false),
                    Lines = table.Column<int>(type: "INTEGER", nullable: false),
                    MachineNameId = table.Column<string>(type: "TEXT", nullable: true),
                    Project = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectRootCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Time = table.Column<double>(type: "REAL", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    UserAgentId = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heartbeats", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heartbeats");
        }
    }
}
