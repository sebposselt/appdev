CREATE TABLE [dbo].[LFGdb] (
    [Username]        VARCHAR(50)     CONSTRAINT [DF_LFGdb_id] DEFAULT (CONVERT([nvarchar](255),newid(),(0))) NOT NULL,
    [Region] VARCHAR(50)  NOT NULL,
    [Language] VARCHAR(50) NOT NULL,
    [Age]   INT         NOT NULL,
    [ProfileText]   VARCHAR(100)                 NULL,
    [SteamTag] VARCHAR(50) NULL, 
    [XboxLiveTag] VARCHAR(50) NULL, 
    [DiscordTag] VARCHAR(50) NULL, 
    [PSNTag] VARCHAR(50) NULL, 
    [Game1] VARCHAR(50) NOT NULL, 
    [Game2] VARCHAR(50) NULL, 
    [Game3] VARCHAR(50) NULL, 
    [Game4] VARCHAR(50) NULL, 
    [Game5] VARCHAR(50) NULL, 
    PRIMARY KEY NONCLUSTERED ([Username] ASC)
);


GO
CREATE CLUSTERED INDEX [createdAt]
    ON [dbo].[LFGdb]([Username] ASC);


GO
CREATE TRIGGER [TR_LFGdb_InsertUpdateDelete] ON [dbo].[LFGdb]
		   AFTER INSERT, UPDATE, DELETE
		AS
		BEGIN
			SET NOCOUNT ON;
			IF TRIGGER_NESTLEVEL() > 3 RETURN;

			UPDATE [dbo].[LFGdb] SET [dbo].[LFGdb].[Language] = CONVERT (DATETIMEOFFSET(3), SYSUTCDATETIME())
			FROM INSERTED
			WHERE INSERTED.[Username] = [dbo].[LFGdb].[Username]
		END