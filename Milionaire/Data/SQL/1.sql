USE [Milions]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 14.03.2018 20:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestContent] [nvarchar](max) NULL,
	[AnswerA] [nvarchar](max) NULL,
	[AnswerB] [nvarchar](max) NULL,
	[AnswerC] [nvarchar](max) NULL,
	[AnswerD] [nvarchar](max) NULL,
	[Correct] [char](1) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Questions] ON 

GO
INSERT [dbo].[Questions] ([Id], [QuestContent], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [Correct]) VALUES (1, N'W jakim mieście urodził się Mikołaj Kopernik?', N'Toruń', N'Przemyśl', N'Przeworsk', N'Białystok', N'a')
GO
INSERT [dbo].[Questions] ([Id], [QuestContent], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [Correct]) VALUES (2, N'W którym roku miała miejsce bitwa pod Grunwaldem?', N'1939', N'1914', N'1495', N'1410', N'd')
GO
INSERT [dbo].[Questions] ([Id], [QuestContent], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [Correct]) VALUES (3, N'Który z wymienionych koszykarzy został najmłodszym MVP w historii NBA?', N'LeBron James', N'Michael Jordan', N'Wit Chamberlain', N'Derrick Rose', N'd')
GO
INSERT [dbo].[Questions] ([Id], [QuestContent], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [Correct]) VALUES (4, N'Gdzie rozgrywa się akcja serialu "Ojciec Mateusz"?', N'Kozia Wólka', N'Sandomierz', N'Mińsk', N'Lwów', N'b')
GO
INSERT [dbo].[Questions] ([Id], [QuestContent], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [Correct]) VALUES (5, N'Która ze słynnych polskich wokalistek śpiewała piosenkę "Pieprz i sól"?', N'Kaja Paschalska', N'Irena Santor', N'Kasia Kowalska', N'Violetta Villas', N'c')
GO
INSERT [dbo].[Questions] ([Id], [QuestContent], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [Correct]) VALUES (6, N'Typ zmiennych o nazwie float przechowuje:', N'liczby calkowite', N'napisy', N'liczby zmiennoprzecinkowe', N'pojedyncze znaki', N'c')
GO
INSERT [dbo].[Questions] ([Id], [QuestContent], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [Correct]) VALUES (7, N'Wstrzymanie wykonania programu na czas 2 sekund uzyskasz instrukcja:', N'Wait(2000)', N'Stop(2000)', N'Delay(2000)', N'Sleep(2000)', N'd')
GO
INSERT [dbo].[Questions] ([Id], [QuestContent], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [Correct]) VALUES (8, N'Który/a z wymienionych polityków nie był(a) nigdy premierem RP?', N'Grzegorz Schetyna', N'Waldemar Pawlak', N'Marek Belka', N'Hanna Suchocka', N'a')
GO
INSERT [dbo].[Questions] ([Id], [QuestContent], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [Correct]) VALUES (9, N'Z jakiego przedzialu zostanie wylosowana liczba: rand()%10+2', N'0..9', N'2..9', N'2..11', N'0..11', N'c')
GO
INSERT [dbo].[Questions] ([Id], [QuestContent], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [Correct]) VALUES (10, N'Która z podanych instytucji nie jest organem Unii Europejskiej?', N'Parlament Europejski', N'Rada Europejska', N'Rada Unii Europejskiej', N'Rada Europy', N'd')
GO
SET IDENTITY_INSERT [dbo].[Questions] OFF
GO
