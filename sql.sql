USE [DB_GeoLocalizador]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/11/2021 11:46:08 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GeoPositions]    Script Date: 11/11/2021 11:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeoPositions](
	[IdPosition] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Latitude] [nvarchar](max) NULL,
	[Longitude] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
	[Number] [int] NOT NULL,
	[ZipCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_GeoPositions] PRIMARY KEY CLUSTERED 
(
	[IdPosition] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Harbors]    Script Date: 11/11/2021 11:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Harbors](
	[IdHarbor] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Latitude] [nvarchar](max) NULL,
	[Longitude] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[UrlPhoto] [nvarchar](max) NULL,
	[IdMarineTraffic] [int] NULL,
	[LogDate] [datetime2](7) NOT NULL,
	[LastChange] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Harbors] PRIMARY KEY CLUSTERED 
(
	[IdHarbor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TruckGeoPositions]    Script Date: 11/11/2021 11:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TruckGeoPositions](
	[IdPosition] [int] IDENTITY(1,1) NOT NULL,
	[IdTruck] [int] NOT NULL,
	[TruckIdTruck] [int] NULL,
	[Latitude] [nvarchar](max) NULL,
	[Longitude] [nvarchar](max) NULL,
	[Speed] [int] NOT NULL,
	[SignalQuality] [nvarchar](max) NULL,
	[Satellites] [int] NOT NULL,
	[Altitude] [int] NOT NULL,
	[AltitudeUnits] [nvarchar](1) NOT NULL,
	[GeoSep] [real] NOT NULL,
	[GeoSepUnits] [nvarchar](1) NOT NULL,
	[AgeGpsData] [nvarchar](max) NULL,
	[RefStationId] [nvarchar](max) NULL,
	[LogDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TruckGeoPositions] PRIMARY KEY CLUSTERED 
(
	[IdPosition] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TruckInfos]    Script Date: 11/11/2021 11:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TruckInfos](
	[IdTruck] [int] IDENTITY(1,1) NOT NULL,
	[LicensePlate] [nvarchar](max) NULL,
	[Carrier] [nvarchar](max) NULL,
	[VolumeCapacity] [int] NOT NULL,
	[WeightCapacity] [int] NOT NULL,
	[Model] [nvarchar](max) NULL,
	[LogDate] [datetime2](7) NOT NULL,
	[LastUpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TruckInfos] PRIMARY KEY CLUSTERED 
(
	[IdTruck] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TruckTravels]    Script Date: 11/11/2021 11:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TruckTravels](
	[IdTravel] [int] IDENTITY(1,1) NOT NULL,
	[IdOrigin] [int] NOT NULL,
	[OriginIdPosition] [int] NULL,
	[IdDestination] [int] NOT NULL,
	[DestinationIdPosition] [int] NULL,
	[IdTruck] [int] NOT NULL,
	[TruckIdTruck] [int] NULL,
	[Cargo] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[LogDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TruckTravels] PRIMARY KEY CLUSTERED 
(
	[IdTravel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/11/2021 11:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VesselGeoPositions]    Script Date: 11/11/2021 11:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VesselGeoPositions](
	[IdPosition] [int] IDENTITY(1,1) NOT NULL,
	[IdVesselInfo] [int] NOT NULL,
	[VesselInfoIdNavio] [int] NULL,
	[LastPositionReceived] [datetime2](7) NULL,
	[LocationArea] [nvarchar](max) NULL,
	[Current_Port] [nvarchar](max) NULL,
	[Latitude] [decimal](18, 2) NOT NULL,
	[Longitude] [decimal](18, 2) NOT NULL,
	[Status] [nvarchar](max) NULL,
	[SpeedCourse] [nvarchar](max) NULL,
	[AISSource] [nvarchar](max) NULL,
	[LogDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_VesselGeoPositions] PRIMARY KEY CLUSTERED 
(
	[IdPosition] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VesselInfos]    Script Date: 11/11/2021 11:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VesselInfos](
	[IdNavio] [int] IDENTITY(1,1) NOT NULL,
	[IMO] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Vessel_Type_Generic] [nvarchar](max) NULL,
	[Vessel_Type_Detailed] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[MMSI] [int] NOT NULL,
	[Call_Sign] [nvarchar](max) NULL,
	[Flag] [nvarchar](max) NULL,
	[Gross_Tonnage] [nvarchar](max) NULL,
	[LengthxBreadth] [nvarchar](max) NULL,
	[Year_Built] [int] NOT NULL,
	[Home_Port] [nvarchar](max) NULL,
	[LogDate] [datetime2](7) NOT NULL,
	[LastChange] [datetime2](7) NULL,
 CONSTRAINT [PK_VesselInfos] PRIMARY KEY CLUSTERED 
(
	[IdNavio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VesselTravels]    Script Date: 11/11/2021 11:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VesselTravels](
	[IdTravel] [int] IDENTITY(1,1) NOT NULL,
	[IdOrigin] [int] NOT NULL,
	[OriginIdHarbor] [int] NULL,
	[IdDestination] [int] NOT NULL,
	[DestinationIdHarbor] [int] NULL,
	[IdVessel] [int] NOT NULL,
	[VesselIdNavio] [int] NULL,
	[Cargo] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[LogDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_VesselTravels] PRIMARY KEY CLUSTERED 
(
	[IdTravel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[TruckTravels] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [LogDate]
GO
ALTER TABLE [dbo].[VesselTravels] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [LogDate]
GO
ALTER TABLE [dbo].[TruckGeoPositions]  WITH CHECK ADD  CONSTRAINT [FK_TruckGeoPositions_TruckInfos_TruckIdTruck] FOREIGN KEY([TruckIdTruck])
REFERENCES [dbo].[TruckInfos] ([IdTruck])
GO
ALTER TABLE [dbo].[TruckGeoPositions] CHECK CONSTRAINT [FK_TruckGeoPositions_TruckInfos_TruckIdTruck]
GO
ALTER TABLE [dbo].[TruckTravels]  WITH CHECK ADD  CONSTRAINT [FK_TruckTravels_GeoPositions_DestinationIdPosition] FOREIGN KEY([DestinationIdPosition])
REFERENCES [dbo].[GeoPositions] ([IdPosition])
GO
ALTER TABLE [dbo].[TruckTravels] CHECK CONSTRAINT [FK_TruckTravels_GeoPositions_DestinationIdPosition]
GO
ALTER TABLE [dbo].[TruckTravels]  WITH CHECK ADD  CONSTRAINT [FK_TruckTravels_GeoPositions_OriginIdPosition] FOREIGN KEY([OriginIdPosition])
REFERENCES [dbo].[GeoPositions] ([IdPosition])
GO
ALTER TABLE [dbo].[TruckTravels] CHECK CONSTRAINT [FK_TruckTravels_GeoPositions_OriginIdPosition]
GO
ALTER TABLE [dbo].[TruckTravels]  WITH CHECK ADD  CONSTRAINT [FK_TruckTravels_TruckInfos_TruckIdTruck] FOREIGN KEY([TruckIdTruck])
REFERENCES [dbo].[TruckInfos] ([IdTruck])
GO
ALTER TABLE [dbo].[TruckTravels] CHECK CONSTRAINT [FK_TruckTravels_TruckInfos_TruckIdTruck]
GO
ALTER TABLE [dbo].[VesselGeoPositions]  WITH CHECK ADD  CONSTRAINT [FK_VesselGeoPositions_VesselInfos_VesselInfoIdNavio] FOREIGN KEY([VesselInfoIdNavio])
REFERENCES [dbo].[VesselInfos] ([IdNavio])
GO
ALTER TABLE [dbo].[VesselGeoPositions] CHECK CONSTRAINT [FK_VesselGeoPositions_VesselInfos_VesselInfoIdNavio]
GO
ALTER TABLE [dbo].[VesselTravels]  WITH CHECK ADD  CONSTRAINT [FK_VesselTravels_Harbors_DestinationIdHarbor] FOREIGN KEY([DestinationIdHarbor])
REFERENCES [dbo].[Harbors] ([IdHarbor])
GO
ALTER TABLE [dbo].[VesselTravels] CHECK CONSTRAINT [FK_VesselTravels_Harbors_DestinationIdHarbor]
GO
ALTER TABLE [dbo].[VesselTravels]  WITH CHECK ADD  CONSTRAINT [FK_VesselTravels_Harbors_OriginIdHarbor] FOREIGN KEY([OriginIdHarbor])
REFERENCES [dbo].[Harbors] ([IdHarbor])
GO
ALTER TABLE [dbo].[VesselTravels] CHECK CONSTRAINT [FK_VesselTravels_Harbors_OriginIdHarbor]
GO
ALTER TABLE [dbo].[VesselTravels]  WITH CHECK ADD  CONSTRAINT [FK_VesselTravels_VesselInfos_VesselIdNavio] FOREIGN KEY([VesselIdNavio])
REFERENCES [dbo].[VesselInfos] ([IdNavio])
GO
ALTER TABLE [dbo].[VesselTravels] CHECK CONSTRAINT [FK_VesselTravels_VesselInfos_VesselIdNavio]
GO

GO
SET IDENTITY_INSERT [dbo].[Harbors] ON 

INSERT [dbo].[Harbors] ([IdHarbor], [Name], [Latitude], [Longitude], [Country], [UrlPhoto], [IdMarineTraffic], [LogDate], [LastChange]) VALUES (4, N'Santos Harbor', N'-23.95109', N'-46.35358', N'Brasil', N'https://photos.marinetraffic.com/ais/showphoto.aspx?photoid=329451', 189, CAST(N'2021-11-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Harbors] OFF
SET IDENTITY_INSERT [dbo].[VesselInfos] ON 

INSERT [dbo].[VesselInfos] ([IdNavio], [IMO], [Name], [Vessel_Type_Generic], [Vessel_Type_Detailed], [Status], [MMSI], [Call_Sign], [Flag], [Gross_Tonnage], [LengthxBreadth], [Year_Built], [Home_Port], [LogDate], [LastChange]) VALUES (1, N'9358060', N'SEA CARGO EXPRESS', N'Cargo', N'Ro-Ro Cargo', N'Active', 229061000, N'9HA3034', N'Malta ', N'6693', N'4894', 2012, N'VALLETTA', CAST(N'2021-11-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-09T10:38:58.8285700' AS DateTime2))
SET IDENTITY_INSERT [dbo].[VesselInfos] OFF
SET IDENTITY_INSERT [dbo].[VesselGeoPositions] ON 

INSERT [dbo].[VesselGeoPositions] ([IdPosition], [IdVesselInfo], [VesselInfoIdNavio], [LastPositionReceived], [LocationArea], [Current_Port], [Latitude], [Longitude], [Status], [SpeedCourse], [AISSource], [LogDate]) VALUES (1, 1, 1, CAST(N'2021-11-01T20:09:00.0000000' AS DateTime2), N'NORDIC - North Sea', N'-', CAST(5877081.00 AS Decimal(18, 2)), CAST(4459502.00 AS Decimal(18, 2)), N'Underway using Engine', N'13.9 kn / 53 °', N'154 rayjak', CAST(N'2021-11-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[VesselGeoPositions] OFF
SET IDENTITY_INSERT [dbo].[GeoPositions] ON 

INSERT [dbo].[GeoPositions] ([IdPosition], [Name], [Latitude], [Longitude], [Country], [State], [City], [Street], [Number], [ZipCode]) VALUES (1, N'São Judas', N'0', N'0', N'Brasil', N'São Paulo', N'São Paulo', N'Rua Taquari', 300, N'00000-00')
INSERT [dbo].[GeoPositions] ([IdPosition], [Name], [Latitude], [Longitude], [Country], [State], [City], [Street], [Number], [ZipCode]) VALUES (2, N'São Judas', N'0', N'0', N'Brasil', N'São Paulo', N'São Paulo', N'Rua Taquari', 300, N'00000-00')
SET IDENTITY_INSERT [dbo].[GeoPositions] OFF
SET IDENTITY_INSERT [dbo].[TruckInfos] ON 

INSERT [dbo].[TruckInfos] ([IdTruck], [LicensePlate], [Carrier], [VolumeCapacity], [WeightCapacity], [Model], [LogDate], [LastUpdateDate]) VALUES (2, N'HGG-0290', N'ABC CARGAS LTDA', 1000, 5000, N'Scania R 540 A6x4NZ', CAST(N'2021-11-08T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TruckInfos] ([IdTruck], [LicensePlate], [Carrier], [VolumeCapacity], [WeightCapacity], [Model], [LogDate], [LastUpdateDate]) VALUES (1002, N'EEG-2021', N'LOTS LATIN AMERICA', 1000, 5000, N'VOLKSWAGEN 24250', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TruckInfos] OFF
SET IDENTITY_INSERT [dbo].[TruckTravels] ON 

INSERT [dbo].[TruckTravels] ([IdTravel], [IdOrigin], [OriginIdPosition], [IdDestination], [DestinationIdPosition], [IdTruck], [TruckIdTruck], [Cargo], [Status], [LogDate]) VALUES (1, 1, NULL, 2, NULL, 2, NULL, N'Carga de Bateria', N'EM TRASNPORTE', CAST(N'2021-11-09T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TruckTravels] OFF
SET IDENTITY_INSERT [dbo].[TruckGeoPositions] ON 

INSERT [dbo].[TruckGeoPositions] ([IdPosition], [IdTruck], [TruckIdTruck], [Latitude], [Longitude], [Speed], [SignalQuality], [Satellites], [Altitude], [AltitudeUnits], [GeoSep], [GeoSepUnits], [AgeGpsData], [RefStationId], [LogDate]) VALUES (2, 2, NULL, N'-23.56137094175366', N'-46.78897417874751', 0, N'0', 0, 0, N'M', 0, N'M', N'0', N'0', CAST(N'2021-11-09T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TruckGeoPositions] OFF
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211101195315_InitialCreation', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211101200721_ChangeTypeLatLon', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211105005813_TruckInformations', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211109190747_Adding-Travel', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211109195405_Adding-Travel-2', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211109220803_Adding-Travel-3', N'5.0.11')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Surname], [Username], [Password], [Role], [Status]) VALUES (1, N'Juan', N'Panighel', N'ssbjvq', N'ssbjvq', N'admin', 1)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Username], [Password], [Role], [Status]) VALUES (2, N'Juan2', N'Panighel', N'ssbjvq2', N'ssbjvq2', N'user', 1)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Username], [Password], [Role], [Status]) VALUES (1002, N'Jorge', N'Jorginho', N'jorginho69', N'1234', N'admin', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF

