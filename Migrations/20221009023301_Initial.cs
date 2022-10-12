using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace carteiravacina.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    IdEspecie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EspecieAnimal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupoAnimal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.IdEspecie);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    PasswordHash = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.PasswordHash);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    IdCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.IdCodigo);
                });

            migrationBuilder.CreateTable(
                name: "Racas",
                columns: table => new
                {
                    IdRaca = table.Column<int>(type: "int", nullable: false),
                    IdEspecie = table.Column<int>(type: "int", nullable: false),
                    DescricaoRaca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PorteRaca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    crRaca = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racas", x => new { x.IdRaca, x.IdEspecie });
                });

            migrationBuilder.CreateTable(
                name: "Sexos",
                columns: table => new
                {
                    IdSexo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoSexo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.IdSexo);
                });

            migrationBuilder.CreateTable(
                name: "Situacao",
                columns: table => new
                {
                    IdSituacao = table.Column<int>(type: "int", nullable: false),
                    DescricaoSituacao = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacao", x => new { x.IdSituacao, x.DescricaoSituacao });
                });

            migrationBuilder.CreateTable(
                name: "TutorAnimal",
                columns: table => new
                {
                    IdTutor = table.Column<int>(type: "int", nullable: false),
                    IdAnimal = table.Column<int>(type: "int", nullable: false),
                    dataInicio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorAnimal", x => new { x.IdTutor, x.IdAnimal });
                });

            migrationBuilder.CreateTable(
                name: "Vacina",
                columns: table => new
                {
                    IdVacina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriacaoVacina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEspecie = table.Column<int>(type: "int", nullable: false),
                    doseVacina = table.Column<int>(type: "int", nullable: false),
                    intervaloVacina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacina", x => x.IdVacina);
                });

            migrationBuilder.CreateTable(
                name: "Tutor",
                columns: table => new
                {
                    IdTutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cpfTutor = table.Column<int>(type: "int", nullable: false),
                    NomeTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTutor = table.Column<int>(type: "int", nullable: false),
                    ComplementoTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BairroTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipioTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ufTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    crm = table.Column<int>(type: "int", nullable: false),
                    PerfilIdCodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor", x => x.IdTutor);
                    table.ForeignKey(
                        name: "FK_Tutor_Perfil_PerfilIdCodigo",
                        column: x => x.PerfilIdCodigo,
                        principalTable: "Perfil",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    IdAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspecieIdEspecie = table.Column<int>(type: "int", nullable: true),
                    RacasIdRaca = table.Column<int>(type: "int", nullable: true),
                    RacasIdEspecie = table.Column<int>(type: "int", nullable: true),
                    SexosIdSexo = table.Column<int>(type: "int", nullable: true),
                    dtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pelagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SituacaoIdSituacao = table.Column<int>(type: "int", nullable: true),
                    SituacaoDescricaoSituacao = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdRGA = table.Column<int>(type: "int", nullable: false),
                    peso = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.IdAnimal);
                    table.ForeignKey(
                        name: "FK_Animal_Especie_EspecieIdEspecie",
                        column: x => x.EspecieIdEspecie,
                        principalTable: "Especie",
                        principalColumn: "IdEspecie",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Racas_RacasIdRaca_RacasIdEspecie",
                        columns: x => new { x.RacasIdRaca, x.RacasIdEspecie },
                        principalTable: "Racas",
                        principalColumns: new[] { "IdRaca", "IdEspecie" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Sexos_SexosIdSexo",
                        column: x => x.SexosIdSexo,
                        principalTable: "Sexos",
                        principalColumn: "IdSexo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Situacao_SituacaoIdSituacao_SituacaoDescricaoSituacao",
                        columns: x => new { x.SituacaoIdSituacao, x.SituacaoDescricaoSituacao },
                        principalTable: "Situacao",
                        principalColumns: new[] { "IdSituacao", "DescricaoSituacao" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarteiraVacina",
                columns: table => new
                {
                    IdCarteira = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataVacina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Medicamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoVacina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimalIdAnimal = table.Column<int>(type: "int", nullable: true),
                    ProxVacina = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteiraVacina", x => x.IdCarteira);
                    table.ForeignKey(
                        name: "FK_CarteiraVacina_Animal_AnimalIdAnimal",
                        column: x => x.AnimalIdAnimal,
                        principalTable: "Animal",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Especie",
                columns: new[] { "IdEspecie", "EspecieAnimal", "GrupoAnimal" },
                values: new object[,]
                {
                    { 1, "Cachorro", "Canina" },
                    { 2, "Gato", "Felinos" }
                });

            migrationBuilder.InsertData(
                table: "Racas",
                columns: new[] { "IdEspecie", "IdRaca", "DescricaoRaca", "PorteRaca", "crRaca" },
                values: new object[,]
                {
                    { 2, 96, "Chausie", "Médio", "-" },
                    { 2, 95, "Chartreux", "Médio", "-" },
                    { 2, 94, "Cingapura", "Médio", "-" },
                    { 2, 93, "California Spangled", "Médio", "-" },
                    { 2, 92, "Burmila", "Médio", "-" },
                    { 2, 91, "Burmês", "Médio", "-" },
                    { 2, 90, "Bombaim", "Médio", "-" },
                    { 2, 89, "Bobtail japonês", "Médio", "-" },
                    { 2, 88, "Bobtail americano", "Médio", "-" },
                    { 2, 87, "Bicolor Oriental", "Médio", "-" },
                    { 2, 86, "Bambino", "Médio", "-" },
                    { 2, 85, "Balinês", "Médio", "-" },
                    { 2, 84, "Azul Russo", "Médio", "-" },
                    { 2, 83, "Asiático de Pelo Semi-Longo", "Médio", "-" },
                    { 2, 82, "Manx de pelo longo", "Médio", "-" },
                    { 2, 81, "Wirehair Americano", "Médio", "-" },
                    { 2, 80, "Van Turco", "Médio", "-" },
                    { 2, 79, "Toyger", "Médio", "-" },
                    { 2, 78, "Tonquinês", "Médio", "-" },
                    { 2, 77, "Tiffany-Chantilly", "Médio", "-" },
                    { 2, 76, "Thai", "Médio", "-" },
                    { 2, 75, "Suphalak", "Médio", "-" },
                    { 2, 74, "Sphynx", "Médio", "-" },
                    { 2, 73, "Somali", "Médio", "-" },
                    { 2, 72, "Sokoke", "Médio", "-" },
                    { 2, 71, "Snowshoe", "Médio", "-" },
                    { 2, 69, "Siamês", "Médio", "-" },
                    { 2, 68, "Serengeti", "Médio", "-" },
                    { 2, 67, "Selkirk Rex", "Médio", "-" },
                    { 2, 97, "Colorpoint de pelo curto", "Médio", "-" },
                    { 2, 98, "Cornish Rex", "Médio", "-" },
                    { 2, 99, "Curl Americano", "Médio", "-" },
                    { 2, 100, "Devon Rex", "Médio", "-" },
                    { 2, 129, "Angorá turco", "Médio", "-" },
                    { 2, 128, "Abissínio", "Médio", "-" },
                    { 2, 127, "Ocicat", "Médio", "-" },
                    { 2, 126, "Norueguês da Floresta", "Médio", "-" },
                    { 2, 125, "Nebelung", "Médio", "-" },
                    { 2, 124, "Munchkin", "Médio", "-" },
                    { 2, 123, "Mist Australiano", "Médio", "-" }
                });

            migrationBuilder.InsertData(
                table: "Racas",
                columns: new[] { "IdEspecie", "IdRaca", "DescricaoRaca", "PorteRaca", "crRaca" },
                values: new object[,]
                {
                    { 2, 122, "Minskin", "Médio", "-" },
                    { 2, 121, "Mau egípcio", "Médio", "-" },
                    { 2, 120, "Mau Árabe", "Médio", "-" },
                    { 2, 119, "Manx", "Médio", "-" },
                    { 2, 118, "Maine Coon", "Médio", "-" },
                    { 2, 117, "Lykoi", "Médio", "-" },
                    { 2, 116, "Levkoy ucraniano", "Médio", "-" },
                    { 2, 115, "LaPerml", "Médio", "-" },
                    { 2, 114, "Kurilian Bobtail", "Médio", "-" },
                    { 2, 113, "Khao Manee", "Médio", "-" },
                    { 2, 112, "Korat", "Médio", "-" },
                    { 2, 111, "Javanês", "Médio", "-" },
                    { 2, 110, "Himalaio", "Médio", "-" },
                    { 2, 109, "Havana marrom", "Médio", "-" },
                    { 2, 108, "Gato Siberiano", "Médio", "-" },
                    { 2, 107, "Gato asiático", "Médio", "-" },
                    { 2, 106, "Exótico", "Médio", "-" },
                    { 2, 105, "Gato do Chipre", "Médio", "-" },
                    { 2, 104, "Gato-de-Bengala", "Médio", "-" },
                    { 2, 103, "Egeu", "Médio", "-" },
                    { 2, 102, "Dragon Li", "Médio", "-" },
                    { 2, 101, "Donskoy", "Médio", "-" },
                    { 2, 66, "Scottish Fold", "Médio", "-" },
                    { 2, 65, "Savannah", "Médio", "-" },
                    { 2, 70, "Singapura", "Médio", "-" },
                    { 2, 63, "Rex Alemão", "Médio", "-" },
                    { 1, 29, "Maltês", "Médio", "Gentil, brincalhão e afetuoso" },
                    { 1, 28, "Lulu da pomerânia", "Médio", "Animado, inteligente e cheio de personalidade" },
                    { 1, 27, "Lhasa apso", "Médio", "Esperto, confiante e independente" },
                    { 2, 64, "Sagrado da Birmânia", "Médio", "-" },
                    { 1, 25, "Jack russell terrier", "Médio", "Amigável, atlético e alerta" },
                    { 1, 24, "Husky siberiano", "Médio", "Amigável, trabalhador e extrovertido" },
                    { 1, 23, "Golden retriever", "Alto", "Inteligente, brincalhão e leal" },
                    { 1, 22, "Fila brasileiro", "Baixo", "Companheiro, corajoso e amoroso" },
                    { 1, 21, "Dogue alemão", "Alto", "Amigável, paciente e dócil" },
                    { 1, 20, "Dogo argentino", "Médio", "Leal, confiável e corajoso" },
                    { 1, 19, "Doberman", "Médio", "Inteligente, leal e protetor" },
                    { 1, 18, "Dálmata", "Médio", "Atlético, protetor e amável" },
                    { 1, 17, "Dachshund", "Médio", "Corajoso, animado e inteligente" },
                    { 1, 16, "Cocker spaniel inglês", "Alto", "Alegre, carinhoso e cheio de vida" },
                    { 1, 15, "Chow chow", "Alto", "Calmo, leal e orgulhoso" },
                    { 1, 14, "Chihuahua", "Médio", "Charmoso, animado e atrevido" }
                });

            migrationBuilder.InsertData(
                table: "Racas",
                columns: new[] { "IdEspecie", "IdRaca", "DescricaoRaca", "PorteRaca", "crRaca" },
                values: new object[,]
                {
                    { 1, 13, "Cavalier king charles spaniel", "Alto", "Companheiro, alegre e afetuoso" },
                    { 1, 12, "Cane corso", "Baixo", "Protetor, leal e inteligente" },
                    { 1, 11, "Bull terrier", "Médio", "Travesso, brincalhão e leal" },
                    { 1, 10, "Buldogue inglês", "Alto", "Calmo, divertido e dócil" },
                    { 1, 9, "Buldogue francês", "Alto", "Carinhoso, leal e brincalhão" },
                    { 1, 8, "Boxer", "Alto", "Leal, afetuoso e brincalhão" },
                    { 1, 7, "Boston terrier", "Médio", "Amigável, inteligente e vivaz" },
                    { 1, 6, "Border collie", "Alto", "Inteligente, leal e cheio de energia" },
                    { 1, 5, "Boiadeiro australiano", "Médio", "Alerta, curioso e leal" },
                    { 1, 4, "Bichon frisé", "Médio", "Brincalhão, curioso e afetivo" },
                    { 1, 3, "Beagle", "Médio", "Alegre, companheiro e aventureiro" },
                    { 1, 2, "Basset hound", "Alto", "Paciente, teimoso e charmoso" },
                    { 1, 1, "Akita", "Alto", "Leal, amigo e brincalhão" },
                    { 1, 30, "Mastiff inglês", "Alto", "Calmo, amável e leal" },
                    { 1, 31, "Mastim tibetano", "Alto", "Independente, reservado e inteligente" },
                    { 1, 26, "Labrador retriever", "Médio", "Inteligente, carinhoso e brincalhão" },
                    { 1, 33, "Pastor australiano", "Alto", "Esperto, trabalhador e exuberante" },
                    { 2, 62, "Ragdoll", "Médio", "-" },
                    { 2, 61, "Ragamuffin", "Médio", "-" },
                    { 2, 60, "Raas", "Médio", "-" },
                    { 2, 59, "Pixie-bob", "Médio", "-" },
                    { 2, 58, "Peterbald", "Médio", "-" },
                    { 2, 57, "Persa", "Médio", "-" },
                    { 2, 56, "Pelo longo Oriental", "Médio", "-" },
                    { 2, 55, "Pelo curto Oriental", "Médio", "-" },
                    { 1, 32, "Pastor alemão", "Alto", "Confiante, corajoso e inteligente" },
                    { 2, 53, "Pelo curto inglês", "Médio", "-" },
                    { 2, 52, "Pelo curto Europeu", "Médio", "-" },
                    { 2, 51, "Pelo curto brasileiro", "Médio", "-" },
                    { 2, 50, "Pelo curto americano", "Médio", "-" },
                    { 2, 49, "Oregon Rex", "Médio", "-" },
                    { 2, 54, "Pelo longo Inglês", "Médio", "-" },
                    { 1, 47, "Yorkshire", "Médio", "Destemido, carinhoso e cheio de energia" },
                    { 1, 34, "Pastor de Shetland", "Médio", "Brincalhão, energético e esperto" },
                    { 2, 48, "Ojos Azules", "Médio", "-" },
                    { 1, 36, "Pinscher", "Médio", "Brincalhão, carinhoso e protetor" },
                    { 1, 37, "Pit bull", "Médio", "Inteligente, forte e leal" },
                    { 1, 38, "Poodle", "Médio", "Orgulhoso, ativo e inteligente" },
                    { 1, 39, "Pug", "Alto", "Amoroso, temperamental e companheiro" },
                    { 1, 35, "Pequinês", "Médio", "Afetuoso, leal e elegante" },
                    { 1, 41, "Schnauzer", "Médio", "Dócil, leal e companheiro" },
                    { 1, 42, "Shar-pei", "Alto", "Amoroso, companheiro e brincalhão" }
                });

            migrationBuilder.InsertData(
                table: "Racas",
                columns: new[] { "IdEspecie", "IdRaca", "DescricaoRaca", "PorteRaca", "crRaca" },
                values: new object[,]
                {
                    { 1, 43, "Shiba", "Baixo", "Independente, leal e alerta" },
                    { 1, 44, "Shih tzu", "Médio", "Carinhoso, brincalhão e encantador" },
                    { 1, 45, "Staffordshire bull terrier", "Médio", "Inteligente, corajoso e determinado" },
                    { 1, 46, "Weimaraner", "Baixo", "Amigável, corajoso e independente" },
                    { 1, 40, "Rottweiler", "Alto", "Protetor, leal e inteligente" }
                });

            migrationBuilder.InsertData(
                table: "Sexos",
                columns: new[] { "IdSexo", "DescricaoSexo" },
                values: new object[,]
                {
                    { 1, "Macho" },
                    { 2, "Femea" }
                });

            migrationBuilder.InsertData(
                table: "Situacao",
                columns: new[] { "DescricaoSituacao", "IdSituacao" },
                values: new object[,]
                {
                    { "Para adoção", 4 },
                    { "Falecido", 3 },
                    { "Ativo", 1 },
                    { "Desaparecido", 2 }
                });

            migrationBuilder.InsertData(
                table: "Vacina",
                columns: new[] { "IdVacina", "DescriacaoVacina", "IdEspecie", "doseVacina", "intervaloVacina" },
                values: new object[,]
                {
                    { 6, "Quádrupla Felina", 2, 3, 4 },
                    { 1, "V8", 1, 3, 1 },
                    { 2, "V10", 1, 3, 1 },
                    { 3, "Gripe Canina", 1, 2, 1 },
                    { 4, "Giardíase", 1, 2, 1 },
                    { 5, "Anti-Rábica", 1, 1, 12 },
                    { 7, "Anti-Rábica", 2, 1, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_EspecieIdEspecie",
                table: "Animal",
                column: "EspecieIdEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_RacasIdRaca_RacasIdEspecie",
                table: "Animal",
                columns: new[] { "RacasIdRaca", "RacasIdEspecie" });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_SexosIdSexo",
                table: "Animal",
                column: "SexosIdSexo");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_SituacaoIdSituacao_SituacaoDescricaoSituacao",
                table: "Animal",
                columns: new[] { "SituacaoIdSituacao", "SituacaoDescricaoSituacao" });

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraVacina_AnimalIdAnimal",
                table: "CarteiraVacina",
                column: "AnimalIdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Tutor_PerfilIdCodigo",
                table: "Tutor",
                column: "PerfilIdCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarteiraVacina");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Tutor");

            migrationBuilder.DropTable(
                name: "TutorAnimal");

            migrationBuilder.DropTable(
                name: "Vacina");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Especie");

            migrationBuilder.DropTable(
                name: "Racas");

            migrationBuilder.DropTable(
                name: "Sexos");

            migrationBuilder.DropTable(
                name: "Situacao");
        }
    }
}
