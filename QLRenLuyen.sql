USE [master]
GO
/****** Object:  Database [QuanLyRenLuyen]    Script Date: 28/12/2022 8:08:42 AM ******/
CREATE DATABASE [QuanLyRenLuyen]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyRenLuyen', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyRenLuyen.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyRenLuyen_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyRenLuyen_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyRenLuyen] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyRenLuyen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyRenLuyen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyRenLuyen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyRenLuyen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyRenLuyen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyRenLuyen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyRenLuyen] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyRenLuyen] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyRenLuyen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyRenLuyen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyRenLuyen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyRenLuyen] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyRenLuyen] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyRenLuyen] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyRenLuyen] SET QUERY_STORE = OFF
GO
USE [QuanLyRenLuyen]
GO
/****** Object:  UserDefinedFunction [dbo].[auto_MaDiemPLKL]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[auto_MaDiemPLKL](@maHV as varchar(20))
returns varchar(20)
AS
BEGIN                                 
	Declare @id char(20)
	set  @id = Concat( @maHV, N'DKL' , cast(REPLACE(STR(MONTH(GETDATE()),2),' ','0') as char(2))  ,right((YEAR(getDate()) ), 2)  ,  N'L')
	return @id 
END
GO
/****** Object:  UserDefinedFunction [dbo].[auto_maHV]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[auto_maHV]()
RETURNS CHAR(8)
AS
BEGIN
   	DECLARE @ID CHAR(8)
   	SELECT @ID = count(MaHocVien) from HOCVIEN
   	IF @ID = 0
          	SET @ID = '0'
   	ELSE
          	SELECT @ID = CASE
                  	WHEN @ID >= 0 and @ID < 9 THEN 'HV00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
                  	WHEN @ID >= 10 and @ID < 99 THEN 'HV0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
                  	WHEN @ID >= 100  THEN 'HV' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
          	END
   	RETURN @ID
END
GO
/****** Object:  UserDefinedFunction [dbo].[auto_MaHVPLRL]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[auto_MaHVPLRL](@maHV as varchar(20))
returns varchar(20)
AS
BEGIN
	Declare @id char(20)
	set  @id = Concat( @maHV , cast(REPLACE(STR(MONTH(GETDATE()),2),' ','0') as char(2))  , right((YEAR(getDate()) ), 2) ,  N'L')
	return @id 
	return @id 
END
GO
/****** Object:  UserDefinedFunction [dbo].[auto_maQC]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[auto_maQC]()
RETURNS CHAR(8)
AS
BEGIN
   	DECLARE @ID CHAR(8)
   	SELECT @ID = count(MaQLQC) from QUYCHUAN
   	IF @ID = 0
          	SET @ID = '0'
   	ELSE
          	SELECT @ID = CASE
                  	WHEN @ID >= 0 and @ID < 9 THEN 'QLQC00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
                  	WHEN @ID >= 10 and @ID < 99 THEN 'QLQC0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
                  	WHEN @ID >= 100  THEN 'QLQC' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
          	END
   	RETURN @ID
END
GO
/****** Object:  UserDefinedFunction [dbo].[auto_maQCKL]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[auto_maQCKL]()
RETURNS CHAR(8)
AS
BEGIN
   	DECLARE @ID CHAR(8)
   	SELECT DISTINCT @ID = count(DISTINCT MaQC) from QUYCHUANKYLUAT
   	IF @ID = 0
          	SET @ID = '0'
   	ELSE
          	SELECT @ID = CASE
                  	WHEN @ID >= 0 and @ID < 9 THEN 'QCKL00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
                  	WHEN @ID >= 10 and @ID < 99 THEN 'QCKL0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
                  	WHEN @ID >= 100  THEN 'QCKL' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
          	END
   	RETURN @ID
END
GO
/****** Object:  UserDefinedFunction [dbo].[auto_maQCTL]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[auto_maQCTL]()
RETURNS CHAR(8)
AS
BEGIN
   	DECLARE @ID CHAR(8)
   	SELECT DISTINCT @ID = count(DISTINCT MaQC) from QUYCHUANTHELUC
   	IF @ID = 0
          	SET @ID = '0'
   	ELSE
          	SELECT @ID = CASE
                  	WHEN @ID >= 0 and @ID < 9 THEN 'QCTL00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
                  	WHEN @ID >= 10 and @ID < 99 THEN 'QCTL0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
                  	WHEN @ID >= 100  THEN 'QCTL' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
          	END
   	RETURN @ID
END
GO
/****** Object:  Table [dbo].[DAIDOI]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DAIDOI](
	[MaDaiDoi] [char](20) NOT NULL,
	[TenDaiDoi] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDaiDoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DIEM_PLKL]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIEM_PLKL](
	[MaDiemPLKL] [char](20) NOT NULL,
	[DiemKL] [int] NULL,
	[DiemHT] [int] NULL,
	[DiemLS] [int] NULL,
	[NhanXet] [nvarchar](100) NULL,
	[NguoiDanhGia] [char](20) NULL,
	[CapDanhGia] [char](20) NULL,
	[MaPLKL] [char](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDiemPLKL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GIAMSAT]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIAMSAT](
	[MaGS] [char](20) NOT NULL,
	[TenNGS] [nvarchar](50) NULL,
	[ChucVu] [nvarchar](30) NULL,
	[CapBac] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOCVIEN]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOCVIEN](
	[MaHocVien] [char](20) NOT NULL,
	[TenHocVien] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](20) NULL,
	[CapBac] [nvarchar](30) NULL,
	[ChucVu] [nvarchar](30) NULL,
	[MaLop] [char](20) NULL,
	[MatKhau] [char](100) NULL,
	[HoatDong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHocVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOCVIEN_PLRL]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOCVIEN_PLRL](
	[MaHVPLRL] [char](20) NOT NULL,
	[ThoiGian] [date] NULL,
	[MaHocVien] [char](20) NULL,
	[MaDiemPLRL] [char](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHVPLRL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOCVIEN_PLTL]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOCVIEN_PLTL](
	[MaHVPLTL] [char](20) NOT NULL,
	[ThoiGian] [date] NULL,
	[MaHocVien] [char](20) NULL,
	[MaGS] [char](20) NULL,
	[MaKQTL] [char](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHVPLTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KETQUATHELUC]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KETQUATHELUC](
	[MaKQTL] [char](20) NOT NULL,
	[Boi] [int] NULL,
	[ChayDai] [time](7) NULL,
	[ChayNgan] [time](7) NULL,
	[NhayXa] [float] NULL,
	[Xa] [int] NULL,
	[ChongDay] [int] NULL,
	[MaPLTL] [char](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKQTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOP]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOP](
	[MaLop] [char](20) NOT NULL,
	[TenLop] [nvarchar](50) NULL,
	[MaDaiDoi] [char](20) NULL,
	[MatKhau] [char](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHANLOAIKYLUAT]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHANLOAIKYLUAT](
	[MaPLKL] [char](20) NOT NULL,
	[TenPhanLoai] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPLKL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHANLOAITHELUC]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHANLOAITHELUC](
	[MaPLTL] [char](20) NOT NULL,
	[TenPLTL] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPLTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUANLY]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUANLY](
	[MaQL] [char](20) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[CapBac] [nvarchar](30) NULL,
	[ChucVu] [nvarchar](30) NULL,
	[MaDaiDoi] [char](20) NULL,
	[MatKhau] [char](100) NULL,
	[HoatDong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUYCHUAN]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUYCHUAN](
	[MaQLQC] [char](20) NOT NULL,
	[ThoiGian] [date] NULL,
	[NguoiSuaDoi] [char](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQLQC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUYCHUANKYLUAT]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUYCHUANKYLUAT](
	[MaQC] [char](20) NOT NULL,
	[NoiDung] [nvarchar](50) NOT NULL,
	[Muc1] [int] NULL,
	[Muc2] [int] NULL,
	[Muc3] [int] NULL,
	[MaQLQC] [char](20) NULL,
 CONSTRAINT [quanlykyluat_pk] PRIMARY KEY CLUSTERED 
(
	[MaQC] ASC,
	[NoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUYCHUANTHELUC]    Script Date: 28/12/2022 8:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUYCHUANTHELUC](
	[MaQC] [char](20) NOT NULL,
	[NoiDung] [nvarchar](30) NOT NULL,
	[DonViTinh] [nvarchar](30) NULL,
	[Gioi] [nvarchar](30) NULL,
	[Kha] [nvarchar](30) NULL,
	[Dat] [nvarchar](30) NULL,
	[MaQLQC] [char](20) NULL,
 CONSTRAINT [quanlytheluc_pk] PRIMARY KEY CLUSTERED 
(
	[MaQC] ASC,
	[NoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DAIDOI] ([MaDaiDoi], [TenDaiDoi]) VALUES (N'c155                ', N'Đại đội 155')
GO
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL012022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL012022DD    ', 8, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL012022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL022022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL022022DD    ', 8, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL022022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL032022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL032022DD    ', 8, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL032022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL042022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL042022DD    ', 8, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL042022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL052022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL052022DD    ', 8, 9, 8, N'Nhất trí', N'QL15502             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL052022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL062022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL062022DD    ', 8, 9, 8, N'Nhất trí', N'QL15503             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL062022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL072022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL072022DD    ', 8, 9, 8, N'Nhất trí', N'QL15503             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL072022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL082022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL082022DD    ', 8, 9, 8, N'Nhất trí', N'QL15504             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL082022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL092022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL092022DD    ', 7, 7, 7, N'Nhất trí', N'QL15504             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV001DKL092022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL012022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL012022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL012022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV015               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL022022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL022022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL022022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV015               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL032022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL032022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL032022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV015               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL042022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL042022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL042022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV015               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL052022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL052022DD    ', 9, 9, 9, N'Nhất trí', N'QL15502             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL052022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV015               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL062022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL062022DD    ', 9, 9, 9, N'Nhất trí', N'QL15503             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL062022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV015               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL072022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL072022DD    ', 9, 9, 9, N'Nhất trí', N'QL15503             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL072022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV015               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL082022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL082022DD    ', 9, 9, 9, N'Nhất trí', N'QL15504             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL082022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV015               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL092022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL092022DD    ', 9, 9, 9, N'Nhất trí', N'QL15504             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV002DKL092022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV015               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL012022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL012022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL012022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL022022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL022022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL022022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL032022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL032022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL032022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL042022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL042022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL042022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL052022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL052022DD    ', 9, 9, 9, N'Nhất trí', N'QL15502             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL052022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL062022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL062022DD    ', 9, 9, 9, N'Nhất trí', N'QL15503             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL062022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL072022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL072022DD    ', 9, 9, 9, N'Nhất trí', N'QL15503             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL072022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL082022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL082022DD    ', 9, 9, 9, N'Nhất trí', N'QL15504             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL082022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL092022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL092022DD    ', 9, 9, 9, N'Nhất trí', N'QL15504             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV003DKL092022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL012022CN    ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL012022DD    ', 9, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL012022L     ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL022022CN    ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL022022DD    ', 9, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL022022L     ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL032022CN    ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL032022DD    ', 9, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL032022L     ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL042022CN    ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL042022DD    ', 9, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL042022L     ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL052022CN    ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL052022DD    ', 9, 9, 8, N'Nhất trí', N'QL15502             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL052022L     ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL062022CN    ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL062022DD    ', 9, 9, 8, N'Nhất trí', N'QL15503             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL062022L     ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL072022CN    ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
GO
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL072022DD    ', 9, 9, 8, N'Nhất trí', N'QL15503             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL072022L     ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL082022CN    ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL082022DD    ', 9, 9, 8, N'Nhất trí', N'QL15504             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL082022L     ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL092022CN    ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL092022DD    ', 9, 9, 8, N'Nhất trí', N'QL15504             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV004DKL092022L     ', 9, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL012022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL012022DD    ', 8, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL012022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL022022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL022022DD    ', 8, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL022022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL032022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL032022DD    ', 8, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL032022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL042022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL042022DD    ', 8, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL042022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL052022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL052022DD    ', 8, 9, 8, N'Nhất trí', N'QL15502             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL052022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL062022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL062022DD    ', 8, 9, 8, N'Nhất trí', N'QL15503             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL062022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL072022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL072022DD    ', 8, 9, 8, N'Nhất trí', N'QL15503             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL072022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL082022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL082022DD    ', 8, 9, 8, N'Nhất trí', N'QL15504             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL082022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL092022CN    ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL092022DD    ', 8, 9, 8, N'Nhất trí', N'QL15504             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV005DKL092022L     ', 8, 9, 8, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV020               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL012022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL012022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL012022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL022022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL022022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL022022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL032022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL032022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL032022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL042022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL042022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL042022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL052022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL052022DD    ', 9, 9, 9, N'Nhất trí', N'QL15502             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL052022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL062022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL062022DD    ', 9, 9, 9, N'Nhất trí', N'QL15503             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL062022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL072022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL072022DD    ', 9, 9, 9, N'Nhất trí', N'QL15503             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL072022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL082022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL082022DD    ', 9, 9, 9, N'Nhất trí', N'QL15504             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL082022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL092022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL092022DD    ', 9, 9, 9, N'Nhất trí', N'QL15504             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV006DKL092022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL012022CN    ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL012022DD    ', 9, 8, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL012022L     ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL022022CN    ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL022022DD    ', 9, 8, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL022022L     ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL032022CN    ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL032022DD    ', 9, 8, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL032022L     ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL042022CN    ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL042022DD    ', 9, 8, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL042022L     ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL052022CN    ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL052022DD    ', 9, 8, 9, N'Nhất trí', N'QL15502             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL052022L     ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL062022CN    ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL062022DD    ', 9, 8, 9, N'Nhất trí', N'QL15503             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL062022L     ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL072022CN    ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL072022DD    ', 9, 8, 9, N'Nhất trí', N'QL15503             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL072022L     ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL082022CN    ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL082022DD    ', 9, 8, 9, N'Nhất trí', N'QL15504             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL082022L     ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL092022CN    ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL092022DD    ', 9, 8, 9, N'Nhất trí', N'QL15504             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV007DKL092022L     ', 9, 8, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL012022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL012022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL012022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL022022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL022022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL022022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL032022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL032022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL032022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL042022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL042022DD    ', 9, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
GO
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL042022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL052022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL052022DD    ', 9, 9, 9, N'Nhất trí', N'QL15502             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL052022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL062022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL062022DD    ', 9, 9, 9, N'Nhất trí', N'QL15503             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL062022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL072022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL072022DD    ', 9, 9, 9, N'Nhất trí', N'QL15503             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL072022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL082022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL082022DD    ', 9, 9, 9, N'Nhất trí', N'QL15504             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL082022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL092022CN    ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL092022DD    ', 9, 9, 9, N'Nhất trí', N'QL15504             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV008DKL092022L     ', 9, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV020               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL012022CN    ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL012022DD    ', 7, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL012022L     ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL022022CN    ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL022022DD    ', 7, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL022022L     ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL032022CN    ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL032022DD    ', 7, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL032022L     ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL042022CN    ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL042022DD    ', 7, 9, 8, N'Nhất trí', N'QL15501             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL042022L     ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL052022CN    ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL052022DD    ', 7, 9, 8, N'Nhất trí', N'QL15502             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL052022L     ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL062022CN    ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL062022DD    ', 7, 9, 8, N'Nhất trí', N'QL15503             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL062022L     ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL072022CN    ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL072022DD    ', 7, 9, 8, N'Nhất trí', N'QL15503             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL072022L     ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL082022CN    ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL082022DD    ', 7, 9, 8, N'Nhất trí', N'QL15504             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL082022L     ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL092022CN    ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Bản lĩnh chính trị vững vàng. Tích cực học tập.', NULL, N'CN                  ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL092022DD    ', 7, 9, 8, N'Nhất trí', N'QL15504             ', N'D                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV009DKL092022L     ', 7, 9, 8, N'NVVS đôi lúc chưa gọn gàng. Có bản lĩnh chính trị vững vàng. Tích cực học tập.', N'HV015               ', N'L                   ', N'K                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL012022CN    ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL012022DD    ', 10, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL012022L     ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL022022CN    ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL022022DD    ', 10, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL022022L     ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL032022CN    ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL032022DD    ', 10, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL032022L     ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL042022CN    ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL042022DD    ', 10, 9, 9, N'Nhất trí', N'QL15501             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL042022L     ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL052022CN    ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL052022DD    ', 10, 9, 9, N'Nhất trí', N'QL15502             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL052022L     ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL062022CN    ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL062022DD    ', 10, 9, 9, N'Nhất trí', N'QL15503             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL062022L     ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL072022CN    ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL072022DD    ', 10, 9, 9, N'Nhất trí', N'QL15503             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL072022L     ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL082022CN    ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL082022DD    ', 10, 9, 9, N'Nhất trí', N'QL15504             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL082022L     ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL092022CN    ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', NULL, N'CN                  ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL092022DD    ', 10, 9, 9, N'Nhất trí', N'QL15504             ', N'D                   ', N'T                   ')
INSERT [dbo].[DIEM_PLKL] ([MaDiemPLKL], [DiemKL], [DiemHT], [DiemLS], [NhanXet], [NguoiDanhGia], [CapDanhGia], [MaPLKL]) VALUES (N'HV010DKL092022L     ', 10, 9, 9, N'Chấp hành nghiêm quy định đơn vị. Có bản lĩnh chính trị, tư tưởng vững vàng. Tích cực học tập tốt.', N'HV024               ', N'L                   ', N'T                   ')
GO
INSERT [dbo].[GIAMSAT] ([MaGS], [TenNGS], [ChucVu], [CapBac]) VALUES (N'GS001               ', N'Lê Bá Khải', N'Tiểu đoàn trưởng', N'Đại tá')
INSERT [dbo].[GIAMSAT] ([MaGS], [TenNGS], [ChucVu], [CapBac]) VALUES (N'GS002               ', N'Lưu Văn Thêm', N'Chính trị viên', N'Đại tá')
INSERT [dbo].[GIAMSAT] ([MaGS], [TenNGS], [ChucVu], [CapBac]) VALUES (N'GS003               ', N'Nguyễn Đức Tâm', N'Trợ lý tiểu đoàn', N'Đại úy')
INSERT [dbo].[GIAMSAT] ([MaGS], [TenNGS], [ChucVu], [CapBac]) VALUES (N'GS004               ', N'Chu Văn Thụ', N'Trợ lý tiểu đoàn', N'Trung úy')
GO
INSERT [dbo].[HOCVIEN] ([MaHocVien], [TenHocVien], [GioiTinh], [CapBac], [ChucVu], [MaLop], [MatKhau], [HoatDong]) VALUES (N'HV001               ', N'Nguyễn Văn Công', N'Nam', N'Trung sỹ', N'Học viên', N'ANHTTT55            ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
INSERT [dbo].[HOCVIEN] ([MaHocVien], [TenHocVien], [GioiTinh], [CapBac], [ChucVu], [MaLop], [MatKhau], [HoatDong]) VALUES (N'HV002               ', N'Nguyễn Duy Trinh', N'Nam', N'Trung sỹ', N'Lớp trưởng', N'ANHTTT55            ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
INSERT [dbo].[HOCVIEN] ([MaHocVien], [TenHocVien], [GioiTinh], [CapBac], [ChucVu], [MaLop], [MatKhau], [HoatDong]) VALUES (N'HV003               ', N'Trần Hiếu Tài', N'Nam', N'Thượng sỹ', N'Học viên', N'BDATTT55            ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
INSERT [dbo].[HOCVIEN] ([MaHocVien], [TenHocVien], [GioiTinh], [CapBac], [ChucVu], [MaLop], [MatKhau], [HoatDong]) VALUES (N'HV004               ', N'Khổng Phương Thảo', N'Nữ', N'Thưỡng sỹ', N'Học viên', N'BDATTT55            ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
INSERT [dbo].[HOCVIEN] ([MaHocVien], [TenHocVien], [GioiTinh], [CapBac], [ChucVu], [MaLop], [MatKhau], [HoatDong]) VALUES (N'HV005               ', N'Đỗ Ngọc Long', N'Nam', N'Trung sỹ', N'Lớp trưởng', N'BDATTT55            ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
INSERT [dbo].[HOCVIEN] ([MaHocVien], [TenHocVien], [GioiTinh], [CapBac], [ChucVu], [MaLop], [MatKhau], [HoatDong]) VALUES (N'HV006               ', N'Trịnh Thị Thanh', N'Nữ', N'Trung sỹ', N'Học viên', N'CNTT155             ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
INSERT [dbo].[HOCVIEN] ([MaHocVien], [TenHocVien], [GioiTinh], [CapBac], [ChucVu], [MaLop], [MatKhau], [HoatDong]) VALUES (N'HV007               ', N'Hoàng Thị Xuân Quỳnh', N'Nữ', N'Thượng sỹ', N'Học viên', N'CNTT155             ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
INSERT [dbo].[HOCVIEN] ([MaHocVien], [TenHocVien], [GioiTinh], [CapBac], [ChucVu], [MaLop], [MatKhau], [HoatDong]) VALUES (N'HV008               ', N'Vũ Anh Đức', N'Nam', N'Thượng sỹ', N'Học viên', N'BDATTT55            ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
INSERT [dbo].[HOCVIEN] ([MaHocVien], [TenHocVien], [GioiTinh], [CapBac], [ChucVu], [MaLop], [MatKhau], [HoatDong]) VALUES (N'HV009               ', N'Nguyễn Hoàng Anh', N'Nam', N'Trung sỹ', N'Học viên', N'ANHTTT55            ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
INSERT [dbo].[HOCVIEN] ([MaHocVien], [TenHocVien], [GioiTinh], [CapBac], [ChucVu], [MaLop], [MatKhau], [HoatDong]) VALUES (N'HV010               ', N'Trương Thị La', N'Nữ', N'Thượng sỹ', N'Học viên', N'CNTT155             ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
GO
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001012022CN       ', CAST(N'2022-01-27' AS Date), N'HV001               ', N'HV001DKL012022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001012022DD       ', CAST(N'2022-01-30' AS Date), N'HV001               ', N'HV001DKL012022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001012022L        ', CAST(N'2022-01-28' AS Date), N'HV001               ', N'HV001DKL012022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001022022CN       ', CAST(N'2022-02-26' AS Date), N'HV001               ', N'HV001DKL022022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001022022DD       ', CAST(N'2022-02-28' AS Date), N'HV001               ', N'HV001DKL022022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001022022L        ', CAST(N'2022-02-27' AS Date), N'HV001               ', N'HV001DKL022022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001032022CN       ', CAST(N'2022-03-27' AS Date), N'HV001               ', N'HV001DKL032022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001032022DD       ', CAST(N'2022-03-30' AS Date), N'HV001               ', N'HV001DKL032022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001032022L        ', CAST(N'2022-03-28' AS Date), N'HV001               ', N'HV001DKL032022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001042022CN       ', CAST(N'2022-04-27' AS Date), N'HV001               ', N'HV001DKL042022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001042022DD       ', CAST(N'2022-04-30' AS Date), N'HV001               ', N'HV001DKL042022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001042022L        ', CAST(N'2022-04-29' AS Date), N'HV001               ', N'HV001DKL042022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001052022CN       ', CAST(N'2022-05-27' AS Date), N'HV001               ', N'HV001DKL052022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001052022DD       ', CAST(N'2022-05-31' AS Date), N'HV001               ', N'HV001DKL052022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001052022L        ', CAST(N'2022-05-29' AS Date), N'HV001               ', N'HV001DKL052022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001062022CN       ', CAST(N'2022-06-27' AS Date), N'HV001               ', N'HV001DKL062022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001062022DD       ', CAST(N'2022-06-30' AS Date), N'HV001               ', N'HV001DKL062022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001062022L        ', CAST(N'2022-06-29' AS Date), N'HV001               ', N'HV001DKL062022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001072022CN       ', CAST(N'2022-07-27' AS Date), N'HV001               ', N'HV001DKL072022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001072022DD       ', CAST(N'2022-07-31' AS Date), N'HV001               ', N'HV001DKL072022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001072022L        ', CAST(N'2022-07-29' AS Date), N'HV001               ', N'HV001DKL072022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001082022CN       ', CAST(N'2022-08-27' AS Date), N'HV001               ', N'HV001DKL082022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001082022DD       ', CAST(N'2022-08-30' AS Date), N'HV001               ', N'HV001DKL082022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001082022L        ', CAST(N'2022-08-29' AS Date), N'HV001               ', N'HV001DKL082022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001092022CN       ', CAST(N'2022-09-27' AS Date), N'HV001               ', N'HV001DKL092022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001092022DD       ', CAST(N'2022-09-30' AS Date), N'HV001               ', N'HV001DKL092022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV001092022L        ', CAST(N'2022-09-29' AS Date), N'HV001               ', N'HV001DKL092022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002012022CN       ', CAST(N'2022-01-27' AS Date), N'HV002               ', N'HV002DKL012022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002012022DD       ', CAST(N'2022-01-30' AS Date), N'HV002               ', N'HV002DKL012022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002012022L        ', CAST(N'2022-01-28' AS Date), N'HV002               ', N'HV002DKL012022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002022022CN       ', CAST(N'2022-02-26' AS Date), N'HV002               ', N'HV002DKL022022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002022022DD       ', CAST(N'2022-02-28' AS Date), N'HV002               ', N'HV002DKL022022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002022022L        ', CAST(N'2022-02-27' AS Date), N'HV002               ', N'HV002DKL022022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002032022CN       ', CAST(N'2022-03-27' AS Date), N'HV002               ', N'HV002DKL032022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002032022DD       ', CAST(N'2022-03-30' AS Date), N'HV002               ', N'HV002DKL032022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002032022L        ', CAST(N'2022-03-28' AS Date), N'HV002               ', N'HV002DKL032022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002042022CN       ', CAST(N'2022-04-27' AS Date), N'HV002               ', N'HV002DKL042022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002042022DD       ', CAST(N'2022-04-30' AS Date), N'HV002               ', N'HV002DKL042022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002042022L        ', CAST(N'2022-04-29' AS Date), N'HV002               ', N'HV002DKL042022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002052022CN       ', CAST(N'2022-05-27' AS Date), N'HV002               ', N'HV002DKL052022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002052022DD       ', CAST(N'2022-05-31' AS Date), N'HV002               ', N'HV002DKL052022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002052022L        ', CAST(N'2022-05-29' AS Date), N'HV002               ', N'HV002DKL052022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002062022CN       ', CAST(N'2022-06-27' AS Date), N'HV002               ', N'HV002DKL062022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002062022DD       ', CAST(N'2022-06-30' AS Date), N'HV002               ', N'HV002DKL062022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002062022L        ', CAST(N'2022-06-29' AS Date), N'HV002               ', N'HV002DKL062022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002072022CN       ', CAST(N'2022-07-27' AS Date), N'HV002               ', N'HV002DKL072022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002072022DD       ', CAST(N'2022-07-31' AS Date), N'HV002               ', N'HV002DKL072022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002072022L        ', CAST(N'2022-07-29' AS Date), N'HV002               ', N'HV002DKL072022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002082022CN       ', CAST(N'2022-08-27' AS Date), N'HV002               ', N'HV002DKL082022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002082022DD       ', CAST(N'2022-08-30' AS Date), N'HV002               ', N'HV002DKL082022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002082022L        ', CAST(N'2022-08-29' AS Date), N'HV002               ', N'HV002DKL082022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002092022CN       ', CAST(N'2022-09-27' AS Date), N'HV002               ', N'HV002DKL092022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002092022DD       ', CAST(N'2022-09-30' AS Date), N'HV002               ', N'HV002DKL092022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV002092022L        ', CAST(N'2022-09-29' AS Date), N'HV002               ', N'HV002DKL092022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003012022CN       ', CAST(N'2022-01-27' AS Date), N'HV003               ', N'HV003DKL012022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003012022DD       ', CAST(N'2022-01-30' AS Date), N'HV003               ', N'HV003DKL012022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003012022L        ', CAST(N'2022-01-28' AS Date), N'HV003               ', N'HV003DKL012022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003022022CN       ', CAST(N'2022-02-26' AS Date), N'HV003               ', N'HV003DKL022022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003022022DD       ', CAST(N'2022-02-28' AS Date), N'HV003               ', N'HV003DKL022022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003022022L        ', CAST(N'2022-02-27' AS Date), N'HV003               ', N'HV003DKL022022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003032022CN       ', CAST(N'2022-03-27' AS Date), N'HV003               ', N'HV003DKL032022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003032022DD       ', CAST(N'2022-03-30' AS Date), N'HV003               ', N'HV003DKL032022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003032022L        ', CAST(N'2022-03-28' AS Date), N'HV003               ', N'HV003DKL032022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003042022CN       ', CAST(N'2022-04-27' AS Date), N'HV003               ', N'HV003DKL042022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003042022DD       ', CAST(N'2022-04-30' AS Date), N'HV003               ', N'HV003DKL042022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003042022L        ', CAST(N'2022-04-29' AS Date), N'HV003               ', N'HV003DKL042022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003052022CN       ', CAST(N'2022-05-27' AS Date), N'HV003               ', N'HV003DKL052022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003052022DD       ', CAST(N'2022-05-31' AS Date), N'HV003               ', N'HV003DKL052022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003052022L        ', CAST(N'2022-05-29' AS Date), N'HV003               ', N'HV003DKL052022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003062022CN       ', CAST(N'2022-06-27' AS Date), N'HV003               ', N'HV003DKL062022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003062022DD       ', CAST(N'2022-06-30' AS Date), N'HV003               ', N'HV003DKL062022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003062022L        ', CAST(N'2022-06-29' AS Date), N'HV003               ', N'HV003DKL062022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003072022CN       ', CAST(N'2022-07-27' AS Date), N'HV003               ', N'HV003DKL072022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003072022DD       ', CAST(N'2022-07-31' AS Date), N'HV003               ', N'HV003DKL072022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003072022L        ', CAST(N'2022-07-29' AS Date), N'HV003               ', N'HV003DKL072022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003082022CN       ', CAST(N'2022-08-27' AS Date), N'HV003               ', N'HV003DKL082022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003082022DD       ', CAST(N'2022-08-30' AS Date), N'HV003               ', N'HV003DKL082022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003082022L        ', CAST(N'2022-08-29' AS Date), N'HV003               ', N'HV003DKL082022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003092022CN       ', CAST(N'2022-09-27' AS Date), N'HV003               ', N'HV003DKL092022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003092022DD       ', CAST(N'2022-09-30' AS Date), N'HV003               ', N'HV003DKL092022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV003092022L        ', CAST(N'2022-09-29' AS Date), N'HV003               ', N'HV003DKL092022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004012022CN       ', CAST(N'2022-01-27' AS Date), N'HV004               ', N'HV004DKL012022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004012022DD       ', CAST(N'2022-01-30' AS Date), N'HV004               ', N'HV004DKL012022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004012022L        ', CAST(N'2022-01-28' AS Date), N'HV004               ', N'HV004DKL012022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004022022CN       ', CAST(N'2022-02-26' AS Date), N'HV004               ', N'HV004DKL022022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004022022DD       ', CAST(N'2022-02-28' AS Date), N'HV004               ', N'HV004DKL022022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004022022L        ', CAST(N'2022-02-27' AS Date), N'HV004               ', N'HV004DKL022022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004032022CN       ', CAST(N'2022-03-27' AS Date), N'HV004               ', N'HV004DKL032022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004032022DD       ', CAST(N'2022-03-30' AS Date), N'HV004               ', N'HV004DKL032022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004032022L        ', CAST(N'2022-03-28' AS Date), N'HV004               ', N'HV004DKL032022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004042022CN       ', CAST(N'2022-04-27' AS Date), N'HV004               ', N'HV004DKL042022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004042022DD       ', CAST(N'2022-04-30' AS Date), N'HV004               ', N'HV004DKL042022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004042022L        ', CAST(N'2022-04-29' AS Date), N'HV004               ', N'HV004DKL042022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004052022CN       ', CAST(N'2022-05-27' AS Date), N'HV004               ', N'HV004DKL052022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004052022DD       ', CAST(N'2022-05-31' AS Date), N'HV004               ', N'HV004DKL052022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004052022L        ', CAST(N'2022-05-29' AS Date), N'HV004               ', N'HV004DKL052022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004062022CN       ', CAST(N'2022-06-27' AS Date), N'HV004               ', N'HV004DKL062022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004062022DD       ', CAST(N'2022-06-30' AS Date), N'HV004               ', N'HV004DKL062022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004062022L        ', CAST(N'2022-06-29' AS Date), N'HV004               ', N'HV004DKL062022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004072022CN       ', CAST(N'2022-07-27' AS Date), N'HV004               ', N'HV004DKL072022CN    ')
GO
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004072022DD       ', CAST(N'2022-07-31' AS Date), N'HV004               ', N'HV004DKL072022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004072022L        ', CAST(N'2022-07-29' AS Date), N'HV004               ', N'HV004DKL072022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004082022CN       ', CAST(N'2022-08-27' AS Date), N'HV004               ', N'HV004DKL082022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004082022DD       ', CAST(N'2022-08-30' AS Date), N'HV004               ', N'HV004DKL082022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004082022L        ', CAST(N'2022-08-29' AS Date), N'HV004               ', N'HV004DKL082022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004092022CN       ', CAST(N'2022-09-27' AS Date), N'HV004               ', N'HV004DKL092022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004092022DD       ', CAST(N'2022-09-30' AS Date), N'HV004               ', N'HV004DKL092022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV004092022L        ', CAST(N'2022-09-29' AS Date), N'HV004               ', N'HV004DKL092022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005012022CN       ', CAST(N'2022-01-27' AS Date), N'HV005               ', N'HV005DKL012022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005012022DD       ', CAST(N'2022-01-30' AS Date), N'HV005               ', N'HV005DKL012022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005012022L        ', CAST(N'2022-01-28' AS Date), N'HV005               ', N'HV005DKL012022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005022022CN       ', CAST(N'2022-02-26' AS Date), N'HV005               ', N'HV005DKL022022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005022022DD       ', CAST(N'2022-02-28' AS Date), N'HV005               ', N'HV005DKL022022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005022022L        ', CAST(N'2022-02-27' AS Date), N'HV005               ', N'HV005DKL022022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005032022CN       ', CAST(N'2022-03-27' AS Date), N'HV005               ', N'HV005DKL032022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005032022DD       ', CAST(N'2022-03-30' AS Date), N'HV005               ', N'HV005DKL032022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005032022L        ', CAST(N'2022-03-28' AS Date), N'HV005               ', N'HV005DKL032022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005042022CN       ', CAST(N'2022-04-27' AS Date), N'HV005               ', N'HV005DKL042022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005042022DD       ', CAST(N'2022-04-30' AS Date), N'HV005               ', N'HV005DKL042022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005042022L        ', CAST(N'2022-04-29' AS Date), N'HV005               ', N'HV005DKL042022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005052022CN       ', CAST(N'2022-05-27' AS Date), N'HV005               ', N'HV005DKL052022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005052022DD       ', CAST(N'2022-05-31' AS Date), N'HV005               ', N'HV005DKL052022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005052022L        ', CAST(N'2022-05-29' AS Date), N'HV005               ', N'HV005DKL052022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005062022CN       ', CAST(N'2022-06-27' AS Date), N'HV005               ', N'HV005DKL062022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005062022DD       ', CAST(N'2022-06-30' AS Date), N'HV005               ', N'HV005DKL062022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005062022L        ', CAST(N'2022-06-29' AS Date), N'HV005               ', N'HV005DKL062022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005072022CN       ', CAST(N'2022-07-27' AS Date), N'HV005               ', N'HV005DKL072022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005072022DD       ', CAST(N'2022-07-31' AS Date), N'HV005               ', N'HV005DKL072022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005072022L        ', CAST(N'2022-07-29' AS Date), N'HV005               ', N'HV005DKL072022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005082022CN       ', CAST(N'2022-08-27' AS Date), N'HV005               ', N'HV005DKL082022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005082022DD       ', CAST(N'2022-08-30' AS Date), N'HV005               ', N'HV005DKL082022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005082022L        ', CAST(N'2022-08-29' AS Date), N'HV005               ', N'HV005DKL082022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005092022CN       ', CAST(N'2022-09-27' AS Date), N'HV005               ', N'HV005DKL092022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005092022DD       ', CAST(N'2022-09-30' AS Date), N'HV005               ', N'HV005DKL092022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV005092022L        ', CAST(N'2022-09-29' AS Date), N'HV005               ', N'HV005DKL092022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006012022CN       ', CAST(N'2022-01-27' AS Date), N'HV006               ', N'HV006DKL012022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006012022DD       ', CAST(N'2022-01-30' AS Date), N'HV006               ', N'HV006DKL012022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006012022L        ', CAST(N'2022-01-28' AS Date), N'HV006               ', N'HV006DKL012022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006022022CN       ', CAST(N'2022-02-26' AS Date), N'HV006               ', N'HV006DKL022022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006022022DD       ', CAST(N'2022-02-28' AS Date), N'HV006               ', N'HV006DKL022022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006022022L        ', CAST(N'2022-02-27' AS Date), N'HV006               ', N'HV006DKL022022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006032022CN       ', CAST(N'2022-03-27' AS Date), N'HV006               ', N'HV006DKL032022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006032022DD       ', CAST(N'2022-03-30' AS Date), N'HV006               ', N'HV006DKL032022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006032022L        ', CAST(N'2022-03-28' AS Date), N'HV006               ', N'HV006DKL032022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006042022CN       ', CAST(N'2022-04-27' AS Date), N'HV006               ', N'HV006DKL042022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006042022DD       ', CAST(N'2022-04-30' AS Date), N'HV006               ', N'HV006DKL042022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006042022L        ', CAST(N'2022-04-29' AS Date), N'HV006               ', N'HV006DKL042022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006052022CN       ', CAST(N'2022-05-27' AS Date), N'HV006               ', N'HV006DKL052022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006052022DD       ', CAST(N'2022-05-31' AS Date), N'HV006               ', N'HV006DKL052022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006052022L        ', CAST(N'2022-05-29' AS Date), N'HV006               ', N'HV006DKL052022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006062022CN       ', CAST(N'2022-06-27' AS Date), N'HV006               ', N'HV006DKL062022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006062022DD       ', CAST(N'2022-06-30' AS Date), N'HV006               ', N'HV006DKL062022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006062022L        ', CAST(N'2022-06-29' AS Date), N'HV006               ', N'HV006DKL062022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006072022CN       ', CAST(N'2022-07-27' AS Date), N'HV006               ', N'HV006DKL072022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006072022DD       ', CAST(N'2022-07-31' AS Date), N'HV006               ', N'HV006DKL072022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006072022L        ', CAST(N'2022-07-29' AS Date), N'HV006               ', N'HV006DKL072022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006082022CN       ', CAST(N'2022-08-27' AS Date), N'HV006               ', N'HV006DKL082022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006082022DD       ', CAST(N'2022-08-30' AS Date), N'HV006               ', N'HV006DKL082022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006082022L        ', CAST(N'2022-08-29' AS Date), N'HV006               ', N'HV006DKL082022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006092022CN       ', CAST(N'2022-09-27' AS Date), N'HV006               ', N'HV006DKL092022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006092022DD       ', CAST(N'2022-09-30' AS Date), N'HV006               ', N'HV006DKL092022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV006092022L        ', CAST(N'2022-09-29' AS Date), N'HV006               ', N'HV006DKL092022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007012022CN       ', CAST(N'2022-01-27' AS Date), N'HV007               ', N'HV007DKL012022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007012022DD       ', CAST(N'2022-01-30' AS Date), N'HV007               ', N'HV007DKL012022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007012022L        ', CAST(N'2022-01-28' AS Date), N'HV007               ', N'HV007DKL012022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007022022CN       ', CAST(N'2022-02-26' AS Date), N'HV007               ', N'HV007DKL022022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007022022DD       ', CAST(N'2022-02-28' AS Date), N'HV007               ', N'HV007DKL022022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007022022L        ', CAST(N'2022-02-27' AS Date), N'HV007               ', N'HV007DKL022022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007032022CN       ', CAST(N'2022-03-27' AS Date), N'HV007               ', N'HV007DKL032022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007032022DD       ', CAST(N'2022-03-30' AS Date), N'HV007               ', N'HV007DKL032022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007032022L        ', CAST(N'2022-03-28' AS Date), N'HV007               ', N'HV007DKL032022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007042022CN       ', CAST(N'2022-04-27' AS Date), N'HV007               ', N'HV007DKL042022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007042022DD       ', CAST(N'2022-04-30' AS Date), N'HV007               ', N'HV007DKL042022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007042022L        ', CAST(N'2022-04-29' AS Date), N'HV007               ', N'HV007DKL042022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007052022CN       ', CAST(N'2022-05-27' AS Date), N'HV007               ', N'HV007DKL052022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007052022DD       ', CAST(N'2022-05-31' AS Date), N'HV007               ', N'HV007DKL052022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007052022L        ', CAST(N'2022-05-29' AS Date), N'HV007               ', N'HV007DKL052022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007062022CN       ', CAST(N'2022-06-27' AS Date), N'HV007               ', N'HV007DKL062022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007062022DD       ', CAST(N'2022-06-30' AS Date), N'HV007               ', N'HV007DKL062022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007062022L        ', CAST(N'2022-06-29' AS Date), N'HV007               ', N'HV007DKL062022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007072022CN       ', CAST(N'2022-07-27' AS Date), N'HV007               ', N'HV007DKL072022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007072022DD       ', CAST(N'2022-07-31' AS Date), N'HV007               ', N'HV007DKL072022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007072022L        ', CAST(N'2022-07-29' AS Date), N'HV007               ', N'HV007DKL072022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007082022CN       ', CAST(N'2022-08-27' AS Date), N'HV007               ', N'HV007DKL082022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007082022DD       ', CAST(N'2022-08-30' AS Date), N'HV007               ', N'HV007DKL082022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007082022L        ', CAST(N'2022-08-29' AS Date), N'HV007               ', N'HV007DKL082022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007092022CN       ', CAST(N'2022-09-27' AS Date), N'HV007               ', N'HV007DKL092022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007092022DD       ', CAST(N'2022-09-30' AS Date), N'HV007               ', N'HV007DKL092022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV007092022L        ', CAST(N'2022-09-29' AS Date), N'HV007               ', N'HV007DKL092022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008012022CN       ', CAST(N'2022-01-27' AS Date), N'HV008               ', N'HV008DKL012022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008012022DD       ', CAST(N'2022-01-30' AS Date), N'HV008               ', N'HV008DKL012022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008012022L        ', CAST(N'2022-01-28' AS Date), N'HV008               ', N'HV008DKL012022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008022022CN       ', CAST(N'2022-02-26' AS Date), N'HV008               ', N'HV008DKL022022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008022022DD       ', CAST(N'2022-02-28' AS Date), N'HV008               ', N'HV008DKL022022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008022022L        ', CAST(N'2022-02-27' AS Date), N'HV008               ', N'HV008DKL022022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008032022CN       ', CAST(N'2022-03-27' AS Date), N'HV008               ', N'HV008DKL032022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008032022DD       ', CAST(N'2022-03-30' AS Date), N'HV008               ', N'HV008DKL032022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008032022L        ', CAST(N'2022-03-28' AS Date), N'HV008               ', N'HV008DKL032022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008042022CN       ', CAST(N'2022-04-27' AS Date), N'HV008               ', N'HV008DKL042022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008042022DD       ', CAST(N'2022-04-30' AS Date), N'HV008               ', N'HV008DKL042022DD    ')
GO
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008042022L        ', CAST(N'2022-04-29' AS Date), N'HV008               ', N'HV008DKL042022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008052022CN       ', CAST(N'2022-05-27' AS Date), N'HV008               ', N'HV008DKL052022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008052022DD       ', CAST(N'2022-05-31' AS Date), N'HV008               ', N'HV008DKL052022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008052022L        ', CAST(N'2022-05-29' AS Date), N'HV008               ', N'HV008DKL052022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008062022CN       ', CAST(N'2022-06-27' AS Date), N'HV008               ', N'HV008DKL062022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008062022DD       ', CAST(N'2022-06-30' AS Date), N'HV008               ', N'HV008DKL062022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008062022L        ', CAST(N'2022-06-29' AS Date), N'HV008               ', N'HV008DKL062022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008072022CN       ', CAST(N'2022-07-27' AS Date), N'HV008               ', N'HV008DKL072022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008072022DD       ', CAST(N'2022-07-31' AS Date), N'HV008               ', N'HV008DKL072022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008072022L        ', CAST(N'2022-07-29' AS Date), N'HV008               ', N'HV008DKL072022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008082022CN       ', CAST(N'2022-08-27' AS Date), N'HV008               ', N'HV008DKL082022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008082022DD       ', CAST(N'2022-08-30' AS Date), N'HV008               ', N'HV008DKL082022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008082022L        ', CAST(N'2022-08-29' AS Date), N'HV008               ', N'HV008DKL082022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008092022CN       ', CAST(N'2022-09-27' AS Date), N'HV008               ', N'HV008DKL092022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008092022DD       ', CAST(N'2022-09-30' AS Date), N'HV008               ', N'HV008DKL092022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV008092022L        ', CAST(N'2022-09-29' AS Date), N'HV008               ', N'HV008DKL092022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009012022CN       ', CAST(N'2022-01-27' AS Date), N'HV009               ', N'HV009DKL012022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009012022DD       ', CAST(N'2022-01-30' AS Date), N'HV009               ', N'HV009DKL012022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009012022L        ', CAST(N'2022-01-28' AS Date), N'HV009               ', N'HV009DKL012022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009022022CN       ', CAST(N'2022-02-26' AS Date), N'HV009               ', N'HV009DKL022022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009022022DD       ', CAST(N'2022-02-28' AS Date), N'HV009               ', N'HV009DKL022022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009022022L        ', CAST(N'2022-02-27' AS Date), N'HV009               ', N'HV009DKL022022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009032022CN       ', CAST(N'2022-03-27' AS Date), N'HV009               ', N'HV009DKL032022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009032022DD       ', CAST(N'2022-03-30' AS Date), N'HV009               ', N'HV009DKL032022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009032022L        ', CAST(N'2022-03-28' AS Date), N'HV009               ', N'HV009DKL032022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009042022CN       ', CAST(N'2022-04-27' AS Date), N'HV009               ', N'HV009DKL042022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009042022DD       ', CAST(N'2022-04-30' AS Date), N'HV009               ', N'HV009DKL042022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009042022L        ', CAST(N'2022-04-29' AS Date), N'HV009               ', N'HV009DKL042022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009052022CN       ', CAST(N'2022-05-27' AS Date), N'HV009               ', N'HV009DKL052022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009052022DD       ', CAST(N'2022-05-31' AS Date), N'HV009               ', N'HV009DKL052022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009052022L        ', CAST(N'2022-05-29' AS Date), N'HV009               ', N'HV009DKL052022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009062022CN       ', CAST(N'2022-06-27' AS Date), N'HV009               ', N'HV009DKL062022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009062022DD       ', CAST(N'2022-06-30' AS Date), N'HV009               ', N'HV009DKL062022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009062022L        ', CAST(N'2022-06-29' AS Date), N'HV009               ', N'HV009DKL062022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009072022CN       ', CAST(N'2022-07-27' AS Date), N'HV009               ', N'HV009DKL072022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009072022DD       ', CAST(N'2022-07-31' AS Date), N'HV009               ', N'HV009DKL072022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009072022L        ', CAST(N'2022-07-29' AS Date), N'HV009               ', N'HV009DKL072022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009082022CN       ', CAST(N'2022-08-27' AS Date), N'HV009               ', N'HV009DKL082022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009082022DD       ', CAST(N'2022-08-30' AS Date), N'HV009               ', N'HV009DKL082022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009082022L        ', CAST(N'2022-08-29' AS Date), N'HV009               ', N'HV009DKL082022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009092022CN       ', CAST(N'2022-09-27' AS Date), N'HV009               ', N'HV009DKL092022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009092022DD       ', CAST(N'2022-09-30' AS Date), N'HV009               ', N'HV009DKL092022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV009092022L        ', CAST(N'2022-09-29' AS Date), N'HV009               ', N'HV009DKL092022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010012022CN       ', CAST(N'2022-01-27' AS Date), N'HV010               ', N'HV010DKL012022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010012022DD       ', CAST(N'2022-01-30' AS Date), N'HV010               ', N'HV010DKL012022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010012022L        ', CAST(N'2022-01-28' AS Date), N'HV010               ', N'HV010DKL012022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010022022CN       ', CAST(N'2022-02-26' AS Date), N'HV010               ', N'HV010DKL022022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010022022DD       ', CAST(N'2022-02-28' AS Date), N'HV010               ', N'HV010DKL022022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010022022L        ', CAST(N'2022-02-27' AS Date), N'HV010               ', N'HV010DKL022022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010032022CN       ', CAST(N'2022-03-27' AS Date), N'HV010               ', N'HV010DKL032022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010032022DD       ', CAST(N'2022-03-30' AS Date), N'HV010               ', N'HV010DKL032022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010032022L        ', CAST(N'2022-03-28' AS Date), N'HV010               ', N'HV010DKL032022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010042022CN       ', CAST(N'2022-04-27' AS Date), N'HV010               ', N'HV010DKL042022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010042022DD       ', CAST(N'2022-04-30' AS Date), N'HV010               ', N'HV010DKL042022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010042022L        ', CAST(N'2022-04-29' AS Date), N'HV010               ', N'HV010DKL042022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010052022CN       ', CAST(N'2022-05-27' AS Date), N'HV010               ', N'HV010DKL052022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010052022DD       ', CAST(N'2022-05-31' AS Date), N'HV010               ', N'HV010DKL052022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010052022L        ', CAST(N'2022-05-29' AS Date), N'HV010               ', N'HV010DKL052022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010062022CN       ', CAST(N'2022-06-27' AS Date), N'HV010               ', N'HV010DKL062022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010062022DD       ', CAST(N'2022-06-30' AS Date), N'HV010               ', N'HV010DKL062022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010062022L        ', CAST(N'2022-06-29' AS Date), N'HV010               ', N'HV010DKL062022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010072022CN       ', CAST(N'2022-07-27' AS Date), N'HV010               ', N'HV010DKL072022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010072022DD       ', CAST(N'2022-07-31' AS Date), N'HV010               ', N'HV010DKL072022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010072022L        ', CAST(N'2022-07-29' AS Date), N'HV010               ', N'HV010DKL072022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010082022CN       ', CAST(N'2022-08-27' AS Date), N'HV010               ', N'HV010DKL082022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010082022DD       ', CAST(N'2022-08-30' AS Date), N'HV010               ', N'HV010DKL082022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010082022L        ', CAST(N'2022-08-29' AS Date), N'HV010               ', N'HV010DKL082022L     ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010092022CN       ', CAST(N'2022-09-27' AS Date), N'HV010               ', N'HV010DKL092022CN    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010092022DD       ', CAST(N'2022-09-30' AS Date), N'HV010               ', N'HV010DKL092022DD    ')
INSERT [dbo].[HOCVIEN_PLRL] ([MaHVPLRL], [ThoiGian], [MaHocVien], [MaDiemPLRL]) VALUES (N'HV010092022L        ', CAST(N'2022-09-29' AS Date), N'HV010               ', N'HV010DKL092022L     ')
GO
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV001032022         ', CAST(N'2022-03-04' AS Date), N'HV001               ', N'GS001               ', N'HV001KQTL032022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV001062022         ', CAST(N'2022-06-09' AS Date), N'HV001               ', N'GS002               ', N'HV001KQTL062022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV001092022         ', CAST(N'2022-09-05' AS Date), N'HV001               ', N'GS001               ', N'HV001KQTL092022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV001122022         ', CAST(N'2022-12-07' AS Date), N'HV001               ', N'GS003               ', N'HV001KQTL122022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV002032022         ', CAST(N'2022-03-04' AS Date), N'HV002               ', N'GS001               ', N'HV002KQTL032022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV002062022         ', CAST(N'2022-06-09' AS Date), N'HV002               ', N'GS002               ', N'HV002KQTL062022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV002222022         ', CAST(N'2022-12-07' AS Date), N'HV002               ', N'GS003               ', N'HV002KQTL122022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV003032022         ', CAST(N'2022-03-04' AS Date), N'HV003               ', N'GS001               ', N'HV003KQTL032022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV003062022         ', CAST(N'2022-06-09' AS Date), N'HV003               ', N'GS002               ', N'HV003KQTL062022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV003092022         ', CAST(N'2022-09-05' AS Date), N'HV003               ', N'GS004               ', N'HV003KQTL092022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV003122022         ', CAST(N'2022-12-07' AS Date), N'HV003               ', N'GS003               ', N'HV003KQTL122022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV004062022         ', CAST(N'2022-06-09' AS Date), N'HV004               ', N'GS002               ', N'HV004KQTL062022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV004092022         ', CAST(N'2022-09-05' AS Date), N'HV004               ', N'GS001               ', N'HV004KQTL092022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV004122022         ', CAST(N'2022-12-07' AS Date), N'HV004               ', N'GS003               ', N'HV004KQTL122022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV005032022         ', CAST(N'2022-03-04' AS Date), N'HV005               ', N'GS001               ', N'HV005KQTL032022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV005062022         ', CAST(N'2022-06-09' AS Date), N'HV005               ', N'GS002               ', N'HV005KQTL062022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV005092022         ', CAST(N'2022-09-05' AS Date), N'HV005               ', N'GS001               ', N'HV005KQTL092022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV005122022         ', CAST(N'2022-12-07' AS Date), N'HV005               ', N'GS003               ', N'HV005KQTL122022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV006032022         ', CAST(N'2022-03-04' AS Date), N'HV006               ', N'GS001               ', N'HV006KQTL032022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV006062022         ', CAST(N'2022-06-09' AS Date), N'HV006               ', N'GS002               ', N'HV006KQTL062022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV006092022         ', CAST(N'2022-09-05' AS Date), N'HV006               ', N'GS001               ', N'HV006KQTL092022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV006122022         ', CAST(N'2022-12-07' AS Date), N'HV006               ', N'GS003               ', N'HV006KQTL122022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV007032022         ', CAST(N'2022-03-04' AS Date), N'HV007               ', N'GS001               ', N'HV007KQTL032022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV007062022         ', CAST(N'2022-06-09' AS Date), N'HV007               ', N'GS002               ', N'HV007KQTL062022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV007092022         ', CAST(N'2022-09-05' AS Date), N'HV007               ', N'GS001               ', N'HV007KQTL092022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV008032022         ', CAST(N'2022-03-04' AS Date), N'HV008               ', N'GS001               ', N'HV008KQTL032022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV008062022         ', CAST(N'2022-06-09' AS Date), N'HV008               ', N'GS002               ', N'HV008KQTL062022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV008092022         ', CAST(N'2022-09-05' AS Date), N'HV008               ', N'GS002               ', N'HV008KQTL092022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV008122022         ', CAST(N'2022-12-07' AS Date), N'HV008               ', N'GS003               ', N'HV009KQTL122022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV009032022         ', CAST(N'2022-03-04' AS Date), N'HV009               ', N'GS001               ', N'HV009KQTL032022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV009062022         ', CAST(N'2022-06-09' AS Date), N'HV009               ', N'GS002               ', N'HV009KQTL062022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV009092022         ', CAST(N'2022-09-05' AS Date), N'HV009               ', N'GS001               ', N'HV009KQTL092022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV009122022         ', CAST(N'2022-12-07' AS Date), N'HV009               ', N'GS003               ', N'HV009KQTL122022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV010032022         ', CAST(N'2022-03-04' AS Date), N'HV010               ', N'GS001               ', N'HV010KQTL032022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV010062022         ', CAST(N'2022-06-09' AS Date), N'HV010               ', N'GS002               ', N'HV010KQTL062022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV010092022         ', CAST(N'2022-09-05' AS Date), N'HV010               ', N'GS001               ', N'HV010KQTL092022     ')
INSERT [dbo].[HOCVIEN_PLTL] ([MaHVPLTL], [ThoiGian], [MaHocVien], [MaGS], [MaKQTL]) VALUES (N'HV010122022         ', CAST(N'2022-12-07' AS Date), N'HV010               ', N'GS003               ', N'HV010KQTL122022     ')
GO
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV001KQTL032022     ', 100, CAST(N'00:11:40' AS Time), CAST(N'00:00:13' AS Time), 6.9, 15, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV001KQTL062022     ', 100, CAST(N'00:12:40' AS Time), CAST(N'00:00:14' AS Time), 6.95, 15, NULL, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV001KQTL092022     ', 50, CAST(N'00:11:55' AS Time), CAST(N'00:00:14' AS Time), 6.9, 19, NULL, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV001KQTL122022     ', 100, CAST(N'00:11:35' AS Time), CAST(N'00:00:14' AS Time), 7.4, 15, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV002KQTL032022     ', 100, CAST(N'00:11:50' AS Time), CAST(N'00:00:14' AS Time), 7.5, 18, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV002KQTL062022     ', 50, CAST(N'00:12:00' AS Time), CAST(N'00:00:13' AS Time), 7.54, 17, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV002KQTL092022     ', 100, CAST(N'00:12:40' AS Time), CAST(N'00:00:14' AS Time), 7.3, 17, NULL, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV002KQTL122022     ', 80, CAST(N'00:12:25' AS Time), CAST(N'00:00:14' AS Time), 6.9, 16, NULL, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV003KQTL032022     ', 50, CAST(N'00:12:45' AS Time), CAST(N'00:00:13' AS Time), 7.3, 15, NULL, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV003KQTL062022     ', 80, CAST(N'00:12:15' AS Time), CAST(N'00:00:14' AS Time), 7.4, 19, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV003KQTL092022     ', 80, CAST(N'00:12:50' AS Time), CAST(N'00:00:13' AS Time), 7.3, 18, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV003KQTL122022     ', 50, CAST(N'00:12:30' AS Time), CAST(N'00:00:13' AS Time), 7.4, 15, NULL, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV004KQTL032022     ', 50, CAST(N'00:08:20' AS Time), CAST(N'00:00:18' AS Time), 1.7, NULL, 16, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV004KQTL062022     ', 100, CAST(N'00:08:20' AS Time), CAST(N'00:00:18' AS Time), 1.74, NULL, 18, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV004KQTL092022     ', 50, CAST(N'00:08:18' AS Time), CAST(N'00:00:17' AS Time), 1.72, NULL, 16, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV004KQTL122022     ', 50, CAST(N'00:08:27' AS Time), CAST(N'00:00:19' AS Time), 1.75, NULL, 16, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV005KQTL032022     ', 80, CAST(N'00:11:50' AS Time), CAST(N'00:00:13' AS Time), 6.9, 19, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV005KQTL062022     ', 100, CAST(N'00:11:55' AS Time), CAST(N'00:00:13' AS Time), 6.9, 18, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV005KQTL092022     ', 100, CAST(N'00:12:30' AS Time), CAST(N'00:00:13' AS Time), 7.2, 19, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV005KQTL122022     ', 80, CAST(N'00:12:50' AS Time), CAST(N'00:00:14' AS Time), 7.5, 20, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV006KQTL032022     ', 80, CAST(N'00:08:00' AS Time), CAST(N'00:00:15' AS Time), 1.9, NULL, 16, N'PLTL001             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV006KQTL062022     ', 100, CAST(N'00:08:15' AS Time), CAST(N'00:00:18' AS Time), 1.9, NULL, 18, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV006KQTL092022     ', 80, CAST(N'00:07:50' AS Time), CAST(N'00:00:18' AS Time), 1.85, NULL, 19, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV006KQTL122022     ', 80, CAST(N'00:08:10' AS Time), CAST(N'00:00:19' AS Time), 1.79, NULL, 18, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV007KQTL032022     ', 50, CAST(N'00:08:25' AS Time), CAST(N'00:00:19' AS Time), 1.8, NULL, 16, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV007KQTL062022     ', 50, CAST(N'00:08:15' AS Time), CAST(N'00:00:19' AS Time), 1.78, NULL, 16, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV007KQTL092022     ', 50, CAST(N'00:08:30' AS Time), CAST(N'00:00:17' AS Time), 1.75, NULL, 16, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV007KQTL122022     ', 50, CAST(N'00:08:20' AS Time), CAST(N'00:00:19' AS Time), 1.75, NULL, 16, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV008KQTL032022     ', 80, CAST(N'00:12:00' AS Time), CAST(N'00:00:13' AS Time), 7.5, 21, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV008KQTL062022     ', 100, CAST(N'00:12:50' AS Time), CAST(N'00:00:12' AS Time), 7.6, 23, NULL, N'PLTL001             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV008KQTL092022     ', 80, CAST(N'00:12:40' AS Time), CAST(N'00:00:13' AS Time), 7.9, 23, NULL, N'PLTL001             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV008KQTL122022     ', 80, CAST(N'00:11:50' AS Time), CAST(N'00:00:12' AS Time), 7.1, 20, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV009KQTL032022     ', 50, CAST(N'00:12:10' AS Time), CAST(N'00:00:14' AS Time), 7.5, 18, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV009KQTL062022     ', 50, CAST(N'00:12:45' AS Time), CAST(N'00:00:13' AS Time), 7.4, 19, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV009KQTL092022     ', 50, CAST(N'00:11:56' AS Time), CAST(N'00:00:13' AS Time), 7.2, 20, NULL, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV009KQTL122022     ', 50, CAST(N'00:12:30' AS Time), CAST(N'00:00:14' AS Time), 7.3, 19, NULL, N'PLTL003             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV010KQTL032022     ', 100, CAST(N'00:08:30' AS Time), CAST(N'00:00:18' AS Time), 1.8, NULL, 17, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV010KQTL062022     ', 80, CAST(N'00:08:30' AS Time), CAST(N'00:00:18' AS Time), 1.85, NULL, 20, N'PLTL002             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV010KQTL092022     ', 100, CAST(N'00:08:28' AS Time), CAST(N'00:00:18' AS Time), 1.9, NULL, 20, N'PLTL001             ')
INSERT [dbo].[KETQUATHELUC] ([MaKQTL], [Boi], [ChayDai], [ChayNgan], [NhayXa], [Xa], [ChongDay], [MaPLTL]) VALUES (N'HV010KQTL122022     ', 100, CAST(N'00:08:32' AS Time), CAST(N'00:00:19' AS Time), 1.8, NULL, 20, N'PLTL002             ')
GO
INSERT [dbo].[LOP] ([MaLop], [TenLop], [MaDaiDoi], [MatKhau]) VALUES (N'ANHTTT55            ', N'An ninh hệ thống thông tin', N'c155                ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ')
INSERT [dbo].[LOP] ([MaLop], [TenLop], [MaDaiDoi], [MatKhau]) VALUES (N'BDATTT55            ', N'Bảo đảm an toàn thông tin', N'c155                ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ')
INSERT [dbo].[LOP] ([MaLop], [TenLop], [MaDaiDoi], [MatKhau]) VALUES (N'CNTT155             ', N'Công nghệ thông tin 1', N'c155                ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ')
INSERT [dbo].[LOP] ([MaLop], [TenLop], [MaDaiDoi], [MatKhau]) VALUES (N'CNTT255             ', N'Công nghệ thông tin 2', N'c155                ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ')
INSERT [dbo].[LOP] ([MaLop], [TenLop], [MaDaiDoi], [MatKhau]) VALUES (N'PTDL55              ', N'Phân tích dữ liệu', N'c155                ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ')
GO
INSERT [dbo].[PHANLOAIKYLUAT] ([MaPLKL], [TenPhanLoai]) VALUES (N'K                   ', N'Khá')
INSERT [dbo].[PHANLOAIKYLUAT] ([MaPLKL], [TenPhanLoai]) VALUES (N'T                   ', N'Tốt')
INSERT [dbo].[PHANLOAIKYLUAT] ([MaPLKL], [TenPhanLoai]) VALUES (N'TB                  ', N'Trung bình')
INSERT [dbo].[PHANLOAIKYLUAT] ([MaPLKL], [TenPhanLoai]) VALUES (N'TBK                 ', N'Trung bình khá')
INSERT [dbo].[PHANLOAIKYLUAT] ([MaPLKL], [TenPhanLoai]) VALUES (N'Y                   ', N'Yếu')
GO
INSERT [dbo].[PHANLOAITHELUC] ([MaPLTL], [TenPLTL]) VALUES (N'PLTL001             ', N'GIỎI')
INSERT [dbo].[PHANLOAITHELUC] ([MaPLTL], [TenPLTL]) VALUES (N'PLTL002             ', N'KHÁ')
INSERT [dbo].[PHANLOAITHELUC] ([MaPLTL], [TenPLTL]) VALUES (N'PLTL003             ', N'ĐẠT')
GO
INSERT [dbo].[QUANLY] ([MaQL], [HoTen], [CapBac], [ChucVu], [MaDaiDoi], [MatKhau], [HoatDong]) VALUES (N'QL15501             ', N'Kiều Khắc Tráng', N'Đại úy', N'Đại đội trưởng', N'c155                ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
INSERT [dbo].[QUANLY] ([MaQL], [HoTen], [CapBac], [ChucVu], [MaDaiDoi], [MatKhau], [HoatDong]) VALUES (N'QL15502             ', N'Phùng Quan Toàn', N'Thiếu tá', N'Chính trị viên', N'c155                ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
INSERT [dbo].[QUANLY] ([MaQL], [HoTen], [CapBac], [ChucVu], [MaDaiDoi], [MatKhau], [HoatDong]) VALUES (N'QL15503             ', N'Vũ Khánh Toàn', N'Trung úy', N'Phó Đại đội trưởng ', N'c155                ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
INSERT [dbo].[QUANLY] ([MaQL], [HoTen], [CapBac], [ChucVu], [MaDaiDoi], [MatKhau], [HoatDong]) VALUES (N'QL15504             ', N'Lê Thế Tạ Tú', N'Trung úy', N'Phó Đại đội trưởng', N'c155                ', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb                                    ', 1)
GO
INSERT [dbo].[QUYCHUAN] ([MaQLQC], [ThoiGian], [NguoiSuaDoi]) VALUES (N'QLQC001             ', CAST(N'2022-01-01' AS Date), N'QL15501             ')
INSERT [dbo].[QUYCHUAN] ([MaQLQC], [ThoiGian], [NguoiSuaDoi]) VALUES (N'QLQC002             ', CAST(N'2022-02-02' AS Date), N'QL15501             ')
INSERT [dbo].[QUYCHUAN] ([MaQLQC], [ThoiGian], [NguoiSuaDoi]) VALUES (N'QLQC003             ', CAST(N'2022-03-03' AS Date), N'QL15501             ')
GO
INSERT [dbo].[QUYCHUANKYLUAT] ([MaQC], [NoiDung], [Muc1], [Muc2], [Muc3], [MaQLQC]) VALUES (N'QCKL001             ', N'Học tập', 10, 9, 8, N'QLQC001             ')
INSERT [dbo].[QUYCHUANKYLUAT] ([MaQC], [NoiDung], [Muc1], [Muc2], [Muc3], [MaQLQC]) VALUES (N'QCKL001             ', N'Kỷ luật', 10, 9, 8, N'QLQC001             ')
INSERT [dbo].[QUYCHUANKYLUAT] ([MaQC], [NoiDung], [Muc1], [Muc2], [Muc3], [MaQLQC]) VALUES (N'QCKL001             ', N'Lối sống', 10, 9, 8, N'QLQC001             ')
INSERT [dbo].[QUYCHUANKYLUAT] ([MaQC], [NoiDung], [Muc1], [Muc2], [Muc3], [MaQLQC]) VALUES (N'QCKL002             ', N'Học tập', 10, 8, 6, N'QLQC003             ')
INSERT [dbo].[QUYCHUANKYLUAT] ([MaQC], [NoiDung], [Muc1], [Muc2], [Muc3], [MaQLQC]) VALUES (N'QCKL002             ', N'Kỷ luật', 10, 8, 6, N'QLQC003             ')
INSERT [dbo].[QUYCHUANKYLUAT] ([MaQC], [NoiDung], [Muc1], [Muc2], [Muc3], [MaQLQC]) VALUES (N'QCKL002             ', N'Lối sống', 10, 8, 6, N'QLQC003             ')
GO
INSERT [dbo].[QUYCHUANTHELUC] ([MaQC], [NoiDung], [DonViTinh], [Gioi], [Kha], [Dat], [MaQLQC]) VALUES (N'QCTL001             ', N'Bơi', N'mét', N'100', N'80', N'80', N'QLQC002             ')
INSERT [dbo].[QUYCHUANTHELUC] ([MaQC], [NoiDung], [DonViTinh], [Gioi], [Kha], [Dat], [MaQLQC]) VALUES (N'QCTL001             ', N'Chạy dài nam', N'phút', N'00:12:30', N'00:12:40', N'00:12:50', N'QLQC002             ')
INSERT [dbo].[QUYCHUANTHELUC] ([MaQC], [NoiDung], [DonViTinh], [Gioi], [Kha], [Dat], [MaQLQC]) VALUES (N'QCTL001             ', N'Chạy dài nữ', N'phút', N'00:07:40', N'00:07:50', N'00:08:00', N'QLQC002             ')
INSERT [dbo].[QUYCHUANTHELUC] ([MaQC], [NoiDung], [DonViTinh], [Gioi], [Kha], [Dat], [MaQLQC]) VALUES (N'QCTL001             ', N'Chạy ngắn nam', N'giây', N'00:00:12.50', N'00:00:13.30', N'00:00:14.00', N'QLQC002             ')
INSERT [dbo].[QUYCHUANTHELUC] ([MaQC], [NoiDung], [DonViTinh], [Gioi], [Kha], [Dat], [MaQLQC]) VALUES (N'QCTL001             ', N'Chạy ngắn nữ', N'giây', N'00:00:16.00', N'00:00:16.30', N'00:00:16.90', N'QLQC002             ')
INSERT [dbo].[QUYCHUANTHELUC] ([MaQC], [NoiDung], [DonViTinh], [Gioi], [Kha], [Dat], [MaQLQC]) VALUES (N'QCTL001             ', N'Chống đẩy', N'cái', N'20', N'17', N'15', N'QLQC002             ')
INSERT [dbo].[QUYCHUANTHELUC] ([MaQC], [NoiDung], [DonViTinh], [Gioi], [Kha], [Dat], [MaQLQC]) VALUES (N'QCTL001             ', N'Nhảy xa nam', N'mét', N'7.5', N'7.2', N'6.9', N'QLQC002             ')
INSERT [dbo].[QUYCHUANTHELUC] ([MaQC], [NoiDung], [DonViTinh], [Gioi], [Kha], [Dat], [MaQLQC]) VALUES (N'QCTL001             ', N'Nhảy xa nữ', N'mét', N'1.7', N'1.65', N'1.6', N'QLQC002             ')
INSERT [dbo].[QUYCHUANTHELUC] ([MaQC], [NoiDung], [DonViTinh], [Gioi], [Kha], [Dat], [MaQLQC]) VALUES (N'QCTL001             ', N'Xà nam', N'cái', N'22', N'17', N'15', N'QLQC002             ')
INSERT [dbo].[QUYCHUANTHELUC] ([MaQC], [NoiDung], [DonViTinh], [Gioi], [Kha], [Dat], [MaQLQC]) VALUES (N'QCTL001             ', N'Xà nữ', N'cái', N'10', N'7', N'5', N'QLQC002             ')
GO
ALTER TABLE [dbo].[DIEM_PLKL]  WITH CHECK ADD  CONSTRAINT [FK_MaPLKL] FOREIGN KEY([MaPLKL])
REFERENCES [dbo].[PHANLOAIKYLUAT] ([MaPLKL])
GO
ALTER TABLE [dbo].[DIEM_PLKL] CHECK CONSTRAINT [FK_MaPLKL]
GO
ALTER TABLE [dbo].[HOCVIEN]  WITH CHECK ADD  CONSTRAINT [FK_MaLop] FOREIGN KEY([MaLop])
REFERENCES [dbo].[LOP] ([MaLop])
GO
ALTER TABLE [dbo].[HOCVIEN] CHECK CONSTRAINT [FK_MaLop]
GO
ALTER TABLE [dbo].[HOCVIEN_PLRL]  WITH CHECK ADD  CONSTRAINT [FK_MaDiemPLKL] FOREIGN KEY([MaDiemPLRL])
REFERENCES [dbo].[DIEM_PLKL] ([MaDiemPLKL])
GO
ALTER TABLE [dbo].[HOCVIEN_PLRL] CHECK CONSTRAINT [FK_MaDiemPLKL]
GO
ALTER TABLE [dbo].[HOCVIEN_PLRL]  WITH CHECK ADD  CONSTRAINT [FK_MaHocVien_PLRL] FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HOCVIEN] ([MaHocVien])
GO
ALTER TABLE [dbo].[HOCVIEN_PLRL] CHECK CONSTRAINT [FK_MaHocVien_PLRL]
GO
ALTER TABLE [dbo].[HOCVIEN_PLTL]  WITH CHECK ADD  CONSTRAINT [FK_MaGS] FOREIGN KEY([MaGS])
REFERENCES [dbo].[GIAMSAT] ([MaGS])
GO
ALTER TABLE [dbo].[HOCVIEN_PLTL] CHECK CONSTRAINT [FK_MaGS]
GO
ALTER TABLE [dbo].[HOCVIEN_PLTL]  WITH CHECK ADD  CONSTRAINT [FK_MaHocVien_PLTL] FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HOCVIEN] ([MaHocVien])
GO
ALTER TABLE [dbo].[HOCVIEN_PLTL] CHECK CONSTRAINT [FK_MaHocVien_PLTL]
GO
ALTER TABLE [dbo].[HOCVIEN_PLTL]  WITH CHECK ADD  CONSTRAINT [FK_MaKQTL] FOREIGN KEY([MaKQTL])
REFERENCES [dbo].[KETQUATHELUC] ([MaKQTL])
GO
ALTER TABLE [dbo].[HOCVIEN_PLTL] CHECK CONSTRAINT [FK_MaKQTL]
GO
ALTER TABLE [dbo].[KETQUATHELUC]  WITH CHECK ADD  CONSTRAINT [FK_MaPLTL] FOREIGN KEY([MaPLTL])
REFERENCES [dbo].[PHANLOAITHELUC] ([MaPLTL])
GO
ALTER TABLE [dbo].[KETQUATHELUC] CHECK CONSTRAINT [FK_MaPLTL]
GO
ALTER TABLE [dbo].[LOP]  WITH CHECK ADD  CONSTRAINT [FK_MaDaiDoi_Lop] FOREIGN KEY([MaDaiDoi])
REFERENCES [dbo].[DAIDOI] ([MaDaiDoi])
GO
ALTER TABLE [dbo].[LOP] CHECK CONSTRAINT [FK_MaDaiDoi_Lop]
GO
ALTER TABLE [dbo].[QUANLY]  WITH CHECK ADD  CONSTRAINT [FK_MaDaiDoi] FOREIGN KEY([MaDaiDoi])
REFERENCES [dbo].[DAIDOI] ([MaDaiDoi])
GO
ALTER TABLE [dbo].[QUANLY] CHECK CONSTRAINT [FK_MaDaiDoi]
GO
ALTER TABLE [dbo].[QUYCHUANKYLUAT]  WITH CHECK ADD  CONSTRAINT [FK_MaQLQC_KL] FOREIGN KEY([MaQLQC])
REFERENCES [dbo].[QUYCHUAN] ([MaQLQC])
GO
ALTER TABLE [dbo].[QUYCHUANKYLUAT] CHECK CONSTRAINT [FK_MaQLQC_KL]
GO
ALTER TABLE [dbo].[QUYCHUANTHELUC]  WITH CHECK ADD  CONSTRAINT [FK_MaQLQC_TL] FOREIGN KEY([MaQLQC])
REFERENCES [dbo].[QUYCHUAN] ([MaQLQC])
GO
ALTER TABLE [dbo].[QUYCHUANTHELUC] CHECK CONSTRAINT [FK_MaQLQC_TL]
GO
USE [master]
GO
ALTER DATABASE [QuanLyRenLuyen] SET  READ_WRITE 
GO
