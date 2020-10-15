USE [SquUSE [SquareEnixTest]
GO

/****** Object:  Table [dbo].[PlatformGames]    Script Date: 15/10/2020 01:11:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlatformGames](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlatformId] [int] NULL,
	[GameId] [int] NULL,
 CONSTRAINT [PK_PlatformGames] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PlatformGames]  WITH CHECK ADD  CONSTRAINT [FK_PlatformGames_Game] FOREIGN KEY([GameId])
REFERENCES [dbo].[Game] ([Id])
GO

ALTER TABLE [dbo].[PlatformGames] CHECK CONSTRAINT [FK_PlatformGames_Game]
GO

ALTER TABLE [dbo].[PlatformGames]  WITH CHECK ADD  CONSTRAINT [FK_PlatformGames_Platform] FOREIGN KEY([PlatformId])
REFERENCES [dbo].[Platform] ([Id])
GO

ALTER TABLE [dbo].[PlatformGames] CHECK CONSTRAINT [FK_PlatformGames_Platform]
GO


