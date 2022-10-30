CREATE TABLE [Performers] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(20) NOT NULL,
    [LastName] nvarchar(20) NOT NULL,
    [Age] int NOT NULL,
    [NetWorth] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Performers] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Producers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(30) NOT NULL,
    [Pseudonym] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    CONSTRAINT [PK_Producers] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Writers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(20) NOT NULL,
    [Pseudonym] nvarchar(max) NULL,
    CONSTRAINT [PK_Writers] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Albums] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(40) NOT NULL,
    [ReleaseDate] datetime2 NOT NULL,
    [ProducerId] int NULL,
    CONSTRAINT [PK_Albums] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Albums_Producers_ProducerId] FOREIGN KEY ([ProducerId]) REFERENCES [Producers] ([Id]) ON DELETE NO ACTION
);
GO


CREATE TABLE [Songs] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(20) NOT NULL,
    [Duration] time NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [Genre] int NOT NULL,
    [AlbumId] int NULL,
    [WriterId] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Songs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Songs_Albums_AlbumId] FOREIGN KEY ([AlbumId]) REFERENCES [Albums] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Songs_Writers_WriterId] FOREIGN KEY ([WriterId]) REFERENCES [Writers] ([Id]) ON DELETE NO ACTION
);
GO


CREATE TABLE [SongsPerformers] (
    [SongId] int NOT NULL,
    [PerformerId] int NOT NULL,
    CONSTRAINT [PK_SongsPerformers] PRIMARY KEY ([SongId], [PerformerId]),
    CONSTRAINT [FK_SongsPerformers_Performers_PerformerId] FOREIGN KEY ([PerformerId]) REFERENCES [Performers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SongsPerformers_Songs_SongId] FOREIGN KEY ([SongId]) REFERENCES [Songs] ([Id]) ON DELETE NO ACTION
);
GO


CREATE INDEX [IX_Albums_ProducerId] ON [Albums] ([ProducerId]);
GO


CREATE INDEX [IX_Songs_AlbumId] ON [Songs] ([AlbumId]);
GO


CREATE INDEX [IX_Songs_WriterId] ON [Songs] ([WriterId]);
GO


CREATE INDEX [IX_SongsPerformers_PerformerId] ON [SongsPerformers] ([PerformerId]);
GO


