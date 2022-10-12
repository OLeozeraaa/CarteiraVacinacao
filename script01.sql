IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Especie] (
    [IdEspecie] int NOT NULL IDENTITY,
    [EspecieAnimal] nvarchar(max) NULL,
    [GrupoAnimal] nvarchar(max) NULL,
    CONSTRAINT [PK_Especie] PRIMARY KEY ([IdEspecie])
);
GO

CREATE TABLE [Login] (
    [PasswordHash] nvarchar(450) NOT NULL,
    [username] nvarchar(max) NULL,
    [PasswordString] nvarchar(max) NULL,
    [PasswordSalt] nvarchar(max) NULL,
    CONSTRAINT [PK_Login] PRIMARY KEY ([PasswordHash])
);
GO

CREATE TABLE [Perfil] (
    [IdCodigo] int NOT NULL IDENTITY,
    [descricao] nvarchar(max) NULL,
    CONSTRAINT [PK_Perfil] PRIMARY KEY ([IdCodigo])
);
GO

CREATE TABLE [Racas] (
    [IdRaca] int NOT NULL,
    [IdEspecie] int NOT NULL,
    [DescricaoRaca] nvarchar(max) NULL,
    [PorteRaca] nvarchar(max) NULL,
    [crRaca] nvarchar(max) NULL,
    CONSTRAINT [PK_Racas] PRIMARY KEY ([IdRaca], [IdEspecie])
);
GO

CREATE TABLE [Sexos] (
    [IdSexo] int NOT NULL IDENTITY,
    [DescricaoSexo] nvarchar(max) NULL,
    CONSTRAINT [PK_Sexos] PRIMARY KEY ([IdSexo])
);
GO

CREATE TABLE [Situacao] (
    [IdSituacao] int NOT NULL,
    [DescricaoSituacao] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Situacao] PRIMARY KEY ([IdSituacao], [DescricaoSituacao])
);
GO

CREATE TABLE [TutorAnimal] (
    [IdTutor] int NOT NULL,
    [IdAnimal] int NOT NULL,
    [dataInicio] datetime2 NOT NULL,
    CONSTRAINT [PK_TutorAnimal] PRIMARY KEY ([IdTutor], [IdAnimal])
);
GO

CREATE TABLE [Vacina] (
    [IdVacina] int NOT NULL IDENTITY,
    [DescriacaoVacina] nvarchar(max) NULL,
    [IdEspecie] int NOT NULL,
    [doseVacina] int NOT NULL,
    [intervaloVacina] int NOT NULL,
    CONSTRAINT [PK_Vacina] PRIMARY KEY ([IdVacina])
);
GO

