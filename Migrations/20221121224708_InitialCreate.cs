using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace carteiravacina.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Sexos_SexosIdSexo",
                table: "Animal");

            migrationBuilder.DropTable(
                name: "CarteiraVacina");

            migrationBuilder.DropIndex(
                name: "IX_Animal_SexosIdSexo",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "IdEspecie",
                table: "Vacina");

            migrationBuilder.DropColumn(
                name: "doseVacina",
                table: "Vacina");

            migrationBuilder.DropColumn(
                name: "SexosIdSexo",
                table: "Animal");

            migrationBuilder.RenameColumn(
                name: "intervaloVacina",
                table: "Vacina",
                newName: "CarteiraId");

            migrationBuilder.RenameColumn(
                name: "DescriacaoVacina",
                table: "Vacina",
                newName: "Medicamento");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVacina",
                table: "Vacina",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProximaVacina",
                table: "Vacina",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Carteira",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteira", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Carteira",
                columns: new[] { "Id", "PetName" },
                values: new object[,]
                {
                    { 1, "Rosa" },
                    { 2, "Pipoca" },
                    { 3, "Mano" }
                });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 1,
                columns: new[] { "DataVacina", "ProximaVacina" },
                values: new object[] { new DateTime(2022, 11, 21, 19, 47, 7, 133, DateTimeKind.Local).AddTicks(621), new DateTime(2022, 11, 21, 19, 47, 7, 135, DateTimeKind.Local).AddTicks(8368) });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 2,
                columns: new[] { "DataVacina", "ProximaVacina" },
                values: new object[] { new DateTime(2022, 11, 21, 19, 47, 7, 136, DateTimeKind.Local).AddTicks(4173), new DateTime(2022, 11, 21, 19, 47, 7, 136, DateTimeKind.Local).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 3,
                columns: new[] { "DataVacina", "ProximaVacina" },
                values: new object[] { new DateTime(2022, 11, 21, 19, 47, 7, 136, DateTimeKind.Local).AddTicks(4194), new DateTime(2022, 11, 21, 19, 47, 7, 136, DateTimeKind.Local).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 4,
                columns: new[] { "DataVacina", "ProximaVacina" },
                values: new object[] { new DateTime(2022, 11, 21, 19, 47, 7, 136, DateTimeKind.Local).AddTicks(4201), new DateTime(2022, 11, 21, 19, 47, 7, 136, DateTimeKind.Local).AddTicks(4203) });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 5,
                columns: new[] { "CarteiraId", "DataVacina", "ProximaVacina" },
                values: new object[] { 2, new DateTime(2022, 11, 21, 19, 47, 7, 136, DateTimeKind.Local).AddTicks(4206), new DateTime(2022, 11, 21, 19, 47, 7, 136, DateTimeKind.Local).AddTicks(4208) });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 6,
                columns: new[] { "CarteiraId", "DataVacina", "ProximaVacina" },
                values: new object[] { 2, new DateTime(2022, 11, 21, 19, 47, 7, 136, DateTimeKind.Local).AddTicks(4226), new DateTime(2022, 11, 21, 19, 47, 7, 136, DateTimeKind.Local).AddTicks(4228) });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 7,
                columns: new[] { "CarteiraId", "DataVacina", "ProximaVacina" },
                values: new object[] { 2, new DateTime(2022, 11, 21, 19, 47, 7, 136, DateTimeKind.Local).AddTicks(4231), new DateTime(2022, 11, 21, 19, 47, 7, 136, DateTimeKind.Local).AddTicks(4234) });

            migrationBuilder.CreateIndex(
                name: "IX_Vacina_CarteiraId",
                table: "Vacina",
                column: "CarteiraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacina_Carteira_CarteiraId",
                table: "Vacina",
                column: "CarteiraId",
                principalTable: "Carteira",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacina_Carteira_CarteiraId",
                table: "Vacina");

            migrationBuilder.DropTable(
                name: "Carteira");

            migrationBuilder.DropIndex(
                name: "IX_Vacina_CarteiraId",
                table: "Vacina");

            migrationBuilder.DropColumn(
                name: "DataVacina",
                table: "Vacina");

            migrationBuilder.DropColumn(
                name: "ProximaVacina",
                table: "Vacina");

            migrationBuilder.RenameColumn(
                name: "Medicamento",
                table: "Vacina",
                newName: "DescriacaoVacina");

            migrationBuilder.RenameColumn(
                name: "CarteiraId",
                table: "Vacina",
                newName: "intervaloVacina");

            migrationBuilder.AddColumn<int>(
                name: "IdEspecie",
                table: "Vacina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "doseVacina",
                table: "Vacina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SexosIdSexo",
                table: "Animal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarteiraVacina",
                columns: table => new
                {
                    IdCarteira = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAnimal = table.Column<int>(type: "int", nullable: true),
                    Medicamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProxVacina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoVacina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataVacina = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteiraVacina", x => x.IdCarteira);
                    table.ForeignKey(
                        name: "FK_CarteiraVacina_Animal_IdAnimal",
                        column: x => x.IdAnimal,
                        principalTable: "Animal",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 1,
                columns: new[] { "IdEspecie", "doseVacina" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 2,
                columns: new[] { "IdEspecie", "doseVacina" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 3,
                columns: new[] { "IdEspecie", "doseVacina" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 4,
                columns: new[] { "IdEspecie", "doseVacina" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 5,
                columns: new[] { "IdEspecie", "doseVacina", "intervaloVacina" },
                values: new object[] { 1, 1, 12 });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 6,
                columns: new[] { "IdEspecie", "doseVacina", "intervaloVacina" },
                values: new object[] { 2, 3, 4 });

            migrationBuilder.UpdateData(
                table: "Vacina",
                keyColumn: "IdVacina",
                keyValue: 7,
                columns: new[] { "IdEspecie", "doseVacina", "intervaloVacina" },
                values: new object[] { 2, 1, 12 });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_SexosIdSexo",
                table: "Animal",
                column: "SexosIdSexo");

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraVacina_IdAnimal",
                table: "CarteiraVacina",
                column: "IdAnimal");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Sexos_SexosIdSexo",
                table: "Animal",
                column: "SexosIdSexo",
                principalTable: "Sexos",
                principalColumn: "IdSexo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
