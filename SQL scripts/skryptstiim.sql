USE [master]
GO
/****** Object:  Database [StiimDB]    Script Date: 12.12.2022 22:48:37 ******/
CREATE DATABASE [StiimDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StiimDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StiimDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StiimDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StiimDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [StiimDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StiimDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StiimDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StiimDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StiimDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StiimDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StiimDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StiimDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StiimDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StiimDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StiimDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StiimDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StiimDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StiimDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StiimDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StiimDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StiimDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StiimDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StiimDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StiimDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StiimDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StiimDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StiimDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [StiimDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StiimDB] SET RECOVERY FULL 
GO
ALTER DATABASE [StiimDB] SET  MULTI_USER 
GO
ALTER DATABASE [StiimDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StiimDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StiimDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StiimDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StiimDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StiimDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'StiimDB', N'ON'
GO
ALTER DATABASE [StiimDB] SET QUERY_STORE = OFF
GO
USE [StiimDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12.12.2022 22:48:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Element_koszyka]    Script Date: 12.12.2022 22:48:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Element_koszyka](
	[ElementId] [uniqueidentifier] NOT NULL,
	[KoszykId] [nvarchar](max) NULL,
	[Ilość] [int] NOT NULL,
	[GraId] [int] NOT NULL,
 CONSTRAINT [PK_Element_koszyka] PRIMARY KEY CLUSTERED 
(
	[ElementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gra]    Script Date: 12.12.2022 22:48:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gra](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [nvarchar](max) NULL,
	[Zdjęcie1] [nvarchar](max) NULL,
	[Zdjęcie2] [nvarchar](max) NULL,
	[Zdjęcie3] [nvarchar](max) NULL,
	[Kategoria] [nvarchar](max) NULL,
	[Cena] [float] NOT NULL,
	[Opis] [nvarchar](max) NULL,
	[Specyfikacjat] [nvarchar](max) NULL,
	[Aktywacja] [nvarchar](max) NULL,
 CONSTRAINT [PK_Gra] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NowyKomentarz]    Script Date: 12.12.2022 22:48:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NowyKomentarz](
	[Id] [uniqueidentifier] NOT NULL,
	[GraId] [int] NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Ocena] [nvarchar](max) NOT NULL,
	[Treść] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_NowyKomentarz] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221212211523_options', N'6.0.10')
GO
SET IDENTITY_INSERT [dbo].[Gra] ON 

INSERT [dbo].[Gra] ([Id], [Nazwa], [Zdjęcie1], [Zdjęcie2], [Zdjęcie3], [Kategoria], [Cena], [Opis], [Specyfikacjat], [Aktywacja]) VALUES (1, N'Battlefield 1', N'battle.jpg', N'battle1.jpg', N'battle2.jpg', N'FPS', 56.99, N'Zdobywaj paski dzięki najwyższej klasy pracy zespołowej, walcząc w historii. Nowa broń została stworzona specjalnie dla tego wydania i musisz odkryć, która broń dobrze współpracuje, aby zapewnić bezbłędne zwycięstwo swojej drużynie!Funkcje: ODNOWIONE KLASY - Wybierz jedną z sześciu klas i pamiętaj o odpowiednim planowaniu z członkami drużyny. Klasy zostały całkowicie przerobione, aby nadać grze bardziej uczciwy charakter. Wybierz, czy chcesz mieszkać w pojeździe jako pilot lub czołgista, czy też chcesz leczyć ludzi jako medyk. Dodatkowo możesz wybrać klasę szturmowca, klasę zwiadowcy i klasę wsparcia.CAŁKOWICIE NOWE MAPY - Jak sugeruje tytuł, jednym z najważniejszych aspektów gry jest pole bitwy! Nowe mapy zostały zawarte w tym wydaniu w historycznych ustawieniach I wojny światowej. Na różnych mapach będą wymagane różne umiejętności i musisz opanować je wszystkie, niezależnie od tego, czy walczysz na froncie zachodnim, w Alpach, czy w Arabii.BROŃ SPECJALNA DLA I WOJNY ŚWIATOWEJ - W grze przywiązuje się dużą wagę do szczegółów, a bronie nie mogą się różnić. System walki wręcz został całkowicie przeprojektowany, dzięki czemu gracze mogą teraz grać łopatami, szabelami i trenczami. Jeśli zabraknie amunicji, nie wszystko jest stracone -dowiedz się, jak wygrywać w walce wręcz!', N'Tak', N'Yea')
INSERT [dbo].[Gra] ([Id], [Nazwa], [Zdjęcie1], [Zdjęcie2], [Zdjęcie3], [Kategoria], [Cena], [Opis], [Specyfikacjat], [Aktywacja]) VALUES (2, N'Battlefield 1', N'battle.jpg', N'battle1.jpg', N'battle2.jpg', N'FPS', 56.99, N'Battlefield 1 to czternasta gra z serii popularnych gier FPS wydawanych przez Electronic Arts. Kontynuuje ona tradycję doskonałego wykonania, której gracze na całym świecie oczekują. Tym razem cofniesz się do czasów I Wojny Światowej, która nigdy wcześniej nie była teatrem walk w serii Battlefield.', N'Tak', N'Yea')
SET IDENTITY_INSERT [dbo].[Gra] OFF
GO
/****** Object:  Index [IX_Element_koszyka_GraId]    Script Date: 12.12.2022 22:48:37 ******/
CREATE NONCLUSTERED INDEX [IX_Element_koszyka_GraId] ON [dbo].[Element_koszyka]
(
	[GraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NowyKomentarz_GraId]    Script Date: 12.12.2022 22:48:37 ******/
CREATE NONCLUSTERED INDEX [IX_NowyKomentarz_GraId] ON [dbo].[NowyKomentarz]
(
	[GraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Element_koszyka]  WITH CHECK ADD  CONSTRAINT [FK_Element_koszyka_Gra_GraId] FOREIGN KEY([GraId])
REFERENCES [dbo].[Gra] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Element_koszyka] CHECK CONSTRAINT [FK_Element_koszyka_Gra_GraId]
GO
ALTER TABLE [dbo].[NowyKomentarz]  WITH CHECK ADD  CONSTRAINT [FK_NowyKomentarz_Gra_GraId] FOREIGN KEY([GraId])
REFERENCES [dbo].[Gra] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NowyKomentarz] CHECK CONSTRAINT [FK_NowyKomentarz_Gra_GraId]
GO
USE [master]
GO
ALTER DATABASE [StiimDB] SET  READ_WRITE 
GO
