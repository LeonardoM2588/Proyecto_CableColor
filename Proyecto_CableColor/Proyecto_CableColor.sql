USE [master]
GO
/****** Object:  Database [Proyecto_CableColor]    Script Date: 31/08/2023 8:27:43 ******/
CREATE DATABASE [Proyecto_CableColor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Proyecto_CableColor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Proyecto_CableColor.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Proyecto_CableColor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Proyecto_CableColor_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Proyecto_CableColor] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Proyecto_CableColor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Proyecto_CableColor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET ARITHABORT OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Proyecto_CableColor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Proyecto_CableColor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Proyecto_CableColor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Proyecto_CableColor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Proyecto_CableColor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Proyecto_CableColor] SET  MULTI_USER 
GO
ALTER DATABASE [Proyecto_CableColor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Proyecto_CableColor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Proyecto_CableColor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Proyecto_CableColor] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Proyecto_CableColor] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER AUTHORIZATION ON DATABASE::[Proyecto_CableColor] TO [LeonardoM]
GO
USE [Proyecto_CableColor]
GO
/****** Object:  Table [dbo].[Cargos]    Script Date: 31/08/2023 8:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cargos](
	[Cod_Cargo] [int] NOT NULL,
	[Cod_Depto_Emp] [int] NOT NULL,
	[Cargo] [varchar](75) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[UsuarioCreacion] [varchar](50) NOT NULL,
	[FechaModificacion] [date] NULL,
	[UsuarioModificacion] [varchar](50) NULL,
 CONSTRAINT [PK__Cargos__BC3BC2E7468F1F71] PRIMARY KEY CLUSTERED 
(
	[Cod_Cargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Cargos] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[Cod_Cliente] [int] NOT NULL,
	[Nombre_Cliente] [varchar](150) NOT NULL,
	[Identidad_Cliente] [varchar](15) NOT NULL,
	[Celular] [varchar](14) NOT NULL,
	[Fecha_Nacimiento] [date] NOT NULL,
	[Cod_Genero] [int] NOT NULL,
	[Cod_EstadoCivil] [int] NOT NULL,
	[Cod_Nacionalidad] [int] NOT NULL,
	[IDSECTOR] [int] NOT NULL,
	[Referencia_Direccion] [varchar](max) NOT NULL,
	[Referencia_Personal] [varchar](150) NOT NULL,
	[Numero_Referencia] [varchar](14) NOT NULL,
	[Cod_Paquete] [int] NOT NULL,
	[Contrato_Anual] [bit] NOT NULL,
	[Observacion] [varchar](max) NOT NULL,
	[Contrato_Fisico] [varchar](8) NOT NULL,
	[Factura_Fisica] [varchar](8) NOT NULL,
	[Fecha_Maxima_Pago] [varchar](50) NOT NULL,
	[Vendedor] [varchar](150) NOT NULL,
	[Fecha_Elaborado] [date] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [date] NULL,
	[UsuarioCreacion] [varchar](50) NULL,
	[FechaModificacion] [date] NULL,
	[UsuarioModificacion] [varchar](50) NULL,
 CONSTRAINT [PK__Clientes__4418E207C85B165C] PRIMARY KEY CLUSTERED 
(
	[Cod_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Clientes] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Clientes_Prospectos]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes_Prospectos](
	[Cod_Cliente_Prospecto] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Cod_Paquete] [int] NOT NULL,
	[Fecha_Estimada_Contratar] [date] NOT NULL,
	[Celular] [varchar](15) NULL,
	[Cod_Empleado] [int] NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[UsuarioCreacion] [varchar](50) NOT NULL,
	[FechaModificacion] [date] NULL,
	[UsuarioModificacion] [varchar](50) NULL,
 CONSTRAINT [PK__Clientes__037AE764FF8DB66D] PRIMARY KEY CLUSTERED 
(
	[Cod_Cliente_Prospecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Clientes_Prospectos] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departamento](
	[IDDEPARTAMENTO] [int] NOT NULL,
	[DEPARTAMENTO] [varchar](75) NOT NULL,
	[IDPAIS] [int] NOT NULL,
 CONSTRAINT [PK__Departam__B529B33727D6125D] PRIMARY KEY CLUSTERED 
(
	[IDDEPARTAMENTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Departamento] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Departamento_Emp]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departamento_Emp](
	[Cod_Depto_Emp] [int] NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[UsuarioCreacion] [varchar](50) NOT NULL,
	[FechaModificacion] [date] NULL,
	[UsuarioModificacion] [varchar](50) NULL,
 CONSTRAINT [PK__Departam__DF3F77EAB5C8EA42] PRIMARY KEY CLUSTERED 
(
	[Cod_Depto_Emp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Departamento_Emp] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleados](
	[Cod_Empleado] [int] NOT NULL,
	[Identidad_Empleado] [varchar](15) NOT NULL,
	[Nombre_Empleado] [varchar](75) NOT NULL,
	[Edad] [int] NOT NULL,
	[Fecha_Nacimiento] [date] NOT NULL,
	[Cod_Genero] [int] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Telefono] [varchar](12) NOT NULL,
	[Cod_EstadoCivil] [int] NOT NULL,
	[IDMUNICIPIO] [int] NOT NULL,
	[Num_Contador] [varchar](12) NOT NULL,
	[Propietario_Vivienda] [bit] NOT NULL,
	[Cod_Cargo] [int] NOT NULL,
	[Cod_Turno] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[UsuarioCreacion] [varchar](50) NOT NULL,
	[FechaModificacion] [date] NULL,
	[UsuarioModificacion] [varchar](50) NULL,
 CONSTRAINT [PK__Empleado__18E3932909D5BB90] PRIMARY KEY CLUSTERED 
(
	[Cod_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Empleados] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Estado_Civil]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estado_Civil](
	[Cod_EstadoCivil] [int] NOT NULL,
	[Estado_Civil] [varchar](75) NOT NULL,
 CONSTRAINT [PK__Estado_C__1183700EE9022CAE] PRIMARY KEY CLUSTERED 
(
	[Cod_EstadoCivil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Estado_Civil] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Generos]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Generos](
	[Cod_Genero] [int] NOT NULL,
	[Genero] [varchar](75) NOT NULL,
 CONSTRAINT [PK__Generos__B2FF3FDB3AFCB4DC] PRIMARY KEY CLUSTERED 
(
	[Cod_Genero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Generos] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Municipio]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Municipio](
	[IDMUNICIPIO] [int] NOT NULL,
	[MUNICIPIO] [varchar](75) NOT NULL,
	[IDDEPARTAMENTO] [int] NOT NULL,
 CONSTRAINT [PK__Municipi__FDA66C58882A2742] PRIMARY KEY CLUSTERED 
(
	[IDMUNICIPIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Municipio] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Nacionalidad]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nacionalidad](
	[Cod_Nacionalidad] [int] NOT NULL,
	[Nacionalidad] [varchar](75) NOT NULL,
 CONSTRAINT [PK__Nacional__AA8953E0EDD9DF73] PRIMARY KEY CLUSTERED 
(
	[Cod_Nacionalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Nacionalidad] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Nivel_Acceso]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nivel_Acceso](
	[IdNivelUser] [int] NOT NULL,
	[Nivel_Acceso] [varchar](75) NOT NULL,
 CONSTRAINT [PK__Nivel_Ac__4203CFEC5A661BFE] PRIMARY KEY CLUSTERED 
(
	[IdNivelUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Nivel_Acceso] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Orden_Instalacion]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orden_Instalacion](
	[Cod_Cliente_Pendiente] [int] NOT NULL,
	[Cod_Cliente] [int] NOT NULL,
	[Fecha_Instalacion] [date] NOT NULL,
	[Cod_Empleado] [int] NOT NULL,
	[Telefono] [varchar](15) NOT NULL,
	[FechaCreacion] [date] NULL,
	[UsuarioCreacion] [varchar](50) NULL,
	[FechaModificacion] [date] NULL,
	[UsuarioModificacion] [varchar](50) NULL,
 CONSTRAINT [PK__Orden_In__92D55B54756C7747] PRIMARY KEY CLUSTERED 
(
	[Cod_Cliente_Pendiente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Orden_Instalacion] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Ordenes_Mantenimiento]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ordenes_Mantenimiento](
	[Cod_Orden_Mant] [int] NOT NULL,
	[Cod_Cliente] [int] NOT NULL,
	[Fecha_Mantenimiento] [date] NOT NULL,
	[Cod_Empleado] [int] NOT NULL,
	[Telefono] [varchar](15) NOT NULL,
	[FechaCreacion] [date] NULL,
	[UsuarioCreacion] [varchar](50) NULL,
	[FechaModificacion] [date] NULL,
	[UsuarioModificacion] [varchar](50) NULL,
 CONSTRAINT [PK__Ordenes___881682F15687F0DE] PRIMARY KEY CLUSTERED 
(
	[Cod_Orden_Mant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Ordenes_Mantenimiento] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pais](
	[IDPAIS] [int] NOT NULL,
	[ISO] [char](2) NOT NULL,
	[PAIS] [varchar](75) NOT NULL,
 CONSTRAINT [PK__Pais__A38A9449C30F2BA6] PRIMARY KEY CLUSTERED 
(
	[IDPAIS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Pais] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Paquetes]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Paquetes](
	[Cod_Paquete] [int] NOT NULL,
	[Cod_TipoPaquete] [int] NOT NULL,
	[Paquete] [varchar](75) NOT NULL,
	[Precio_Paquete] [varchar](10) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK__Paquetes__6B728F99554B167D] PRIMARY KEY CLUSTERED 
(
	[Cod_Paquete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Paquetes] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Sector]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sector](
	[IDSECTOR] [int] NOT NULL,
	[SECTOR] [varchar](75) NOT NULL,
	[IdTipoSector] [int] NOT NULL,
	[IDMUNICIPIO] [int] NOT NULL,
 CONSTRAINT [PK__Sector__26BAA6440BA58AD3] PRIMARY KEY CLUSTERED 
(
	[IDSECTOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Sector] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Tipo_Paquete]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipo_Paquete](
	[Cod_TipoPaquete] [int] NOT NULL,
	[Tipo_Paquete] [varchar](50) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[UsuarioCreacion] [varchar](50) NOT NULL,
	[FechaModificacion] [date] NULL,
	[UsuarioModificacion] [varchar](50) NULL,
 CONSTRAINT [PK__Tipo_Paq__C688D131CEABB399] PRIMARY KEY CLUSTERED 
(
	[Cod_TipoPaquete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Tipo_Paquete] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[TipoSector]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoSector](
	[IdTipoSector] [int] NOT NULL,
	[TipoSector] [varchar](75) NOT NULL,
 CONSTRAINT [PK__TipoSect__84B9D4B89871B5A6] PRIMARY KEY CLUSTERED 
(
	[IdTipoSector] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[TipoSector] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Turnos](
	[Cod_Turno] [int] NOT NULL,
	[Turno] [varchar](75) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
 CONSTRAINT [PK__Turnos__44BEB8E22C6294A5] PRIMARY KEY CLUSTERED 
(
	[Cod_Turno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Turnos] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Cod_Usuario] [int] NOT NULL,
	[Cod_Empleado] [int] NOT NULL,
	[Usuario] [varchar](75) NOT NULL,
	[Contrasena] [varchar](200) NOT NULL,
	[IdNivelUser] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK__Usuarios__D16E26A6FE357061] PRIMARY KEY CLUSTERED 
(
	[Cod_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Usuarios] TO  SCHEMA OWNER 
GO
INSERT [dbo].[Cargos] ([Cod_Cargo], [Cod_Depto_Emp], [Cargo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (1, 1, N'Jefe IT', CAST(N'2023-06-18' AS Date), N'Administrador', NULL, NULL)
INSERT [dbo].[Cargos] ([Cod_Cargo], [Cod_Depto_Emp], [Cargo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (2, 2, N'Ejecutivo De Venta Residencial', CAST(N'2023-07-04' AS Date), N'Administrador', NULL, NULL)
INSERT [dbo].[Cargos] ([Cod_Cargo], [Cod_Depto_Emp], [Cargo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (3, 2, N'Administrador De Ventas Residenciales', CAST(N'2023-07-13' AS Date), N'Administrador', NULL, NULL)
INSERT [dbo].[Cargos] ([Cod_Cargo], [Cod_Depto_Emp], [Cargo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (4, 2, N'Supervisor De Ventas Residencial', CAST(N'2023-07-13' AS Date), N'Administrador', NULL, NULL)
INSERT [dbo].[Cargos] ([Cod_Cargo], [Cod_Depto_Emp], [Cargo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (5, 1, N'Asistente De IT', CAST(N'2023-08-14' AS Date), N'Administrador', NULL, NULL)
INSERT [dbo].[Clientes] ([Cod_Cliente], [Nombre_Cliente], [Identidad_Cliente], [Celular], [Fecha_Nacimiento], [Cod_Genero], [Cod_EstadoCivil], [Cod_Nacionalidad], [IDSECTOR], [Referencia_Direccion], [Referencia_Personal], [Numero_Referencia], [Cod_Paquete], [Contrato_Anual], [Observacion], [Contrato_Fisico], [Factura_Fisica], [Fecha_Maxima_Pago], [Vendedor], [Fecha_Elaborado], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (1, N'Ilse Daniela Carcamo', N'1709-2000-00359', N'3252-6522', CAST(N'2000-06-09' AS Date), 2, 1, 1, 1, N'Del lado nor-oeste del campamento de la ENEE 20 metros al sur y 20 metros al oeste', N'Lizzy Flores', N'3252-2145', 1, 1, N'Paga mes de agosto 2023 instalacion y 3 tv adicionales gratis, cliente solicita modem wifi, dias restantes del mes de junio y mes de julio 2023 gratis autorizado por gerencia general, enviar credenciales al correo DaniCarcamo8200@gmail.com', N'559218', N'13845521', N'15 De Cada Mes', N'Edwin Leonardo Molina Flores', CAST(N'2023-06-25' AS Date), 1, CAST(N'2023-06-25' AS Date), N'LeonardoM', NULL, NULL)
INSERT [dbo].[Clientes] ([Cod_Cliente], [Nombre_Cliente], [Identidad_Cliente], [Celular], [Fecha_Nacimiento], [Cod_Genero], [Cod_EstadoCivil], [Cod_Nacionalidad], [IDSECTOR], [Referencia_Direccion], [Referencia_Personal], [Numero_Referencia], [Cod_Paquete], [Contrato_Anual], [Observacion], [Contrato_Fisico], [Factura_Fisica], [Fecha_Maxima_Pago], [Vendedor], [Fecha_Elaborado], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (2, N'Alondra Espadas', N'1709-2001-00541', N'3255-4512', CAST(N'2001-01-15' AS Date), 2, 1, 1, 3, N'Del lado nor-oeste del campamento de la ENEE 20 metros al sur y 20 metros al oeste', N'Andrea Funez', N'0000-0000', 1, 1, N'asdasd', N'559219', N'13845522', N'15 De Cada Mes', N'Edwin Leonardo Molina Flores', CAST(N'2023-06-25' AS Date), 1, CAST(N'2023-06-25' AS Date), N'LeonardoM', NULL, NULL)
INSERT [dbo].[Clientes] ([Cod_Cliente], [Nombre_Cliente], [Identidad_Cliente], [Celular], [Fecha_Nacimiento], [Cod_Genero], [Cod_EstadoCivil], [Cod_Nacionalidad], [IDSECTOR], [Referencia_Direccion], [Referencia_Personal], [Numero_Referencia], [Cod_Paquete], [Contrato_Anual], [Observacion], [Contrato_Fisico], [Factura_Fisica], [Fecha_Maxima_Pago], [Vendedor], [Fecha_Elaborado], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (3, N'Andrea Medina', N'1709-2002-00541', N'3252-6522', CAST(N'2002-03-15' AS Date), 2, 1, 1, 3, N'Del lado nor-oeste del campamento de la ENEE 20 metros al sur y 20 metros al oeste', N'Andrea Funez', N'0000-0000', 1, 1, N'asdasd', N'559219', N'13845522', N'15 De Cada Mes', N'Edwin Leonardo Molina Flores', CAST(N'2023-06-25' AS Date), 1, CAST(N'2023-06-25' AS Date), N'LeonardoM', NULL, NULL)
INSERT [dbo].[Clientes] ([Cod_Cliente], [Nombre_Cliente], [Identidad_Cliente], [Celular], [Fecha_Nacimiento], [Cod_Genero], [Cod_EstadoCivil], [Cod_Nacionalidad], [IDSECTOR], [Referencia_Direccion], [Referencia_Personal], [Numero_Referencia], [Cod_Paquete], [Contrato_Anual], [Observacion], [Contrato_Fisico], [Factura_Fisica], [Fecha_Maxima_Pago], [Vendedor], [Fecha_Elaborado], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (4, N'Josefa Garcia', N'1709-2003-00541', N'3255-4512', CAST(N'2003-12-15' AS Date), 2, 1, 1, 3, N'Del lado nor-oeste del campamento de la ENEE 20 metros al sur y 20 metros al oeste', N'Andrea Funez', N'0000-0000', 1, 1, N'asdasd', N'559219', N'13845522', N'15 De Cada Mes', N'Edwin Leonardo Molina Flores', CAST(N'2023-06-25' AS Date), 1, CAST(N'2023-06-25' AS Date), N'LeonardoM', NULL, NULL)
INSERT [dbo].[Clientes] ([Cod_Cliente], [Nombre_Cliente], [Identidad_Cliente], [Celular], [Fecha_Nacimiento], [Cod_Genero], [Cod_EstadoCivil], [Cod_Nacionalidad], [IDSECTOR], [Referencia_Direccion], [Referencia_Personal], [Numero_Referencia], [Cod_Paquete], [Contrato_Anual], [Observacion], [Contrato_Fisico], [Factura_Fisica], [Fecha_Maxima_Pago], [Vendedor], [Fecha_Elaborado], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (5, N'Ylla Xiomara Pereira Morazani', N'1709-1999-00541', N'3252-6522', CAST(N'1999-09-15' AS Date), 2, 1, 1, 3, N'Del lado nor-oeste del campamento de la ENEE 20 metros al sur y 20 metros al oeste', N'Andrea Funez', N'0000-0000', 1, 1, N'asdasd', N'559219', N'13845522', N'15 De Cada Mes', N'Edwin Leonardo Molina Flores', CAST(N'2023-06-25' AS Date), 1, CAST(N'2023-06-25' AS Date), N'LeonardoM', CAST(N'2023-08-14' AS Date), N'Administrador')
INSERT [dbo].[Clientes] ([Cod_Cliente], [Nombre_Cliente], [Identidad_Cliente], [Celular], [Fecha_Nacimiento], [Cod_Genero], [Cod_EstadoCivil], [Cod_Nacionalidad], [IDSECTOR], [Referencia_Direccion], [Referencia_Personal], [Numero_Referencia], [Cod_Paquete], [Contrato_Anual], [Observacion], [Contrato_Fisico], [Factura_Fisica], [Fecha_Maxima_Pago], [Vendedor], [Fecha_Elaborado], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (6, N'María Del Carmen Hernández Salazar', N'1709-1999-00541', N'3252-6522', CAST(N'1999-09-15' AS Date), 2, 1, 1, 3, N'Del lado nor-oeste del campamento de la ENEE 20 metros al sur y 20 metros al oeste', N'Andrea Funez', N'0000-0000', 1, 1, N'asdasd', N'559219', N'13845522', N'15 De Cada Mes', N'Edwin Leonardo Molina Flores', CAST(N'2023-06-25' AS Date), 1, CAST(N'2023-06-25' AS Date), N'LeonardoM', NULL, NULL)
INSERT [dbo].[Clientes] ([Cod_Cliente], [Nombre_Cliente], [Identidad_Cliente], [Celular], [Fecha_Nacimiento], [Cod_Genero], [Cod_EstadoCivil], [Cod_Nacionalidad], [IDSECTOR], [Referencia_Direccion], [Referencia_Personal], [Numero_Referencia], [Cod_Paquete], [Contrato_Anual], [Observacion], [Contrato_Fisico], [Factura_Fisica], [Fecha_Maxima_Pago], [Vendedor], [Fecha_Elaborado], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (7, N'Oscar Martín Valle Flores', N'1709-1999-00541', N'3252-6522', CAST(N'1999-09-15' AS Date), 1, 1, 1, 3, N'Del lado nor-oeste del campamento de la ENEE 20 metros al sur y 20 metros al oeste', N'Andrea Funez', N'0000-0000', 1, 1, N'asdasd', N'559219', N'13845522', N'15 De Cada Mes', N'Edwin Leonardo Molina Flores', CAST(N'2023-06-25' AS Date), 1, CAST(N'2023-06-25' AS Date), N'LeonardoM', CAST(N'2023-08-14' AS Date), N'Administrador')
INSERT [dbo].[Clientes] ([Cod_Cliente], [Nombre_Cliente], [Identidad_Cliente], [Celular], [Fecha_Nacimiento], [Cod_Genero], [Cod_EstadoCivil], [Cod_Nacionalidad], [IDSECTOR], [Referencia_Direccion], [Referencia_Personal], [Numero_Referencia], [Cod_Paquete], [Contrato_Anual], [Observacion], [Contrato_Fisico], [Factura_Fisica], [Fecha_Maxima_Pago], [Vendedor], [Fecha_Elaborado], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (8, N'Nelson Vladimir Pineda Peña', N'1709-1999-00541', N'3252-6522', CAST(N'1999-09-15' AS Date), 1, 1, 1, 3, N'Del lado nor-oeste del campamento de la ENEE 20 metros al sur y 20 metros al oeste', N'Andrea Funez', N'0000-0000', 1, 1, N'asdasd', N'559219', N'13845522', N'15 De Cada Mes', N'Edwin Leonardo Molina Flores', CAST(N'2023-06-25' AS Date), 1, CAST(N'2023-06-25' AS Date), N'LeonardoM', CAST(N'2023-08-14' AS Date), N'Administrador')
INSERT [dbo].[Clientes] ([Cod_Cliente], [Nombre_Cliente], [Identidad_Cliente], [Celular], [Fecha_Nacimiento], [Cod_Genero], [Cod_EstadoCivil], [Cod_Nacionalidad], [IDSECTOR], [Referencia_Direccion], [Referencia_Personal], [Numero_Referencia], [Cod_Paquete], [Contrato_Anual], [Observacion], [Contrato_Fisico], [Factura_Fisica], [Fecha_Maxima_Pago], [Vendedor], [Fecha_Elaborado], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (9, N'Carolina Madai Beltran Lopéz', N'1709-1999-00541', N'3252-6522', CAST(N'1999-09-15' AS Date), 2, 1, 1, 3, N'Del lado nor-oeste del campamento de la ENEE 20 metros al sur y 20 metros al oeste', N'Andrea Funez', N'0000-0000', 1, 1, N'asdasd', N'559219', N'13845522', N'15 De Cada Mes', N'Edwin Leonardo Molina Flores', CAST(N'2023-06-25' AS Date), 1, CAST(N'2023-06-25' AS Date), N'LeonardoM', NULL, NULL)
INSERT [dbo].[Clientes] ([Cod_Cliente], [Nombre_Cliente], [Identidad_Cliente], [Celular], [Fecha_Nacimiento], [Cod_Genero], [Cod_EstadoCivil], [Cod_Nacionalidad], [IDSECTOR], [Referencia_Direccion], [Referencia_Personal], [Numero_Referencia], [Cod_Paquete], [Contrato_Anual], [Observacion], [Contrato_Fisico], [Factura_Fisica], [Fecha_Maxima_Pago], [Vendedor], [Fecha_Elaborado], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (10, N'Ernesto Francisco Portillo Mendez', N'1709-1999-00541', N'3252-6522', CAST(N'1999-09-15' AS Date), 1, 1, 1, 3, N'Del lado nor-oeste del campamento de la ENEE 20 metros al sur y 20 metros al oeste', N'Andrea Funez', N'0000-0000', 1, 1, N'asdasd', N'559219', N'13845522', N'15 De Cada Mes', N'Edwin Leonardo Molina Flores', CAST(N'2023-06-25' AS Date), 1, CAST(N'2023-06-25' AS Date), N'LeonardoM', CAST(N'2023-08-14' AS Date), N'Administrador')
INSERT [dbo].[Clientes] ([Cod_Cliente], [Nombre_Cliente], [Identidad_Cliente], [Celular], [Fecha_Nacimiento], [Cod_Genero], [Cod_EstadoCivil], [Cod_Nacionalidad], [IDSECTOR], [Referencia_Direccion], [Referencia_Personal], [Numero_Referencia], [Cod_Paquete], [Contrato_Anual], [Observacion], [Contrato_Fisico], [Factura_Fisica], [Fecha_Maxima_Pago], [Vendedor], [Fecha_Elaborado], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (11, N'Lucia Abigail Peréz Sosa', N'1709-1999-00541', N'3252-6522', CAST(N'1999-09-15' AS Date), 2, 1, 1, 3, N'Del lado nor-oeste del campamento de la ENEE 20 metros al sur y 20 metros al oeste', N'Andrea Funez', N'0000-0000', 1, 1, N'asdasd', N'559219', N'13845522', N'15 De Cada Mes', N'Edwin Leonardo Molina Flores', CAST(N'2023-06-25' AS Date), 1, CAST(N'2023-06-25' AS Date), N'LeonardoM', NULL, NULL)
INSERT [dbo].[Clientes] ([Cod_Cliente], [Nombre_Cliente], [Identidad_Cliente], [Celular], [Fecha_Nacimiento], [Cod_Genero], [Cod_EstadoCivil], [Cod_Nacionalidad], [IDSECTOR], [Referencia_Direccion], [Referencia_Personal], [Numero_Referencia], [Cod_Paquete], [Contrato_Anual], [Observacion], [Contrato_Fisico], [Factura_Fisica], [Fecha_Maxima_Pago], [Vendedor], [Fecha_Elaborado], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (12, N'Guadalupe Del Rosario Alvárez Espinoza', N'1709-1999-00541', N'3252-6522', CAST(N'1999-09-15' AS Date), 2, 1, 1, 3, N'Del lado nor-oeste del campamento de la ENEE 20 metros al sur y 20 metros al oeste', N'Andrea Funez', N'0000-0000', 1, 1, N'asdasd', N'559219', N'13845522', N'15 De Cada Mes', N'Edwin Leonardo Molina Flores', CAST(N'2023-06-25' AS Date), 1, CAST(N'2023-06-25' AS Date), N'LeonardoM', NULL, NULL)
INSERT [dbo].[Clientes_Prospectos] ([Cod_Cliente_Prospecto], [Nombre], [Cod_Paquete], [Fecha_Estimada_Contratar], [Celular], [Cod_Empleado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (1, N'Nathaly Mariela Ortiz', 1, CAST(N'2023-07-05' AS Date), N'3265-1426', 1, CAST(N'2023-07-04' AS Date), N'LeonardoM', CAST(N'2023-07-04' AS Date), N'LeonardoM')
INSERT [dbo].[Clientes_Prospectos] ([Cod_Cliente_Prospecto], [Nombre], [Cod_Paquete], [Fecha_Estimada_Contratar], [Celular], [Cod_Empleado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (2, N'Lizzy Flores', 1, CAST(N'2023-07-15' AS Date), N'3255-2211', 1, CAST(N'2023-07-04' AS Date), N'LeonardoM', NULL, NULL)
INSERT [dbo].[Clientes_Prospectos] ([Cod_Cliente_Prospecto], [Nombre], [Cod_Paquete], [Fecha_Estimada_Contratar], [Celular], [Cod_Empleado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (3, N'Rixi Noemy Flores', 1, CAST(N'2023-07-28' AS Date), N'8855-2266', 2, CAST(N'2023-07-04' AS Date), N'LizethM', NULL, NULL)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (1, N'Atlántida', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (2, N'Choluteca', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (3, N'Colón', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (4, N'Comayagua', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (5, N'Copán', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (6, N'Cortés', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (7, N'El Paraíso', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (8, N'Francisco Morazán', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (9, N'Gracias a Dios', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (10, N'Intibucá', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (11, N'Islas de la Bahía', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (12, N'La Paz', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (13, N'Lempira', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (14, N'Ocotepeque', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (15, N'Olancho', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (16, N'Santa Bárbara', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (17, N'Yoro', 102)
INSERT [dbo].[Departamento] ([IDDEPARTAMENTO], [DEPARTAMENTO], [IDPAIS]) VALUES (18, N'Valle', 102)
INSERT [dbo].[Departamento_Emp] ([Cod_Depto_Emp], [Descripcion], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (1, N'Departamento De Sistemas', CAST(N'2023-06-18' AS Date), N'Administrador', NULL, NULL)
INSERT [dbo].[Departamento_Emp] ([Cod_Depto_Emp], [Descripcion], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (2, N'Departamento De Ventas', CAST(N'2023-07-04' AS Date), N'Administrador', NULL, NULL)
INSERT [dbo].[Departamento_Emp] ([Cod_Depto_Emp], [Descripcion], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (3, N'Departamento De ATC', CAST(N'2023-08-14' AS Date), N'Administrador', NULL, NULL)
INSERT [dbo].[Departamento_Emp] ([Cod_Depto_Emp], [Descripcion], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (4, N'Departamento De Contratos', CAST(N'2023-08-14' AS Date), N'Administrador', NULL, NULL)
INSERT [dbo].[Empleados] ([Cod_Empleado], [Identidad_Empleado], [Nombre_Empleado], [Edad], [Fecha_Nacimiento], [Cod_Genero], [Email], [Telefono], [Cod_EstadoCivil], [IDMUNICIPIO], [Num_Contador], [Propietario_Vivienda], [Cod_Cargo], [Cod_Turno], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (1, N'1707-2002-00389', N'Edwin Leonardo Molina Flores', 21, CAST(N'2002-02-18' AS Date), 1, N'leonardomolina8200@gmail.com', N'3140-1467', 1, 1, N'18542136', 1, 2, 1, 1, CAST(N'2023-06-18' AS Date), N'ElviaV', NULL, NULL)
INSERT [dbo].[Empleados] ([Cod_Empleado], [Identidad_Empleado], [Nombre_Empleado], [Edad], [Fecha_Nacimiento], [Cod_Genero], [Email], [Telefono], [Cod_EstadoCivil], [IDMUNICIPIO], [Num_Contador], [Propietario_Vivienda], [Cod_Cargo], [Cod_Turno], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (2, N'0000-0000-0000', N'Modesta Lizeth Chavez', 23, CAST(N'2000-07-01' AS Date), 2, N'LizethMolina@gmail.com', N'3220-4962', 1, 1, N'00000000', 1, 2, 1, 1, CAST(N'2023-06-28' AS Date), N'ElviaV', NULL, NULL)
INSERT [dbo].[Empleados] ([Cod_Empleado], [Identidad_Empleado], [Nombre_Empleado], [Edad], [Fecha_Nacimiento], [Cod_Genero], [Email], [Telefono], [Cod_EstadoCivil], [IDMUNICIPIO], [Num_Contador], [Propietario_Vivienda], [Cod_Cargo], [Cod_Turno], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (3, N'0000-0000-0000', N'Elvia Johana Velasquez', 0, CAST(N'1977-01-01' AS Date), 2, N'ElviaV@gmail.com', N'9620-4919', 2, 1, N'00000000', 1, 3, 1, 1, CAST(N'2023-07-14' AS Date), N'Administrador', NULL, NULL)
INSERT [dbo].[Empleados] ([Cod_Empleado], [Identidad_Empleado], [Nombre_Empleado], [Edad], [Fecha_Nacimiento], [Cod_Genero], [Email], [Telefono], [Cod_EstadoCivil], [IDMUNICIPIO], [Num_Contador], [Propietario_Vivienda], [Cod_Cargo], [Cod_Turno], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (4, N'1709-1993-01081', N'Wilson Zuniga', 29, CAST(N'1993-12-02' AS Date), 1, N'Wilson.zuniga@cablecolor.net', N'8990-8052', 2, 1, N'00000000', 1, 4, 1, 1, CAST(N'2023-07-14' AS Date), N'ElviaV', CAST(N'2023-07-28' AS Date), N'Administrador')
INSERT [dbo].[Empleados] ([Cod_Empleado], [Identidad_Empleado], [Nombre_Empleado], [Edad], [Fecha_Nacimiento], [Cod_Genero], [Email], [Telefono], [Cod_EstadoCivil], [IDMUNICIPIO], [Num_Contador], [Propietario_Vivienda], [Cod_Cargo], [Cod_Turno], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (5, N'0000-0000-0000', N'Administrador', 0, CAST(N'2002-02-18' AS Date), 1, N'administrador@CableColor.net', N'3172-5023', 1, 1, N'00000000', 1, 3, 1, 1, CAST(N'2023-06-18' AS Date), N'Administrador', NULL, NULL)
INSERT [dbo].[Estado_Civil] ([Cod_EstadoCivil], [Estado_Civil]) VALUES (1, N'Soltero')
INSERT [dbo].[Estado_Civil] ([Cod_EstadoCivil], [Estado_Civil]) VALUES (2, N'Casado')
INSERT [dbo].[Estado_Civil] ([Cod_EstadoCivil], [Estado_Civil]) VALUES (3, N'Divorciado')
INSERT [dbo].[Estado_Civil] ([Cod_EstadoCivil], [Estado_Civil]) VALUES (4, N'Separacion en proceso judicial')
INSERT [dbo].[Estado_Civil] ([Cod_EstadoCivil], [Estado_Civil]) VALUES (5, N'Viudo')
INSERT [dbo].[Estado_Civil] ([Cod_EstadoCivil], [Estado_Civil]) VALUES (6, N'Concubinato')
INSERT [dbo].[Generos] ([Cod_Genero], [Genero]) VALUES (1, N'Masculino')
INSERT [dbo].[Generos] ([Cod_Genero], [Genero]) VALUES (2, N'Femenino')
INSERT [dbo].[Municipio] ([IDMUNICIPIO], [MUNICIPIO], [IDDEPARTAMENTO]) VALUES (1, N'San Lorenzo', 18)
INSERT [dbo].[Municipio] ([IDMUNICIPIO], [MUNICIPIO], [IDDEPARTAMENTO]) VALUES (2, N'Nacaome', 18)
INSERT [dbo].[Nacionalidad] ([Cod_Nacionalidad], [Nacionalidad]) VALUES (1, N'Hondureña')
INSERT [dbo].[Nacionalidad] ([Cod_Nacionalidad], [Nacionalidad]) VALUES (2, N'Mexicana')
INSERT [dbo].[Nivel_Acceso] ([IdNivelUser], [Nivel_Acceso]) VALUES (1, N'Administrador')
INSERT [dbo].[Nivel_Acceso] ([IdNivelUser], [Nivel_Acceso]) VALUES (2, N'Programador')
INSERT [dbo].[Nivel_Acceso] ([IdNivelUser], [Nivel_Acceso]) VALUES (3, N'IT')
INSERT [dbo].[Nivel_Acceso] ([IdNivelUser], [Nivel_Acceso]) VALUES (4, N'Supervisor Residencial')
INSERT [dbo].[Nivel_Acceso] ([IdNivelUser], [Nivel_Acceso]) VALUES (5, N'Gerente')
INSERT [dbo].[Nivel_Acceso] ([IdNivelUser], [Nivel_Acceso]) VALUES (6, N'Vendedor')
INSERT [dbo].[Orden_Instalacion] ([Cod_Cliente_Pendiente], [Cod_Cliente], [Fecha_Instalacion], [Cod_Empleado], [Telefono], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (1, 1, CAST(N'2023-07-08' AS Date), 1, N'0000-0000', CAST(N'2023-07-08' AS Date), N'LeonardoM', NULL, NULL)
INSERT [dbo].[Orden_Instalacion] ([Cod_Cliente_Pendiente], [Cod_Cliente], [Fecha_Instalacion], [Cod_Empleado], [Telefono], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (2, 2, CAST(N'2023-07-08' AS Date), 1, N'0000-0000', CAST(N'2023-07-08' AS Date), N'LeonardoM', NULL, NULL)
INSERT [dbo].[Ordenes_Mantenimiento] ([Cod_Orden_Mant], [Cod_Cliente], [Fecha_Mantenimiento], [Cod_Empleado], [Telefono], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (1, 1, CAST(N'2023-07-08' AS Date), 1, N'3265-2255', CAST(N'2023-07-08' AS Date), N'LeonardoM', NULL, NULL)
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (1, N'AF', N'Afganistán')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (2, N'AX', N'Islas Gland')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (3, N'AL', N'Albania')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (4, N'DE', N'Alemania')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (5, N'AD', N'Andorra')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (6, N'AO', N'Angola')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (7, N'AI', N'Anguilla')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (8, N'AQ', N'Antártida')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (9, N'AG', N'Antigua y Barbuda')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (10, N'AN', N'Antillas Holandesas')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (11, N'SA', N'Arabia Saudí')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (12, N'DZ', N'Argelia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (13, N'AR', N'Argentina')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (14, N'AM', N'Armenia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (15, N'AW', N'Aruba')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (16, N'AU', N'Australia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (17, N'AT', N'Austria')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (18, N'AZ', N'Azerbaiyán')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (19, N'BS', N'Bahamas')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (20, N'BH', N'Bahréin')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (21, N'BD', N'Bangladesh')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (22, N'BB', N'Barbados')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (23, N'BY', N'Bielorrusia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (24, N'BE', N'Bélgica')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (25, N'BZ', N'Belice')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (26, N'BJ', N'Benin')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (27, N'BM', N'Bermudas')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (28, N'BT', N'Bhután')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (29, N'BO', N'Bolivia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (30, N'BA', N'Bosnia y Herzegovina')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (31, N'BW', N'Botsuana')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (32, N'BV', N'Isla Bouvet')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (33, N'BR', N'Brasil')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (34, N'BN', N'Brunéi')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (35, N'BG', N'Bulgaria')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (36, N'BF', N'Burkina Faso')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (37, N'BI', N'Burundi')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (38, N'CV', N'Cabo Verde')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (39, N'KY', N'Islas Caimán')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (40, N'KH', N'Camboya')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (41, N'CM', N'Camerún')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (42, N'CA', N'Canadá')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (43, N'CF', N'República Centroafricana')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (44, N'TD', N'Chad')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (45, N'CZ', N'República Checa')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (46, N'CL', N'Chile')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (47, N'CN', N'China')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (48, N'CY', N'Chipre')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (49, N'CX', N'Isla de Navidad')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (50, N'VA', N'Ciudad del Vaticano')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (51, N'CC', N'Islas Cocos')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (52, N'CO', N'Colombia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (53, N'KM', N'Comoras')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (54, N'CD', N'República Democrática del Congo')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (55, N'CG', N'Congo')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (56, N'CK', N'Islas Cook')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (57, N'KP', N'Corea del Norte')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (58, N'KR', N'Corea del Sur')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (59, N'CI', N'Costa de Marfil')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (60, N'CR', N'Costa Rica')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (61, N'HR', N'Croacia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (62, N'CU', N'Cuba')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (63, N'DK', N'Dinamarca')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (64, N'DM', N'Dominica')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (65, N'DO', N'República Dominicana')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (66, N'EC', N'Ecuador')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (67, N'EG', N'Egipto')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (68, N'SV', N'El Salvador')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (69, N'AE', N'Emiratos Árabes Unidos')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (70, N'ER', N'Eritrea')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (71, N'SK', N'Eslovaquia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (72, N'SI', N'Eslovenia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (73, N'ES', N'España')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (74, N'UM', N'Islas ultramarinas de Estados Unidos')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (75, N'US', N'Estados Unidos')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (76, N'EE', N'Estonia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (77, N'ET', N'Etiopía')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (78, N'FO', N'Islas Feroe')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (79, N'PH', N'Filipinas')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (80, N'FI', N'Finlandia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (81, N'FJ', N'Fiyi')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (82, N'FR', N'Francia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (83, N'GA', N'Gabón')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (84, N'GM', N'Gambia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (85, N'GE', N'Georgia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (86, N'GS', N'Islas Georgias del Sur y Sandwich del Sur')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (87, N'GH', N'Ghana')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (88, N'GI', N'Gibraltar')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (89, N'GD', N'Granada')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (90, N'GR', N'Grecia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (91, N'GL', N'Groenlandia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (92, N'GP', N'Guadalupe')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (93, N'GU', N'Guam')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (94, N'GT', N'Guatemala')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (95, N'GF', N'Guayana Francesa')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (96, N'GN', N'Guinea')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (97, N'GQ', N'Guinea Ecuatorial')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (98, N'GW', N'Guinea-Bissau')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (99, N'GY', N'Guyana')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (100, N'HT', N'Haití')
GO
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (101, N'HM', N'Islas Heard y McDonald')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (102, N'HN', N'Honduras')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (103, N'HK', N'Hong Kong')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (104, N'HU', N'Hungría')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (105, N'IN', N'India')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (106, N'ID', N'Indonesia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (107, N'IR', N'Irán')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (108, N'IQ', N'Iraq')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (109, N'IE', N'Irlanda')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (110, N'IS', N'Islandia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (111, N'IL', N'Israel')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (112, N'IT', N'Italia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (113, N'JM', N'Jamaica')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (114, N'JP', N'Japón')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (115, N'JO', N'Jordania')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (116, N'KZ', N'Kazajstán')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (117, N'KE', N'Kenia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (118, N'KG', N'Kirguistán')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (119, N'KI', N'Kiribati')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (120, N'KW', N'Kuwait')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (121, N'LA', N'Laos')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (122, N'LS', N'Lesotho')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (123, N'LV', N'Letonia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (124, N'LB', N'Líbano')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (125, N'LR', N'Liberia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (126, N'LY', N'Libia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (127, N'LI', N'Liechtenstein')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (128, N'LT', N'Lituania')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (129, N'LU', N'Luxemburgo')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (130, N'MO', N'Macao')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (131, N'MK', N'ARY Macedonia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (132, N'MG', N'Madagascar')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (133, N'MY', N'Malasia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (134, N'MW', N'Malawi')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (135, N'MV', N'Maldivas')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (136, N'ML', N'Malí')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (137, N'MT', N'Malta')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (138, N'FK', N'Islas Malvinas')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (139, N'MP', N'Islas Marianas del Norte')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (140, N'MA', N'Marruecos')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (141, N'MH', N'Islas Marshall')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (142, N'MQ', N'Martinica')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (143, N'MU', N'Mauricio')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (144, N'MR', N'Mauritania')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (145, N'YT', N'Mayotte')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (146, N'MX', N'México')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (147, N'FM', N'Micronesia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (148, N'MD', N'Moldavia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (149, N'MC', N'Mónaco')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (150, N'MN', N'Mongolia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (151, N'MS', N'Montserrat')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (152, N'MZ', N'Mozambique')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (153, N'MM', N'Myanmar')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (154, N'NA', N'Namibia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (155, N'NR', N'Nauru')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (156, N'NP', N'Nepal')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (157, N'NI', N'Nicaragua')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (158, N'NE', N'Níger')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (159, N'NG', N'Nigeria')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (160, N'NU', N'Niue')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (161, N'NF', N'Isla Norfolk')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (162, N'NO', N'Noruega')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (163, N'NC', N'Nueva Caledonia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (164, N'NZ', N'Nueva Zelanda')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (165, N'OM', N'Omán')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (166, N'NL', N'Países Bajos')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (167, N'PK', N'Pakistán')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (168, N'PW', N'Palau')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (169, N'PS', N'Palestina')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (170, N'PA', N'Panamá')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (171, N'PG', N'Papúa Nueva Guinea')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (172, N'PY', N'Paraguay')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (173, N'PE', N'Perú')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (174, N'PN', N'Islas Pitcairn')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (175, N'PF', N'Polinesia Francesa')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (176, N'PL', N'Polonia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (177, N'PT', N'Portugal')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (178, N'PR', N'Puerto Rico')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (179, N'QA', N'Qatar')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (180, N'GB', N'Reino Unido')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (181, N'RE', N'Reunión')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (182, N'RW', N'Ruanda')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (183, N'RO', N'Rumania')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (184, N'RU', N'Rusia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (185, N'EH', N'Sahara Occidental')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (186, N'SB', N'Islas Salomón')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (187, N'WS', N'Samoa')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (188, N'AS', N'Samoa Americana')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (189, N'KN', N'San Cristóbal y Nevis')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (190, N'SM', N'San Marino')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (191, N'PM', N'San Pedro y Miquelón')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (192, N'VC', N'San Vicente y las Granadinas')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (193, N'SH', N'Santa Helena')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (194, N'LC', N'Santa Lucía')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (195, N'ST', N'Santo Tomé y Príncipe')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (196, N'SN', N'Senegal')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (197, N'CS', N'Serbia y Montenegro')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (198, N'SC', N'Seychelles')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (199, N'SL', N'Sierra Leona')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (200, N'SG', N'Singapur')
GO
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (201, N'SY', N'Siria')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (202, N'SO', N'Somalia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (203, N'LK', N'Sri Lanka')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (204, N'SZ', N'Suazilandia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (205, N'ZA', N'Sudáfrica')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (206, N'SD', N'Sudán')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (207, N'SE', N'Suecia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (208, N'CH', N'Suiza')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (209, N'SR', N'Surinam')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (210, N'SJ', N'Svalbard y Jan Mayen')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (211, N'TH', N'Tailandia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (212, N'TW', N'Taiwán')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (213, N'TZ', N'Tanzania')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (214, N'TJ', N'Tayikistán')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (215, N'IO', N'Territorio Británico del Océano Índico')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (216, N'TF', N'Territorios Australes Franceses')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (217, N'TL', N'Timor Oriental')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (218, N'TG', N'Togo')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (219, N'TK', N'Tokelau')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (220, N'TO', N'Tonga')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (221, N'TT', N'Trinidad y Tobago')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (222, N'TN', N'Túnez')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (223, N'TC', N'Islas Turcas y Caicos')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (224, N'TM', N'Turkmenistán')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (225, N'TR', N'Turquía')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (226, N'TV', N'Tuvalu')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (227, N'UA', N'Ucrania')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (228, N'UG', N'Uganda')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (229, N'UY', N'Uruguay')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (230, N'UZ', N'Uzbekistán')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (231, N'VU', N'Vanuatu')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (232, N'VE', N'Venezuela')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (233, N'VN', N'Vietnam')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (234, N'VG', N'Islas Vírgenes Británicas')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (235, N'VI', N'Islas Vírgenes de los Estados Unidos')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (236, N'WF', N'Wallis y Futuna')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (237, N'YE', N'Yemen')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (238, N'DJ', N'Yibuti')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (239, N'ZM', N'Zambia')
INSERT [dbo].[Pais] ([IDPAIS], [ISO], [PAIS]) VALUES (240, N'ZW', N'Zimbabue')
INSERT [dbo].[Paquetes] ([Cod_Paquete], [Cod_TipoPaquete], [Paquete], [Precio_Paquete], [Estado]) VALUES (1, 1, N'3 PLAY OTT CCVEO 30MB', N'$ 0025,00', 1)
INSERT [dbo].[Paquetes] ([Cod_Paquete], [Cod_TipoPaquete], [Paquete], [Precio_Paquete], [Estado]) VALUES (2, 2, N'3 PLAY OTT CCVEO 30MB FIBRA', N'$ 0025,00', 1)
INSERT [dbo].[Paquetes] ([Cod_Paquete], [Cod_TipoPaquete], [Paquete], [Precio_Paquete], [Estado]) VALUES (3, 1, N'3 PLAY OTT CCVEO 50MB', N'$ 0030,00', 1)
INSERT [dbo].[Paquetes] ([Cod_Paquete], [Cod_TipoPaquete], [Paquete], [Precio_Paquete], [Estado]) VALUES (4, 2, N'3 PLAY OTT CCVEO 50MB FIBRA', N'$ 0030,00', 1)
INSERT [dbo].[Paquetes] ([Cod_Paquete], [Cod_TipoPaquete], [Paquete], [Precio_Paquete], [Estado]) VALUES (5, 1, N'3 PLAY OTT CCVEO 70MB', N'$ 0035,00', 1)
INSERT [dbo].[Paquetes] ([Cod_Paquete], [Cod_TipoPaquete], [Paquete], [Precio_Paquete], [Estado]) VALUES (6, 2, N'3 PLAY OTT CCVEO 70MB FIBRA', N'$ 0035,00', 1)
INSERT [dbo].[Paquetes] ([Cod_Paquete], [Cod_TipoPaquete], [Paquete], [Precio_Paquete], [Estado]) VALUES (7, 1, N'3 PLAY OTT CCVEO 100MB', N'$ 0045,00', 1)
INSERT [dbo].[Paquetes] ([Cod_Paquete], [Cod_TipoPaquete], [Paquete], [Precio_Paquete], [Estado]) VALUES (8, 2, N'3 PLAY OTT CCVEO 100MB FIBRA', N'$ 0045,00', 1)
INSERT [dbo].[Paquetes] ([Cod_Paquete], [Cod_TipoPaquete], [Paquete], [Precio_Paquete], [Estado]) VALUES (9, 1, N'2 PLAY 10 MB', N'$ 0020,00', 0)
INSERT [dbo].[Sector] ([IDSECTOR], [SECTOR], [IdTipoSector], [IDMUNICIPIO]) VALUES (1, N'El Comercio', 3, 1)
INSERT [dbo].[Sector] ([IDSECTOR], [SECTOR], [IdTipoSector], [IDMUNICIPIO]) VALUES (2, N'San Antonio', 1, 1)
INSERT [dbo].[Sector] ([IDSECTOR], [SECTOR], [IdTipoSector], [IDMUNICIPIO]) VALUES (3, N'Morazan', 2, 1)
INSERT [dbo].[Tipo_Paquete] ([Cod_TipoPaquete], [Tipo_Paquete], [Descripcion], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (1, N'HFC', N'Conexion Inalambrica (Coaxial)', CAST(N'2023-06-19' AS Date), N'Administrador', NULL, NULL)
INSERT [dbo].[Tipo_Paquete] ([Cod_TipoPaquete], [Tipo_Paquete], [Descripcion], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion]) VALUES (2, N'HTTF', N'Conexion Fibra Optica', CAST(N'2023-06-19' AS Date), N'Administrador', NULL, NULL)
INSERT [dbo].[TipoSector] ([IdTipoSector], [TipoSector]) VALUES (1, N'Barrio')
INSERT [dbo].[TipoSector] ([IdTipoSector], [TipoSector]) VALUES (2, N'Colonia')
INSERT [dbo].[TipoSector] ([IdTipoSector], [TipoSector]) VALUES (3, N'Aldea')
INSERT [dbo].[TipoSector] ([IdTipoSector], [TipoSector]) VALUES (4, N'Caserio')
INSERT [dbo].[Turnos] ([Cod_Turno], [Turno], [Descripcion]) VALUES (1, N'Semanal', N'Lunes A Sabado 8:00 AM - 5:00 PM')
INSERT [dbo].[Usuarios] ([Cod_Usuario], [Cod_Empleado], [Usuario], [Contrasena], [IdNivelUser], [Estado]) VALUES (1, 1, N'LeonardoM', N'3BmcIOhB35MaKDY05tj6Ge9+9JiKzVW3ywuTi44zTIsHO24qWX1JMPdbAolgZV31hStrFgH1a/5esxvszwZ4jQ==', 6, 1)
INSERT [dbo].[Usuarios] ([Cod_Usuario], [Cod_Empleado], [Usuario], [Contrasena], [IdNivelUser], [Estado]) VALUES (2, 3, N'ElviaV', N'XsRjsFCVbt1Mvj0OtFtPWuWZKEod4VvZFUKX7EsLBs+5AgoDwHTMFCy0mVN9VTq+vriADZCQyeWNH/JUzExxyw==', 1, 1)
INSERT [dbo].[Usuarios] ([Cod_Usuario], [Cod_Empleado], [Usuario], [Contrasena], [IdNivelUser], [Estado]) VALUES (3, 4, N'WilsonZ', N'XsRjsFCVbt1Mvj0OtFtPWuWZKEod4VvZFUKX7EsLBs+5AgoDwHTMFCy0mVN9VTq+vriADZCQyeWNH/JUzExxyw==', 4, 1)
INSERT [dbo].[Usuarios] ([Cod_Usuario], [Cod_Empleado], [Usuario], [Contrasena], [IdNivelUser], [Estado]) VALUES (4, 5, N'Administrador', N'7eIhWy+CLSJO89ptcKLKyiCRVdxziYR1+5jJxQ5/+L25vnoW2PBUHH9QIcw+rh3ICCmBc0Al+7dn7FLV0r0fjw==', 2, 1)
ALTER TABLE [dbo].[Cargos]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Depto_Emp_Cargos] FOREIGN KEY([Cod_Depto_Emp])
REFERENCES [dbo].[Departamento_Emp] ([Cod_Depto_Emp])
GO
ALTER TABLE [dbo].[Cargos] CHECK CONSTRAINT [FK_Cod_Depto_Emp_Cargos]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Cod_EstadoCivil_Clientes] FOREIGN KEY([Cod_EstadoCivil])
REFERENCES [dbo].[Estado_Civil] ([Cod_EstadoCivil])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Cod_EstadoCivil_Clientes]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Genero_Clientes] FOREIGN KEY([Cod_Genero])
REFERENCES [dbo].[Generos] ([Cod_Genero])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Cod_Genero_Clientes]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Nacionalidad_Clientes] FOREIGN KEY([Cod_Nacionalidad])
REFERENCES [dbo].[Nacionalidad] ([Cod_Nacionalidad])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Cod_Nacionalidad_Clientes]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Paquete_Clientes] FOREIGN KEY([Cod_Paquete])
REFERENCES [dbo].[Paquetes] ([Cod_Paquete])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Cod_Paquete_Clientes]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_IDSECTOR_Clientes] FOREIGN KEY([IDSECTOR])
REFERENCES [dbo].[Sector] ([IDSECTOR])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_IDSECTOR_Clientes]
GO
ALTER TABLE [dbo].[Clientes_Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Empleado_Clientes_Prospectos] FOREIGN KEY([Cod_Empleado])
REFERENCES [dbo].[Empleados] ([Cod_Empleado])
GO
ALTER TABLE [dbo].[Clientes_Prospectos] CHECK CONSTRAINT [FK_Cod_Empleado_Clientes_Prospectos]
GO
ALTER TABLE [dbo].[Departamento]  WITH CHECK ADD  CONSTRAINT [FK_IdPais_Departamento] FOREIGN KEY([IDPAIS])
REFERENCES [dbo].[Pais] ([IDPAIS])
GO
ALTER TABLE [dbo].[Departamento] CHECK CONSTRAINT [FK_IdPais_Departamento]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Cargo_Empleado] FOREIGN KEY([Cod_Cargo])
REFERENCES [dbo].[Cargos] ([Cod_Cargo])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Cod_Cargo_Empleado]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Cod_EstadoCivil_Empleado] FOREIGN KEY([Cod_EstadoCivil])
REFERENCES [dbo].[Estado_Civil] ([Cod_EstadoCivil])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Cod_EstadoCivil_Empleado]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Genero_Empleado] FOREIGN KEY([Cod_Genero])
REFERENCES [dbo].[Generos] ([Cod_Genero])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Cod_Genero_Empleado]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Turno_Empleado] FOREIGN KEY([Cod_Turno])
REFERENCES [dbo].[Turnos] ([Cod_Turno])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Cod_Turno_Empleado]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_IDMUNICIPIO_Empleado] FOREIGN KEY([IDMUNICIPIO])
REFERENCES [dbo].[Municipio] ([IDMUNICIPIO])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_IDMUNICIPIO_Empleado]
GO
ALTER TABLE [dbo].[Municipio]  WITH CHECK ADD  CONSTRAINT [FK_IDDEPARTAMENTO_Municipio] FOREIGN KEY([IDDEPARTAMENTO])
REFERENCES [dbo].[Departamento] ([IDDEPARTAMENTO])
GO
ALTER TABLE [dbo].[Municipio] CHECK CONSTRAINT [FK_IDDEPARTAMENTO_Municipio]
GO
ALTER TABLE [dbo].[Orden_Instalacion]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Cliente_Orden_Instalacion] FOREIGN KEY([Cod_Cliente])
REFERENCES [dbo].[Clientes] ([Cod_Cliente])
GO
ALTER TABLE [dbo].[Orden_Instalacion] CHECK CONSTRAINT [FK_Cod_Cliente_Orden_Instalacion]
GO
ALTER TABLE [dbo].[Orden_Instalacion]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Empleado_Orden_Instalacion] FOREIGN KEY([Cod_Empleado])
REFERENCES [dbo].[Empleados] ([Cod_Empleado])
GO
ALTER TABLE [dbo].[Orden_Instalacion] CHECK CONSTRAINT [FK_Cod_Empleado_Orden_Instalacion]
GO
ALTER TABLE [dbo].[Ordenes_Mantenimiento]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Cliente_Ordenes_Mantenimiento] FOREIGN KEY([Cod_Cliente])
REFERENCES [dbo].[Clientes] ([Cod_Cliente])
GO
ALTER TABLE [dbo].[Ordenes_Mantenimiento] CHECK CONSTRAINT [FK_Cod_Cliente_Ordenes_Mantenimiento]
GO
ALTER TABLE [dbo].[Ordenes_Mantenimiento]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Empleado_Ordenes_Mantenimiento] FOREIGN KEY([Cod_Empleado])
REFERENCES [dbo].[Empleados] ([Cod_Empleado])
GO
ALTER TABLE [dbo].[Ordenes_Mantenimiento] CHECK CONSTRAINT [FK_Cod_Empleado_Ordenes_Mantenimiento]
GO
ALTER TABLE [dbo].[Paquetes]  WITH CHECK ADD  CONSTRAINT [FK_Cod_TipoPaquete_Paquetes] FOREIGN KEY([Cod_TipoPaquete])
REFERENCES [dbo].[Tipo_Paquete] ([Cod_TipoPaquete])
GO
ALTER TABLE [dbo].[Paquetes] CHECK CONSTRAINT [FK_Cod_TipoPaquete_Paquetes]
GO
ALTER TABLE [dbo].[Sector]  WITH CHECK ADD  CONSTRAINT [FK_IDMUNICIPIO_Sector] FOREIGN KEY([IDMUNICIPIO])
REFERENCES [dbo].[Municipio] ([IDMUNICIPIO])
GO
ALTER TABLE [dbo].[Sector] CHECK CONSTRAINT [FK_IDMUNICIPIO_Sector]
GO
ALTER TABLE [dbo].[Sector]  WITH CHECK ADD  CONSTRAINT [FK_IdTipoSector_Sector] FOREIGN KEY([IdTipoSector])
REFERENCES [dbo].[TipoSector] ([IdTipoSector])
GO
ALTER TABLE [dbo].[Sector] CHECK CONSTRAINT [FK_IdTipoSector_Sector]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK__Usuarios__IdNive__73BA3083] FOREIGN KEY([IdNivelUser])
REFERENCES [dbo].[Nivel_Acceso] ([IdNivelUser])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK__Usuarios__IdNive__73BA3083]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Cod_Empleado_Usuarios] FOREIGN KEY([Cod_Empleado])
REFERENCES [dbo].[Empleados] ([Cod_Empleado])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Cod_Empleado_Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[sp_Cargos]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Cargos] @Indicador int, @Cod_Cargo as int, @Cod_Depto_Emp int, @Cargo varchar(75), @UsuarioCreacion varchar(50), @UsuarioModificacion varchar(50)

as
begin

if @Indicador = 1

begin
insert into dbo.Cargos select isnull((select max(Cod_Cargo) from dbo.Cargos),0)+1,@Cod_Depto_Emp,@Cargo,getdate(),@UsuarioCreacion,null,null

end
 if @Indicador = 2
 begin
 update dbo.Cargos set Cod_Depto_Emp = @Cod_Depto_Emp, Cargo = @Cargo, UsuarioModificacion = @UsuarioModificacion, FechaModificacion = getdate() where Cod_Cargo = @Cod_Cargo
end
 if @Indicador = 3

 begin 
 delete dbo.Cargos where Cod_Cargo = @Cod_Cargo

 end

  if @Indicador = 4
  begin 
  select Cod_Cargo,Cod_Depto_Emp,Cargo,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion from dbo.Cargos

end
  if @Indicador = 5
  begin
  select Cod_Cargo,Cod_Depto_Emp,Cargo,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion from dbo.Cargos where Cod_Cargo = Cod_Cargo

end

 if @Indicador = 6
  begin
  select Cod_Cargo,Departamento_Emp.Descripcion AS Departamento,Cargo,Cargos.FechaCreacion,Cargos.UsuarioCreacion,Cargos.FechaModificacion,Cargos.UsuarioModificacion from dbo.Cargos
  INNER JOIN Departamento_Emp ON Departamento_Emp.Cod_Depto_Emp = Cargos.Cod_Depto_Emp

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_Cargos] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_Clientes]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Clientes] @Indicador int, @Cod_Cliente as int, @Nombre_Cliente varchar(150),@Identidad_Cliente varchar(15), 
@Celular varchar(14), @Fecha_Nacimiento date, @Cod_Genero int, @Cod_EstadoCivil int, @Cod_Nacionalidad int, @IDSECTOR int, 
@Referencia_Direccion varchar(max), @Referencia_Personal varchar(150), @Numero_Referencia varchar(14), @Cod_Paquete int, 
@Contrato_Anual bit, @Observacion varchar(max), @Contrato_Fisico varchar(8), @Factura_Fisica varchar(8), @Fecha_Maxima_Pago varchar(50), 
@Vendedor varchar(150), @Fecha_Elaborado date, @Estado bit,@UsuarioCreacion varchar(50), @UsuarioModificacion varchar(50)

as
begin

if @Indicador = 1

begin
insert into dbo.Clientes select isnull((select max(Cod_Cliente) from dbo.Clientes),0)+1,@Nombre_Cliente,@Identidad_Cliente,@Celular,
@Fecha_Nacimiento,@Cod_Genero,@Cod_EstadoCivil,@Cod_Nacionalidad,@IDSECTOR,@Referencia_Direccion,@Referencia_Personal,@Numero_Referencia,
@Cod_Paquete,@Contrato_Anual,@Observacion,@Contrato_Fisico,@Factura_Fisica,@Fecha_Maxima_Pago,@Vendedor,@Fecha_Elaborado,@Estado,
getdate(),@UsuarioCreacion,null,null

end
 if @Indicador = 2
 begin
 update dbo.Clientes set Nombre_Cliente = @Nombre_Cliente, Identidad_Cliente = @Identidad_Cliente,Celular = @Celular,Fecha_Nacimiento = @Fecha_Nacimiento,
 Cod_Genero = @Cod_Genero,Cod_EstadoCivil = @Cod_EstadoCivil, Cod_Nacionalidad = @Cod_Nacionalidad, IDSECTOR = @IDSECTOR, Referencia_Direccion = @Referencia_Direccion,
 Referencia_Personal = @Referencia_Personal,Numero_Referencia = @Numero_Referencia,Cod_Paquete = @Cod_Paquete,Contrato_Anual = @Contrato_Anual, Observacion = @Observacion,
 Contrato_Fisico = @Contrato_Fisico,Factura_Fisica = @Factura_Fisica,Fecha_Maxima_Pago = @Fecha_Maxima_Pago,Vendedor = @Vendedor, Fecha_Elaborado = @Fecha_Elaborado,
 Estado = @Estado,UsuarioModificacion = @UsuarioModificacion, FechaModificacion = getdate() 
 where Cod_Cliente = @Cod_Cliente
end
 if @Indicador = 3

 begin 
 delete dbo.Clientes where Cod_Cliente = @Cod_Cliente

 end

  if @Indicador = 4
  begin 
  select Cod_Cliente,Nombre_Cliente,Identidad_Cliente,Celular,Fecha_Nacimiento,Cod_Genero,Cod_Nacionalidad,Cod_EstadoCivil,IDSECTOR,
  Referencia_Direccion,Referencia_Personal,Numero_Referencia,Cod_Paquete,Contrato_Anual,Observacion,Contrato_Fisico,Factura_Fisica,
  Fecha_Maxima_Pago,Vendedor,Fecha_Elaborado,Estado,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion
 from dbo.Clientes where Estado = @Estado

end
  if @Indicador = 5
  begin
  select Cod_Cliente,Nombre_Cliente,Identidad_Cliente,Celular,Fecha_Nacimiento,Cod_Genero,Cod_Nacionalidad,Cod_EstadoCivil,IDSECTOR,
  Referencia_Direccion,Referencia_Personal,Numero_Referencia,Cod_Paquete,Contrato_Anual,Observacion,Contrato_Fisico,Factura_Fisica,
  Fecha_Maxima_Pago,Vendedor,Fecha_Elaborado,Estado,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion
   from dbo.Clientes where Cod_Cliente = @Cod_Cliente

end

if @Indicador = 6
  begin
  select Cod_Cliente,Nombre_Cliente,Identidad_Cliente,Celular,Fecha_Nacimiento,Generos.Genero,Nacionalidad.Nacionalidad,Estado_Civil.Estado_Civil,Sector.SECTOR AS Sector,
  Referencia_Direccion,Referencia_Personal,Numero_Referencia,Paquetes.Paquete,Contrato_Anual,Observacion,Contrato_Fisico,Factura_Fisica,
  Fecha_Maxima_Pago,Vendedor,Fecha_Elaborado,Clientes.Estado,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion from dbo.Clientes
  INNER JOIN Generos ON Clientes.Cod_Genero = Generos.Cod_Genero
  INNER JOIN Nacionalidad ON Clientes.Cod_Nacionalidad = Nacionalidad.Cod_Nacionalidad
  INNER JOIN Estado_Civil ON Clientes.Cod_EstadoCivil = Estado_Civil.Cod_EstadoCivil
  INNER JOIN Sector ON Clientes.IDSECTOR = SECTOR.IDSECTOR
  INNER JOIN Paquetes ON Clientes.Cod_Paquete = Paquetes.Cod_Paquete
  where Clientes.Estado = @Estado
end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_Clientes] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_ClientesProspectos]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_ClientesProspectos] @Indicador int, @Cod_Cliente_Prospecto as int,@Nombre varchar(50), @Cod_Paquete int, @Fecha_Estimada_Contratar date, 
@Celular varchar(15), @Cod_Empleado int, @UsuarioCreacion varchar(50), @UsuarioModificacion varchar(50)

as
begin

if @Indicador = 1

begin
insert into dbo.Clientes_Prospectos select isnull((select max(Cod_Cliente_Prospecto) from dbo.Clientes_Prospectos),0)+1,@Nombre,@Cod_Paquete,
@Fecha_Estimada_Contratar,@Celular,@Cod_Empleado,GETDATE(),@UsuarioCreacion,null,null

end
 if @Indicador = 2
 begin
 update dbo.Clientes_Prospectos set Nombre = @Nombre, Cod_Paquete = @Cod_Paquete, Fecha_Estimada_Contratar = @Fecha_Estimada_Contratar,Celular=@Celular,
 Cod_Empleado = @Cod_Empleado,FechaModificacion = getdate(), UsuarioModificacion = @UsuarioModificacion 
 where Cod_Cliente_Prospecto = @Cod_Cliente_Prospecto
end
 if @Indicador = 3

 begin 
 delete dbo.Clientes_Prospectos where Cod_Cliente_Prospecto = @Cod_Cliente_Prospecto

 end

  if @Indicador = 4
  begin 
  select Cod_Cliente_Prospecto,Nombre,Cod_Paquete,Fecha_Estimada_Contratar,Celular,Cod_Empleado,FechaCreacion,UsuarioCreacion,
  FechaModificacion,UsuarioModificacion from dbo.Clientes_Prospectos
  where UsuarioCreacion = @UsuarioCreacion

end
  if @Indicador = 5
  begin
  select Cod_Cliente_Prospecto,Nombre,Cod_Paquete,Fecha_Estimada_Contratar,Celular,Cod_Empleado,FechaCreacion,UsuarioCreacion,
  FechaModificacion,UsuarioModificacion from dbo.Clientes_Prospectos
  where Cod_Cliente_Prospecto = @Cod_Cliente_Prospecto

end

 if @Indicador = 6
  begin
  select Cod_Cliente_Prospecto,Clientes_Prospectos.Nombre,Paquete,Fecha_Estimada_Contratar,Celular,Nombre_Empleado,Clientes_Prospectos.FechaCreacion,
  Clientes_Prospectos.UsuarioCreacion,Clientes_Prospectos.FechaModificacion,Clientes_Prospectos.UsuarioModificacion 
  from dbo.Clientes_Prospectos 
  INNER JOIN Paquetes ON Paquetes.Cod_Paquete = Clientes_Prospectos.Cod_Paquete
  INNER JOIN Empleados ON Empleados.Cod_Empleado = Clientes_Prospectos.Cod_Empleado
  where Clientes_Prospectos.UsuarioCreacion = @UsuarioCreacion

end

if @Indicador = 7
  begin
  select Cod_Cliente_Prospecto,Clientes_Prospectos.Nombre,Paquete,Fecha_Estimada_Contratar,Celular,Nombre_Empleado,Clientes_Prospectos.FechaCreacion,
  Clientes_Prospectos.UsuarioCreacion,Clientes_Prospectos.FechaModificacion,Clientes_Prospectos.UsuarioModificacion 
  from dbo.Clientes_Prospectos 
  INNER JOIN Paquetes ON Paquetes.Cod_Paquete = Clientes_Prospectos.Cod_Paquete
  INNER JOIN Empleados ON Empleados.Cod_Empleado = Clientes_Prospectos.Cod_Empleado

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_ClientesProspectos] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_Departamento_Emp]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Departamento_Emp] @Indicador int, @Cod_Depto_Emp as int, @Descripcion varchar(150), @UsuarioCreacion varchar(50), @UsuarioModificacion varchar(50)

as
begin

if @Indicador = 1

begin
insert into dbo.Departamento_Emp select isnull((select max(Cod_Depto_Emp) from dbo.Departamento_Emp),0)+1,@Descripcion,GETDATE(),@UsuarioCreacion,null,null

end
 if @Indicador = 2
 begin
 update dbo.Departamento_Emp set Descripcion = @Descripcion, UsuarioModificacion = @UsuarioModificacion, FechaModificacion = getdate() where Cod_Depto_Emp = @Cod_Depto_Emp
end
 if @Indicador = 3

 begin 
 delete dbo.Departamento_Emp where Cod_Depto_Emp = @Cod_Depto_Emp

 end

  if @Indicador = 4
  begin 
  select Cod_Depto_Emp,Descripcion,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion from dbo.Departamento_Emp

end
  if @Indicador = 5
  begin
  select Cod_Depto_Emp,Descripcion,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion from dbo.Departamento_Emp where Cod_Depto_Emp = @Cod_Depto_Emp

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_Departamento_Emp] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_DepartamentoPais]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_DepartamentoPais] @Indicador int, @IDDEPARTAMENTO as int, @DEPARTAMENTO varchar(75), @IDPAIS int

as
begin

if @Indicador = 1

begin
insert into dbo.Departamento select isnull((select max(IDDEPARTAMENTO) from dbo.Departamento),0)+1,@DEPARTAMENTO,@IDPAIS

end
 if @Indicador = 2
 begin
 update dbo.Departamento set DEPARTAMENTO = @DEPARTAMENTO, IDPAIS = @IDPAIS where IDDEPARTAMENTO = @IDDEPARTAMENTO
end
 if @Indicador = 3

 begin 
 delete dbo.Departamento where IDDEPARTAMENTO = @IDDEPARTAMENTO

 end

  if @Indicador = 4
  begin 
  select IDDEPARTAMENTO,DEPARTAMENTO,IDPAIS from dbo.Departamento

end
  if @Indicador = 5
  begin
  select IDDEPARTAMENTO,DEPARTAMENTO,IDPAIS from dbo.Departamento where IDDEPARTAMENTO = @IDDEPARTAMENTO

end

if @Indicador = 6
  begin
  select IDDEPARTAMENTO,DEPARTAMENTO,Pais.PAIS AS PAIS from dbo.Departamento 
  INNER JOIN Pais ON Pais.IDPAIS = Departamento.IDPAIS
end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_DepartamentoPais] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_Empleados]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Empleados] @Indicador int, @Cod_Empleado as int, @Identidad_Empleado varchar(15), @Nombre_Empleado varchar(75), 
@Edad int, @Fecha_Nacimiento date, @Cod_Genero int, @Email varchar(50), @Telefono varchar(12), @Cod_EstadoCivil int, @IDMUNICIPIO int,
@Num_Contador varchar(12), @Propietario_Vivienda bit, @Cod_Cargo int, @Cod_Turno int, @Estado bit, @UsuarioCreacion varchar(50), 
@UsuarioModificacion varchar(50)

as
begin

if @Indicador = 1

begin
insert into dbo.Empleados select isnull((select max(Cod_Empleado) from dbo.Empleados),0)+1,@Identidad_Empleado,@Nombre_Empleado,@Edad,
@Fecha_Nacimiento,@Cod_Genero,@Email,@Telefono,@Cod_EstadoCivil,@IDMUNICIPIO,@Num_Contador,@Propietario_Vivienda,@Cod_Cargo,@Cod_Turno,
@Estado,getdate(),@UsuarioCreacion,null,null

end
 if @Indicador = 2
 begin
 update dbo.Empleados set Identidad_Empleado = @Identidad_Empleado, Nombre_Empleado = @Nombre_Empleado,Edad = @Edad,
 Fecha_Nacimiento = @Fecha_Nacimiento,Cod_Genero = @Cod_Genero,Email = @Email, Telefono = @Telefono, Cod_EstadoCivil = @Cod_EstadoCivil, 
 IDMUNICIPIO = @IDMUNICIPIO, Num_Contador = @Num_Contador, Propietario_Vivienda = @Propietario_Vivienda, 
 Cod_Cargo = @Cod_Cargo, Cod_Turno = @Cod_Turno, Estado = @Estado, UsuarioModificacion = @UsuarioModificacion, FechaModificacion = getdate() 
 where Cod_Empleado = @Cod_Empleado
end
 if @Indicador = 3

 begin 
 delete dbo.Empleados where Cod_Empleado = @Cod_Empleado

 end

  if @Indicador = 4
  begin 
  select Cod_Empleado,Identidad_Empleado,Nombre_Empleado,Edad,Fecha_Nacimiento,Cod_Genero,Email,Telefono,Cod_EstadoCivil,
  IDMUNICIPIO,Num_Contador,Propietario_Vivienda,Cod_Cargo,Cod_Turno,Estado,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion
   from dbo.Empleados where Estado = @Estado

end
  if @Indicador = 5
  begin
  select Cod_Empleado,Identidad_Empleado,Nombre_Empleado,Edad,Fecha_Nacimiento,Cod_Genero,Email,Telefono,Cod_EstadoCivil,
  IDMUNICIPIO,Num_Contador,Propietario_Vivienda,Cod_Cargo,Cod_Turno,Estado,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion
   from dbo.Empleados where Cod_Empleado = @Cod_Empleado

end

  if @Indicador = 6
  begin
  select Cod_Empleado,Identidad_Empleado,Nombre_Empleado,Edad,Fecha_Nacimiento,Genero,Email,Telefono,Estado_Civil,
  MUNICIPIO AS Municipio,Num_Contador,Propietario_Vivienda,Cargo,Turno,Estado,Empleados.FechaCreacion,Empleados.UsuarioCreacion,
  Empleados.FechaModificacion,Empleados.UsuarioModificacion
   from dbo.Empleados 
   INNER JOIN Generos ON Generos.Cod_Genero = Empleados.Cod_Genero
   INNER JOIN Estado_Civil ON Estado_Civil.Cod_EstadoCivil = Empleados.Cod_EstadoCivil
   INNER JOIN Municipio ON Municipio.IDMUNICIPIO = Empleados.IDMUNICIPIO
   INNER JOIN Cargos ON Cargos.Cod_Cargo = Empleados.Cod_Cargo
   INNER JOIN Turnos ON Turnos.Cod_Turno = Empleados.Cod_Turno
   where Estado = @Estado

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_Empleados] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_EstadoCivil]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EstadoCivil] @Indicador int, @Cod_EstadoCivil as int, @Estado_Civil varchar(75)

as
begin

if @Indicador = 1

begin
insert into dbo.Estado_Civil select isnull((select max(Cod_EstadoCivil) from dbo.Estado_Civil),0)+1,@Estado_Civil

end
 if @Indicador = 2
 begin
 update dbo.Estado_Civil set Estado_Civil = @Estado_Civil where Cod_EstadoCivil = @Cod_EstadoCivil
end
 if @Indicador = 3

 begin 
 delete dbo.Estado_Civil where Cod_EstadoCivil = @Cod_EstadoCivil

 end

  if @Indicador = 4
  begin 
  select Cod_EstadoCivil,Estado_Civil from dbo.Estado_Civil

end
  if @Indicador = 5
  begin
     select Cod_EstadoCivil,Estado_Civil from dbo.Estado_Civil where Cod_EstadoCivil = @Cod_EstadoCivil
end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_EstadoCivil] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_EventosUsuario]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_EventosUsuario] @Indicador int, @Cod_Usuario as int, @Cod_Empleado int, @Usuario varchar(75), @Contrasena varchar(200), @IdNivelUser int, @Estado bit

as
begin

if @Indicador = 1

begin
insert into dbo.Usuarios select isnull((select max(Cod_Usuario) from dbo.Usuarios),0)+1,@Cod_Empleado,@Usuario,@Contrasena,@IdNivelUser,@Estado

end
 if @Indicador = 2
 begin
 update dbo.Usuarios set Cod_Empleado = @Cod_Empleado, Usuario = @Usuario,Contrasena = Contrasena,IdNivelUser = @IdNivelUser,Estado = @Estado where Cod_Usuario = @Cod_Usuario
end
 if @Indicador = 3

 begin 
 delete dbo.Usuarios where Cod_Usuario = @Cod_Usuario

 end

  if @Indicador = 4
  begin 
  select Cod_Usuario,Cod_Empleado,Usuario,Contrasena,IdNivelUser,Estado from dbo.Usuarios where Estado = @Estado

end
  if @Indicador = 5
  begin
   select Cod_Usuario,Cod_Empleado,Usuario,Contrasena,IdNivelUser,Estado from dbo.Usuarios where Cod_Usuario = @Cod_Usuario

end

  if @Indicador = 6
  begin
   select Cod_Usuario,Empleados.Nombre_Empleado,Usuario,Contrasena,Nivel_Acceso.Nivel_Acceso,Usuarios.Estado from dbo.Usuarios 
   inner join Empleados on Empleados.Cod_Empleado = Usuarios.Cod_Empleado
   inner join Nivel_Acceso on Nivel_Acceso.IdNivelUser = Usuarios.IdNivelUser
   where Usuarios.Estado = @Estado

end

  if @Indicador = 7
  begin
  select Cod_Usuario,Empleados.Nombre_Empleado,Usuario,Contrasena,Nivel_Acceso.Nivel_Acceso,Usuarios.Estado from dbo.Usuarios 
   inner join Empleados on Empleados.Cod_Empleado = Usuarios.Cod_Empleado
   inner join Nivel_Acceso on Nivel_Acceso.IdNivelUser = Usuarios.IdNivelUser
   where Usuarios.Estado = @Estado

end
end



GO
ALTER AUTHORIZATION ON [dbo].[sp_EventosUsuario] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_Generos]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Generos] @Indicador int, @Cod_Genero as int, @Genero varchar(75)

as
begin

if @Indicador = 1

begin
insert into dbo.Generos select isnull((select max(Cod_Genero) from dbo.Generos),0)+1,@Genero

end
 if @Indicador = 2
 begin
 update dbo.Generos set Genero = @Genero where Cod_Genero = @Cod_Genero
end
 if @Indicador = 3

 begin 
 delete dbo.Generos where Cod_Genero = @Cod_Genero

 end

  if @Indicador = 4
  begin 
  select Cod_Genero,Genero from Generos

end
  if @Indicador = 5
  begin
  select Cod_Genero,Genero from Generos where Cod_Genero = @Cod_Genero

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_Generos] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_Mantenimiento]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Mantenimiento] @Indicador int, @Cod_Orden_Mant as int,@Cod_Cliente int, @Fecha_Mantenimiento date, @Cod_Empleado int, 
@Telefono varchar(15), @UsuarioCreacion varchar(50), @UsuarioModificacion varchar(50)

as
begin

if @Indicador = 1

begin
insert into dbo.Ordenes_Mantenimiento select isnull((select max(Cod_Orden_Mant) from dbo.Ordenes_Mantenimiento),0)+1,@Cod_Cliente,@Fecha_Mantenimiento,
@Cod_Empleado,@Telefono,GETDATE(),@UsuarioCreacion,null,null

end
 if @Indicador = 2
 begin
 update dbo.Ordenes_Mantenimiento set Cod_Cliente = @Cod_Cliente, Fecha_Mantenimiento = @Fecha_Mantenimiento, Cod_Empleado = @Cod_Empleado,Telefono=@Telefono,
 FechaModificacion = getdate(), UsuarioModificacion = @UsuarioModificacion 
 where Cod_Orden_Mant = @Cod_Orden_Mant
end
 if @Indicador = 3

 begin 
 delete dbo.Ordenes_Mantenimiento where Cod_Orden_Mant = @Cod_Orden_Mant

 end

  if @Indicador = 4
  begin 
  select Cod_Orden_Mant,Cod_Cliente,Fecha_Mantenimiento,Cod_Empleado,Telefono,FechaCreacion,UsuarioCreacion,
  FechaModificacion,UsuarioModificacion from dbo.Ordenes_Mantenimiento
  where UsuarioCreacion = @UsuarioCreacion

end
  if @Indicador = 5
  begin
  select Cod_Orden_Mant,Cod_Cliente,Fecha_Mantenimiento,Cod_Empleado,Telefono,FechaCreacion,UsuarioCreacion,
  FechaModificacion,UsuarioModificacion from dbo.Ordenes_Mantenimiento
  where Cod_Orden_Mant = @Cod_Orden_Mant

end

 if @Indicador = 6
  begin
  select Cod_Orden_Mant,Nombre_Cliente,Ordenes_Mantenimiento.Fecha_Mantenimiento,Nombre_Empleado,Ordenes_Mantenimiento.Telefono,Ordenes_Mantenimiento.FechaCreacion,
  Ordenes_Mantenimiento.UsuarioCreacion,Ordenes_Mantenimiento.FechaModificacion,Ordenes_Mantenimiento.UsuarioModificacion 
  from dbo.Ordenes_Mantenimiento 
  INNER JOIN Clientes ON Clientes.Cod_Cliente = Ordenes_Mantenimiento.Cod_Cliente
  INNER JOIN Empleados ON Empleados.Cod_Empleado = Ordenes_Mantenimiento.Cod_Empleado
  where Ordenes_Mantenimiento.UsuarioCreacion = @UsuarioCreacion

end

if @Indicador = 7
  begin
  select Cod_Orden_Mant,Nombre_Cliente,Ordenes_Mantenimiento.Fecha_Mantenimiento,Nombre_Empleado,Ordenes_Mantenimiento.Telefono,Ordenes_Mantenimiento.FechaCreacion,
  Ordenes_Mantenimiento.UsuarioCreacion,Ordenes_Mantenimiento.FechaModificacion,Ordenes_Mantenimiento.UsuarioModificacion 
  from dbo.Ordenes_Mantenimiento 
  INNER JOIN Clientes ON Clientes.Cod_Cliente = Ordenes_Mantenimiento.Cod_Cliente
  INNER JOIN Empleados ON Empleados.Cod_Empleado = Ordenes_Mantenimiento.Cod_Empleado

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_Mantenimiento] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_Municipios]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Municipios] @Indicador int, @IDMUNICIPIO as int, @MUNICIPIO varchar(75), @IDDEPARTAMENTO int

as
begin

if @Indicador = 1

begin
insert into dbo.Municipio select isnull((select max(IDMUNICIPIO) from dbo.Municipio),0)+1,@MUNICIPIO,@IDDEPARTAMENTO

end
 if @Indicador = 2
 begin
 update dbo.Municipio set MUNICIPIO = @MUNICIPIO, IDDEPARTAMENTO = @IDDEPARTAMENTO where IDMUNICIPIO = @IDMUNICIPIO
end
 if @Indicador = 3

 begin 
 delete dbo.Municipio where IDMUNICIPIO = @IDMUNICIPIO

 end

  if @Indicador = 4
  begin 
  select IDMUNICIPIO,MUNICIPIO,IDDEPARTAMENTO from dbo.Municipio

end
  if @Indicador = 5
  begin
  select IDMUNICIPIO,MUNICIPIO,IDDEPARTAMENTO from dbo.Municipio where IDMUNICIPIO = @IDMUNICIPIO

end

if @Indicador = 6
  begin
  select IDMUNICIPIO,MUNICIPIO,Departamento.DEPARTAMENTO AS DEPARTAMENTO from dbo.Municipio
  INNER JOIN Departamento ON Departamento.IDDEPARTAMENTO = Municipio.IDDEPARTAMENTO

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_Municipios] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_Nacionalidad]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Nacionalidad] @Indicador int, @Cod_Nacionalidad as int, @Nacionalidad varchar(75)

as
begin

if @Indicador = 1

begin
insert into dbo.Nacionalidad select isnull((select max(Cod_Nacionalidad) from dbo.Nacionalidad),0)+1,@Nacionalidad

end
 if @Indicador = 2
 begin
 update dbo.Nacionalidad set Nacionalidad = @Nacionalidad where Cod_Nacionalidad = @Cod_Nacionalidad
end
 if @Indicador = 3

 begin 
 delete dbo.Nacionalidad where Cod_Nacionalidad = @Cod_Nacionalidad

 end

  if @Indicador = 4
  begin 
  select Cod_Nacionalidad,Nacionalidad from dbo.Nacionalidad

end
  if @Indicador = 5
  begin
  select Cod_Nacionalidad,Nacionalidad from dbo.Nacionalidad where Cod_Nacionalidad = @Cod_Nacionalidad

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_Nacionalidad] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_NivelAcceso]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_NivelAcceso] @Indicador int, @IdNivelUser as int, @Nivel_Acceso varchar(75)

as
begin

if @Indicador = 1

begin
insert into dbo.Nivel_Acceso select isnull((select max(IdNivelUser) from dbo.Nivel_Acceso),0)+1,@Nivel_Acceso

end
 if @Indicador = 2
 begin
 update dbo.Nivel_Acceso set Nivel_Acceso = @Nivel_Acceso where IdNivelUser = @IdNivelUser
end
 if @Indicador = 3

 begin 
 delete dbo.Nivel_Acceso where IdNivelUser = @IdNivelUser

 end

  if @Indicador = 4
  begin 
  select IdNivelUser,Nivel_Acceso from dbo.Nivel_Acceso

end
  if @Indicador = 5
  begin
  select IdNivelUser,Nivel_Acceso from dbo.Nivel_Acceso where IdNivelUser = @IdNivelUser

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_NivelAcceso] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_Ordenes]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Ordenes] @Indicador int, @Cod_Cliente_Pendiente as int,@Cod_Cliente int, @Fecha_Instalacion date, @Cod_Empleado int, 
@Telefono varchar(15), @UsuarioCreacion varchar(50), @UsuarioModificacion varchar(50)

as
begin

if @Indicador = 1

begin
insert into dbo.Orden_Instalacion select isnull((select max(Cod_Cliente_Pendiente) from dbo.Orden_Instalacion),0)+1,@Cod_Cliente,@Fecha_Instalacion,
@Cod_Empleado,@Telefono,GETDATE(),@UsuarioCreacion,null,null

end
 if @Indicador = 2
 begin
 update dbo.Orden_Instalacion set Cod_Cliente = @Cod_Cliente, Fecha_Instalacion = @Fecha_Instalacion, Cod_Empleado = @Cod_Empleado,Telefono=@Telefono,
 FechaModificacion = getdate(), UsuarioModificacion = @UsuarioModificacion 
 where Cod_Cliente_Pendiente = @Cod_Cliente_Pendiente
end
 if @Indicador = 3

 begin 
 delete dbo.Orden_Instalacion where Cod_Cliente_Pendiente = @Cod_Cliente_Pendiente

 end

  if @Indicador = 4
  begin 
  select Cod_Cliente_Pendiente,Cod_Cliente,Fecha_Instalacion,Cod_Empleado,Telefono,FechaCreacion,UsuarioCreacion,
  FechaModificacion,UsuarioModificacion from dbo.Orden_Instalacion
  where UsuarioCreacion = @UsuarioCreacion

end
  if @Indicador = 5
  begin
  select Cod_Cliente_Pendiente,Cod_Cliente,Fecha_Instalacion,Cod_Empleado,Telefono,FechaCreacion,UsuarioCreacion,
  FechaModificacion,UsuarioModificacion from dbo.Orden_Instalacion
  where Cod_Cliente_Pendiente = @Cod_Cliente_Pendiente

end

 if @Indicador = 6
  begin
  select Cod_Cliente_Pendiente,Nombre_Cliente,Fecha_Instalacion,Nombre_Empleado,Orden_Instalacion.Telefono,Orden_Instalacion.FechaCreacion,
  Orden_Instalacion.UsuarioCreacion,Orden_Instalacion.FechaModificacion,Orden_Instalacion.UsuarioModificacion 
  from dbo.Orden_Instalacion 
  INNER JOIN Clientes ON Clientes.Cod_Cliente = Orden_Instalacion.Cod_Cliente
  INNER JOIN Empleados ON Empleados.Cod_Empleado = Orden_Instalacion.Cod_Empleado
  where Orden_Instalacion.UsuarioCreacion = @UsuarioCreacion

end

 if @Indicador = 7
  begin
  select Cod_Cliente_Pendiente,Nombre_Cliente,Fecha_Instalacion,Nombre_Empleado,Orden_Instalacion.Telefono,Orden_Instalacion.FechaCreacion,
  Orden_Instalacion.UsuarioCreacion,Orden_Instalacion.FechaModificacion,Orden_Instalacion.UsuarioModificacion 
  from dbo.Orden_Instalacion 
  INNER JOIN Clientes ON Clientes.Cod_Cliente = Orden_Instalacion.Cod_Cliente
  INNER JOIN Empleados ON Empleados.Cod_Empleado = Orden_Instalacion.Cod_Empleado

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_Ordenes] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_Pais]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Pais] @Indicador int, @IDPAIS as int, @ISO char(2), @PAIS varchar(75)
as
begin

if @Indicador = 1

begin
insert into dbo.Pais select isnull((select max(IDPAIS) from dbo.Pais),0)+1,@ISO,@PAIS

end
 if @Indicador = 2
 begin
 update dbo.Pais set ISO = @ISO, PAIS = @PAIS where IDPAIS = @IDPAIS
end
 if @Indicador = 3

 begin 
 delete dbo.Pais where IDPAIS = @IDPAIS

 end

  if @Indicador = 4
  begin 
  select IDPAIS,ISO,PAIS from dbo.Pais

end
  if @Indicador = 5
  begin
  select IDPAIS,ISO,PAIS from dbo.Pais where IDPAIS = @IDPAIS

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_Pais] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_Paquetes]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Paquetes] @Indicador int, @Cod_Paquete as int, @Cod_TipoPaquete int, @Paquete varchar(75), @Precio_Paquete varchar(10), @Estado bit

as
begin

if @Indicador = 1

begin
insert into dbo.Paquetes select isnull((select max(Cod_Paquete) from dbo.Paquetes),0)+1,@Cod_TipoPaquete,@Paquete,@Precio_Paquete,@Estado

end
 if @Indicador = 2
 begin
 update dbo.Paquetes set Cod_TipoPaquete = @Cod_TipoPaquete, Paquete = @Paquete,Precio_Paquete = @Precio_Paquete,Estado = @Estado where Cod_Paquete = @Cod_Paquete
end
 if @Indicador = 3

 begin 
 delete dbo.Paquetes where Cod_Paquete = @Cod_Paquete

 end

  if @Indicador = 4
  begin 
  select Cod_Paquete,Cod_TipoPaquete,Paquete,Precio_Paquete,Estado from dbo.Paquetes where Estado = @Estado

end
  if @Indicador = 5
  begin
  select Cod_Paquete,Cod_TipoPaquete,Paquete,Precio_Paquete,Estado from dbo.Paquetes where Cod_Paquete = @Cod_Paquete

end

  if @Indicador = 6
  begin
  select Cod_Paquete,Tipo_Paquete.Tipo_Paquete AS Tipo_Paquetes,Paquete,Precio_Paquete,Estado from dbo.Paquetes 
  INNER JOIN Tipo_Paquete ON Tipo_Paquete.Cod_TipoPaquete = Paquetes.Cod_TipoPaquete
  where Estado = @Estado

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_Paquetes] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_Sector]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Sector] @Indicador int, @IDSECTOR as int, @SECTOR varchar(75), @IdTipoSector int, @IDMUNICIPIO int

as
begin

if @Indicador = 1

begin
insert into dbo.Sector select isnull((select max(IDSECTOR) from dbo.Sector),0)+1,@SECTOR,@IdTipoSector,@IDMUNICIPIO

end
 if @Indicador = 2
 begin
 update dbo.Sector set SECTOR = @SECTOR, IdTipoSector = @IdTipoSector,IDMUNICIPIO = @IDMUNICIPIO where IDSECTOR = @IDSECTOR
end
 if @Indicador = 3

 begin 
 delete dbo.Sector where IDSECTOR = @IDSECTOR

 end

  if @Indicador = 4
  begin 
  select IDSECTOR,SECTOR,IdTipoSector,IDMUNICIPIO from dbo.Sector

end
  if @Indicador = 5
  begin
  select IDSECTOR,SECTOR,IdTipoSector,IDMUNICIPIO from dbo.Sector where IDSECTOR = @IDSECTOR

end
  if @Indicador = 6
  begin
  select IDSECTOR,SECTOR,TipoSector.TipoSector AS TIPO_SECTOR,Municipio.MUNICIPIO as MUNICIPIO from dbo.Sector
  INNER JOIN TipoSector ON TipoSector.IdTipoSector = Sector.IdTipoSector 
  INNER JOIN Municipio ON Municipio.IDMUNICIPIO = Sector.IDMUNICIPIO
end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_Sector] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_Tipo_Paquete]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Tipo_Paquete] @Indicador int, @Cod_TipoPaquete as int, @Tipo_Paquete varchar(50), @Descripcion varchar(150), @FechaCreacion date, @UsuarioCreacion varchar(50), @FechaModificacion date, @UsuarioModificacion varchar(50)

as
begin

if @Indicador = 1

begin
insert into dbo.Tipo_Paquete select isnull((select max(Cod_TipoPaquete) from dbo.Tipo_Paquete),0)+1,@Tipo_Paquete,@Descripcion,GETDATE(),@UsuarioCreacion,null,null

end
 if @Indicador = 2
 begin
 update dbo.Tipo_Paquete set Tipo_Paquete = @Tipo_Paquete, Descripcion = @Descripcion, FechaModificacion = getdate(), UsuarioModificacion = @UsuarioModificacion where Cod_TipoPaquete = @Cod_TipoPaquete
end
 if @Indicador = 3

 begin 
 delete dbo.Tipo_Paquete where Cod_TipoPaquete = @Cod_TipoPaquete

 end

  if @Indicador = 4
  begin 
  select Cod_TipoPaquete,Tipo_Paquete,Descripcion,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion from dbo.Tipo_Paquete

end
  if @Indicador = 5
  begin
    select Cod_TipoPaquete,Tipo_Paquete,Descripcion,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion from dbo.Tipo_Paquete where Cod_TipoPaquete = @Cod_TipoPaquete

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_Tipo_Paquete] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_TipoSector]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_TipoSector] @Indicador int, @IdTipoSector as int, @TipoSector varchar(75)

as
begin

if @Indicador = 1

begin
insert into dbo.TipoSector select isnull((select max(IdTipoSector) from dbo.TipoSector),0)+1,@TipoSector

end
 if @Indicador = 2
 begin
 update dbo.TipoSector set TipoSector = @TipoSector where IdTipoSector = @IdTipoSector
end
 if @Indicador = 3

 begin 
 delete dbo.TipoSector where IdTipoSector = @IdTipoSector

 end

  if @Indicador = 4
  begin 
  select IdTipoSector,TipoSector from dbo.TipoSector

end
  if @Indicador = 5
  begin
  select IdTipoSector,TipoSector from dbo.TipoSector where IdTipoSector = @IdTipoSector

end
end


GO
ALTER AUTHORIZATION ON [dbo].[sp_TipoSector] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[sp_Turnos]    Script Date: 31/08/2023 8:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Turnos] @Indicador int, @Cod_Turno as int, @Turno varchar(75), @Descripcion varchar(150)

as
begin

if @Indicador = 1

begin
insert into dbo.Turnos select isnull((select max(Cod_Turno) from dbo.Turnos),0)+1,@Turno,@Descripcion

end
 if @Indicador = 2
 begin
 update dbo.Turnos set Turno = @Turno, Descripcion = @Descripcion  where Cod_Turno = @Cod_Turno
end
 if @Indicador = 3

 begin 
 delete dbo.Turnos where Cod_Turno = @Cod_Turno

 end

  if @Indicador = 4
  begin 
  select Cod_Turno,Turno,Descripcion from dbo.Turnos

end
  if @Indicador = 5
  begin
  select Cod_Turno,Turno,Descripcion from dbo.Turnos where Cod_Turno = @Cod_Turno

end
end

GO
ALTER AUTHORIZATION ON [dbo].[sp_Turnos] TO  SCHEMA OWNER 
GO
/****** Object:  Statistic [_WA_Sys_00000002_0EA330E9]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_0EA330E9] ON [dbo].[Cargos]([Cod_Depto_Emp]) WITH STATS_STREAM = 0x010000000100000000000000000000007FE0074100000000EA01000000000000AA010000000000003803FFFF3800000004000A000000000000000000000000000700000089C5EB004FB0000004000000000000000400000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000804000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F010000000400001000140000004040000000000000803F020000000400000400000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000003_0EA330E9]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000003_0EA330E9] ON [dbo].[Cargos]([Cargo]) WITH STATS_STREAM = 0x01000000010000000000000000000000E8116F010000000047030000000000000703000000000000A7030000A70000004B0000000000000028D000004600000007000000E9B9FA0052B0000004000000000000000400000000000000000000000000803E0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000040000000400000001000000100000000000D44100008040000000000000D441000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000013000000000000000000000000000000E60000000000000093010000000000009B0100000000000020000000000000005C000000000000009100000000000000AF00000000000000300010000000803F000000000000803F04000001003C0041646D696E6973747261646F722044652056656E746173205265736964656E6369616C6573300010000000803F000000000000803F04000001003500456A6563757469766F2044652056656E7461205265736964656E6369616C300010000000803F000000000000803F04000001001E004A656665204954300010000000803F000000000000803F0400000100370053757065727669736F722044652056656E746173205265736964656E6369616CFF01000000000000000400000004000000280000002800000000000000000000006A00000041646D696E6973747261646F722044652056656E746173205265736964656E6369616C6573456A6563757469766F2044652056656E7461205265736964656E6369616C4A65666520495453757065727669736F722044652056656E746173205265736964656E6369616C0500000040000000008125000000811E250000810743000001204A0000000400000000000000
GO
/****** Object:  Statistic [PK__Cargos__BC3BC2E7468F1F71]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Cargos]([PK__Cargos__BC3BC2E7468F1F71]) WITH STATS_STREAM = 0x0100000001000000000000000000000027E5E30D000000000902000000000000C90100000000000038031A6E3800000004000A0000000000000000000000000007000000C3C5EB004FB00000040000000000000004000000000000000000803F0000803E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000014000000000080400000804000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000005D00000000000000650000000000000018000000000000002F000000000000004600000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F000000000000803F040000000400000400000000000000, ROWCOUNT = 5, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_108B795B]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_108B795B] ON [dbo].[Clientes]([Nombre_Cliente]) WITH STATS_STREAM = 0x01000000010000000000000000000000E570F96A0000000071020000000000003102000000000000A7030000A7000000960000000000000028D000000400000007000000B2E06F0151B0000002000000000000000200000000000000000000000000003F00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000200000002000000010000001000000000008C41000000400000000000008C410000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000130000000000000000000000000000006100000000000000BD00000000000000C50000000000000010000000000000003600000000000000300010000000803F000000000000803F04000001002600416C6F6E6472612045737061646173300010000000803F000000000000803F04000001002B00496C73652044616E69656C612043617263616D6FFF010000000000000002000000020000002800000028000000000000000000000023000000416C6F6E6472612045737061646173496C73652044616E69656C612043617263616D6F030000004000000000810F00000001140F0000000200000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000006_108B795B]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000006_108B795B] ON [dbo].[Clientes]([Cod_Genero]) WITH STATS_STREAM = 0x010000000100000000000000000000005EB8287000000000EA01000000000000AA01000000000000380300003800000004000A0000000000000000000000000007000000B3C5EB004FB0000002000000000000000200000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F000000000000803F020000000400000200000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000007_108B795B]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000007_108B795B] ON [dbo].[Clientes]([Cod_EstadoCivil]) WITH STATS_STREAM = 0x01000000010000000000000000000000E71B03D400000000CB010000000000008B0100000000000038031A6E3800000004000A0000000000000000000000000007000000B1C5EB004FB0000002000000000000000200000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F00000000000000270000000000000008000000000000001000140000000040000000000000803F010000000400000200000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000008_108B795B]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000008_108B795B] ON [dbo].[Clientes]([Cod_Nacionalidad]) WITH STATS_STREAM = 0x010000000100000000000000000000007AF7F7A900000000CB010000000000008B0100000000000038031A6E3800000004000A0000000000000000000000000007000000B4C5EB004FB0000002000000000000000200000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F00000000000000270000000000000008000000000000001000140000000040000000000000803F010000000400000200000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000009_108B795B]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000009_108B795B] ON [dbo].[Clientes]([IDSECTOR]) WITH STATS_STREAM = 0x0100000001000000000000000000000069E09EAA00000000EA01000000000000AA01000000000000380300003800000004000A0000000000000000000000000007000000B8C5EB004FB0000002000000000000000200000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F000000000000803F030000000400000200000000000000
GO
/****** Object:  Statistic [_WA_Sys_0000000D_108B795B]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_0000000D_108B795B] ON [dbo].[Clientes]([Cod_Paquete]) WITH STATS_STREAM = 0x01000000010000000000000000000000A299F54000000000CB010000000000008B0100000000000038031A6E3800000004000A0000000000000000000000000007000000B6C5EB004FB0000002000000000000000200000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F00000000000000270000000000000008000000000000001000140000000040000000000000803F010000000400000200000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000015_108B795B]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000015_108B795B] ON [dbo].[Clientes]([Estado]) WITH STATS_STREAM = 0x01000000010000000000000000000000CC73949000000000C801000000000000880100000000000068031A6E680000000100010000000000000000000000000007000000F239690151B0000002000000000000000200000000000000000000000000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000100000001000000110000000000803F00000040000000000000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001C00000000000000240000000000000008000000000000001000110000000040000000000000803F010400000200000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000017_108B795B]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000017_108B795B] ON [dbo].[Clientes]([UsuarioCreacion]) WITH STATS_STREAM = 0x0100000001000000000000000000000074D0F8F3000000001902000000000000D901000000000000A7020000A7000000320000000000000028D00000000000000700000048F36D0151B0000002000000000000000200000000000000000000000000803F00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000001000000010000001000000000001041000000400000000000001041000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000013000000000000000000000000000000280000000000000065000000000000006D0000000000000008000000000000003000100000000040000000000000803F040000010020004C656F6E6172646F4DFF0100000000000000020000000100000028000000280000000000000000000000090000004C656F6E6172646F4D0200000040000000000209000000000200000000000000
GO
/****** Object:  Statistic [PK__Clientes__4418E207C85B165C]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Clientes]([PK__Clientes__4418E207C85B165C]) WITH STATS_STREAM = 0x01000000010000000000000000000000F854B4A200000000EA01000000000000AA01000000000000380300003800000004000A0000000000000000000000000007000000D6C5EB004FB0000002000000000000000200000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F000000000000803F020000000400000200000000000000, ROWCOUNT = 12, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000003_1273C1CD]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000003_1273C1CD] ON [dbo].[Clientes_Prospectos]([Cod_Paquete]) WITH STATS_STREAM = 0x01000000010000000000000000000000E39A8B3500000000CB010000000000008B01000000000000380313003800000004000A00000000000000000002000000070000009746700151B0000003000000000000000300000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000404000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F00000000000000270000000000000008000000000000001000140000004040000000000000803F010000000400000300000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000006_1273C1CD]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000006_1273C1CD] ON [dbo].[Clientes_Prospectos]([Cod_Empleado]) WITH STATS_STREAM = 0x01000000010000000000000000000000E06EC9B300000000EA01000000000000AA01000000000000380300003800000004000A0000000000000000000000000007000000BAC5EB004FB0000003000000000000000300000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000404000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E000000000000004600000000000000100000000000000027000000000000001000140000000040000000000000803F01000000040000100014000000803F000000000000803F020000000400000300000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000008_1273C1CD]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000008_1273C1CD] ON [dbo].[Clientes_Prospectos]([UsuarioCreacion]) WITH STATS_STREAM = 0x01000000010000000000000000000000ED42F8D6000000004F020000000000000F02000000000000A7030000A7000000320000000000000028D0000000000000070000009346700151B0000003000000000000000300000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000010000000555505410000404000000000555505410000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000130000000000000000000000000000004E000000000000009B00000000000000A300000000000000100000000000000030000000000000003000100000000040000000000000803F040000010020004C656F6E6172646F4D300010000000803F000000000000803F04000001001E004C697A6574684DFF01000000000000000300000002000000280000002800000000000000000000000F0000004C656F6E6172646F4D697A6574684D040000004000000000400100000082080100000106090000000300000000000000
GO
/****** Object:  Statistic [PK__Clientes__037AE764FF8DB66D]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Clientes_Prospectos]([PK__Clientes__037AE764FF8DB66D]) WITH STATS_STREAM = 0x010000000100000000000000000000004592D2BD00000000EA01000000000000AA01000000000000380300003800000004000A00000000000000000000000000070000002A4A700151B00000030000000000000003000000000000000000803FABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000404000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F030000000400000300000000000000, ROWCOUNT = 3, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_145C0A3F]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_145C0A3F] ON [dbo].[Departamento]([DEPARTAMENTO]) WITH STATS_STREAM = 0x01000000010000000000000000000000F861BD3900000000DF040000000000009F04000000000000A7031A6EA70000004B0000000000000028D000000000000007000000A9D4FF0052B00000120000000000000012000000000000000000803F398E633D000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000100000000100000010000000721C0F410000904100000000721C0F4100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001300000000000000000000000000000073020000000000002B0300000000000033030000000000008000000000000000A000000000000000C000000000000000DC00000000000000FC000000000000001801000000000000350100000000000056010000000000007B010000000000009A01000000000000C201000000000000DF01000000000000FD010000000000001E020000000000003C020000000000005802000000000000300010000000803F000000000000803F0400000100200041746CE16E74696461300010000000803F000000000000803F0400000100200043686F6C7574656361300010000000803F000000000000803F04000001001C00436F6CF36E300010000000803F000000000000803F04000001002000436F6D617961677561300010000000803F000000000000803F04000001001C00436F70E16E300010000000803F000000000000803F04000001001D00436F7274E973300010000000803F000000000000803F04000001002100456C2050617261ED736F300010000000803F0000803F0000803F040000010025004772616369617320612044696F73300010000000803F000000000000803F04000001001F00496E7469627563E1300010000000803F000000000000803F0400000100280049736C6173206465206C6120426168ED61300010000000803F000000000000803F04000001001D004C612050617A300010000000803F000000000000803F04000001001E004C656D70697261300010000000803F000000000000803F040000010021004F636F74657065717565300010000000803F000000000000803F04000001001E004F6C616E63686F300010000000803F0000803F0000803F04000001001C0056616C6C65300010000000803F000000000000803F04000001001B00596F726FFF01000000000000000A0000000A000000280000002800000000000000000000005200000041746CE16E74696461436F6CF36E70E16E456C2050617261ED736F4772616369617320612044696F73496E7469627563E14C612050617A4F636F7465706571756553616E74612042E17262617261596F726F0C00000040000000008109000000C00209000081030B000001030E0000810A110000810E1B000081082900008106310000810A370000810D41000001044E0000001200000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000003_145C0A3F]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000003_145C0A3F] ON [dbo].[Departamento]([IDPAIS]) WITH STATS_STREAM = 0x010000000100000000000000000000003290360E00000000CB010000000000008B010000000000003803803F3800000004000A0000000000000000006F7274E907000000C1C5EB004FB0000012000000000000001200000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000904100000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F00000000000000270000000000000008000000000000001000140000009041000000000000803F660000000400001200000000000000
GO
/****** Object:  Statistic [PK__Departam__B529B33727D6125D]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Departamento]([PK__Departam__B529B33727D6125D]) WITH STATS_STREAM = 0x010000000100000000000000000000006B57EC6100000000E202000000000000A202000000000000380300003800000004000A0000000000000000006600000007000000D5C5EB004FB00000120000000000000012000000000000000000803F398E633D00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000A0000000A00000001000000140000000000804000009041000000000000804000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001100000000000000000000000000000036010000000000003E01000000000000500000000000000067000000000000007E000000000000009500000000000000AC00000000000000C300000000000000DA00000000000000F10000000000000008010000000000001F01000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F0000803F0000803F05000000040000100014000000803F0000803F0000803F07000000040000100014000000803F0000803F0000803F09000000040000100014000000803F0000803F0000803F0B000000040000100014000000803F0000803F0000803F0D000000040000100014000000803F0000803F0000803F0F000000040000100014000000803F0000803F0000803F11000000040000100014000000803F000000000000803F120000000400001200000000000000, ROWCOUNT = 18, PAGECOUNT = 1
GO
/****** Object:  Statistic [PK__Departam__DF3F77EAB5C8EA42]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Departamento_Emp]([PK__Departam__DF3F77EAB5C8EA42]) WITH STATS_STREAM = 0x01000000010000000000000000000000DDB6F4E000000000EA01000000000000AA01000000000000380300003800000004000A000000000000000000000000000700000089C5EB004FB0000002000000000000000200000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F000000000000803F020000000400000200000000000000, ROWCOUNT = 4, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000003_182C9B23]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000003_182C9B23] ON [dbo].[Empleados]([Nombre_Empleado]) WITH STATS_STREAM = 0x0100000001000000000000000000000080D5F894000000005D030000000000001D03000000000000A7030000A70000004B0000000000000028D0000000000000070000009CE06F0151B000000500000000000000050000000000000000000000CDCC4C3E00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000500000005000000010000001000000033339B410000A0400000000033339B41000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000013000000000000000000000000000000FC00000000000000A901000000000000B10100000000000028000000000000004C000000000000007F00000000000000AC00000000000000D800000000000000300010000000803F000000000000803F0400000100240041646D696E6973747261646F72300010000000803F000000000000803F04000001003300456477696E204C656F6E6172646F204D6F6C696E6120466C6F726573300010000000803F000000000000803F04000001002D00456C766961204A6F68616E612056656C61737175657A300010000000803F000000000000803F04000001002C004D6F6465737461204C697A6574682043686176657A300010000000803F000000000000803F0400000100240057696C736F6E205A756E696761FF01000000000000000500000005000000280000002800000000000000000000006000000041646D696E6973747261646F72456477696E204C656F6E6172646F204D6F6C696E6120466C6F7265736C766961204A6F68616E612056656C61737175657A4D6F6465737461204C697A6574682043686176657A57696C736F6E205A756E696761070000004000000000810D000000C0010D0000811B0E0000011529000081153E0000010D530000000500000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000006_182C9B23]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000006_182C9B23] ON [dbo].[Empleados]([Cod_Genero]) WITH STATS_STREAM = 0x010000000100000000000000000000004924290E00000000EA01000000000000AA0100000000000038036F6C3800000004000A0000000000000000006F68616E07000000C6C5EB004FB0000005000000000000000500000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000A04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E000000000000004600000000000000100000000000000027000000000000001000140000004040000000000000803F010000000400001000140000000040000000000000803F020000000400000500000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000009_182C9B23]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000009_182C9B23] ON [dbo].[Empleados]([Cod_EstadoCivil]) WITH STATS_STREAM = 0x0100000001000000000000000000000036B1468500000000EA01000000000000AA0100000000000038036F6C3800000004000A0000000000000000006F68616E07000000C4C5EB004FB0000005000000000000000500000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000A04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E000000000000004600000000000000100000000000000027000000000000001000140000004040000000000000803F010000000400001000140000000040000000000000803F020000000400000500000000000000
GO
/****** Object:  Statistic [_WA_Sys_0000000A_182C9B23]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_0000000A_182C9B23] ON [dbo].[Empleados]([IDMUNICIPIO]) WITH STATS_STREAM = 0x010000000100000000000000000000004B8E350700000000CB010000000000008B0100000000000038031A6E3800000004000A0000000000000000000000000007000000D3C5EB004FB0000005000000000000000500000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000A04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000A040000000000000803F010000000400000500000000000000
GO
/****** Object:  Statistic [_WA_Sys_0000000D_182C9B23]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_0000000D_182C9B23] ON [dbo].[Empleados]([Cod_Cargo]) WITH STATS_STREAM = 0x01000000010000000000000000000000F555D7C3000000000902000000000000C901000000000000380300003800000004000A0000000000000000000000000007000000C3C5EB004FB000000500000000000000050000000000000000000000ABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000014000000000080400000A04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000005D00000000000000650000000000000018000000000000002F0000000000000046000000000000001000140000000040000000000000803F020000000400001000140000000040000000000000803F03000000040000100014000000803F000000000000803F040000000400000500000000000000
GO
/****** Object:  Statistic [_WA_Sys_0000000E_182C9B23]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_0000000E_182C9B23] ON [dbo].[Empleados]([Cod_Turno]) WITH STATS_STREAM = 0x01000000010000000000000000000000F4B998C200000000CB010000000000008B0100000000000038030A6E3800000004000A0000000000000000000000000007000000C7C5EB004FB0000005000000000000000500000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000A04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000A040000000000000803F010000000400000500000000000000
GO
/****** Object:  Statistic [_WA_Sys_0000000F_182C9B23]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_0000000F_182C9B23] ON [dbo].[Empleados]([Estado]) WITH STATS_STREAM = 0x010000000100000000000000000000003697393100000000C801000000000000880100000000000068030A6E6800000001000100000000000000000000000000070000008871FA0052B0000005000000000000000500000000000000000000000000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000100000001000000110000000000803F0000A040000000000000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001C0000000000000024000000000000000800000000000000100011000000A040000000000000803F010400000500000000000000
GO
/****** Object:  Statistic [PK__Empleado__18E3932909D5BB90]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Empleados]([PK__Empleado__18E3932909D5BB90]) WITH STATS_STREAM = 0x010000000100000000000000000000005A49BBA3000000000902000000000000C901000000000000380300003800000004000A0000000000000000000000000007000000BAC5EB004FB00000050000000000000005000000000000000000803FCDCC4C3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000014000000000080400000A04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000005D00000000000000650000000000000018000000000000002F000000000000004600000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F0000803F0000803F050000000400000500000000000000, ROWCOUNT = 5, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_1A14E395]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_1A14E395] ON [dbo].[Estado_Civil]([Estado_Civil]) WITH STATS_STREAM = 0x010000000100000000000000000000008204D415000000004D030000000000000D03000000000000A7030000A70000004B0000000000000028D00000000000000700000080286A0151B000000600000000000000060000000000000000000000ABAA2A3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000006000000060000000100000010000000000038410000C0400000000000003841000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000013000000000000000000000000000000FF000000000000009901000000000000A10100000000000030000000000000004D000000000000006F000000000000009000000000000000C500000000000000E300000000000000300010000000803F000000000000803F04000001001D0043617361646F300010000000803F000000000000803F04000001002200436F6E637562696E61746F300010000000803F000000000000803F040000010021004469766F72636961646F300010000000803F000000000000803F0400000100350053657061726163696F6E20656E2070726F6365736F206A7564696369616C300010000000803F000000000000803F04000001001E00536F6C7465726F300010000000803F000000000000803F04000001001C00566975646FFF01000000000000000600000006000000280000002800000000000000000000004300000043617361646F6F6E637562696E61746F4469766F72636961646F53657061726163696F6E20656E2070726F6365736F206A7564696369616C6F6C7465726F566975646F090000004000000000C0010000008105010000010A060000810A100000C0011A0000811D1B0000010638000001053E0000000600000000000000
GO
/****** Object:  Statistic [PK__Estado_C__1183700EE9022CAE]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Estado_Civil]([PK__Estado_C__1183700EE9022CAE]) WITH STATS_STREAM = 0x010000000100000000000000000000005F5DB9D1000000002802000000000000E80100000000000038031A6E3800000004000A0000000000000000000000000007000000B1C5EB004FB00000060000000000000006000000000000000000803FABAA2A3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004000000040000000100000014000000000080400000C04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000007C000000000000008400000000000000200000000000000037000000000000004E000000000000006500000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F0000803F0000803F05000000040000100014000000803F000000000000803F060000000400000600000000000000, ROWCOUNT = 6, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_1BFD2C07]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_1BFD2C07] ON [dbo].[Generos]([Genero]) WITH STATS_STREAM = 0x010000000100000000000000000000001A2B831C000000004D020000000000000D02000000000000A7031A6EA70000004B0000000000000028D00000000000000700000075286A0151B0000002000000000000000200000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000010000000000008410000004000000000000008410000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000130000000000000000000000000000004F000000000000009900000000000000A10000000000000010000000000000002F00000000000000300010000000803F000000000000803F04000001001F0046656D656E696E6F300010000000803F000000000000803F040000010020004D617363756C696E6FFF01000000000000000200000002000000280000002800000000000000000000001100000046656D656E696E6F4D617363756C696E6F03000000400000000081080000000109080000000200000000000000
GO
/****** Object:  Statistic [PK__Generos__B2FF3FDB3AFCB4DC]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Generos]([PK__Generos__B2FF3FDB3AFCB4DC]) WITH STATS_STREAM = 0x01000000010000000000000000000000337F784500000000EA01000000000000AA0100000000000038031A6E3800000004000A0000000000000000000000000007000000B3C5EB004FB0000002000000000000000200000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F000000000000803F020000000400000200000000000000, ROWCOUNT = 2, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_1DE57479]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_1DE57479] ON [dbo].[Municipio]([MUNICIPIO]) WITH STATS_STREAM = 0x01000000010000000000000000000000190946CF000000004F020000000000000F02000000000000A7031A6EA70000004B0000000000000028D000000000000007000000E7B9FA0052B0000002000000000000000200000000000000000000000000003F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000020000000200000001000000100000000000104100000040000000000000104100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001300000000000000000000000000000050000000000000009B00000000000000A30000000000000010000000000000002E00000000000000300010000000803F000000000000803F04000001001E004E6163616F6D65300010000000803F000000000000803F0400000100220053616E204C6F72656E7A6FFF0100000000000000020000000200000028000000280000000000000000000000120000004E6163616F6D6553616E204C6F72656E7A6F0300000040000000008107000000010B070000000200000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000003_1DE57479]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000003_1DE57479] ON [dbo].[Municipio]([IDDEPARTAMENTO]) WITH STATS_STREAM = 0x010000000100000000000000000000000A97EEB100000000CB010000000000008B01000000000000380300003800000004000A0000000000000000007F00000007000000D5C5EB004FB0000002000000000000000200000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F00000000000000270000000000000008000000000000001000140000000040000000000000803F120000000400000200000000000000
GO
/****** Object:  Statistic [PK__Municipi__FDA66C58882A2742]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Municipio]([PK__Municipi__FDA66C58882A2742]) WITH STATS_STREAM = 0x01000000010000000000000000000000D83115C700000000EA01000000000000AA01000000000000380300003800000004000A0000000000000000000000000007000000D3C5EB004FB0000002000000000000000200000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F000000000000803F020000000400000200000000000000, ROWCOUNT = 2, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_1FCDBCEB]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_1FCDBCEB] ON [dbo].[Nacionalidad]([Nacionalidad]) WITH STATS_STREAM = 0x01000000010000000000000000000000BA189765000000004D020000000000000D02000000000000A7030000A70000004B0000000000000028D00000020000000700000092286A0151B0000002000000000000000200000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000010000000000008410000004000000000000008410000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000130000000000000000000000000000004F000000000000009900000000000000A10000000000000010000000000000003000000000000000300010000000803F000000000000803F04000001002000486F6E64757265F161300010000000803F000000000000803F04000001001F004D65786963616E61FF010000000000000002000000020000002800000028000000000000000000000011000000486F6E64757265F1614D65786963616E6103000000400000000081090000000108090000000200000000000000
GO
/****** Object:  Statistic [PK__Nacional__AA8953E0EDD9DF73]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Nacionalidad]([PK__Nacional__AA8953E0EDD9DF73]) WITH STATS_STREAM = 0x01000000010000000000000000000000AAAEF26900000000EA01000000000000AA01000000000000380300003800000004000A0000000000000000000200000007000000B4C5EB004FB0000002000000000000000200000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F000000000000803F020000000400000200000000000000, ROWCOUNT = 2, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_21B6055D]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_21B6055D] ON [dbo].[Nivel_Acceso]([Nivel_Acceso]) WITH STATS_STREAM = 0x010000000100000000000000000000001492526C000000000403000000000000C402000000000000A7030000A70000004B0000000000000028D0000000000000070000004F32010152B00000060000000000000006000000000000000000803FABAA2A3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000005000000050000000100000010000000000028410000C0400000000000002841000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000013000000000000000000000000000000C4000000000000005001000000000000580100000000000028000000000000004C000000000000006A000000000000008300000000000000A500000000000000300010000000803F000000000000803F0400000100240041646D696E6973747261646F72300010000000803F000000000000803F04000001001E00476572656E7465300010000000803F000000000000803F040000010019004954300010000000803F000000000000803F0400000100220050726F6772616D61646F72300010000000803F0000803F0000803F04000001001F0056656E6465646F72FF01000000000000000600000006000000280000002800000000000000000000003F00000041646D696E6973747261646F72476572656E7465495450726F6772616D61646F7253757065727669736F72205265736964656E6369616C56656E6465646F72070000004000000000810D00000081070D00008102140000810B16000081162100000108370000000600000000000000
GO
/****** Object:  Statistic [PK__Nivel_Ac__4203CFEC5A661BFE]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Nivel_Acceso]([PK__Nivel_Ac__4203CFEC5A661BFE]) WITH STATS_STREAM = 0x010000000100000000000000000000000273BD69000000002802000000000000E801000000000000380300003800000004000A0000000000000000007F00000007000000E0C5EB004FB00000060000000000000006000000000000000000803FABAA2A3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004000000040000000100000014000000000080400000C04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000007C000000000000008400000000000000200000000000000037000000000000004E000000000000006500000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F0000803F0000803F05000000040000100014000000803F000000000000803F060000000400000600000000000000, ROWCOUNT = 6, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_239E4DCF]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_239E4DCF] ON [dbo].[Orden_Instalacion]([Cod_Cliente]) WITH STATS_STREAM = 0x0100000001000000000000000000000099C5FCC800000000EA01000000000000AA010000000000003803FFFF3800000004000A0000000000000000000000000007000000D6C5EB004FB0000002000000000000000200000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F000000000000803F020000000400000200000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000004_239E4DCF]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000004_239E4DCF] ON [dbo].[Orden_Instalacion]([Cod_Empleado]) WITH STATS_STREAM = 0x01000000010000000000000000000000F1FB9A6E00000000CB010000000000008B0100000000000038031A6E3800000004000A0000000000000000000000000007000000D8C5EB004FB0000002000000000000000200000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F00000000000000270000000000000008000000000000001000140000000040000000000000803F010000000400000200000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000007_239E4DCF]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000007_239E4DCF] ON [dbo].[Orden_Instalacion]([UsuarioCreacion]) WITH STATS_STREAM = 0x010000000100000000000000000000008D5278B2000000001902000000000000D901000000000000A7020000A7000000320000000000000028D00000000000000700000061F06D0151B0000002000000000000000200000000000000000000000000803F00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000001000000010000001000000000001041000000400000000000001041000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000013000000000000000000000000000000280000000000000065000000000000006D0000000000000008000000000000003000100000000040000000000000803F040000010020004C656F6E6172646F4DFF0100000000000000020000000100000028000000280000000000000000000000090000004C656F6E6172646F4D0200000040000000000209000000000200000000000000
GO
/****** Object:  Statistic [PK__Orden_In__92D55B54756C7747]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Orden_Instalacion]([PK__Orden_In__92D55B54756C7747]) WITH STATS_STREAM = 0x01000000010000000000000000000000E746B2F100000000EA01000000000000AA01000000000000380300003800000004000A00000000000000000000000000070000005FF36D0151B0000002000000000000000200000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F000000000000803F020000000400000200000000000000, ROWCOUNT = 2, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_25869641]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_25869641] ON [dbo].[Ordenes_Mantenimiento]([Cod_Cliente]) WITH STATS_STREAM = 0x01000000010000000000000000000000CFCCBDDC00000000CB010000000000008B01000000000000380300003800000004000A0000000000000000000000000007000000D9C5EB004FB0000001000000000000000100000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000803F00000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F010000000400000100000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000004_25869641]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000004_25869641] ON [dbo].[Ordenes_Mantenimiento]([Cod_Empleado]) WITH STATS_STREAM = 0x010000000100000000000000000000007B953E4100000000CB010000000000008B01000000000000380300003800000004000A0000000000000000000000000007000000DAC5EB004FB0000001000000000000000100000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000803F00000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F010000000400000100000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000007_25869641]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000007_25869641] ON [dbo].[Ordenes_Mantenimiento]([UsuarioCreacion]) WITH STATS_STREAM = 0x0100000001000000000000000000000093036764000000001902000000000000D901000000000000A7020000A7000000320000000000000028D000000000000007000000546B6F0151B0000001000000000000000100000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000010000000000010410000803F0000000000001041000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000013000000000000000000000000000000280000000000000065000000000000006D000000000000000800000000000000300010000000803F000000000000803F040000010020004C656F6E6172646F4DFF0100000000000000010000000100000028000000280000000000000000000000090000004C656F6E6172646F4D0200000040000000000109000000000100000000000000
GO
/****** Object:  Statistic [PK__Ordenes___881682F15687F0DE]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Ordenes_Mantenimiento]([PK__Ordenes___881682F15687F0DE]) WITH STATS_STREAM = 0x0100000001000000000000000000000067ABD68500000000CB010000000000008B01000000000000380300003800000004000A00000000000000000001000000070000002A8E6F0151B0000001000000000000000100000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000803F00000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F010000000400000100000000000000, ROWCOUNT = 1, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000003_276EDEB3]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000003_276EDEB3] ON [dbo].[Pais]([PAIS]) WITH STATS_STREAM = 0x01000000010000000000000000000000D2087FC000000000F420000000000000B420000000000000A7030000A70000004B0000000000000028D000000000000007000000323CFF0052B00000F000000000000000F0000000000000000000803F8988883B0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000BA000000BA0000000100000010000000CDCC1D410000704300000000CDCC1D41000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000013000000000000000000000000000000C01D000000000000401F000000000000481F000000000000D005000000000000F10500000000000010060000000000002E060000000000004D060000000000006D060000000000009506000000000000B306000000000000CF06000000000000F30600000000000013070000000000003407000000000000530700000000000071070000000000008E07000000000000AA07000000000000C907000000000000E60700000000000008080000000000002608000000000000510800000000000070080000000000008D08000000000000AC08000000000000CA08000000000000E70800000000000002090000000000001E090000000000003A0900000000000057090000000000008109000000000000A009000000000000BE09000000000000E209000000000000080A000000000000290A000000000000470A000000000000620A000000000000820A000000000000A10A000000000000BF0A000000000000DC0A000000000000FE0A0000000000002B0B000000000000490B0000000000006A0B0000000000008A0B000000000000A70B000000000000C50B000000000000E50B000000000000000C0000000000001D0C0000000000003B0C000000000000570C000000000000770C000000000000950C000000000000B20C000000000000D40C000000000000F40C0000000000000F0D0000000000002F0D000000000000560D000000000000730D000000000000970D000000000000B40D000000000000D00D000000000000EF0D0000000000000F0E0000000000002D0E000000000000490E000000000000690E000000000000840E0000000000009F0E000000000000BD0E000000000000DF0E000000000000050F000000000000280F000000000000470F0000000000006A0F0000000000008C0F000000000000AD0F000000000000CF0F0000000000000F1000000000000031100000000000005E100000000000008310000000000000B210000000000000D710000000000000FC1000000000000020110000000000004C110000000000008711000000000000B711000000000000F2110000000000000F120000000000002C120000000000004A1200000000000066120000000000008612000000000000A212000000000000C312000000000000E212000000000000FF120000000000001A130000000000003813000000000000551300000000000071130000000000009013000000000000AC13000000000000CA13000000000000E91300000000000005140000000000002514000000000000441400000000000065140000000000008314000000000000A014000000000000C114000000000000E014000000000000FD140000000000001C150000000000003D150000000000005E150000000000007C150000000000009A15000000000000B615000000000000D215000000000000F2150000000000000E160000000000002C16000000000000471600000000000065160000000000008B16000000000000AF16000000000000CA16000000000000ED160000000000000C170000000000002817000000000000481700000000000065170000000000008E17000000000000AD17000000000000C817000000000000F1170000000000000F180000000000002E1800000000000050180000000000006C180000000000008E18000000000000BD18000000000000E3180000000000001919000000000000441900000000000062190000000000007F190000000000009D19000000000000B919000000000000E119000000000000FD19000000000000231A0000000000004F1A000000000000701A0000000000009B1A000000000000CE1A000000000000F11A000000000000131B0000000000003F1B000000000000621B0000000000007E1B0000000000009E1B000000000000BE1B000000000000DB1B000000000000F91B000000000000191C000000000000381C0000000000005D1C0000000000007B1C000000000000A31C000000000000C61C000000000000E31C000000000000001D000000000000211D000000000000411D000000000000671D000000000000841D000000000000A11D000000000000300010000000803F000000000000803F04000001002100416667616E697374E16E300010000000803F0000803F0000803F04000001001F00416C656D616E6961300010000000803F000000000000803F04000001001E00416E646F727261300010000000803F0000803F0000803F04000001001F00416E6775696C6C61300010000000803F000000000000803F04000001002000416E74E17274696461300010000000803F000000000000803F04000001002800416E746967756120792042617262756461300010000000803F000080400000803F04000001001E0041726D656E6961300010000000803F000000000000803F04000001001C004172756261300010000000803F000000000000803F04000001002400415259204D616365646F6E6961300010000000803F000000000000803F040000010020004175737472616C6961300010000000803F0000803F0000803F04000001002100417A657262616979E16E300010000000803F000040400000803F04000001001F004261726261646F73300010000000803F000000000000803F04000001001E0042E96C67696361300010000000803F000000000000803F04000001001D0042656C696365300010000000803F000000000000803F04000001001C0042656E696E300010000000803F000000000000803F04000001001F004265726D75646173300010000000803F000000000000803F04000001001D0042687574E16E300010000000803F000000000000803F040000010022004269656C6F727275736961300010000000803F000000000000803F04000001001E00426F6C69766961300010000000803F000000000000803F04000001002B00426F736E69612079204865727A65676F76696E61300010000000803F000000000000803F04000001001F00426F747375616E61300010000000803F000000000000803F04000001001D0042726173696C300010000000803F0000803F0000803F04000001001F0042756C6761726961300010000000803F0000803F0000803F04000001001E00427572756E6469300010000000803F000040400000803F04000001001D0043616E6164E1300010000000803F000000000000803F04000001001B0043686164300010000000803F000000000000803F04000001001C004368696C65300010000000803F000000000000803F04000001001C004368696E61300010000000803F000000000000803F04000001001D00436869707265300010000000803F000000000000803F04000001002A004369756461642064656C205661746963616E6F300010000000803F000000000000803F04000001001F00436F6C6F6D626961300010000000803F000000000000803F04000001001E00436F6D6F726173300010000000803F000000400000803F04000001002400436F7265612064656C20537572300010000000803F000000000000803F04000001002600436F737461206465204D617266696C300010000000803F000000000000803F04000001002100436F7374612052696361300010000000803F000000000000803F04000001001E0043726F61636961300010000000803F000000000000803F04000001001B0043756261300010000000803F000000000000803F0400000100200044696E616D61726361300010000000803F000000000000803F04000001001F00446F6D696E696361300010000000803F000000000000803F04000001001E0045637561646F72300010000000803F000000000000803F04000001001D0045676970746F300010000000803F000000000000803F04000001002200456C2053616C7661646F72300010000000803F000000000000803F04000001002D00456D697261746F7320C1726162657320556E69646F73300010000000803F000000000000803F04000001001E0045726974726561300010000000803F000000000000803F0400000100210045736C6F766171756961300010000000803F000000000000803F0400000100200045736C6F76656E6961300010000000803F000000000000803F04000001001D0045737061F161300010000000803F0000803F0000803F04000001001E004573746F6E6961300010000000803F0000803F0000803F0400000100200046696C6970696E6173300010000000803F0000803F0000803F04000001001B0046697969300010000000803F000000400000803F04000001001D0047616D626961300010000000803F000000000000803F04000001001E0047656F72676961300010000000803F000000000000803F04000001001C004768616E61300010000000803F000000000000803F0400000100200047696272616C746172300010000000803F000000000000803F04000001001E004772616E616461300010000000803F000000000000803F04000001001D00477265636961300010000000803F000000000000803F0400000100220047726F656E6C616E646961300010000000803F000000000000803F0400000100200047756164616C757065300010000000803F000000000000803F04000001001B004775616D300010000000803F000000000000803F0400000100200047756174656D616C61300010000000803F000000000000803F0400000100270047756179616E61204672616E63657361300010000000803F000000000000803F04000001001D004775696E6561300010000000803F0000803F0000803F040000010024004775696E65612D426973736175300010000000803F000000000000803F04000001001D00477579616E61300010000000803F000000000000803F04000001001C0048616974ED300010000000803F000000000000803F04000001001F00486F6E6475726173300010000000803F000000000000803F04000001002000486F6E67204B6F6E67300010000000803F000000000000803F04000001001E0048756E6772ED61300010000000803F000000000000803F04000001001C00496E646961300010000000803F000000000000803F04000001002000496E646F6E65736961300010000000803F000000000000803F04000001001B004972E16E300010000000803F000000000000803F04000001001B0049726171300010000000803F000000000000803F04000001001E0049726C616E6461300010000000803F000000000000803F0400000100220049736C6120426F75766574300010000000803F000000000000803F0400000100260049736C61206465204E617669646164300010000000803F000000000000803F0400000100230049736C61204E6F72666F6C6B300010000000803F000000000000803F04000001001F0049736C616E646961300010000000803F000000000000803F0400000100230049736C6173204361696DE16E300010000000803F000000000000803F0400000100220049736C617320436F636F73300010000000803F000000000000803F0400000100210049736C617320436F6F6B300010000000803F000000000000803F0400000100220049736C6173204665726F65300010000000803F000000000000803F0400000100400049736C61732047656F72676961732064656C2053757220792053616E64776963682064656C20537572300010000000803F000000000000803F0400000100220049736C617320476C616E64300010000000803F000000000000803F04000001002D0049736C61732048656172642079204D63446F6E616C64300010000000803F000000000000803F0400000100250049736C6173204D616C76696E6173300010000000803F000000000000803F04000001002F0049736C6173204D617269616E61732064656C204E6F727465300010000000803F000000000000803F0400000100250049736C6173204D61727368616C6C300010000000803F000000000000803F0400000100250049736C617320506974636169726E300010000000803F000000000000803F0400000100240049736C61732053616C6F6DF36E300010000000803F000000000000803F04000001002C0049736C617320547572636173207920436169636F73300010000000803F000000000000803F04000001003B0049736C617320756C7472616D6172696E61732064652045737461646F7320556E69646F73300010000000803F000000000000803F0400000100300049736C61732056ED7267656E65732042726974E16E69636173300010000000803F000000000000803F04000001003B0049736C61732056ED7267656E6573206465206C6F732045737461646F7320556E69646F73300010000000803F000000000000803F04000001001D0049737261656C300010000000803F000000000000803F04000001001D004974616C6961300010000000803F000000000000803F04000001001E004A616D61696361300010000000803F000000000000803F04000001001C004A6170F36E300010000000803F0000803F0000803F040000010020004B617A616A7374E16E300010000000803F000000000000803F04000001001C004B656E6961300010000000803F000000000000803F040000010021004B69726775697374E16E300010000000803F000000000000803F04000001001F004B69726962617469300010000000803F000000000000803F04000001001D004B7577616974300010000000803F000000000000803F04000001001B004C616F73300010000000803F000000000000803F04000001001E004C65736F74686F300010000000803F0000803F0000803F04000001001D004CED62616E6F300010000000803F0000803F0000803F04000001001C004C69626961300010000000803F0000803F0000803F04000001001F004C697475616E6961300010000000803F0000803F0000803F04000001001C004D6163616F300010000000803F0000803F0000803F04000001001E004D616C61736961300010000000803F0000803F0000803F04000001001F004D616C6469766173300010000000803F0000803F0000803F04000001001C004D616C7461300010000000803F0000803F0000803F040000010020004D617274696E696361300010000000803F000000000000803F04000001001F004D6175726963696F300010000000803F000000000000803F040000010021004D6175726974616E6961300010000000803F000000000000803F04000001001E004D61796F747465300010000000803F000000000000803F04000001001D004DE97869636F300010000000803F000000000000803F040000010021004D6963726F6E65736961300010000000803F000000000000803F04000001001F004D6F6C6461766961300010000000803F000000000000803F04000001001D004DF36E61636F300010000000803F000000000000803F04000001001F004D6F6E676F6C6961300010000000803F000000000000803F040000010021004D6F6E74736572726174300010000000803F000000000000803F040000010021004D6F7A616D6269717565300010000000803F000000000000803F04000001001E004D79616E6D6172300010000000803F000000000000803F04000001001E004E616D69626961300010000000803F000000000000803F04000001001C004E61757275300010000000803F000000000000803F04000001001C004E6570616C300010000000803F000000000000803F040000010020004E6963617261677561300010000000803F000000000000803F04000001001C004EED676572300010000000803F000000000000803F04000001001E004E696765726961300010000000803F000000000000803F04000001001B004E697565300010000000803F000000000000803F04000001001E004E6F7275656761300010000000803F000000000000803F040000010026004E756576612043616C65646F6E6961300010000000803F000000000000803F040000010024004E75657661205A656C616E6461300010000000803F000000000000803F04000001001B004F6DE16E300010000000803F000000000000803F040000010023005061ED7365732042616A6F73300010000000803F000000000000803F04000001001F0050616B697374E16E300010000000803F000000000000803F04000001001C0050616C6175300010000000803F000000000000803F0400000100200050616C657374696E61300010000000803F000000000000803F04000001001D0050616E616DE1300010000000803F000000000000803F04000001002900506170FA61204E75657661204775696E6561300010000000803F000000000000803F04000001001F005061726167756179300010000000803F000000000000803F04000001001B00506572FA300010000000803F000000000000803F04000001002900506F6C696E65736961204672616E63657361300010000000803F000000000000803F04000001001E00506F6C6F6E6961300010000000803F000000000000803F04000001001F00506F72747567616C300010000000803F000000000000803F0400000100220050756572746F205269636F300010000000803F000000000000803F04000001001C005161746172300010000000803F000000000000803F040000010022005265696E6F20556E69646F300010000000803F000000000000803F04000001002F00526570FA626C6963612043656E74726F6166726963616E61300010000000803F000000000000803F04000001002600526570FA626C696361204368656361300010000000803F000000000000803F04000001003600526570FA626C6963612044656D6F6372E1746963612064656C20436F6E676F300010000000803F000000000000803F04000001002B00526570FA626C69636120446F6D696E6963616E61300010000000803F000000000000803F04000001001E005265756E69F36E300010000000803F000000000000803F04000001001D005275616E6461300010000000803F000000000000803F04000001001E0052756D616E6961300010000000803F000000000000803F04000001001C005275736961300010000000803F000000000000803F04000001002800536168617261204F63636964656E74616C300010000000803F000000000000803F04000001001C0053616D6F61300010000000803F000000000000803F0400000100260053616D6F6120416D65726963616E61300010000000803F000000000000803F04000001002C0053616E204372697374F362616C2079204E65766973300010000000803F000000000000803F0400000100210053616E204D6172696E6F300010000000803F000000000000803F04000001002B0053616E20506564726F2079204D697175656CF36E300010000000803F000000000000803F0400000100330053616E20566963656E74652079206C6173204772616E6164696E6173300010000000803F000000000000803F0400000100230053616E74612048656C656E61300010000000803F000000000000803F0400000100220053616E7461204C7563ED61300010000000803F000000000000803F04000001002C0053616E746F20546F6DE92079205072ED6E63697065300010000000803F000040400000803F04000001002300536965727261204C656F6E61300010000000803F0000803F0000803F04000001001C005369726961300010000000803F0000803F0000803F04000001002000537269204C616E6B61300010000000803F0000803F0000803F04000001002000537564E16672696361300010000000803F0000803F0000803F04000001001D00537565636961300010000000803F0000803F0000803F04000001001E00537572696E616D300010000000803F0000803F0000803F040000010020005461696C616E646961300010000000803F0000803F0000803F04000001001F0054616E7A616E6961300010000000803F000040400000803F0400000100250054696D6F72204F7269656E74616C300010000000803F0000803F0000803F04000001001E00546F6B656C6175300010000000803F0000803F0000803F040000010028005472696E69646164207920546F6261676F300010000000803F0000803F0000803F040000010023005475726B6D656E697374E16E300010000000803F0000803F0000803F04000001001D00547576616C75300010000000803F0000803F0000803F04000001001D005567616E6461300010000000803F0000803F0000803F04000001002100557A62656B697374E16E300010000000803F0000803F0000803F0400000100200056656E657A75656C61300010000000803F0000803F0000803F0400000100260057616C6C6973207920467574756E61300010000000803F0000803F0000803F04000001001D00596962757469300010000000803F000000000000803F04000001001D005A616D626961300010000000803F000000000000803F04000001001F005A696D6261627565FF0100000000000000160000001600000028000000280000000000000000000000CA000000416667616E697374E16E7267656E74696E6142E96C67696361756C67617269614369756461642064656C205661746963616E6F446F6D696E6963614574696F70ED61477265636961486F6E647572617349736C616E6469617320506974636169726E4A6F7264616E69614C696269614D6172727565636F736F7A616D62697175654E75657661205A656C616E6461506F6C6F6E696152756D616E696153616E746F20546F6DE92079205072ED6E636970657564E16E54696D6F72204F7269656E74616C557275677561791C0000004000000000C001000000810901000001080A0000C001120000810613000001071900008113200000810833000081073B000081064200008108480000C0045000008104540000010A580000810862000081056A0000C0016F000081087000000109780000810D81000081078E00008107950000C0019C000081149D00000104B10000810EB500000107C3000000F000000000000000
GO
/****** Object:  Statistic [PK__Pais__A38A9449C30F2BA6]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Pais]([PK__Pais__A38A9449C30F2BA6]) WITH STATS_STREAM = 0x01000000010000000000000000000000C1AD597E0000000053100000000000001310000000000000380370003800000004000A0000000000000000005300690007000000C1C5EB004FB00000F000000000000000F0000000000000000000803F8988883B00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000007900000079000000010000001400000000008040000070430000000000008040000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000011000000000000000000000000000000A70E000000000000AF0E000000000000C803000000000000DF03000000000000F6030000000000000D0400000000000024040000000000003B040000000000005204000000000000690400000000000080040000000000009704000000000000AE04000000000000C504000000000000DC04000000000000F3040000000000000A05000000000000210500000000000038050000000000004F0500000000000066050000000000007D050000000000009405000000000000AB05000000000000C205000000000000D905000000000000F00500000000000007060000000000001E0600000000000035060000000000004C0600000000000063060000000000007A060000000000009106000000000000A806000000000000BF06000000000000D606000000000000ED0600000000000004070000000000001B0700000000000032070000000000004907000000000000600700000000000077070000000000008E07000000000000A507000000000000BC07000000000000D307000000000000EA07000000000000010800000000000018080000000000002F0800000000000046080000000000005D0800000000000074080000000000008B08000000000000A208000000000000B908000000000000D008000000000000E708000000000000FE0800000000000015090000000000002C0900000000000043090000000000005A09000000000000710900000000000088090000000000009F09000000000000B609000000000000CD09000000000000E409000000000000FB09000000000000120A000000000000290A000000000000400A000000000000570A0000000000006E0A000000000000850A0000000000009C0A000000000000B30A000000000000CA0A000000000000E10A000000000000F80A0000000000000F0B000000000000260B0000000000003D0B000000000000540B0000000000006B0B000000000000820B000000000000990B000000000000B00B000000000000C70B000000000000DE0B000000000000F50B0000000000000C0C000000000000230C0000000000003A0C000000000000510C000000000000680C0000000000007F0C000000000000960C000000000000AD0C000000000000C40C000000000000DB0C000000000000F20C000000000000090D000000000000200D000000000000370D0000000000004E0D000000000000650D0000000000007C0D000000000000930D000000000000AA0D000000000000C10D000000000000D80D000000000000EF0D000000000000060E0000000000001D0E000000000000340E0000000000004B0E000000000000620E000000000000790E000000000000900E000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F000000000000803F04000000040000100014000000803F0000803F0000803F06000000040000100014000000803F0000803F0000803F08000000040000100014000000803F0000803F0000803F0A000000040000100014000000803F0000803F0000803F0C000000040000100014000000803F0000803F0000803F0E000000040000100014000000803F0000803F0000803F10000000040000100014000000803F0000803F0000803F12000000040000100014000000803F0000803F0000803F14000000040000100014000000803F0000803F0000803F16000000040000100014000000803F0000803F0000803F18000000040000100014000000803F0000803F0000803F1A000000040000100014000000803F0000803F0000803F1C000000040000100014000000803F0000803F0000803F1E000000040000100014000000803F0000803F0000803F20000000040000100014000000803F0000803F0000803F22000000040000100014000000803F0000803F0000803F24000000040000100014000000803F0000803F0000803F26000000040000100014000000803F0000803F0000803F28000000040000100014000000803F0000803F0000803F2A000000040000100014000000803F0000803F0000803F2C000000040000100014000000803F0000803F0000803F2E000000040000100014000000803F0000803F0000803F30000000040000100014000000803F0000803F0000803F32000000040000100014000000803F0000803F0000803F34000000040000100014000000803F0000803F0000803F36000000040000100014000000803F0000803F0000803F38000000040000100014000000803F0000803F0000803F3A000000040000100014000000803F0000803F0000803F3C000000040000100014000000803F0000803F0000803F3E000000040000100014000000803F0000803F0000803F40000000040000100014000000803F0000803F0000803F42000000040000100014000000803F0000803F0000803F44000000040000100014000000803F0000803F0000803F46000000040000100014000000803F0000803F0000803F48000000040000100014000000803F0000803F0000803F4A000000040000100014000000803F0000803F0000803F4C000000040000100014000000803F0000803F0000803F4E000000040000100014000000803F0000803F0000803F50000000040000100014000000803F0000803F0000803F52000000040000100014000000803F0000803F0000803F54000000040000100014000000803F0000803F0000803F56000000040000100014000000803F0000803F0000803F58000000040000100014000000803F0000803F0000803F5A000000040000100014000000803F0000803F0000803F5C000000040000100014000000803F0000803F0000803F5E000000040000100014000000803F0000803F0000803F60000000040000100014000000803F0000803F0000803F62000000040000100014000000803F0000803F0000803F64000000040000100014000000803F0000803F0000803F66000000040000100014000000803F0000803F0000803F68000000040000100014000000803F0000803F0000803F6A000000040000100014000000803F0000803F0000803F6C000000040000100014000000803F0000803F0000803F6E000000040000100014000000803F0000803F0000803F70000000040000100014000000803F0000803F0000803F72000000040000100014000000803F0000803F0000803F74000000040000100014000000803F0000803F0000803F76000000040000100014000000803F0000803F0000803F78000000040000100014000000803F0000803F0000803F7A000000040000100014000000803F0000803F0000803F7C000000040000100014000000803F0000803F0000803F7E000000040000100014000000803F0000803F0000803F80000000040000100014000000803F0000803F0000803F82000000040000100014000000803F0000803F0000803F84000000040000100014000000803F0000803F0000803F86000000040000100014000000803F0000803F0000803F88000000040000100014000000803F0000803F0000803F8A000000040000100014000000803F0000803F0000803F8C000000040000100014000000803F0000803F0000803F8E000000040000100014000000803F0000803F0000803F90000000040000100014000000803F0000803F0000803F92000000040000100014000000803F0000803F0000803F94000000040000100014000000803F0000803F0000803F96000000040000100014000000803F0000803F0000803F98000000040000100014000000803F0000803F0000803F9A000000040000100014000000803F0000803F0000803F9C000000040000100014000000803F0000803F0000803F9E000000040000100014000000803F0000803F0000803FA0000000040000100014000000803F0000803F0000803FA2000000040000100014000000803F0000803F0000803FA4000000040000100014000000803F0000803F0000803FA6000000040000100014000000803F0000803F0000803FA8000000040000100014000000803F0000803F0000803FAA000000040000100014000000803F0000803F0000803FAC000000040000100014000000803F0000803F0000803FAE000000040000100014000000803F0000803F0000803FB0000000040000100014000000803F0000803F0000803FB2000000040000100014000000803F0000803F0000803FB4000000040000100014000000803F0000803F0000803FB6000000040000100014000000803F0000803F0000803FB8000000040000100014000000803F0000803F0000803FBA000000040000100014000000803F0000803F0000803FBC000000040000100014000000803F0000803F0000803FBE000000040000100014000000803F0000803F0000803FC0000000040000100014000000803F0000803F0000803FC2000000040000100014000000803F0000803F0000803FC4000000040000100014000000803F0000803F0000803FC6000000040000100014000000803F0000803F0000803FC8000000040000100014000000803F0000803F0000803FCA000000040000100014000000803F0000803F0000803FCC000000040000100014000000803F0000803F0000803FCE000000040000100014000000803F0000803F0000803FD0000000040000100014000000803F0000803F0000803FD2000000040000100014000000803F0000803F0000803FD4000000040000100014000000803F0000803F0000803FD6000000040000100014000000803F0000803F0000803FD8000000040000100014000000803F0000803F0000803FDA000000040000100014000000803F0000803F0000803FDC000000040000100014000000803F0000803F0000803FDE000000040000100014000000803F0000803F0000803FE0000000040000100014000000803F0000803F0000803FE2000000040000100014000000803F0000803F0000803FE4000000040000100014000000803F0000803F0000803FE6000000040000100014000000803F0000803F0000803FE8000000040000100014000000803F0000803F0000803FEA000000040000100014000000803F0000803F0000803FEC000000040000100014000000803F0000803F0000803FEE000000040000100014000000803F0000803F0000803FF0000000040000F000000000000000, ROWCOUNT = 240, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_29572725]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_29572725] ON [dbo].[Paquetes]([Cod_TipoPaquete]) WITH STATS_STREAM = 0x01000000010000000000000000000000C17F2EB100000000EA01000000000000AA01000000000000380313003800000004000A0000000000000000000200000007000000DBC5EB004FB0000009000000000000000900000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000104100000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000A040000000000000803F010000000400001000140000008040000000000000803F020000000400000900000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000003_29572725]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000003_29572725] ON [dbo].[Paquetes]([Paquete]) WITH STATS_STREAM = 0x01000000010000000000000000000000B8CA8356000000002E04000000000000EE03000000000000A7030000A70000004B0000000000000028D0000000000000070000009C286A0151B000000900000000000000090000000000000000000000398EE33D000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000009000000090000000100000010000000721CB7410000104100000000721CB741000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000013000000000000000000000000000000E5010000000000007A02000000000000820200000000000048000000000000006B000000000000009800000000000000CB00000000000000F700000000000000290100000000000055010000000000008701000000000000B301000000000000300010000000803F000000000000803F040000010023003220504C4159203130204D42300010000000803F000000000000803F04000001002D003320504C4159204F545420434356454F203130304D42300010000000803F000000000000803F040000010033003320504C4159204F545420434356454F203130304D42204649425241300010000000803F000000000000803F04000001002C003320504C4159204F545420434356454F2033304D42300010000000803F000000000000803F040000010032003320504C4159204F545420434356454F2033304D42204649425241300010000000803F000000000000803F04000001002C003320504C4159204F545420434356454F2035304D42300010000000803F000000000000803F040000010032003320504C4159204F545420434356454F2035304D42204649425241300010000000803F000000000000803F04000001002C003320504C4159204F545420434356454F2037304D42300010000000803F000000000000803F040000010032003320504C4159204F545420434356454F2037304D42204649425241FF0100000000000000090000000900000028000000280000000000000000000000340000003220504C4159203130204D423320504C4159204F545420434356454F203130304D4220464942524133304D4235304D4237304D420B0000004000000000810C00000040110C0000C1051D00000106220000C1042800000106220000C1042C0000010622000041043000000106220000000900000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000005_29572725]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000005_29572725] ON [dbo].[Paquetes]([Estado]) WITH STATS_STREAM = 0x0100000001000000000000000000000056DA139B00000000C801000000000000880100000000000068032033680000000100010000000000000000003F000000070000008D6CFC0052B0000009000000000000000900000000000000000000000000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000100000001000000110000000000803F00001041000000000000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001C00000000000000240000000000000008000000000000001000110000001041000000000000803F010400000900000000000000
GO
/****** Object:  Statistic [PK__Paquetes__6B728F99554B167D]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Paquetes]([PK__Paquetes__6B728F99554B167D]) WITH STATS_STREAM = 0x01000000010000000000000000000000A115E6200000000047020000000000000702000000000000380300003800000004000A0000000000000000000000000007000000B6C5EB004FB00000090000000000000009000000000000000000803F398EE33D000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000005000000050000000100000014000000000080400000104100000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000009B00000000000000A30000000000000028000000000000003F0000000000000056000000000000006D000000000000008400000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F0000803F0000803F05000000040000100014000000803F0000803F0000803F07000000040000100014000000803F0000803F0000803F090000000400000900000000000000, ROWCOUNT = 9, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_2B3F6F97]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_2B3F6F97] ON [dbo].[Sector]([SECTOR]) WITH STATS_STREAM = 0x010000000100000000000000000000001FFF47DC0000000089020000000000004902000000000000A7031A6EA70000004B0000000000000028D0000000000000070000009A286A0151B000000300000000000000030000000000000000000000ABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000010000000ABAA1A410000404000000000ABAA1A410000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000130000000000000000000000000000007A00000000000000D500000000000000DD0000000000000018000000000000003A000000000000005800000000000000300010000000803F000000000000803F04000001002200456C20436F6D657263696F300010000000803F000000000000803F04000001001E004D6F72617A616E300010000000803F000000000000803F0400000100220053616E20416E746F6E696FFF01000000000000000300000003000000280000002800000000000000000000001D000000456C20436F6D657263696F4D6F72617A616E53616E20416E746F6E696F040000004000000000810B00000081070B0000010B120000000300000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000003_2B3F6F97]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000003_2B3F6F97] ON [dbo].[Sector]([IdTipoSector]) WITH STATS_STREAM = 0x01000000010000000000000000000000E313648E00000000EA01000000000000AA010000000000003803FFFF3800000004000A0000000000000000000000000007000000DEC5EB004FB00000030000000000000003000000000000000000803FABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000404000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F030000000400000300000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000004_2B3F6F97]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000004_2B3F6F97] ON [dbo].[Sector]([IDMUNICIPIO]) WITH STATS_STREAM = 0x0100000001000000000000000000000031D28D1D00000000CB010000000000008B0100000000000038031A6E3800000004000A0000000000000000000000000007000000DDC5EB004FB0000003000000000000000300000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000404000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F00000000000000270000000000000008000000000000001000140000004040000000000000803F010000000400000300000000000000
GO
/****** Object:  Statistic [PK__Sector__26BAA6440BA58AD3]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Sector]([PK__Sector__26BAA6440BA58AD3]) WITH STATS_STREAM = 0x01000000010000000000000000000000C4B2D01500000000EA01000000000000AA01000000000000380300003800000004000A0000000000000000000000000007000000B8C5EB004FB00000030000000000000003000000000000000000803FABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000404000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F030000000400000300000000000000, ROWCOUNT = 3, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_2D27B809]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_2D27B809] ON [dbo].[Tipo_Paquete]([Tipo_Paquete]) WITH STATS_STREAM = 0x010000000100000000000000000000004DB6CFA0000000003D02000000000000FD01000000000000A7030000A7000000320000000000000028D00000000000000700000005B1FC0052B0000002000000000000000200000000000000000000000000003F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000020000000200000001000000100000000000604000000040000000000000604000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001300000000000000000000000000000045000000000000008900000000000000910000000000000010000000000000002A00000000000000300010000000803F000000000000803F04000001001A00484643300010000000803F000000000000803F04000001001B0048545446FF010000000000000002000000020000002800000028000000000000000000000006000000484643545446040000004000000000400100000081020100000103030000000200000000000000
GO
/****** Object:  Statistic [PK__Tipo_Paq__C688D131CEABB399]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Tipo_Paquete]([PK__Tipo_Paq__C688D131CEABB399]) WITH STATS_STREAM = 0x010000000100000000000000000000001378E29E00000000EA01000000000000AA01000000000000380300003800000004000A0000000000000000000200000007000000DCC5EB004FB0000002000000000000000200000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000004000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F000000000000803F020000000400000200000000000000, ROWCOUNT = 2, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_2F10007B]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_2F10007B] ON [dbo].[TipoSector]([TipoSector]) WITH STATS_STREAM = 0x01000000010000000000000000000000CB58AB0300000000A9020000000000006902000000000000A7030000A70000004B0000000000000028D000000000000007000000A666000152B0000004000000000000000400000000000000000000000000803E0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000040000000400000001000000100000000000C84000008040000000000000C8400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000130000000000000000000000000000009500000000000000F500000000000000FD0000000000000020000000000000003C0000000000000059000000000000007700000000000000300010000000803F000000000000803F04000001001C00416C646561300010000000803F000000000000803F04000001001D0042617272696F300010000000803F000000000000803F04000001001E004361736572696F300010000000803F000000000000803F04000001001E00436F6C6F6E6961FF010000000000000004000000040000002800000028000000000000000000000018000000416C64656142617272696F4361736572696F6F6C6F6E69610600000040000000008105000000810605000040010B000081060C00000106120000000400000000000000
GO
/****** Object:  Statistic [PK__TipoSect__84B9D4B89871B5A6]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[TipoSector]([PK__TipoSect__84B9D4B89871B5A6]) WITH STATS_STREAM = 0x010000000100000000000000000000005C05DB87000000000902000000000000C90100000000000038030A023800000004000A0000000000000000000200000007000000DEC5EB004FB00000040000000000000004000000000000000000803F0000803E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000014000000000080400000804000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000005D00000000000000650000000000000018000000000000002F000000000000004600000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F000000000000803F040000000400000400000000000000, ROWCOUNT = 4, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_30F848ED]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_30F848ED] ON [dbo].[Turnos]([Turno]) WITH STATS_STREAM = 0x0100000001000000000000000000000049ED2107000000001502000000000000D501000000000000A7031A6EA70000004B0000000000000028D000000000000007000000EAB9FA0052B0000001000000000000000100000000000000000000000000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000100000001000000100000000000E0400000803F000000000000E0400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000130000000000000000000000000000002600000000000000610000000000000069000000000000000800000000000000300010000000803F000000000000803F04000001001E0053656D616E616CFF01000000000000000100000001000000280000002800000000000000000000000700000053656D616E616C0200000040000000000107000000000100000000000000
GO
/****** Object:  Statistic [PK__Turnos__44BEB8E22C6294A5]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Turnos]([PK__Turnos__44BEB8E22C6294A5]) WITH STATS_STREAM = 0x010000000100000000000000000000003D3BD5BE00000000CB010000000000008B01000000000000380300003800000004000A0000000000000000000100000007000000C8C5EB004FB0000001000000000000000100000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000803F00000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F010000000400000100000000000000, ROWCOUNT = 1, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_32E0915F]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000002_32E0915F] ON [dbo].[Usuarios]([Cod_Empleado]) WITH STATS_STREAM = 0x010000000100000000000000000000005664F81300000000EA01000000000000AA0100000000000038030A023800000004000A0000000000000000000200000007000000E1C5EB004FB00000040000000000000004000000000000000000803F0000803E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000804000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F000000400000803F050000000400000400000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000003_32E0915F]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000003_32E0915F] ON [dbo].[Usuarios]([Usuario]) WITH STATS_STREAM = 0x010000000100000000000000000000001637835500000000B9020000000000007902000000000000A7038040A70000004B0000000000000028D000000000000007000000EA12680151B0000004000000000000000400000000000000000000000000803E00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000400000004000000010000001000000000000C41000080400000000000000C410000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000130000000000000000000000000000009F0000000000000005010000000000000D010000000000002000000000000000440000000000000061000000000000008100000000000000300010000000803F000000000000803F0400000100240041646D696E6973747261646F72300010000000803F000000000000803F04000001001D00456C76696156300010000000803F000000000000803F040000010020004C656F6E6172646F4D300010000000803F000000000000803F04000001001E0057696C736F6E5AFF01000000000000000400000004000000280000002800000000000000000000002300000041646D696E6973747261646F72456C766961564C656F6E6172646F4D57696C736F6E5A050000004000000000810D00000081060D0000810913000001071C0000000400000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000005_32E0915F]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000005_32E0915F] ON [dbo].[Usuarios]([IdNivelUser]) WITH STATS_STREAM = 0x01000000010000000000000000000000A17CB85A000000000902000000000000C90100000000000038030C023800000004000A000000000000000000FFFFFFFF07000000E0C5EB004FB00000040000000000000004000000000000000000803F0000803E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000014000000000080400000804000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000005D00000000000000650000000000000018000000000000002F000000000000004600000000000000100014000000803F000000000000803F01000000040000100014000000803F000000000000803F02000000040000100014000000803F0000803F0000803F060000000400000400000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000006_32E0915F]    Script Date: 31/08/2023 8:27:45 ******/
CREATE STATISTICS [_WA_Sys_00000006_32E0915F] ON [dbo].[Usuarios]([Estado]) WITH STATS_STREAM = 0x01000000010000000000000000000000FCF5CF6C00000000C801000000000000880100000000000068030A02680000000100010000000000000000000200000007000000D522010152B0000004000000000000000400000000000000000000000000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000100000001000000110000000000803F00008040000000000000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001C00000000000000240000000000000008000000000000001000110000008040000000000000803F010400000400000000000000
GO
/****** Object:  Statistic [PK__Usuarios__D16E26A6FE357061]    Script Date: 31/08/2023 8:27:45 ******/
UPDATE STATISTICS [dbo].[Usuarios]([PK__Usuarios__D16E26A6FE357061]) WITH STATS_STREAM = 0x010000000100000000000000000000008C72E123000000000902000000000000C901000000000000380300003800000004000A0000000000000000000000000007000000A52B010152B00000040000000000000004000000000000000000803F0000803E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000014000000000080400000804000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000005D00000000000000650000000000000018000000000000002F000000000000004600000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F000000000000803F040000000400000400000000000000, ROWCOUNT = 4, PAGECOUNT = 1
GO
USE [master]
GO
ALTER DATABASE [Proyecto_CableColor] SET  READ_WRITE 
GO
