using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseStudy.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sınıflar",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    OluşturulmaTarihi = table.Column<DateTime>(name: "Oluşturulma Tarihi", type: "datetime2", nullable: true),
                    DüzenlemeTarihi = table.Column<DateTime>(name: "Düzenleme Tarihi", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sınıflar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Öğrenciler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adı = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Soyadı = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DoğumTarihi = table.Column<DateTime>(name: "Doğum Tarihi", type: "datetime", nullable: false),
                    Sınıfı = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    OluşturulmaTarihi = table.Column<DateTime>(name: "Oluşturulma Tarihi", type: "datetime2", nullable: true),
                    DüzenlemeTarihi = table.Column<DateTime>(name: "Düzenleme Tarihi", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Öğrenciler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Öğrenciler_Sınıflar_Sınıfı",
                        column: x => x.Sınıfı,
                        principalTable: "Sınıflar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sınıf Öğretmenleri",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adı = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Soyadı = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ClassRoomID = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    OluşturulmaTarihi = table.Column<DateTime>(name: "Oluşturulma Tarihi", type: "datetime2", nullable: true),
                    DüzenlemeTarihi = table.Column<DateTime>(name: "Düzenleme Tarihi", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sınıf Öğretmenleri", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sınıf Öğretmenleri_Sınıflar_ClassRoomID",
                        column: x => x.ClassRoomID,
                        principalTable: "Sınıflar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Öğrenciler_Sınıfı",
                table: "Öğrenciler",
                column: "Sınıfı");

            migrationBuilder.CreateIndex(
                name: "IX_Sınıf Öğretmenleri_ClassRoomID",
                table: "Sınıf Öğretmenleri",
                column: "ClassRoomID",
                unique: true,
                filter: "[ClassRoomID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Öğrenciler");

            migrationBuilder.DropTable(
                name: "Sınıf Öğretmenleri");

            migrationBuilder.DropTable(
                name: "Sınıflar");
        }
    }
}
