using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementOneToMany.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HostelMasterOtoM",
                columns: table => new
                {
                    HostelRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostelMasterOtoM", x => x.HostelRoomId);
                });

            migrationBuilder.CreateTable(
                name: "StudentMasterOtoM",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostelRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMasterOtoM", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_StudentMasterOtoM_HostelMasterOtoM_HostelRoomId",
                        column: x => x.HostelRoomId,
                        principalTable: "HostelMasterOtoM",
                        principalColumn: "HostelRoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymenttMasterOtoM",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymenttMasterOtoM", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_PaymenttMasterOtoM_StudentMasterOtoM_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentMasterOtoM",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymenttMasterOtoM_StudentId",
                table: "PaymenttMasterOtoM",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentMasterOtoM_HostelRoomId",
                table: "StudentMasterOtoM",
                column: "HostelRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymenttMasterOtoM");

            migrationBuilder.DropTable(
                name: "StudentMasterOtoM");

            migrationBuilder.DropTable(
                name: "HostelMasterOtoM");
        }
    }
}
