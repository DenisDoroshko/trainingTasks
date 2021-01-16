USE [master]
GO
/****** Object:  Database [dbTask6]    Script Date: 14.01.2021 16:10:10 ******/
CREATE DATABASE [dbTask6]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbTask6', FILENAME = N'D:\dbTask6.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbTask6_log', FILENAME = N'D:\dbTask6_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbTask6] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbTask6].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbTask6] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbTask6] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbTask6] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbTask6] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbTask6] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbTask6] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbTask6] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbTask6] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbTask6] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbTask6] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbTask6] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbTask6] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbTask6] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbTask6] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbTask6] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbTask6] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbTask6] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbTask6] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbTask6] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbTask6] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbTask6] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbTask6] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbTask6] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbTask6] SET  MULTI_USER 
GO
ALTER DATABASE [dbTask6] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbTask6] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbTask6] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbTask6] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbTask6] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbTask6] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbTask6] SET QUERY_STORE = OFF
GO
USE [dbTask6]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 14.01.2021 16:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [uniqueidentifier] NOT NULL,
	[GroupName] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Groups_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 14.01.2021 16:10:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [uniqueidentifier] NOT NULL,
	[FullName] [nchar](50) NOT NULL,
	[Sex] [int] NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[GroupId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Students_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_GroupStudent]    Script Date: 14.01.2021 16:10:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_GroupStudent]
AS
SELECT        dbo.Groups.GroupName, dbo.Students.FullName
FROM            dbo.Groups INNER JOIN
                         dbo.Students ON dbo.Groups.Id = dbo.Students.GroupId