CREATE TABLE [Tutor] (
    [IdTutor] int NOT NULL IDENTITY,
    [cpfTutor] int NOT NULL,
    [NomeTutor] nvarchar(max) NULL,
    [EnderecoTutor] nvarchar(max) NULL,
    [NumeroTutor] int NOT NULL,
    [ComplementoTutor] nvarchar(max) NULL,
    [BairroTutor] nvarchar(max) NULL,
    [MunicipioTutor] nvarchar(max) NULL,
    [ufTutor] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [crm] int NOT NULL,
    [PerfilIdCodigo] int NULL,
    CONSTRAINT [PK_Tutor] PRIMARY KEY ([IdTutor]),
    CONSTRAINT [FK_Tutor_Perfil_PerfilIdCodigo] FOREIGN KEY ([PerfilIdCodigo]) REFERENCES [Perfil] ([IdCodigo]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Animal] (
    [IdAnimal] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [EspecieIdEspecie] int NULL,
    [RacasIdRaca] int NULL,
    [RacasIdEspecie] int NULL,
    [SexosIdSexo] int NULL,
    [dtNascimento] datetime2 NOT NULL,
    [Pelagem] nvarchar(max) NULL,
    [SituacaoIdSituacao] int NULL,
    [SituacaoDescricaoSituacao] nvarchar(450) NULL,
    [IdRGA] int NOT NULL,
    [peso] real NOT NULL,
    CONSTRAINT [PK_Animal] PRIMARY KEY ([IdAnimal]),
    CONSTRAINT [FK_Animal_Especie_EspecieIdEspecie] FOREIGN KEY ([EspecieIdEspecie]) REFERENCES [Especie] ([IdEspecie]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Animal_Racas_RacasIdRaca_RacasIdEspecie] FOREIGN KEY ([RacasIdRaca], [RacasIdEspecie]) REFERENCES [Racas] ([IdRaca], [IdEspecie]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Animal_Sexos_SexosIdSexo] FOREIGN KEY ([SexosIdSexo]) REFERENCES [Sexos] ([IdSexo]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Animal_Situacao_SituacaoIdSituacao_SituacaoDescricaoSituacao] FOREIGN KEY ([SituacaoIdSituacao], [SituacaoDescricaoSituacao]) REFERENCES [Situacao] ([IdSituacao], [DescricaoSituacao]) ON DELETE NO ACTION
);
GO

CREATE TABLE [CarteiraVacina] (
    [IdCarteira] int NOT NULL IDENTITY,
    [dataVacina] datetime2 NOT NULL,
    [Medicamento] nvarchar(max) NULL,
    [TipoVacina] nvarchar(max) NULL,
    [AnimalIdAnimal] int NULL,
    [ProxVacina] datetime2 NOT NULL,
    CONSTRAINT [PK_CarteiraVacina] PRIMARY KEY ([IdCarteira]),
    CONSTRAINT [FK_CarteiraVacina_Animal_AnimalIdAnimal] FOREIGN KEY ([AnimalIdAnimal]) REFERENCES [Animal] ([IdAnimal]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEspecie', N'EspecieAnimal', N'GrupoAnimal') AND [object_id] = OBJECT_ID(N'[Especie]'))
    SET IDENTITY_INSERT [Especie] ON;
INSERT INTO [Especie] ([IdEspecie], [EspecieAnimal], [GrupoAnimal])
VALUES (1, N'Cachorro', N'Canina'),
(2, N'Gato', N'Felinos');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEspecie', N'EspecieAnimal', N'GrupoAnimal') AND [object_id] = OBJECT_ID(N'[Especie]'))
    SET IDENTITY_INSERT [Especie] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEspecie', N'IdRaca', N'DescricaoRaca', N'PorteRaca', N'crRaca') AND [object_id] = OBJECT_ID(N'[Racas]'))
    SET IDENTITY_INSERT [Racas] ON;
INSERT INTO [Racas] ([IdEspecie], [IdRaca], [DescricaoRaca], [PorteRaca], [crRaca])
VALUES (2, 96, N'Chausie', N'Médio', N'-'),
(2, 95, N'Chartreux', N'Médio', N'-'),
(2, 94, N'Cingapura', N'Médio', N'-'),
(2, 93, N'California Spangled', N'Médio', N'-'),
(2, 92, N'Burmila', N'Médio', N'-'),
(2, 91, N'Burmês', N'Médio', N'-'),
(2, 90, N'Bombaim', N'Médio', N'-'),
(2, 89, N'Bobtail japonês', N'Médio', N'-'),
(2, 88, N'Bobtail americano', N'Médio', N'-'),
(2, 87, N'Bicolor Oriental', N'Médio', N'-'),
(2, 86, N'Bambino', N'Médio', N'-'),
(2, 85, N'Balinês', N'Médio', N'-'),
(2, 84, N'Azul Russo', N'Médio', N'-'),
(2, 83, N'Asiático de Pelo Semi-Longo', N'Médio', N'-'),
(2, 82, N'Manx de pelo longo', N'Médio', N'-'),
(2, 81, N'Wirehair Americano', N'Médio', N'-'),
(2, 80, N'Van Turco', N'Médio', N'-'),
(2, 79, N'Toyger', N'Médio', N'-'),
(2, 78, N'Tonquinês', N'Médio', N'-'),
(2, 77, N'Tiffany-Chantilly', N'Médio', N'-'),
(2, 76, N'Thai', N'Médio', N'-'),
(2, 75, N'Suphalak', N'Médio', N'-'),
(2, 74, N'Sphynx', N'Médio', N'-'),
(2, 73, N'Somali', N'Médio', N'-'),
(2, 72, N'Sokoke', N'Médio', N'-'),
(2, 71, N'Snowshoe', N'Médio', N'-'),
(2, 69, N'Siamês', N'Médio', N'-'),
(2, 68, N'Serengeti', N'Médio', N'-'),
(2, 67, N'Selkirk Rex', N'Médio', N'-'),
(2, 97, N'Colorpoint de pelo curto', N'Médio', N'-'),
(2, 98, N'Cornish Rex', N'Médio', N'-'),
(2, 99, N'Curl Americano', N'Médio', N'-'),
(2, 100, N'Devon Rex', N'Médio', N'-'),
(2, 129, N'Angorá turco', N'Médio', N'-'),
(2, 128, N'Abissínio', N'Médio', N'-'),
(2, 127, N'Ocicat', N'Médio', N'-'),
(2, 126, N'Norueguês da Floresta', N'Médio', N'-'),
(2, 125, N'Nebelung', N'Médio', N'-'),
(2, 124, N'Munchkin', N'Médio', N'-'),
(2, 123, N'Mist Australiano', N'Médio', N'-');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEspecie', N'IdRaca', N'DescricaoRaca', N'PorteRaca', N'crRaca') AND [object_id] = OBJECT_ID(N'[Racas]'))
    SET IDENTITY_INSERT [Racas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEspecie', N'IdRaca', N'DescricaoRaca', N'PorteRaca', N'crRaca') AND [object_id] = OBJECT_ID(N'[Racas]'))
    SET IDENTITY_INSERT [Racas] ON;
INSERT INTO [Racas] ([IdEspecie], [IdRaca], [DescricaoRaca], [PorteRaca], [crRaca])
VALUES (2, 122, N'Minskin', N'Médio', N'-'),
(2, 121, N'Mau egípcio', N'Médio', N'-'),
(2, 120, N'Mau Árabe', N'Médio', N'-'),
(2, 119, N'Manx', N'Médio', N'-'),
(2, 118, N'Maine Coon', N'Médio', N'-'),
(2, 117, N'Lykoi', N'Médio', N'-'),
(2, 116, N'Levkoy ucraniano', N'Médio', N'-'),
(2, 115, N'LaPerml', N'Médio', N'-'),
(2, 114, N'Kurilian Bobtail', N'Médio', N'-'),
(2, 113, N'Khao Manee', N'Médio', N'-'),
(2, 112, N'Korat', N'Médio', N'-'),
(2, 111, N'Javanês', N'Médio', N'-'),
(2, 110, N'Himalaio', N'Médio', N'-'),
(2, 109, N'Havana marrom', N'Médio', N'-'),
(2, 108, N'Gato Siberiano', N'Médio', N'-'),
(2, 107, N'Gato asiático', N'Médio', N'-'),
(2, 106, N'Exótico', N'Médio', N'-'),
(2, 105, N'Gato do Chipre', N'Médio', N'-'),
(2, 104, N'Gato-de-Bengala', N'Médio', N'-'),
(2, 103, N'Egeu', N'Médio', N'-'),
(2, 102, N'Dragon Li', N'Médio', N'-'),
(2, 101, N'Donskoy', N'Médio', N'-'),
(2, 66, N'Scottish Fold', N'Médio', N'-'),
(2, 65, N'Savannah', N'Médio', N'-'),
(2, 70, N'Singapura', N'Médio', N'-'),
(2, 63, N'Rex Alemão', N'Médio', N'-'),
(1, 29, N'Maltês', N'Médio', N'Gentil, brincalhão e afetuoso'),
(1, 28, N'Lulu da pomerânia', N'Médio', N'Animado, inteligente e cheio de personalidade'),
(1, 27, N'Lhasa apso', N'Médio', N'Esperto, confiante e independente'),
(2, 64, N'Sagrado da Birmânia', N'Médio', N'-'),
(1, 25, N'Jack russell terrier', N'Médio', N'Amigável, atlético e alerta'),
(1, 24, N'Husky siberiano', N'Médio', N'Amigável, trabalhador e extrovertido'),
(1, 23, N'Golden retriever', N'Alto', N'Inteligente, brincalhão e leal'),
(1, 22, N'Fila brasileiro', N'Baixo', N'Companheiro, corajoso e amoroso'),
(1, 21, N'Dogue alemão', N'Alto', N'Amigável, paciente e dócil'),
(1, 20, N'Dogo argentino', N'Médio', N'Leal, confiável e corajoso'),
(1, 19, N'Doberman', N'Médio', N'Inteligente, leal e protetor'),
(1, 18, N'Dálmata', N'Médio', N'Atlético, protetor e amável'),
(1, 17, N'Dachshund', N'Médio', N'Corajoso, animado e inteligente'),
(1, 16, N'Cocker spaniel inglês', N'Alto', N'Alegre, carinhoso e cheio de vida'),
(1, 15, N'Chow chow', N'Alto', N'Calmo, leal e orgulhoso'),
(1, 14, N'Chihuahua', N'Médio', N'Charmoso, animado e atrevido');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEspecie', N'IdRaca', N'DescricaoRaca', N'PorteRaca', N'crRaca') AND [object_id] = OBJECT_ID(N'[Racas]'))
    SET IDENTITY_INSERT [Racas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEspecie', N'IdRaca', N'DescricaoRaca', N'PorteRaca', N'crRaca') AND [object_id] = OBJECT_ID(N'[Racas]'))
    SET IDENTITY_INSERT [Racas] ON;
INSERT INTO [Racas] ([IdEspecie], [IdRaca], [DescricaoRaca], [PorteRaca], [crRaca])
VALUES (1, 13, N'Cavalier king charles spaniel', N'Alto', N'Companheiro, alegre e afetuoso'),
(1, 12, N'Cane corso', N'Baixo', N'Protetor, leal e inteligente'),
(1, 11, N'Bull terrier', N'Médio', N'Travesso, brincalhão e leal'),
(1, 10, N'Buldogue inglês', N'Alto', N'Calmo, divertido e dócil'),
(1, 9, N'Buldogue francês', N'Alto', N'Carinhoso, leal e brincalhão'),
(1, 8, N'Boxer', N'Alto', N'Leal, afetuoso e brincalhão'),
(1, 7, N'Boston terrier', N'Médio', N'Amigável, inteligente e vivaz'),
(1, 6, N'Border collie', N'Alto', N'Inteligente, leal e cheio de energia'),
(1, 5, N'Boiadeiro australiano', N'Médio', N'Alerta, curioso e leal'),
(1, 4, N'Bichon frisé', N'Médio', N'Brincalhão, curioso e afetivo'),
(1, 3, N'Beagle', N'Médio', N'Alegre, companheiro e aventureiro'),
(1, 2, N'Basset hound', N'Alto', N'Paciente, teimoso e charmoso'),
(1, 1, N'Akita', N'Alto', N'Leal, amigo e brincalhão'),
(1, 30, N'Mastiff inglês', N'Alto', N'Calmo, amável e leal'),
(1, 31, N'Mastim tibetano', N'Alto', N'Independente, reservado e inteligente'),
(1, 26, N'Labrador retriever', N'Médio', N'Inteligente, carinhoso e brincalhão'),
(1, 33, N'Pastor australiano', N'Alto', N'Esperto, trabalhador e exuberante'),
(2, 62, N'Ragdoll', N'Médio', N'-'),
(2, 61, N'Ragamuffin', N'Médio', N'-'),
(2, 60, N'Raas', N'Médio', N'-'),
(2, 59, N'Pixie-bob', N'Médio', N'-'),
(2, 58, N'Peterbald', N'Médio', N'-'),
(2, 57, N'Persa', N'Médio', N'-'),
(2, 56, N'Pelo longo Oriental', N'Médio', N'-'),
(2, 55, N'Pelo curto Oriental', N'Médio', N'-'),
(1, 32, N'Pastor alemão', N'Alto', N'Confiante, corajoso e inteligente'),
(2, 53, N'Pelo curto inglês', N'Médio', N'-'),
(2, 52, N'Pelo curto Europeu', N'Médio', N'-'),
(2, 51, N'Pelo curto brasileiro', N'Médio', N'-'),
(2, 50, N'Pelo curto americano', N'Médio', N'-'),
(2, 49, N'Oregon Rex', N'Médio', N'-'),
(2, 54, N'Pelo longo Inglês', N'Médio', N'-'),
(1, 47, N'Yorkshire', N'Médio', N'Destemido, carinhoso e cheio de energia'),
(1, 34, N'Pastor de Shetland', N'Médio', N'Brincalhão, energético e esperto'),
(2, 48, N'Ojos Azules', N'Médio', N'-'),
(1, 36, N'Pinscher', N'Médio', N'Brincalhão, carinhoso e protetor'),
(1, 37, N'Pit bull', N'Médio', N'Inteligente, forte e leal'),
(1, 38, N'Poodle', N'Médio', N'Orgulhoso, ativo e inteligente'),
(1, 39, N'Pug', N'Alto', N'Amoroso, temperamental e companheiro'),
(1, 35, N'Pequinês', N'Médio', N'Afetuoso, leal e elegante'),
(1, 41, N'Schnauzer', N'Médio', N'Dócil, leal e companheiro'),
(1, 42, N'Shar-pei', N'Alto', N'Amoroso, companheiro e brincalhão');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEspecie', N'IdRaca', N'DescricaoRaca', N'PorteRaca', N'crRaca') AND [object_id] = OBJECT_ID(N'[Racas]'))
    SET IDENTITY_INSERT [Racas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEspecie', N'IdRaca', N'DescricaoRaca', N'PorteRaca', N'crRaca') AND [object_id] = OBJECT_ID(N'[Racas]'))
    SET IDENTITY_INSERT [Racas] ON;
INSERT INTO [Racas] ([IdEspecie], [IdRaca], [DescricaoRaca], [PorteRaca], [crRaca])
VALUES (1, 43, N'Shiba', N'Baixo', N'Independente, leal e alerta'),
(1, 44, N'Shih tzu', N'Médio', N'Carinhoso, brincalhão e encantador'),
(1, 45, N'Staffordshire bull terrier', N'Médio', N'Inteligente, corajoso e determinado'),
(1, 46, N'Weimaraner', N'Baixo', N'Amigável, corajoso e independente'),
(1, 40, N'Rottweiler', N'Alto', N'Protetor, leal e inteligente');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEspecie', N'IdRaca', N'DescricaoRaca', N'PorteRaca', N'crRaca') AND [object_id] = OBJECT_ID(N'[Racas]'))
    SET IDENTITY_INSERT [Racas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdSexo', N'DescricaoSexo') AND [object_id] = OBJECT_ID(N'[Sexos]'))
    SET IDENTITY_INSERT [Sexos] ON;
INSERT INTO [Sexos] ([IdSexo], [DescricaoSexo])
VALUES (1, N'Macho'),
(2, N'Femea');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdSexo', N'DescricaoSexo') AND [object_id] = OBJECT_ID(N'[Sexos]'))
    SET IDENTITY_INSERT [Sexos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DescricaoSituacao', N'IdSituacao') AND [object_id] = OBJECT_ID(N'[Situacao]'))
    SET IDENTITY_INSERT [Situacao] ON;
INSERT INTO [Situacao] ([DescricaoSituacao], [IdSituacao])
VALUES (N'Para adoção', 4),
(N'Falecido', 3),
(N'Ativo', 1),
(N'Desaparecido', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DescricaoSituacao', N'IdSituacao') AND [object_id] = OBJECT_ID(N'[Situacao]'))
    SET IDENTITY_INSERT [Situacao] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdVacina', N'DescriacaoVacina', N'IdEspecie', N'doseVacina', N'intervaloVacina') AND [object_id] = OBJECT_ID(N'[Vacina]'))
    SET IDENTITY_INSERT [Vacina] ON;
INSERT INTO [Vacina] ([IdVacina], [DescriacaoVacina], [IdEspecie], [doseVacina], [intervaloVacina])
VALUES (6, N'Quádrupla Felina', 2, 3, 4),
(1, N'V8', 1, 3, 1),
(2, N'V10', 1, 3, 1),
(3, N'Gripe Canina', 1, 2, 1),
(4, N'Giardíase', 1, 2, 1),
(5, N'Anti-Rábica', 1, 1, 12),
(7, N'Anti-Rábica', 2, 1, 12);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdVacina', N'DescriacaoVacina', N'IdEspecie', N'doseVacina', N'intervaloVacina') AND [object_id] = OBJECT_ID(N'[Vacina]'))
    SET IDENTITY_INSERT [Vacina] OFF;
GO

CREATE INDEX [IX_Animal_EspecieIdEspecie] ON [Animal] ([EspecieIdEspecie]);
GO

CREATE INDEX [IX_Animal_RacasIdRaca_RacasIdEspecie] ON [Animal] ([RacasIdRaca], [RacasIdEspecie]);
GO

CREATE INDEX [IX_Animal_SexosIdSexo] ON [Animal] ([SexosIdSexo]);
GO

CREATE INDEX [IX_Animal_SituacaoIdSituacao_SituacaoDescricaoSituacao] ON [Animal] ([SituacaoIdSituacao], [SituacaoDescricaoSituacao]);
GO

CREATE INDEX [IX_CarteiraVacina_AnimalIdAnimal] ON [CarteiraVacina] ([AnimalIdAnimal]);
GO

CREATE INDEX [IX_Tutor_PerfilIdCodigo] ON [Tutor] ([PerfilIdCodigo]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221009023301_Initial', N'5.0.17');
GO

COMMIT;
GO

