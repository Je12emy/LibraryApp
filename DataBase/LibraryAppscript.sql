USE [master]
GO
/****** Object:  Database [Library]    Script Date: 8/5/2019 1:24:51 PM ******/
CREATE DATABASE [Library]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.JEREMY\MSSQL\DATA\Library.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.JEREMY\MSSQL\DATA\Library_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Library] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Library] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Library] SET  MULTI_USER 
GO
ALTER DATABASE [Library] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Library] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Library]
GO
/****** Object:  Table [dbo].[Administracion.Bibliotecario]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administracion.Bibliotecario](
	[Usuario] [nvarchar](30) NULL,
	[Clave] [varchar](12) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libreria.Catalogo]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libreria.Catalogo](
	[CodigoLibro] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](90) NOT NULL,
	[Autor] [nvarchar](60) NOT NULL,
	[Disponibilidad] [bit] NOT NULL,
	[CodigoUbicacion] [int] NOT NULL,
 CONSTRAINT [PK_Libreria.Catalogo] PRIMARY KEY CLUSTERED 
(
	[CodigoLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libreria.Ubicacion]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libreria.Ubicacion](
	[CodigoUbicacion] [int] IDENTITY(1,1) NOT NULL,
	[Signatura] [nvarchar](30) NOT NULL,
	[Ubicacion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Libreria.Ubicacion] PRIMARY KEY CLUSTERED 
(
	[CodigoUbicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Socio.Informacion]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Socio.Informacion](
	[CodigoSocio] [int] IDENTITY(1,1) NOT NULL,
	[NombreSocio] [nvarchar](50) NOT NULL,
	[PrimerApellido] [nvarchar](50) NOT NULL,
	[SegundoApellido] [nvarchar](50) NOT NULL,
	[DireccionSocio] [nvarchar](60) NOT NULL,
	[EstadoSocio] [bit] NOT NULL,
	[Clave] [varchar](12) NOT NULL,
 CONSTRAINT [PK_Socio.Informacion] PRIMARY KEY CLUSTERED 
(
	[CodigoSocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Socio.Prestamo]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Socio.Prestamo](
	[CodigoPrestamo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoSocio] [int] NOT NULL,
	[CodigoLibro] [int] NOT NULL,
	[FechaPrestamo] [datetime] NOT NULL,
	[Estado] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Libreria.Catalogo]  WITH CHECK ADD  CONSTRAINT [FK_Libreria.Catalogo_Libreria.Ubicacion] FOREIGN KEY([CodigoUbicacion])
REFERENCES [dbo].[Libreria.Ubicacion] ([CodigoUbicacion])
GO
ALTER TABLE [dbo].[Libreria.Catalogo] CHECK CONSTRAINT [FK_Libreria.Catalogo_Libreria.Ubicacion]
GO
ALTER TABLE [dbo].[Socio.Prestamo]  WITH CHECK ADD  CONSTRAINT [FK_Socio.Prestamo_Libreria.Catalogo] FOREIGN KEY([CodigoLibro])
REFERENCES [dbo].[Libreria.Catalogo] ([CodigoLibro])
GO
ALTER TABLE [dbo].[Socio.Prestamo] CHECK CONSTRAINT [FK_Socio.Prestamo_Libreria.Catalogo]
GO
ALTER TABLE [dbo].[Socio.Prestamo]  WITH CHECK ADD  CONSTRAINT [FK_Socio.Prestamo_Socio.Informacion] FOREIGN KEY([CodigoSocio])
REFERENCES [dbo].[Socio.Informacion] ([CodigoSocio])
GO
ALTER TABLE [dbo].[Socio.Prestamo] CHECK CONSTRAINT [FK_Socio.Prestamo_Socio.Informacion]
GO
/****** Object:  StoredProcedure [dbo].[ComprobarEstadoSocio]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ComprobarEstadoSocio] @CodigoSocio int
AS
SELECT Socio.EstadoSocio as EstadoSocio FROM [Socio.Informacion] as Socio 
WHERE Socio.CodigoSocio = @CodigoSocio
GO
/****** Object:  StoredProcedure [dbo].[ConsultarPrestamos]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ConsultarPrestamos] @CodigoSocio int
AS

SELECT 
	Prestamo.CodigoPrestamo AS 'CodigoPrestamo',
	NombreSocio +' '+ PrimerApellido +' '+ SegundoApellido AS 'NombreSocio',
	Catalogo.Titulo AS 'NombreLibro',
	Prestamo.FechaPrestamo AS 'FechaPrestamo'
 FROM
	[Socio.Prestamo] as Prestamo left join [Socio.Informacion] as Socio 
	ON Prestamo.CodigoSocio = Socio.CodigoSocio
	left join [Libreria.Catalogo] as Catalogo ON 
	Prestamo.CodigoLibro = Catalogo.CodigoLibro
	WHERE Socio.CodigoSocio = @CodigoSocio 
	
	
GO
/****** Object:  StoredProcedure [dbo].[ContarPrestamos]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ContarPrestamos] @CodigoCliente int
AS
SELECT COUNT(*) FROM [Socio.Prestamo] WHERE CodigoSocio = @CodigoCliente AND Estado = 'True'
GO
/****** Object:  StoredProcedure [dbo].[HistorialSocio]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Se busca con el codigo del socio TODO su historial de prestamos --
CREATE PROC [dbo].[HistorialSocio] @CodigoSocio int
AS
  SELECT
    Prestamo.CodigoPrestamo,
    Catalogo.Titulo,
    Prestamo.Estado,
    Prestamo.FechaPrestamo
  FROM [Socio.Prestamo] AS Prestamo
  LEFT JOIN [Socio.Informacion] AS Socio
    ON Socio.CodigoSocio = Prestamo.CodigoSocio
  LEFT JOIN [Libreria.Catalogo] AS Catalogo
    ON Catalogo.CodigoLibro = Prestamo.CodigoLibro
  WHERE Prestamo.CodigoSocio = @CodigoSocio
GO
/****** Object:  StoredProcedure [dbo].[HistorialSocioActivos]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Se busca con el codigo del socio TODO su historial de prestamos --
CREATE PROC [dbo].[HistorialSocioActivos] @CodigoSocio int
AS
  SELECT
    Prestamo.CodigoPrestamo,
    Catalogo.Titulo,
    Prestamo.Estado,
    Prestamo.FechaPrestamo
  FROM [Socio.Prestamo] AS Prestamo
  LEFT JOIN [Socio.Informacion] AS Socio
    ON Socio.CodigoSocio = Prestamo.CodigoSocio
  LEFT JOIN [Libreria.Catalogo] AS Catalogo
    ON Catalogo.CodigoLibro = Prestamo.CodigoLibro
  WHERE Prestamo.CodigoSocio = @CodigoSocio AND Prestamo.Estado = '1'
GO
/****** Object:  StoredProcedure [dbo].[HistorialSocioInactivos]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Se busca con el codigo del socio TODO su historial de prestamos --
CREATE PROC [dbo].[HistorialSocioInactivos] @CodigoSocio int
AS
  SELECT
    Prestamo.CodigoPrestamo,
    Catalogo.Titulo,
    Prestamo.Estado,
    Prestamo.FechaPrestamo
  FROM [Socio.Prestamo] AS Prestamo
  LEFT JOIN [Socio.Informacion] AS Socio
    ON Socio.CodigoSocio = Prestamo.CodigoSocio
  LEFT JOIN [Libreria.Catalogo] AS Catalogo
    ON Catalogo.CodigoLibro = Prestamo.CodigoLibro
  WHERE Prestamo.CodigoSocio = @CodigoSocio AND Prestamo.Estado = '0'
GO
/****** Object:  StoredProcedure [dbo].[UbicarLibro]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UbicarLibro] @CodigoLibro int
AS
  SELECT
    Catalogo.Titulo AS 'NombreLibro',
    Catalogo.Autor AS 'Autor',
    Catalogo.Disponibilidad AS 'Disponibilidad',
    Ubicacion.Ubicacion AS 'Ubicacion',
    Ubicacion.Signatura AS 'Signatura'
  FROM [Libreria.Catalogo] AS Catalogo
  LEFT JOIN [Libreria.Ubicacion] AS Ubicacion
    ON Ubicacion.CodigoUbicacion = Catalogo.CodigoUbicacion
  WHERE Catalogo.CodigoLibro = @CodigoLibro
GO
/****** Object:  StoredProcedure [dbo].[VerificarBibliotecario]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[VerificarBibliotecario] @Usuario nvarchar(30), @Clave varchar(12)
AS
  SELECT
    CASE
      WHEN EXISTS (SELECT
          *
        FROM [Administracion.Bibliotecario]
        WHERE Usuario = @Usuario
        AND Clave = @Clave) THEN CAST(1 AS bit)
      ELSE CAST(0 AS bit)
    END
GO
/****** Object:  StoredProcedure [dbo].[VerificarSocio]    Script Date: 8/5/2019 1:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[VerificarSocio] @CodigoSocio int, @Clave nvarchar(12)
AS
  SELECT
    CASE
      WHEN EXISTS (SELECT
          *
        FROM [Socio.Informacion]
        WHERE CodigoSocio = @CodigoSocio AND
		Clave = @Clave
		) 
		THEN CAST(1 AS bit)
		ELSE CAST(0 AS bit)
    END
GO
USE [master]
GO
ALTER DATABASE [Library] SET  READ_WRITE 
GO
