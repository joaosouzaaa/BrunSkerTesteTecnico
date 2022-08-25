using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrunSker.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cep = table.Column<string>(type: "char(8)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logradouro = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complemento = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bairro = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    localidade = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    uf = table.Column<string>(type: "char(2)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ibge = table.Column<string>(type: "char(7)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gia = table.Column<string>(type: "char(4)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ddd = table.Column<string>(type: "char(2)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    siafi = table.Column<string>(type: "char(4)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    registration_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lease",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    is_rented = table.Column<ulong>(type: "bit(1)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    registration_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lease_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Lease_AddressId",
                table: "Lease",
                column: "AddressId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lease");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