GO
/****** Object:  Table [dbo].[Credits]    Script Date: 14.01.2021 16:10:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credits](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Creditation] [int] NULL,
	[Date] [datetime] NOT NULL,
	[SessionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Credits_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exams]    Script Date: 14.01.2021 16:10:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exams](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Mark] [int] NULL,
	[Date] [datetime] NOT NULL,
	[SessionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 14.01.2021 16:10:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[Id] [uniqueidentifier] NOT NULL,
	[Number] [int] NOT NULL,
	[OwnerType] [int] NOT NULL,
	[GroupId] [uniqueidentifier] NULL,
	[StudentId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'639d3794-d2ad-49ac-af4d-07da23e15169', N'History                                                                                             ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'ec7a132b-9fcd-4bcb-9238-0aceaa9ddf92')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'd15197cb-24ac-45b1-8986-0be3f0290cd3', N'Math                                                                                                ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'bfcda7c2-cf12-4ff9-abb1-4d3183a2c835')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'70b5654b-99d8-438f-a7b2-0bee8773cb66', N'PE                                                                                                  ', 1, CAST(N'2020-12-26T00:00:00.000' AS DateTime), N'20de923a-51b7-4dea-b2a8-c9238301fe0c')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'5ed67099-d210-4df0-b126-211067a8b574', N'History                                                                                             ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'e918f7bc-3f22-4fd2-8960-3c1cdea222c7')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'2b3d8231-156a-4d81-86dd-31351d01c516', N'Python                                                                                              ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'ed87b8e6-4327-4c13-bdbb-8fe03dc7ee2c')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'dd48030d-1859-4b7e-b112-3472f039d586', N'Python                                                                                              ', 1, CAST(N'2020-12-24T00:00:00.000' AS DateTime), N'20de923a-51b7-4dea-b2a8-c9238301fe0c')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'269d8e80-b049-4ebb-afc4-34b0eaecb540', N'Math                                                                                                ', 0, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'5622a95d-e4ee-4cdc-88e5-4234529421b1')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'dd3e7399-0364-4b6a-9fbe-3bf0f88f2d63', N'PE                                                                                                  ', 1, CAST(N'2020-12-26T00:00:00.000' AS DateTime), N'e918f7bc-3f22-4fd2-8960-3c1cdea222c7')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'd508263b-d495-4ac3-8248-3f7adc43b33e', N'Python                                                                                              ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'e39d4a1a-e29b-4ac9-85c9-89f7d09cf3dd')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'768a5be0-2d16-4553-88cb-51ddc8b1fc93', N'PE                                                                                                  ', 1, CAST(N'2020-12-25T00:00:00.000' AS DateTime), N'ed87b8e6-4327-4c13-bdbb-8fe03dc7ee2c')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'bc81c2b7-15bb-4f16-aa29-5daa2e9a6e68', N'Python                                                                                              ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'b223b9cf-b9f1-4d5a-8030-01638d379004')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'85021579-ab82-42d2-8cca-5ff2efd3a9b5', N'PE                                                                                                  ', 1, CAST(N'2020-12-25T00:00:00.000' AS DateTime), N'b223b9cf-b9f1-4d5a-8030-01638d379004')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'0092a900-630f-46ed-9bde-6058dfcb6e3c', N'PE                                                                                                  ', 0, CAST(N'2020-12-25T00:00:00.000' AS DateTime), N'98fa615b-938f-42bd-b0a5-2c57a61690f1')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'de39bc98-f28f-4c5f-be77-6564a1d7d036', N'Math                                                                                                ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'df1dd4ba-cd56-4ee5-a106-7517ae8eb4e2')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'61eadea7-9fc8-49b0-8009-6ddedb634ccf', N'Math                                                                                                ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'4b4050ce-2c4c-431c-b8e2-311b5bedc788')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'96bed943-bce0-46e5-aaec-717e9421acf1', N'Python                                                                                              ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'fa338944-23bb-414a-a0bb-92e82d0fd7c0')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'5dd30a75-f88d-43c5-ac1a-7ab4fbc6a681', N'Python                                                                                              ', 1, CAST(N'2020-12-24T00:00:00.000' AS DateTime), N'450b0ceb-e2ae-44bd-a613-88d98e0c2e1c')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'bd928af5-e389-4a6e-bc24-7fd492291e73', N'PE                                                                                                  ', 1, CAST(N'2020-12-26T00:00:00.000' AS DateTime), N'ec7a132b-9fcd-4bcb-9238-0aceaa9ddf92')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'3bff8c9a-996b-4ff7-b16f-7fef4caa845b', N'Python                                                                                              ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'397d7645-fe5b-4731-8baf-9854f0fe2e06')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'98cdd896-e098-4835-a969-9f9b4f768011', N'Python                                                                                              ', 1, CAST(N'2020-12-24T00:00:00.000' AS DateTime), N'e918f7bc-3f22-4fd2-8960-3c1cdea222c7')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'2608ef7a-76ee-4b8d-ac3f-a6ac36bd0741', N'History                                                                                             ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'20de923a-51b7-4dea-b2a8-c9238301fe0c')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'60b03fd8-2fab-4e75-8465-a6cfd4f85a16', N'PE                                                                                                  ', 1, CAST(N'2020-12-25T00:00:00.000' AS DateTime), N'fa338944-23bb-414a-a0bb-92e82d0fd7c0')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'1cc93afd-eabc-4eec-bb33-ac9b3502d873', N'History                                                                                             ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'450b0ceb-e2ae-44bd-a613-88d98e0c2e1c')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'149085c7-220c-4951-9f92-b0f736f659fd', N'PE                                                                                                  ', 1, CAST(N'2020-12-25T00:00:00.000' AS DateTime), N'9b9c4876-95c3-4c64-9782-b0224e594495')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'b02de8e8-7ddb-41a2-bd01-b11f5fddf75a', N'PE                                                                                                  ', 1, CAST(N'2020-12-25T00:00:00.000' AS DateTime), N'397d7645-fe5b-4731-8baf-9854f0fe2e06')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'2cf1a550-cb0c-4353-8fdd-b7a2605a3244', N'Math                                                                                                ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'dc7d337f-a543-4463-a7d7-59e40d7debb3')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'1cbf42d9-5093-497e-b488-bae3dd04613d', N'Math                                                                                                ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'5ef8cb5e-493a-4006-8b9e-1eef341e960f')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'8e67dafc-fb7c-4d4d-88e5-c6a5f84b23cd', N'Python                                                                                              ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'9664c19c-08d8-4a4e-8c3b-4d5a518b99cf')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'23ddcfd6-6af2-4376-9859-c7ebaa3870c0', N'PE                                                                                                  ', 1, CAST(N'2020-12-25T00:00:00.000' AS DateTime), N'2a04b6d5-9814-45bb-9a0d-b715cf5a3d50')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'6bde3cd5-4f10-457e-94d3-cc207fae6f88', N'Python                                                                                              ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'98fa615b-938f-42bd-b0a5-2c57a61690f1')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'e64017f8-42ba-491b-b49a-dd877fc69418', N'PE                                                                                                  ', 1, CAST(N'2020-12-26T00:00:00.000' AS DateTime), N'450b0ceb-e2ae-44bd-a613-88d98e0c2e1c')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'b9e3f6ba-7011-4bd5-9c4c-dd987e1c9814', N'Python                                                                                              ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'9b9c4876-95c3-4c64-9782-b0224e594495')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'73f55265-950e-4867-a8e0-e22263fe143e', N'Python                                                                                              ', 1, CAST(N'2020-12-24T00:00:00.000' AS DateTime), N'ec7a132b-9fcd-4bcb-9238-0aceaa9ddf92')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'8692063a-9996-45be-a7cf-e43fc469ef8b', N'PE                                                                                                  ', 1, CAST(N'2020-12-25T00:00:00.000' AS DateTime), N'9664c19c-08d8-4a4e-8c3b-4d5a518b99cf')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'12ba3e4c-3edc-4fed-ad21-ed3a38539abb', N'Math                                                                                                ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'c0f3ce7f-db1d-4943-9401-bc71d31bcfdc')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'7fee295c-e67b-42ec-b564-ede4d1683eb6', N'Python                                                                                              ', 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime), N'2a04b6d5-9814-45bb-9a0d-b715cf5a3d50')
INSERT [dbo].[Credits] ([Id], [Name], [Creditation], [Date], [SessionId]) VALUES (N'a8bd823e-ba9c-49f9-99c1-f4d8456bda77', N'PE                                                                                                  ', 1, CAST(N'2020-12-25T00:00:00.000' AS DateTime), N'e39d4a1a-e29b-4ac9-85c9-89f7d09cf3dd')
GO
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'48e7e62f-c97e-46b8-9c9c-08694e7a7939', N'OS                                                                                                  ', 10, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'450b0ceb-e2ae-44bd-a613-88d98e0c2e1c')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'd2b62b95-b774-486e-b6ed-09dca6743529', N'Math                                                                                                ', 9, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'e39d4a1a-e29b-4ac9-85c9-89f7d09cf3dd')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'029e98f7-3690-4225-a5bb-0d14164c679d', N'OOP                                                                                                 ', 6, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'c0f3ce7f-db1d-4943-9401-bc71d31bcfdc')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'508476cc-8cfd-4365-9d50-129a8cbc08e5', N'OS                                                                                                  ', 7, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'ec7a132b-9fcd-4bcb-9238-0aceaa9ddf92')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'f80e172c-c74d-4ec4-b9f3-1adf5745a20b', N'English                                                                                             ', 3, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'450b0ceb-e2ae-44bd-a613-88d98e0c2e1c')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'960da281-4dc9-4864-9ae2-1bc8d7cae84a', N'Math                                                                                                ', 5, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'9664c19c-08d8-4a4e-8c3b-4d5a518b99cf')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'e4f733fc-31fb-4ed9-a8d1-27081c917a68', N'OS                                                                                                  ', 7, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'ed87b8e6-4327-4c13-bdbb-8fe03dc7ee2c')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'06ba2daa-dff3-43c3-ad0a-2b8479df4f45', N'Economic                                                                                            ', 3, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'e918f7bc-3f22-4fd2-8960-3c1cdea222c7')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'2eea6127-d0e8-4e73-b1fe-2c86a8a66a89', N'Economic                                                                                            ', 7, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'450b0ceb-e2ae-44bd-a613-88d98e0c2e1c')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'6b711279-c00b-4270-b6eb-2ccfe491a4ff', N'English                                                                                             ', 8, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'ec7a132b-9fcd-4bcb-9238-0aceaa9ddf92')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'14061c39-6820-4528-aedb-3702e80dd23c', N'OS                                                                                                  ', 5, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'9664c19c-08d8-4a4e-8c3b-4d5a518b99cf')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'21119e1f-d4e9-4220-8069-37b7f8e7ca1e', N'OAIP                                                                                                ', 7, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'b223b9cf-b9f1-4d5a-8030-01638d379004')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'8a6b1eff-e527-4b9b-a89d-3836b74f5bda', N'OAIP                                                                                                ', 3, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'9b9c4876-95c3-4c64-9782-b0224e594495')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'7f8ca917-65d5-42f1-b1c4-39b52393a016', N'OS                                                                                                  ', 6, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'397d7645-fe5b-4731-8baf-9854f0fe2e06')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'e4eefbca-3558-426f-99d7-3af6322d5d53', N'KS                                                                                                  ', 5, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'5622a95d-e4ee-4cdc-88e5-4234529421b1')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'd7c1bb23-3346-44a5-bc65-3ece45c86e8a', N'KS                                                                                                  ', 8, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'dc7d337f-a543-4463-a7d7-59e40d7debb3')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'457a1907-c695-4751-9be1-4b369a692de6', N'Economic                                                                                            ', 5, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'dc7d337f-a543-4463-a7d7-59e40d7debb3')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'd8e0b00e-bbcf-490b-b523-4d51796582bc', N'OAIP                                                                                                ', 3, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'2a04b6d5-9814-45bb-9a0d-b715cf5a3d50')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'4bd2c6db-0845-4981-a67f-4db6729a5ff2', N'Math                                                                                                ', 2, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'397d7645-fe5b-4731-8baf-9854f0fe2e06')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'2cbbdcc3-e97e-4080-a65b-4dcb53f12a0f', N'OS                                                                                                  ', 9, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'20de923a-51b7-4dea-b2a8-c9238301fe0c')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'07cefafd-4929-408d-a027-4fcb317415d4', N'OS                                                                                                  ', 5, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'9b9c4876-95c3-4c64-9782-b0224e594495')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'96f8c5f2-4132-4527-a80f-5270dd070fc0', N'Math                                                                                                ', 6, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'98fa615b-938f-42bd-b0a5-2c57a61690f1')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'ef68c2ce-51cd-47ed-957e-56718e6f634a', N'OAIP                                                                                                ', 4, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'ed87b8e6-4327-4c13-bdbb-8fe03dc7ee2c')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'17d291e3-4bc1-4e38-b5bd-6564f35780b8', N'OAIP                                                                                                ', 7, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'98fa615b-938f-42bd-b0a5-2c57a61690f1')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'30d526d0-ce69-4aaf-b01e-6d01fcfe5a98', N'Economic                                                                                            ', 6, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'ec7a132b-9fcd-4bcb-9238-0aceaa9ddf92')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'87d38170-18bf-4efe-a8a0-70833e046339', N'Math                                                                                                ', 5, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'ed87b8e6-4327-4c13-bdbb-8fe03dc7ee2c')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'3607257d-9022-4a0c-bce3-729087f49919', N'Math                                                                                                ', 3, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'9b9c4876-95c3-4c64-9782-b0224e594495')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'edb5bb46-2d04-406a-b4e7-7696eaf5a194', N'Economic                                                                                            ', 9, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'df1dd4ba-cd56-4ee5-a106-7517ae8eb4e2')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'b997167f-51c0-4e9b-90c0-83e5bb2c58ab', N'English                                                                                             ', 10, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'e918f7bc-3f22-4fd2-8960-3c1cdea222c7')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'70693536-77ee-4382-a5f0-85add683533c', N'OS                                                                                                  ', 6, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'fa338944-23bb-414a-a0bb-92e82d0fd7c0')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'b0c6ec4b-f4b0-4741-81c5-8b09b5d85ceb', N'Math                                                                                                ', 6, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'fa338944-23bb-414a-a0bb-92e82d0fd7c0')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'5454f97c-a098-4b66-9607-8e1ec48708c2', N'OS                                                                                                  ', 6, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'b223b9cf-b9f1-4d5a-8030-01638d379004')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'd3f7ea37-93db-452d-a0bf-936a54357a88', N'OAIP                                                                                                ', 7, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'fa338944-23bb-414a-a0bb-92e82d0fd7c0')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'a13d863e-9a5b-4628-9dee-98b830e70d71', N'Math                                                                                                ', 8, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'b223b9cf-b9f1-4d5a-8030-01638d379004')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'66ca10a6-6cbc-4111-8dfd-99bc1f2946e0', N'Economic                                                                                            ', 9, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'c0f3ce7f-db1d-4943-9401-bc71d31bcfdc')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'696f8885-d154-4f0f-be0d-9c962448ade4', N'Economic                                                                                            ', 5, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'4b4050ce-2c4c-431c-b8e2-311b5bedc788')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'0a135f7a-891d-454c-9284-a3a4b1d5d8ef', N'OOP                                                                                                 ', 7, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'bfcda7c2-cf12-4ff9-abb1-4d3183a2c835')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'7add37a1-d92e-4036-a8c9-aa4a3c9877cd', N'OOP                                                                                                 ', 8, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'dc7d337f-a543-4463-a7d7-59e40d7debb3')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'33d8c8de-4796-424f-a4c5-afda3c7097cf', N'OS                                                                                                  ', 9, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'e918f7bc-3f22-4fd2-8960-3c1cdea222c7')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'263db82a-b784-44b0-9438-bb1f1ee08083', N'Economic                                                                                            ', 6, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'5622a95d-e4ee-4cdc-88e5-4234529421b1')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'f2c56c75-3409-4959-bf35-bdac2cfdd044', N'Economic                                                                                            ', 7, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'20de923a-51b7-4dea-b2a8-c9238301fe0c')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'229ef2a2-8fa2-4417-b2f3-bf76742be13f', N'OOP                                                                                                 ', 7, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'4b4050ce-2c4c-431c-b8e2-311b5bedc788')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'aebbaa3f-b9bf-444e-9ee3-c20d8563b71c', N'OS                                                                                                  ', 9, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'2a04b6d5-9814-45bb-9a0d-b715cf5a3d50')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'9775c6f1-a649-4c36-acb7-c30d66b49cc6', N'OOP                                                                                                 ', 6, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'5ef8cb5e-493a-4006-8b9e-1eef341e960f')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'5d7dc94a-e48f-41b5-8b1e-c4e180494182', N'English                                                                                             ', 8, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'20de923a-51b7-4dea-b2a8-c9238301fe0c')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'8c1c438d-f751-4946-bb61-c5d536317c19', N'OOP                                                                                                 ', 9, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'5622a95d-e4ee-4cdc-88e5-4234529421b1')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'c652b334-5dca-41d2-8703-c81e78c80ff3', N'OAIP                                                                                                ', 6, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'9664c19c-08d8-4a4e-8c3b-4d5a518b99cf')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'e5e052f2-f81c-4efb-be0f-cabbca2942d5', N'KS                                                                                                  ', 6, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'c0f3ce7f-db1d-4943-9401-bc71d31bcfdc')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'9a639aa9-3b42-467d-8ab1-da88a6a67d47', N'OS                                                                                                  ', 7, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'98fa615b-938f-42bd-b0a5-2c57a61690f1')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'f712a35a-f018-4472-858d-e55580a683a6', N'OAIP                                                                                                ', 8, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'397d7645-fe5b-4731-8baf-9854f0fe2e06')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'd5191603-7154-4c21-b921-e715144f4c63', N'OAIP                                                                                                ', 6, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'e39d4a1a-e29b-4ac9-85c9-89f7d09cf3dd')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'ce6a2779-9c65-4af9-aed2-eb013c406830', N'Economic                                                                                            ', 9, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'bfcda7c2-cf12-4ff9-abb1-4d3183a2c835')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'c31411ff-40d8-42c4-a10c-eb1093457d45', N'KS                                                                                                  ', 7, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'4b4050ce-2c4c-431c-b8e2-311b5bedc788')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'3c92596d-fa52-4c50-9f3c-eeb2bbfadb01', N'Economic                                                                                            ', 1, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'5ef8cb5e-493a-4006-8b9e-1eef341e960f')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'a0f7d37d-6322-4248-853e-ef822c023bee', N'KS                                                                                                  ', 4, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'5ef8cb5e-493a-4006-8b9e-1eef341e960f')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'95c41229-9457-4d1c-8a93-f1344536417c', N'KS                                                                                                  ', 6, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'bfcda7c2-cf12-4ff9-abb1-4d3183a2c835')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'd3aa07d4-eab7-47ef-8cf2-f158fa15e05e', N'KS                                                                                                  ', 6, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'df1dd4ba-cd56-4ee5-a106-7517ae8eb4e2')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'28b7edaa-21f8-4e1e-81af-f59dbcf4e823', N'OOP                                                                                                 ', 6, CAST(N'2021-01-15T00:00:00.000' AS DateTime), N'df1dd4ba-cd56-4ee5-a106-7517ae8eb4e2')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'f0927ddc-cf3f-4379-b22c-f9fa73ec236d', N'OS                                                                                                  ', 6, CAST(N'2021-01-19T00:00:00.000' AS DateTime), N'e39d4a1a-e29b-4ac9-85c9-89f7d09cf3dd')
INSERT [dbo].[Exams] ([Id], [Name], [Mark], [Date], [SessionId]) VALUES (N'5b5a41db-ad70-4b74-a5d4-fec91dde0c86', N'Math                                                                                                ', 6, CAST(N'2021-01-10T00:00:00.000' AS DateTime), N'2a04b6d5-9814-45bb-9a0d-b715cf5a3d50')
GO
INSERT [dbo].[Groups] ([Id], [GroupName]) VALUES (N'0152f751-0f1e-4d15-b773-1a338055e4ce', N'ITI-21              ')
INSERT [dbo].[Groups] ([Id], [GroupName]) VALUES (N'a6fa326d-6f9c-4c0a-a1df-82ed622f3b63', N'IP-21               ')
INSERT [dbo].[Groups] ([Id], [GroupName]) VALUES (N'b509fd3f-38d1-4cff-be61-c2f67d37c701', N'ITP-21              ')
GO
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'b223b9cf-b9f1-4d5a-8030-01638d379004', 1, 1, NULL, N'eb1e2a9f-14c8-42c4-a89a-249245312da3')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'ec7a132b-9fcd-4bcb-9238-0aceaa9ddf92', 1, 0, N'b509fd3f-38d1-4cff-be61-c2f67d37c701', NULL)
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'5ef8cb5e-493a-4006-8b9e-1eef341e960f', 1, 1, NULL, N'f9d5b83f-4883-46c1-a49a-edc51012a825')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'98fa615b-938f-42bd-b0a5-2c57a61690f1', 1, 1, NULL, N'a6fdffdd-9fec-41e1-8369-00f0f58ab363')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'4b4050ce-2c4c-431c-b8e2-311b5bedc788', 1, 0, N'0152f751-0f1e-4d15-b773-1a338055e4ce', NULL)
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'e918f7bc-3f22-4fd2-8960-3c1cdea222c7', 1, 1, NULL, N'd0228277-6a07-4840-acd1-bb26859235d3')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'5622a95d-e4ee-4cdc-88e5-4234529421b1', 1, 1, NULL, N'79518c70-c275-4ea4-a9bc-f6810c57ff99')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'bfcda7c2-cf12-4ff9-abb1-4d3183a2c835', 1, 1, NULL, N'0f52d7fd-d892-47ce-973a-06914561784f')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'9664c19c-08d8-4a4e-8c3b-4d5a518b99cf', 1, 1, NULL, N'0f7a9d03-871a-4d2d-89d3-33f41d0d185c')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'dc7d337f-a543-4463-a7d7-59e40d7debb3', 1, 1, NULL, N'191d3eb7-777d-4e18-8505-592b96e95ab3')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'df1dd4ba-cd56-4ee5-a106-7517ae8eb4e2', 1, 1, NULL, N'705cb450-20f1-47a2-a685-b312bf091043')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'450b0ceb-e2ae-44bd-a613-88d98e0c2e1c', 1, 1, NULL, N'b9cd110e-ecfd-4c63-a6dc-ab3d5af023d4')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'e39d4a1a-e29b-4ac9-85c9-89f7d09cf3dd', 1, 1, NULL, N'fb9ca885-2927-41d4-b746-8df78fc0afe5')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'ed87b8e6-4327-4c13-bdbb-8fe03dc7ee2c', 1, 1, NULL, N'20a8685f-3184-4350-9fe2-f2f99c802e9a')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'fa338944-23bb-414a-a0bb-92e82d0fd7c0', 1, 1, NULL, N'890f47e6-9dba-4a13-8306-639ebf770253')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'397d7645-fe5b-4731-8baf-9854f0fe2e06', 1, 1, NULL, N'26338597-a094-4c1b-94e1-4d7d8f123117')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'9b9c4876-95c3-4c64-9782-b0224e594495', 1, 0, N'a6fa326d-6f9c-4c0a-a1df-82ed622f3b63', NULL)
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'2a04b6d5-9814-45bb-9a0d-b715cf5a3d50', 1, 1, NULL, N'31e847ce-a1c3-41f3-9715-9573e0f99d5b')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'c0f3ce7f-db1d-4943-9401-bc71d31bcfdc', 1, 1, NULL, N'eed013f2-33e7-4278-a958-b76166385610')
INSERT [dbo].[Sessions] ([Id], [Number], [OwnerType], [GroupId], [StudentId]) VALUES (N'20de923a-51b7-4dea-b2a8-c9238301fe0c', 1, 1, NULL, N'787b7b14-f208-4555-9206-b2624301b00a')
GO
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'a6fdffdd-9fec-41e1-8369-00f0f58ab363', N'Borisova Karina                                   ', 2, CAST(N'2000-12-15T00:00:00.000' AS DateTime), N'a6fa326d-6f9c-4c0a-a1df-82ed622f3b63')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'0f52d7fd-d892-47ce-973a-06914561784f', N'Petrov Alexander                                  ', 1, CAST(N'2001-03-20T00:00:00.000' AS DateTime), N'0152f751-0f1e-4d15-b773-1a338055e4ce')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'eb1e2a9f-14c8-42c4-a89a-249245312da3', N'Pushkina Olga                                     ', 2, CAST(N'2000-10-03T00:00:00.000' AS DateTime), N'a6fa326d-6f9c-4c0a-a1df-82ed622f3b63')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'0f7a9d03-871a-4d2d-89d3-33f41d0d185c', N'Alexandrow Alexander                              ', 1, CAST(N'2001-03-20T00:00:00.000' AS DateTime), N'a6fa326d-6f9c-4c0a-a1df-82ed622f3b63')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'26338597-a094-4c1b-94e1-4d7d8f123117', N'Ivanova Karina                                    ', 2, CAST(N'2000-12-15T00:00:00.000' AS DateTime), N'a6fa326d-6f9c-4c0a-a1df-82ed622f3b63')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'191d3eb7-777d-4e18-8505-592b96e95ab3', N'Ivanova Karina                                    ', 2, CAST(N'2000-12-15T00:00:00.000' AS DateTime), N'0152f751-0f1e-4d15-b773-1a338055e4ce')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'890f47e6-9dba-4a13-8306-639ebf770253', N'Borisov Nikita                                    ', 1, CAST(N'2000-10-03T00:00:00.000' AS DateTime), N'a6fa326d-6f9c-4c0a-a1df-82ed622f3b63')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'fb9ca885-2927-41d4-b746-8df78fc0afe5', N'Ivanov Boris                                      ', 1, CAST(N'2000-12-20T00:00:00.000' AS DateTime), N'a6fa326d-6f9c-4c0a-a1df-82ed622f3b63')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'31e847ce-a1c3-41f3-9715-9573e0f99d5b', N'Elizarov Alexander                                ', 1, CAST(N'2000-11-12T00:00:00.000' AS DateTime), N'a6fa326d-6f9c-4c0a-a1df-82ed622f3b63')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'b9cd110e-ecfd-4c63-a6dc-ab3d5af023d4', N'Borisov Nikita                                    ', 1, CAST(N'2000-10-03T00:00:00.000' AS DateTime), N'b509fd3f-38d1-4cff-be61-c2f67d37c701')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'787b7b14-f208-4555-9206-b2624301b00a', N'Ivanova Karina                                    ', 2, CAST(N'2000-12-15T00:00:00.000' AS DateTime), N'b509fd3f-38d1-4cff-be61-c2f67d37c701')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'705cb450-20f1-47a2-a685-b312bf091043', N'Ivanov Denis                                      ', 1, CAST(N'2000-12-20T00:00:00.000' AS DateTime), N'0152f751-0f1e-4d15-b773-1a338055e4ce')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'eed013f2-33e7-4278-a958-b76166385610', N'Ivanova Alexandra                                 ', 2, CAST(N'2000-11-12T00:00:00.000' AS DateTime), N'0152f751-0f1e-4d15-b773-1a338055e4ce')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'd0228277-6a07-4840-acd1-bb26859235d3', N'Borisova Karina                                   ', 2, CAST(N'2000-12-15T00:00:00.000' AS DateTime), N'b509fd3f-38d1-4cff-be61-c2f67d37c701')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'f9d5b83f-4883-46c1-a49a-edc51012a825', N'Pushkina Olga                                     ', 2, CAST(N'2000-10-03T00:00:00.000' AS DateTime), N'0152f751-0f1e-4d15-b773-1a338055e4ce')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'20a8685f-3184-4350-9fe2-f2f99c802e9a', N'Denisov Sergei                                    ', 1, CAST(N'2000-12-15T00:00:00.000' AS DateTime), N'a6fa326d-6f9c-4c0a-a1df-82ed622f3b63')
INSERT [dbo].[Students] ([Id], [FullName], [Sex], [BirthDate], [GroupId]) VALUES (N'79518c70-c275-4ea4-a9bc-f6810c57ff99', N'Denisov Sergei                                    ', 1, CAST(N'2000-12-15T00:00:00.000' AS DateTime), N'0152f751-0f1e-4d15-b773-1a338055e4ce')
GO
ALTER TABLE [dbo].[Groups] ADD  CONSTRAINT [DF_Groups_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Credits]  WITH CHECK ADD  CONSTRAINT [FK_Credits_Sessions] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Sessions] ([Id])
GO
ALTER TABLE [dbo].[Credits] CHECK CONSTRAINT [FK_Credits_Sessions]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Sessions] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Sessions] ([Id])
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Sessions]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Groups]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Groups]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Groups"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Students"
            Begin Extent = 
               Top = 8
               Left = 282
               Bottom = 138
               Right = 452
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GroupStudent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GroupStudent'
GO
USE [master]
GO
ALTER DATABASE [dbTask6] SET  READ_WRITE 
GO
