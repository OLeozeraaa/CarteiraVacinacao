using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace carteiravacina.Migrations
{
    public partial class Secondary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraVacina_Animal_AnimalIdAnimal",
                table: "CarteiraVacina");

            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraVacina_CarteiraVacina_CarteiraVacinaIdCarteira",
                table: "CarteiraVacina");

            migrationBuilder.DropIndex(
                name: "IX_CarteiraVacina_AnimalIdAnimal",
                table: "CarteiraVacina");

            migrationBuilder.DropIndex(
                name: "IX_CarteiraVacina_CarteiraVacinaIdCarteira",
                table: "CarteiraVacina");

            migrationBuilder.DropColumn(
                name: "AnimalIdAnimal",
                table: "CarteiraVacina");

            migrationBuilder.DropColumn(
                name: "CarteiraVacinaIdCarteira",
                table: "CarteiraVacina");

            migrationBuilder.AlterColumn<string>(
                name: "dataVacina",
                table: "CarteiraVacina",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ProxVacina",
                table: "CarteiraVacina",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "CarteiraVacina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraVacina_AnimalId",
                table: "CarteiraVacina",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarteiraVacina_Animal_AnimalId",
                table: "CarteiraVacina",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "IdAnimal",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraVacina_Animal_AnimalId",
                table: "CarteiraVacina");

            migrationBuilder.DropIndex(
                name: "IX_CarteiraVacina_AnimalId",
                table: "CarteiraVacina");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "CarteiraVacina");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataVacina",
                table: "CarteiraVacina",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProxVacina",
                table: "CarteiraVacina",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimalIdAnimal",
                table: "CarteiraVacina",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarteiraVacinaIdCarteira",
                table: "CarteiraVacina",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraVacina_AnimalIdAnimal",
                table: "CarteiraVacina",
                column: "AnimalIdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraVacina_CarteiraVacinaIdCarteira",
                table: "CarteiraVacina",
                column: "CarteiraVacinaIdCarteira");

            migrationBuilder.AddForeignKey(
                name: "FK_CarteiraVacina_Animal_AnimalIdAnimal",
                table: "CarteiraVacina",
                column: "AnimalIdAnimal",
                principalTable: "Animal",
                principalColumn: "IdAnimal",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarteiraVacina_CarteiraVacina_CarteiraVacinaIdCarteira",
                table: "CarteiraVacina",
                column: "CarteiraVacinaIdCarteira",
                principalTable: "CarteiraVacina",
                principalColumn: "IdCarteira",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
