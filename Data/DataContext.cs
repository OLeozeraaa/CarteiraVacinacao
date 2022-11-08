using System.Collections.Generic;
using carteiravacina.Models;
using CarteiraVacinacao.Models;
using Microsoft.EntityFrameworkCore;

namespace CarteiraVacina_BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Especie> Especie { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Racas> Racas { get; set; }
        public DbSet<Sexos> Sexos { get; set; }
        public DbSet<Situacao> Situacao { get; set; }
        public DbSet<Tutor> Tutor { get; set; }
        public DbSet<TutorAnimal> TutorAnimal { get; set; }
        //public DbSet<Vacina> Vacina { get; set; }
        public DbSet<Carteira> Carteira { get; set; }
        public DbSet<Vacina> Vacina { get; set; }
        public DbSet<RGA> RGA { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sexos>()
                .HasKey(SX => new { SX.idSexo });

            builder.Entity<Sexos>()
                .HasData(new List<Sexos>(){
                    new Sexos(1, "Macho"),
                    new Sexos(2, "Femea"),
                });
            
             builder.Entity<Especie>()
                .HasKey(ES => new { ES.IdEspecie });
                
            builder.Entity<Especie>()
                .HasData(new List<Especie>{
                    new Especie(1, "Cachorro", "Canina"),
                    new Especie(2, "Gato", "Felinos"),
                });
            
            builder.Entity<Racas>()
                .HasKey(RC => new { RC.idRaca, RC.idEspecie });

            builder.Entity<Racas>()
                .HasData(new List<Racas>(){
                    new Racas (  1,1,"Akita","Alto","Leal, amigo e brincalhão"),
                    new Racas (  2,1,"Basset hound","Alto","Paciente, teimoso e charmoso"),
                    new Racas (  3,1,"Beagle","Médio","Alegre, companheiro e aventureiro"),
                    new Racas (  4,1,"Bichon frisé","Médio","Brincalhão, curioso e afetivo"),
                    new Racas (  5,1,"Boiadeiro australiano","Médio","Alerta, curioso e leal"),
                    new Racas (  6,1,"Border collie","Alto","Inteligente, leal e cheio de energia"),
                    new Racas (  7,1,"Boston terrier","Médio","Amigável, inteligente e vivaz"),
                    new Racas (  8,1,"Boxer","Alto","Leal, afetuoso e brincalhão"),
                    new Racas (  9,1,"Buldogue francês","Alto","Carinhoso, leal e brincalhão"),
                    new Racas ( 10,1,"Buldogue inglês","Alto","Calmo, divertido e dócil"),
                    new Racas ( 11,1,"Bull terrier","Médio","Travesso, brincalhão e leal"),
                    new Racas ( 12,1,"Cane corso","Baixo","Protetor, leal e inteligente"),
                    new Racas ( 13,1,"Cavalier king charles spaniel","Alto","Companheiro, alegre e afetuoso"),
                    new Racas ( 14,1,"Chihuahua","Médio","Charmoso, animado e atrevido"),
                    new Racas( 15,1,"Chow chow","Alto","Calmo, leal e orgulhoso"),
                    new Racas ( 16,1,"Cocker spaniel inglês","Alto","Alegre, carinhoso e cheio de vida"),
                    new Racas ( 17,1,"Dachshund","Médio","Corajoso, animado e inteligente"),
                    new Racas ( 18,1,"Dálmata","Médio","Atlético, protetor e amável"),
                    new Racas ( 19,1,"Doberman","Médio","Inteligente, leal e protetor"),
                    new Racas ( 20,1,"Dogo argentino","Médio","Leal, confiável e corajoso"),
                    new Racas ( 21,1,"Dogue alemão","Alto","Amigável, paciente e dócil"),
                    new Racas ( 22,1,"Fila brasileiro","Baixo","Companheiro, corajoso e amoroso"),
                    new Racas ( 23,1,"Golden retriever","Alto","Inteligente, brincalhão e leal"),
                    new Racas ( 24,1,"Husky siberiano","Médio","Amigável, trabalhador e extrovertido"),
                    new Racas ( 25,1,"Jack russell terrier","Médio","Amigável, atlético e alerta"),
                    new Racas ( 26,1,"Labrador retriever","Médio","Inteligente, carinhoso e brincalhão"),
                    new Racas ( 27,1,"Lhasa apso","Médio","Esperto, confiante e independente"),
                    new Racas ( 28,1,"Lulu da pomerânia","Médio","Animado, inteligente e cheio de personalidade"),
                    new Racas ( 29,1,"Maltês","Médio","Gentil, brincalhão e afetuoso"),
                    new Racas ( 30,1,"Mastiff inglês","Alto","Calmo, amável e leal"),
                    new Racas (31,1,"Mastim tibetano","Alto","Independente, reservado e inteligente"),
                    new Racas ( 32,1,"Pastor alemão","Alto","Confiante, corajoso e inteligente"),
                    new Racas ( 33,1,"Pastor australiano","Alto","Esperto, trabalhador e exuberante"),
                    new Racas ( 34,1,"Pastor de Shetland","Médio","Brincalhão, energético e esperto"),
                    new Racas ( 35,1,"Pequinês","Médio","Afetuoso, leal e elegante"),
                    new Racas ( 36,1,"Pinscher","Médio","Brincalhão, carinhoso e protetor"),
                    new Racas ( 37,1,"Pit bull","Médio","Inteligente, forte e leal"),
                    new Racas ( 38,1,"Poodle","Médio","Orgulhoso, ativo e inteligente"),
                    new Racas ( 39,1,"Pug","Alto","Amoroso, temperamental e companheiro"),
                    new Racas ( 40,1,"Rottweiler","Alto","Protetor, leal e inteligente"),
                    new Racas ( 41,1,"Schnauzer","Médio","Dócil, leal e companheiro"),
                    new Racas ( 42,1,"Shar-pei","Alto","Amoroso, companheiro e brincalhão"),
                    new Racas ( 43,1,"Shiba","Baixo","Independente, leal e alerta"),
                    new Racas ( 44,1,"Shih tzu","Médio","Carinhoso, brincalhão e encantador"),
                    new Racas ( 45,1,"Staffordshire bull terrier","Médio","Inteligente, corajoso e determinado"),
                    new Racas ( 46,1,"Weimaraner","Baixo","Amigável, corajoso e independente"),
                    new Racas ( 47,1,"Yorkshire","Médio","Destemido, carinhoso e cheio de energia"),
                    new Racas ( 48,2,"Ojos Azules","Médio","-"),
                    new Racas ( 49,2,"Oregon Rex","Médio","-"),
                    new Racas ( 50,2,"Pelo curto americano","Médio","-"),
                    new Racas ( 51,2,"Pelo curto brasileiro","Médio","-"),
                    new Racas ( 52,2,"Pelo curto Europeu","Médio","-"),
                    new Racas ( 53,2,"Pelo curto inglês","Médio","-"),
                    new Racas ( 54,2,"Pelo longo Inglês","Médio","-"),
                    new Racas ( 55,2,"Pelo curto Oriental","Médio","-"),
                    new Racas ( 56,2,"Pelo longo Oriental","Médio","-"),
                    new Racas ( 57,2,"Persa","Médio","-"),
                    new Racas ( 58,2,"Peterbald","Médio","-"),
                    new Racas ( 59,2,"Pixie-bob","Médio","-"),
                    new Racas ( 60,2,"Raas","Médio","-"),
                    new Racas ( 61,2,"Ragamuffin","Médio","-"),
                    new Racas ( 62,2,"Ragdoll","Médio","-"),
                    new Racas ( 63,2,"Rex Alemão","Médio","-"),
                    new Racas ( 64,2,"Sagrado da Birmânia","Médio","-"),
                    new Racas ( 65,2,"Savannah","Médio","-"),
                    new Racas ( 66,2,"Scottish Fold","Médio","-"),
                    new Racas ( 67,2,"Selkirk Rex","Médio","-"),
                    new Racas ( 68,2,"Serengeti","Médio","-"),
                    new Racas ( 69,2,"Siamês","Médio","-"),
                    new Racas ( 70,2,"Singapura","Médio","-"),
                    new Racas ( 71,2,"Snowshoe","Médio","-"),
                    new Racas ( 72,2,"Sokoke","Médio","-"),
                    new Racas ( 73,2,"Somali","Médio","-"),
                    new Racas ( 74,2,"Sphynx","Médio","-"),
                    new Racas ( 75,2,"Suphalak","Médio","-"),
                    new Racas ( 76,2,"Thai","Médio","-"),
                    new Racas ( 77,2,"Tiffany-Chantilly","Médio","-"),
                    new Racas ( 78,2,"Tonquinês","Médio","-"),
                    new Racas ( 79,2,"Toyger","Médio","-"),
                    new Racas ( 80,2,"Van Turco","Médio","-"),
                    new Racas ( 81,2,"Wirehair Americano","Médio","-"),
                    new Racas ( 82,2,"Manx de pelo longo","Médio","-"),
                    new Racas ( 83,2,"Asiático de Pelo Semi-Longo","Médio","-"),
                    new Racas ( 84,2,"Azul Russo","Médio","-"),
                    new Racas ( 85,2,"Balinês","Médio","-"),
                    new Racas ( 86,2,"Bambino","Médio","-"),
                    new Racas ( 87,2,"Bicolor Oriental","Médio","-"),
                    new Racas ( 88,2,"Bobtail americano","Médio","-"),
                    new Racas ( 89,2,"Bobtail japonês","Médio","-"),
                    new Racas ( 90,2,"Bombaim","Médio","-"),
                    new Racas ( 91,2,"Burmês","Médio","-"),
                    new Racas ( 92,2,"Burmila","Médio","-"),
                    new Racas ( 93,2,"California Spangled","Médio","-"),
                    new Racas ( 94,2,"Cingapura","Médio","-"),
                    new Racas ( 95,2,"Chartreux","Médio","-"),
                    new Racas ( 96,2,"Chausie","Médio","-"),
                    new Racas ( 97,2,"Colorpoint de pelo curto","Médio","-"),
                    new Racas ( 98,2,"Cornish Rex","Médio","-"),
                    new Racas ( 99,2,"Curl Americano","Médio","-"),
                    new Racas (100,2,"Devon Rex","Médio","-"),
                    new Racas (101,2,"Donskoy","Médio","-"),
                    new Racas (102,2,"Dragon Li","Médio","-"),
                    new Racas (103,2,"Egeu","Médio","-"),
                    new Racas (104,2,"Gato-de-Bengala","Médio","-"),
                    new Racas (105,2,"Gato do Chipre","Médio","-"),
                    new Racas (106,2,"Exótico","Médio","-"),
                    new Racas (107,2,"Gato asiático","Médio","-"),
                    new Racas (108,2,"Gato Siberiano","Médio","-"),
                    new Racas (109,2,"Havana marrom","Médio","-"),
                    new Racas (110,2,"Himalaio","Médio","-"),
                    new Racas (111,2,"Javanês","Médio","-"),
                    new Racas (112,2,"Korat","Médio","-"),
                    new Racas (113,2,"Khao Manee","Médio","-"),
                    new Racas (114,2,"Kurilian Bobtail","Médio","-"),
                    new Racas (115,2,"LaPerml","Médio","-"),
                    new Racas (116,2,"Levkoy ucraniano","Médio","-"),
                    new Racas (117,2,"Lykoi","Médio","-"),
                    new Racas (118,2,"Maine Coon","Médio","-"),
                    new Racas (119,2,"Manx","Médio","-"),
                    new Racas (120,2,"Mau Árabe","Médio","-"),
                    new Racas (121,2,"Mau egípcio","Médio","-"),
                    new Racas (122,2,"Minskin","Médio","-"),
                    new Racas (123,2,"Mist Australiano","Médio","-"),
                    new Racas (124,2,"Munchkin","Médio","-"),
                    new Racas (125,2,"Nebelung","Médio","-"),
                    new Racas (126,2,"Norueguês da Floresta","Médio","-"),
                    new Racas (127,2,"Ocicat","Médio","-"),
                    new Racas (128,2,"Abissínio","Médio","-"),
                    new Racas (129,2,"Angorá turco","Médio","-"),
                });

            builder.Entity<Situacao>()
            .HasKey(ST => new { ST.IdSituacao, ST.DescricaoSituacao });

            builder.Entity<Situacao>()
                .HasData(new List<Situacao>(){
                    new Situacao(1, "Ativo"),
                    new Situacao(2, "Desaparecido"),
                    new Situacao(3, "Falecido"),
                    new Situacao(4, "Para adoção"),
                });

                /* builder.Entity<Vacina>()
                .HasKey(VC => new { VC.IdVacina });

            builder.Entity<Vacina>()
                .HasData(new List<Vacina>(){
                    new Vacina (1,"V8",1,3,1),
                    new Vacina (2,"V10",1,3,1),
                    new Vacina (3,"Gripe Canina",1,2,1),
                    new Vacina (4,"Giardíase",1,2,1),
                    new Vacina (5,"Anti-Rábica",1,1,12),
                    new Vacina (6,"Quádrupla Felina",2,3,4),
                    new Vacina (7,"Anti-Rábica",2,1,12),
                }); */

                builder.Entity<Perfil>()
                .HasKey(PL => new { PL.IdCodigo });

                builder.Entity<Animal>()
                .HasKey(AN => new { AN.Id });

                builder.Entity<Tutor>()
                .HasKey(TT => new { TT.IdTutor });

                builder.Entity<TutorAnimal>()
                .HasKey(TA => new { TA.IdTutor, TA.IdAnimal });

                builder.Entity<Login>()
                .HasKey(LG => new { LG.Id });

                builder.Entity<Vacina>()
                .HasKey(VC => new { VC.IdVacina });

                builder.Entity<Vacina>()
                .HasData(new List<Vacina>(){
                    new Vacina (1,System.DateTime.Now,"V8",1,System.DateTime.Now),
                    new Vacina (2,System.DateTime.Now,"V10",1,System.DateTime.Now),
                    new Vacina (3,System.DateTime.Now,"Gripe Canina",1,System.DateTime.Now),
                    new Vacina (4,System.DateTime.Now,"Giardíase", 1 ,System.DateTime.Now),
                    new Vacina (5,System.DateTime.Now,"Anti-Rábica",2 ,System.DateTime.Now),
                    new Vacina (6,System.DateTime.Now,"Quádrupla Felina",2 ,System.DateTime.Now),
                    new Vacina (7,System.DateTime.Now,"Anti-Rábica",2 ,System.DateTime.Now)
                });

                builder.Entity<Carteira>()
                .HasKey(CT => new { CT.Id });

                /* builder.Entity<Carteira>()
                .HasData(new List<Carteira>(){
                    new Carteira(1,"Rosa"),
                    new Carteira(2,"Pipoca"),
                    new Carteira(3,"Mano")
                }); */

                builder.Entity<RGA>()
                .HasKey(RG => new { RG.IdRGA });
        }
    }
}