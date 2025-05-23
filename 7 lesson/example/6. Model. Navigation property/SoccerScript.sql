USE [master]
GO
/****** Object:  Database [Soccer]    Script Date: 21.08.2023 16:16:51 ******/
CREATE DATABASE [Soccer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Soccer', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\Soccer.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Soccer_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\Soccer_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Soccer] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Soccer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Soccer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Soccer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Soccer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Soccer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Soccer] SET ARITHABORT OFF 
GO
ALTER DATABASE [Soccer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Soccer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Soccer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Soccer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Soccer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Soccer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Soccer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Soccer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Soccer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Soccer] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Soccer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Soccer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Soccer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Soccer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Soccer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Soccer] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Soccer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Soccer] SET RECOVERY FULL 
GO
ALTER DATABASE [Soccer] SET  MULTI_USER 
GO
ALTER DATABASE [Soccer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Soccer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Soccer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Soccer] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Soccer] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Soccer] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Soccer', N'ON'
GO
ALTER DATABASE [Soccer] SET QUERY_STORE = OFF
GO
USE [Soccer]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 21.08.2023 16:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Age] [int] NOT NULL,
	[Position] [nvarchar](max) NOT NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 21.08.2023 16:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Coach] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Players] ON 

INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (3, N'Роберт Левандовски', 34, N'Нападающий', 5)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (5, N'Мохамед Салах', 31, N'Нападающий', 2)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (7, N'Лионель Месси', 35, N'Нападающий', 9)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (11, N'Эрлинг Холанн', 22, N'Нападающий', 10)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (15, N'Виталий Миколенко', 23, N'Защитник', 11)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (20, N'Виктор Осимхен', 24, N'Нападающий', 1014)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (21, N'Хвича Кварацхелия', 22, N'Нападающий', 1014)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (22, N'Виталий Буяльский', 30, N'Полузащитник', 3)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (23, N'Карим Бензема', 35, N'Нападающий', 12)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (24, N'Серж Гнабри', 27, N'Полузащитник', 6)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (26, N' Ромелу Лукаку', 29, N'Нападающий', 1016)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (27, N'Эдин Джеко', 37, N'Нападающий', 1016)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (28, N'Хакан Чалханоглу', 29, N'Полузащитник', 1016)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (29, N'Бенжамен Павар', 27, N'Защитник', 6)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (30, N'Леон Горецка', 28, N'Полузащитник', 6)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (31, N'Эрик Шупо-Мотинг', 34, N'Нападающий', 6)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (32, N'Усман Дембеле', 25, N'Нападающий', 5)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (33, N'Килиан Мбаппе', 24, N'Нападающий', 9)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (34, N'Неймар', 31, N'Нападающий', 9)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (35, N'Роберто Фирмино', 31, N'Нападающий', 2)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (36, N'Александр Караваев', 30, N'Защитник', 3)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (37, N'Кевин Де Брёйне', 31, N'Полузащитник', 10)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (38, N'Эдер Милитао', 25, N'Защитник', 12)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (39, N'Винисиус Жуниор', 22, N'Нападающий', 12)
INSERT [dbo].[Players] ([Id], [Name], [Age], [Position], [TeamId]) VALUES (40, N'Пётр Зелиньски', 28, N'Полузащитник', 1014)
SET IDENTITY_INSERT [dbo].[Players] OFF
GO
SET IDENTITY_INSERT [dbo].[Teams] ON 

INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (2, N'Ливерпуль', N'Юрген Клопп')
INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (3, N'Динамо Киев', N'Мирча Луческу')
INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (5, N'Барселона', N'Хавье́р Эрна́ндес')
INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (6, N'Бавария Мюнхен', N'Томас Тухель')
INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (9, N'Пари Сен-Жермен', N'Кристоф Гальтье')
INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (10, N'Манчестер Сити', N'Хосеп Гвардиола')
INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (11, N'Эвертон Ливерпуль', N'Шон Дайч')
INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (12, N'Реал Мадрид', N'Карло Анчелотти')
INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (1014, N'Наполи, Неаполь', N'Лучано Спаллетти')
INSERT [dbo].[Teams] ([Id], [Name], [Coach]) VALUES (1016, N'Интер, Милан', N'Симоне Индзаги')
SET IDENTITY_INSERT [dbo].[Teams] OFF
GO
/****** Object:  Index [IX_Players_TeamId]    Script Date: 21.08.2023 16:16:51 ******/
CREATE NONCLUSTERED INDEX [IX_Players_TeamId] ON [dbo].[Players]
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Teams_TeamId]
GO
USE [master]
GO
ALTER DATABASE [Soccer] SET  READ_WRITE 
GO
