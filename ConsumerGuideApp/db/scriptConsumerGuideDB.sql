USE [ConsumerGuideDB]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 28.05.2024 2:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Grade] [nvarchar](50) NULL,
	[Address] [nvarchar](255) NULL,
	[Phone] [nvarchar](50) NULL,
	[SpecializationID] [int] NULL,
	[OwnershipTypeID] [int] NULL,
	[WorkingHours] [nvarchar](255) NULL,
	[WorkingDays] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyServices]    Script Date: 28.05.2024 2:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyServices](
	[CompanyID] [int] NOT NULL,
	[ServiceID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OwnershipTypes]    Script Date: 28.05.2024 2:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OwnershipTypes](
	[OwnershipTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OwnershipTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceCategories]    Script Date: 28.05.2024 2:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceCategories](
	[ServiceCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 28.05.2024 2:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ServiceCategoryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specializations]    Script Date: 28.05.2024 2:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specializations](
	[SpecializationID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SpecializationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([CompanyID], [Name], [Grade], [Address], [Phone], [SpecializationID], [OwnershipTypeID], [WorkingHours], [WorkingDays]) VALUES (1, N'Компания А', N'Высший', N'ул. Ленина, д. 1', N'123-456-789', 1, 1, N'09:00-18:00', N'Пн-Пт')
INSERT [dbo].[Companies] ([CompanyID], [Name], [Grade], [Address], [Phone], [SpecializationID], [OwnershipTypeID], [WorkingHours], [WorkingDays]) VALUES (2, N'Компания Б', N'Первый', N'ул. Пушкина, д. 2', N'987-654-321', 2, 2, N'08:00-17:00', N'Пн-Сб')
INSERT [dbo].[Companies] ([CompanyID], [Name], [Grade], [Address], [Phone], [SpecializationID], [OwnershipTypeID], [WorkingHours], [WorkingDays]) VALUES (3, N'Компания В', N'Второй', N'ул. Гагарина, д. 3', N'456-789-123', 3, 3, N'10:00-19:00', N'Пн-Пт')
INSERT [dbo].[Companies] ([CompanyID], [Name], [Grade], [Address], [Phone], [SpecializationID], [OwnershipTypeID], [WorkingHours], [WorkingDays]) VALUES (4, N'Компания Г', N'Третий', N'ул. Чехова, д. 4', N'321-654-987', 4, 4, N'08:00-20:00', N'Пн-Вс')
INSERT [dbo].[Companies] ([CompanyID], [Name], [Grade], [Address], [Phone], [SpecializationID], [OwnershipTypeID], [WorkingHours], [WorkingDays]) VALUES (6, N'fsdfsd', N'fsdfsd', N'fsdfsd', N'34242', 1, 1, N'08:00-18:00', N'Пн, Вт, Ср')
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
INSERT [dbo].[CompanyServices] ([CompanyID], [ServiceID]) VALUES (1, 1)
INSERT [dbo].[CompanyServices] ([CompanyID], [ServiceID]) VALUES (2, 2)
INSERT [dbo].[CompanyServices] ([CompanyID], [ServiceID]) VALUES (3, 3)
INSERT [dbo].[CompanyServices] ([CompanyID], [ServiceID]) VALUES (4, 4)
INSERT [dbo].[CompanyServices] ([CompanyID], [ServiceID]) VALUES (6, 1)
INSERT [dbo].[CompanyServices] ([CompanyID], [ServiceID]) VALUES (6, 2)
INSERT [dbo].[CompanyServices] ([CompanyID], [ServiceID]) VALUES (6, 7)
GO
SET IDENTITY_INSERT [dbo].[OwnershipTypes] ON 

INSERT [dbo].[OwnershipTypes] ([OwnershipTypeID], [Name]) VALUES (1, N'Частная')
INSERT [dbo].[OwnershipTypes] ([OwnershipTypeID], [Name]) VALUES (2, N'Государственная')
INSERT [dbo].[OwnershipTypes] ([OwnershipTypeID], [Name]) VALUES (3, N'Муниципальная')
INSERT [dbo].[OwnershipTypes] ([OwnershipTypeID], [Name]) VALUES (4, N'Смешанная')
SET IDENTITY_INSERT [dbo].[OwnershipTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceCategories] ON 

INSERT [dbo].[ServiceCategories] ([ServiceCategoryID], [Name]) VALUES (1, N'Ремонт')
INSERT [dbo].[ServiceCategories] ([ServiceCategoryID], [Name]) VALUES (2, N'Уборка')
INSERT [dbo].[ServiceCategories] ([ServiceCategoryID], [Name]) VALUES (3, N'Образование')
INSERT [dbo].[ServiceCategories] ([ServiceCategoryID], [Name]) VALUES (4, N'Здравоохранение')
SET IDENTITY_INSERT [dbo].[ServiceCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([ServiceID], [Name], [Description], [ServiceCategoryID]) VALUES (1, N'Ремонт бытовой техники', N'Ремонт стиральных машин, холодильников и другой бытовой техники', 1)
INSERT [dbo].[Services] ([ServiceID], [Name], [Description], [ServiceCategoryID]) VALUES (2, N'Уборка помещений', N'Комплексная уборка жилых и нежилых помещений', 2)
INSERT [dbo].[Services] ([ServiceID], [Name], [Description], [ServiceCategoryID]) VALUES (3, N'Курсы английского языка', N'Обучение английскому языку для детей и взрослых', 3)
INSERT [dbo].[Services] ([ServiceID], [Name], [Description], [ServiceCategoryID]) VALUES (4, N'Медицинские консультации', N'Консультации врачей различных специальностей', 4)
INSERT [dbo].[Services] ([ServiceID], [Name], [Description], [ServiceCategoryID]) VALUES (7, N'авыавы', N'аываыв', 3)
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[Specializations] ON 

INSERT [dbo].[Specializations] ([SpecializationID], [Name]) VALUES (1, N'Ремонт бытовой техники')
INSERT [dbo].[Specializations] ([SpecializationID], [Name]) VALUES (2, N'Уборка помещений')
INSERT [dbo].[Specializations] ([SpecializationID], [Name]) VALUES (3, N'Курсы английского языка')
INSERT [dbo].[Specializations] ([SpecializationID], [Name]) VALUES (4, N'Медицинские консультации')
SET IDENTITY_INSERT [dbo].[Specializations] OFF
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD FOREIGN KEY([OwnershipTypeID])
REFERENCES [dbo].[OwnershipTypes] ([OwnershipTypeID])
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD FOREIGN KEY([SpecializationID])
REFERENCES [dbo].[Specializations] ([SpecializationID])
GO
ALTER TABLE [dbo].[CompanyServices]  WITH CHECK ADD  CONSTRAINT [FK__CompanySe__Compa__440B1D61] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Companies] ([CompanyID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompanyServices] CHECK CONSTRAINT [FK__CompanySe__Compa__440B1D61]
GO
ALTER TABLE [dbo].[CompanyServices]  WITH CHECK ADD  CONSTRAINT [FK__CompanySe__Servi__44FF419A] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Services] ([ServiceID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompanyServices] CHECK CONSTRAINT [FK__CompanySe__Servi__44FF419A]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD FOREIGN KEY([ServiceCategoryID])
REFERENCES [dbo].[ServiceCategories] ([ServiceCategoryID])
GO
