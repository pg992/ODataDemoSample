﻿USE [odatademodb]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 03-Apr-20 12:52:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](70) NOT NULL,
	[Addreess] [varchar](80) NOT NULL,
	[Type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 03-Apr-20 12:52:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Address] [varchar](80) NOT NULL,
	[Height] [int] NOT NULL,
	[Weight] [int] NOT NULL,
	[CompanyId] [uniqueidentifier] NOT NULL,
	[PracticeId] [uniqueidentifier] NULL,
	[TitleId] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeProject]    Script Date: 03-Apr-20 12:52:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeProject](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[ProjectId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EmployeeProject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Practice]    Script Date: 03-Apr-20 12:52:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Practice](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Practice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 03-Apr-20 12:52:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](70) NOT NULL,
	[Industry] [varchar](70) NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Title]    Script Date: 03-Apr-20 12:52:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Title](
	[Id] [int] NOT NULL,
	[Name] [varchar](30) NULL,
 CONSTRAINT [PK_Title] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Company] ([Id], [Name], [Addreess], [Type]) VALUES (N'b61b6d10-b806-4d58-8ebc-3a64aaa10bf7', N'InterWorks', N'Karpos 14 Bitola', N'IT')
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [Address], [Height], [Weight], [CompanyId], [PracticeId], [TitleId]) VALUES (N'6c1273f5-02d0-4b69-9be4-6c8f87ab8950', N'Trajanka', N'Trajanovska', N'Test Address 1', 160, 60, N'b61b6d10-b806-4d58-8ebc-3a64aaa10bf7', N'053f77df-50c5-4691-bad6-78b86ab1aac2', 2)
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [Address], [Height], [Weight], [CompanyId], [PracticeId], [TitleId]) VALUES (N'e0859df2-3045-419f-9963-73edf7144419', N'Petko', N'Petkovski', N'Test Address 2', 180, 80, N'b61b6d10-b806-4d58-8ebc-3a64aaa10bf7', N'053f77df-50c5-4691-bad6-78b86ab1aac2', 7)
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [Address], [Height], [Weight], [CompanyId], [PracticeId], [TitleId]) VALUES (N'8b6dab75-261d-457c-91cc-dc54662a3165', N'John', N'Doe', N'Test Address 3', 178, 78, N'b61b6d10-b806-4d58-8ebc-3a64aaa10bf7', N'053f77df-50c5-4691-bad6-78b86ab1aac2', 3)
INSERT [dbo].[EmployeeProject] ([Id], [EmployeeId], [ProjectId]) VALUES (N'26f45889-7307-4f8f-b5a1-2c9fbd21db42', N'8b6dab75-261d-457c-91cc-dc54662a3165', N'4c90e3ea-5b3c-43ac-a496-a7565ed17482')
INSERT [dbo].[EmployeeProject] ([Id], [EmployeeId], [ProjectId]) VALUES (N'f41bd10a-67ce-466e-bf7f-ec8fee21c2d7', N'e0859df2-3045-419f-9963-73edf7144419', N'4c90e3ea-5b3c-43ac-a496-a7565ed17482')
INSERT [dbo].[Practice] ([Id], [Name]) VALUES (N'053f77df-50c5-4691-bad6-78b86ab1aac2', N'Microsoft')
INSERT [dbo].[Project] ([Id], [Name], [Industry]) VALUES (N'4c90e3ea-5b3c-43ac-a496-a7565ed17482', N'Daka', N'Elevator')
INSERT [dbo].[Title] ([Id], [Name]) VALUES (1, N'JrTechnicalConsultant')
INSERT [dbo].[Title] ([Id], [Name]) VALUES (2, N'TechnicalConsultant')
INSERT [dbo].[Title] ([Id], [Name]) VALUES (3, N'SrTechnicalConsultant')
INSERT [dbo].[Title] ([Id], [Name]) VALUES (4, N'LeadTechnicalConsultant')
INSERT [dbo].[Title] ([Id], [Name]) VALUES (5, N'PracticeLead')
INSERT [dbo].[Title] ([Id], [Name]) VALUES (6, N'JrTechnicalArchitect')
INSERT [dbo].[Title] ([Id], [Name]) VALUES (7, N'TechincalArchitect')
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Company]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([Id])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Practice] FOREIGN KEY([PracticeId])
REFERENCES [dbo].[Practice] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Practice]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Title] FOREIGN KEY([TitleId])
REFERENCES [dbo].[Title] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Title]
GO
ALTER TABLE [dbo].[EmployeeProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProject_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_EmployeeProject_Employee]
GO
ALTER TABLE [dbo].[EmployeeProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_EmployeeProject_Project]
GO
