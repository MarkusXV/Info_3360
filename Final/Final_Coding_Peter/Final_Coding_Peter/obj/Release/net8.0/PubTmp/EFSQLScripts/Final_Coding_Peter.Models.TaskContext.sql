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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428185851_initial'
)
BEGIN
    CREATE TABLE [Workers] (
        [WorkerID] int NOT NULL IDENTITY,
        [Firstname] nvarchar(max) NULL,
        [Lastname] nvarchar(max) NULL,
        [Position] nvarchar(max) NULL,
        CONSTRAINT [PK_Workers] PRIMARY KEY ([WorkerID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428185851_initial'
)
BEGIN
    CREATE TABLE [Tasks] (
        [TaskId] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [DueDate] datetime2 NOT NULL,
        [Status] nvarchar(max) NULL,
        [WorkerID] int NOT NULL,
        CONSTRAINT [PK_Tasks] PRIMARY KEY ([TaskId]),
        CONSTRAINT [FK_Tasks_Workers_WorkerID] FOREIGN KEY ([WorkerID]) REFERENCES [Workers] ([WorkerID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428185851_initial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'WorkerID', N'Firstname', N'Lastname', N'Position') AND [object_id] = OBJECT_ID(N'[Workers]'))
        SET IDENTITY_INSERT [Workers] ON;
    EXEC(N'INSERT INTO [Workers] ([WorkerID], [Firstname], [Lastname], [Position])
    VALUES (1, N''Fred'', N''Ballard'', N''Accountant''),
    (2, N''Ester'', N''Frederick'', N''HR''),
    (3, N''Bruce'', N''Ford'', N''CEO'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'WorkerID', N'Firstname', N'Lastname', N'Position') AND [object_id] = OBJECT_ID(N'[Workers]'))
        SET IDENTITY_INSERT [Workers] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428185851_initial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TaskId', N'Description', N'DueDate', N'Status', N'Title', N'WorkerID') AND [object_id] = OBJECT_ID(N'[Tasks]'))
        SET IDENTITY_INSERT [Tasks] ON;
    EXEC(N'INSERT INTO [Tasks] ([TaskId], [Description], [DueDate], [Status], [Title], [WorkerID])
    VALUES (1, N''We need to hire 3 new people for our support staff.'', ''2024-05-01T00:00:00.0000000'', N''Pending'', N''Hire new personnel'', 2),
    (2, N''File Taxes for last year'', ''2024-04-15T00:00:00.0000000'', N''Past Due'', N''Finish Taxes'', 1),
    (3, N''Board Meeting needs to be conducted at the end of the Quarter'', ''2024-06-30T00:00:00.0000000'', N''Upcoming'', N''Have a Board Meeting'', 3)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TaskId', N'Description', N'DueDate', N'Status', N'Title', N'WorkerID') AND [object_id] = OBJECT_ID(N'[Tasks]'))
        SET IDENTITY_INSERT [Tasks] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428185851_initial'
)
BEGIN
    CREATE INDEX [IX_Tasks_WorkerID] ON [Tasks] ([WorkerID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428185851_initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240428185851_initial', N'8.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428194913_new_column'
)
BEGIN
    ALTER TABLE [Tasks] DROP CONSTRAINT [FK_Tasks_Workers_WorkerID];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428194913_new_column'
)
BEGIN
    DROP TABLE [Workers];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428194913_new_column'
)
BEGIN
    DROP INDEX [IX_Tasks_WorkerID] ON [Tasks];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428194913_new_column'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tasks]') AND [c].[name] = N'WorkerID');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Tasks] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Tasks] DROP COLUMN [WorkerID];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428194913_new_column'
)
BEGIN
    ALTER TABLE [Tasks] ADD [WorkerName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428194913_new_column'
)
BEGIN
    EXEC(N'UPDATE [Tasks] SET [WorkerName] = N''Ester''
    WHERE [TaskId] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428194913_new_column'
)
BEGIN
    EXEC(N'UPDATE [Tasks] SET [WorkerName] = N''Fred''
    WHERE [TaskId] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428194913_new_column'
)
BEGIN
    EXEC(N'UPDATE [Tasks] SET [WorkerName] = N''Bruce''
    WHERE [TaskId] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240428194913_new_column'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240428194913_new_column', N'8.0.4');
END;
GO

COMMIT;
GO

