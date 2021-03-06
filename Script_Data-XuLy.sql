USE [master]
GO
/****** Object:  Database [QUANLYNHADAT2]    Script Date: 12/12/2020 9:15:53 PM ******/
CREATE DATABASE [QUANLYNHADAT2]
go
 /*CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QUANLYNHADAT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QUANLYNHADAT.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QUANLYNHADAT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QUANLYNHADAT_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT*/
 USe  [QUANLYNHADAT2]
GO
ALTER DATABASE [QUANLYNHADAT2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QUANLYNHADAT2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QUANLYNHADAT2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET ARITHABORT OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QUANLYNHADAT2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QUANLYNHADAT2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QUANLYNHADAT2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QUANLYNHADAT2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QUANLYNHADAT2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QUANLYNHADAT2] SET  MULTI_USER 
GO
ALTER DATABASE [QUANLYNHADAT2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QUANLYNHADAT2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QUANLYNHADAT2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QUANLYNHADAT2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QUANLYNHADAT2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QUANLYNHADAT2] SET QUERY_STORE = OFF
GO
USE [QUANLYNHADAT2]
GO
/****** Object:  Table [dbo].[CHINHANH]    Script Date: 12/12/2020 9:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHINHANH](
	[MACN] [int] IDENTITY(1,1) NOT NULL,
	[FAX] [nvarchar](10) NULL,
	[SDT] [nvarchar](10) NULL,
	[DIACHI] [nvarchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[MACN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETNHABAN]    Script Date: 12/12/2020 9:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETNHABAN](
	[MANHA] [int] NOT NULL,
	[MACN] [int] NOT NULL,
	[GIABAN] [int] NULL,
	[DIEUKIEN] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MANHA] ASC,
	[MACN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETNHATHUE]    Script Date: 12/12/2020 9:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETNHATHUE](
	[MANHA] [int] NOT NULL ,
	[MACN] [int] NOT NULL,
	[GIATHUE] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MANHA] ASC,
	[MACN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHUNHA]    Script Date: 12/12/2020 9:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUNHA](
	[MACNHA] [int] IDENTITY(1,1) NOT NULL,
	[TEN] [nvarchar](20) NULL,
	[SDT] [nvarchar](10) NULL,
	[DIACHI] [nvarchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[MACNHA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOPDONG]    Script Date: 12/12/2020 9:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOPDONG](
	[MAHD] [int] IDENTITY(1,1) NOT NULL,
	[MAKH] [int] NULL,
	[MANHA] [int] NULL,
	[MACN] [int] NULL,
	[NGAYLAP] [datetime] NULL,
	[GHICHU] [nvarchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KEHOACHXEMNHA]    Script Date: 12/12/2020 9:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KEHOACHXEMNHA](
	[MAKH] [int] NOT NULL,
	[MANV] [int] NOT NULL,
	[MANHA] [int] NOT NULL,
	[MACN] [int] NULL,
	[NGAYXEM] [datetime] NULL,
	[NHANXET] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC,
	[MANV] ASC,
	[MANHA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 12/12/2020 9:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MAKH] [int] IDENTITY(1,1) NOT NULL,
	[CNQUANLY] [int] NOT NULL,
	[TEN] [nvarchar](20) NULL,
	[DIACHI] [nvarchar](40) NULL,
	[SDT] [nvarchar](10) NULL,
	[CHITIET] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC,
	[CNQUANLY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAINHA]    Script Date: 12/12/2020 9:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAINHA](
	[MALOAI] [int] IDENTITY(1,1) NOT NULL,
	[TEN] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MALOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHA]    Script Date: 12/12/2020 9:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHA](
	[MANHA] [int] IDENTITY(1,1) NOT NULL,
	[MACN] [int] NOT NULL,
	[MACNHA] [int] NULL,
	[MANV] [int] NULL,
	[MALOAI] [int] NULL,
	[SOLUONGPHONGO] [int] NULL,
	[NGAYHETHAN] [datetime] NULL,
	[NGAYDANG] [datetime] NULL,
	[DUONG] [nvarchar](40) NULL,
	[QUAN] [nvarchar](40) NULL,
	[KHUVUC] [nvarchar](40) NULL,
	[THANHPHO] [nvarchar](40) NULL,
	[TINHTRANG] [nvarchar](20) NULL,
	[SOLUOTXEM] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MANHA] ASC,
	[MACN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 12/12/2020 9:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MACN] [int] NOT NULL,
	[MANV] [int] IDENTITY(1,1) NOT NULL,
	[TEN] [nvarchar](20) NULL,
	[SDT] [nvarchar](10) NULL,
	[DIACHI] [nvarchar](40) NULL,
	[GIOITINH] [bit] NULL,
	[NGAYSINH] [date] NULL,
	[LUONG] [decimal](19, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[MANV] ASC,
	[MACN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YEUCAU]    Script Date: 12/12/2020 9:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YEUCAU](
	[MAKH] [int] NOT NULL,
	[MACN] [int] NOT NULL,
	[LOAINHAYEUCAU] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC,
	[MACN] ASC,
	[LOAINHAYEUCAU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CHINHANH] ON 

INSERT [dbo].[CHINHANH] ([MACN], [FAX], [SDT], [DIACHI]) VALUES (1, N'0837244405', N'0837244406', N'Quận Thủ Đức, TP.Hồ Chí Minh')
INSERT [dbo].[CHINHANH] ([MACN], [FAX], [SDT], [DIACHI]) VALUES (2, N'0884588856', N'0884588857', N'Quận 9, TP.Hồ Chí Minh')
INSERT [dbo].[CHINHANH] ([MACN], [FAX], [SDT], [DIACHI]) VALUES (3, N'0837785698', N'0837785694', N'Quận 2, TP.Hồ Chí Minh')
INSERT [dbo].[CHINHANH] ([MACN], [FAX], [SDT], [DIACHI]) VALUES (4, N'0832156231', N'0965133516', N'Quận 6, TP.Hồ Chí Minh')
INSERT [dbo].[CHINHANH] ([MACN], [FAX], [SDT], [DIACHI]) VALUES (5, N'0853256145', N'0971561657', N'Quận 7, TP.Hồ Chí Minh')
INSERT [dbo].[CHINHANH] ([MACN], [FAX], [SDT], [DIACHI]) VALUES (6, N'0821367829', N'0919054563', N'Quận 9, TP.Hồ Chí Minh')
SET IDENTITY_INSERT [dbo].[CHINHANH] OFF
GO

INSERT [dbo].[CHITIETNHABAN] ([MANHA], [MACN], [GIABAN], [DIEUKIEN]) VALUES (2, 2, 1000000000, N'Điều kiện An ninh tốt')
INSERT [dbo].[CHITIETNHABAN] ([MANHA], [MACN], [GIABAN], [DIEUKIEN]) VALUES (4, 4, 2000000000, N'Điều kiện An ninh tốt, đầy đủ nội thất')
GO
INSERT [dbo].[CHITIETNHATHUE] ([MANHA], [MACN], [GIATHUE]) VALUES (1, 1,  5000000)
INSERT [dbo].[CHITIETNHATHUE] ([MANHA], [MACN], [GIATHUE]) VALUES (3, 3,  3500000)
INSERT [dbo].[CHITIETNHATHUE] ([MANHA], [MACN], [GIATHUE]) VALUES (5, 1,  7000000)
INSERT [dbo].[CHITIETNHATHUE] ([MANHA], [MACN], [GIATHUE]) VALUES (6, 4,  4500000)
GO
SET IDENTITY_INSERT [dbo].[CHUNHA] ON 

INSERT [dbo].[CHUNHA] ([MACNHA], [TEN], [SDT], [DIACHI]) VALUES (1, N'Nguyễn Thị Kiều Diễm', N'0123456789', N'115 Đỗ Xuân Hợp, Thủ Đức, Hồ Chí Minh')
INSERT [dbo].[CHUNHA] ([MACNHA], [TEN], [SDT], [DIACHI]) VALUES (2, N'Nguyễn Thị Xuân Diệu', N'0848448478', N'12 Lê Văn Việt, Quận 9, Hồ Chí Minh')
INSERT [dbo].[CHUNHA] ([MACNHA], [TEN], [SDT], [DIACHI]) VALUES (3, N'Nguyễn Anh Thịnh', N'0877484848', N'123 An Phú, Quận 2, Hồ Chí Minh')
INSERT [dbo].[CHUNHA] ([MACNHA], [TEN], [SDT], [DIACHI]) VALUES (4, N'Ngô Thành Phúc', N'0915467456', N'117 Nghĩa Thục, Quận 5, TP Hồ Chí Minh')
INSERT [dbo].[CHUNHA] ([MACNHA], [TEN], [SDT], [DIACHI]) VALUES (5, N'Nguyễn Thị Nha Chang', N'0919546742', N'227 Trần Hưng Đạo, Quận 1, Hồ Chí Minh')
INSERT [dbo].[CHUNHA] ([MACNHA], [TEN], [SDT], [DIACHI]) VALUES (6, N'Nguyễn Ngô Bảo Long', N'0334567415', N'245 Bến Nghe, Quận 1, Hồ Chí Minh')
SET IDENTITY_INSERT [dbo].[CHUNHA] OFF
GO
SET IDENTITY_INSERT [dbo].[HOPDONG] ON 

INSERT [dbo].[HOPDONG] ([MAHD], [MAKH], [MANHA], [MACN], [NGAYLAP], [GHICHU]) VALUES (1, 2, 4, 1, CAST(N'2020-12-06T00:00:00.000' AS DateTime), N'Đã thanh toán')
INSERT [dbo].[HOPDONG] ([MAHD], [MAKH], [MANHA], [MACN], [NGAYLAP], [GHICHU]) VALUES (2, 3, 5, 2, CAST(N'2020-12-06T00:00:00.000' AS DateTime), N'Đã thanh toán')
INSERT [dbo].[HOPDONG] ([MAHD], [MAKH], [MANHA], [MACN], [NGAYLAP], [GHICHU]) VALUES (3, 4, 6, 3, CAST(N'2020-12-06T00:00:00.000' AS DateTime), N'Đã thanh toán')
SET IDENTITY_INSERT [dbo].[HOPDONG] OFF
GO
INSERT [dbo].[KEHOACHXEMNHA] ([MAKH], [MANV], [MANHA], [MACN], [NGAYXEM], [NHANXET]) VALUES (2, 1, 4, 1, CAST(N'2021-01-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[KEHOACHXEMNHA] ([MAKH], [MANV], [MANHA], [MACN], [NGAYXEM], [NHANXET]) VALUES (3, 2, 5, 2, CAST(N'2021-01-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[KEHOACHXEMNHA] ([MAKH], [MANV], [MANHA], [MACN], [NGAYXEM], [NHANXET]) VALUES (4, 3, 6, 3, CAST(N'2021-01-12T00:00:00.000' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([MAKH], [CNQUANLY], [TEN], [DIACHI], [SDT], [CHITIET]) VALUES (1, 1, N'Đoàn Gia baro', N'Quận Thủ Đức, TP.Hồ Chí Minh', N'0941313741', NULL)
INSERT [dbo].[KHACHHANG] ([MAKH], [CNQUANLY], [TEN], [DIACHI], [SDT], [CHITIET]) VALUES (2, 1, N'Đoàn Anh Đào', N'Quận Thủ Đức, TP.Hồ Chí Minh', N'0785412396', NULL)
INSERT [dbo].[KHACHHANG] ([MAKH], [CNQUANLY], [TEN], [DIACHI], [SDT], [CHITIET]) VALUES (3, 2, N'Hoàng Kim Toản', N'Quận 9, TP.Hồ Chí Minh', N'0785417456', NULL)
INSERT [dbo].[KHACHHANG] ([MAKH], [CNQUANLY], [TEN], [DIACHI], [SDT], [CHITIET]) VALUES (4, 3, N'Lê Kim Ngân', N'2, TP.Hồ Chí Minh', N'0785413926', NULL)
INSERT [dbo].[KHACHHANG] ([MAKH], [CNQUANLY], [TEN], [DIACHI], [SDT], [CHITIET]) VALUES (5, 4, N'Võ Thiện Thanh', N'Quận 5, Tp Hồ Chí Minh', N'0335464457', NULL)
INSERT [dbo].[KHACHHANG] ([MAKH], [CNQUANLY], [TEN], [DIACHI], [SDT], [CHITIET]) VALUES (6, 4, N'Lê Thanh Thảo', N'Quận Thủ Đức, TP Hồ Chí Minh', N'0965456156', NULL)
INSERT [dbo].[KHACHHANG] ([MAKH], [CNQUANLY], [TEN], [DIACHI], [SDT], [CHITIET]) VALUES (7, 3, N'Trần Duy Nhất', N'Quận Bình Thạnh, TP Hồ Chí Minh', N'0914566437', NULL)
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[LOAINHA] ON 

INSERT [dbo].[LOAINHA] ([MALOAI], [TEN]) VALUES (1, N'Nhà cấp 4')
INSERT [dbo].[LOAINHA] ([MALOAI], [TEN]) VALUES (2, N'Nhà cấp 3')
INSERT [dbo].[LOAINHA] ([MALOAI], [TEN]) VALUES (3, N'Nhà cấp 2')
SET IDENTITY_INSERT [dbo].[LOAINHA] OFF
GO
SET IDENTITY_INSERT [dbo].[NHA] ON 

INSERT [dbo].[NHA] ([MANHA], [MACN], [MACNHA], [MANV], [MALOAI],[SOLUONGPHONGO], [NGAYHETHAN], [NGAYDANG], [DUONG], [QUAN], [KHUVUC], [THANHPHO], [TINHTRANG], [SOLUOTXEM]) VALUES (1, 1, 1, 1, 1,5, CAST(N'2021-01-30T00:00:00.000' AS DateTime), CAST(N'2020-12-02T00:00:00.000' AS DateTime), N'Lê Văn Việt', N'Quận 9', N'KP3', N'Hồ Chí Minh', 1, 10)
INSERT [dbo].[NHA] ([MANHA], [MACN], [MACNHA], [MANV], [MALOAI],[SOLUONGPHONGO], [NGAYHETHAN], [NGAYDANG], [DUONG], [QUAN], [KHUVUC], [THANHPHO], [TINHTRANG], [SOLUOTXEM]) VALUES (2, 2, 2, 2, 2,5,  NULL,CAST(N'2021-01-24T00:00:00.000' AS DateTime), N'Đỗ Xuân Hợp', N'Quận Thủ Đức', N'KP1', N'Hồ Chí Minh', 0, 20)
INSERT [dbo].[NHA] ([MANHA], [MACN], [MACNHA], [MANV], [MALOAI],[SOLUONGPHONGO], [NGAYHETHAN], [NGAYDANG], [DUONG], [QUAN], [KHUVUC], [THANHPHO], [TINHTRANG], [SOLUOTXEM]) VALUES (3, 3, 3, 3, 3,5,  NULL,CAST(N'2021-01-25T00:00:00.000' AS DateTime), N'An Phú', N'Quận 2', N'KP4', N'Hồ Chí Minh', 0, 4)
INSERT [dbo].[NHA] ([MANHA], [MACN], [MACNHA], [MANV], [MALOAI],[SOLUONGPHONGO], [NGAYHETHAN], [NGAYDANG], [DUONG], [QUAN], [KHUVUC], [THANHPHO], [TINHTRANG], [SOLUOTXEM]) VALUES (4, 4, 1, 6, 1,5,  NULL , CAST(N'2021-01-26T00:00:00.000' AS DateTime),N'Lý Thái Tổ', N'Quận 10', N'KP5', N'Hồ Chí Minh', 0, 5)
INSERT [dbo].[NHA] ([MANHA], [MACN], [MACNHA], [MANV], [MALOAI],[SOLUONGPHONGO], [NGAYHETHAN], [NGAYDANG], [DUONG], [QUAN], [KHUVUC], [THANHPHO], [TINHTRANG], [SOLUOTXEM]) VALUES (5, 1, 2, 1, 2,5,  NULL ,CAST(N'2021-01-27T00:00:00.000' AS DateTime), N'Nguyễn Thị Minh Khai', N'Quận 1', N'KP1', N'Hồ Chí Minh', 0, 7)
INSERT [dbo].[NHA] ([MANHA], [MACN], [MACNHA], [MANV], [MALOAI],[SOLUONGPHONGO], [NGAYHETHAN], [NGAYDANG], [DUONG], [QUAN], [KHUVUC], [THANHPHO], [TINHTRANG], [SOLUOTXEM]) VALUES (6, 4, 6, 6, 3,5, NULL , CAST(N'2021-01-28T00:00:00.000' AS DateTime), N'An Bình', N'Quận 5', N'KP5', N'Hồ Chí Minh', 0, 9)
SET IDENTITY_INSERT [dbo].[NHA] OFF
GO
SET IDENTITY_INSERT [dbo].[NHANVIEN] ON 

INSERT [dbo].[NHANVIEN] ([MACN], [MANV], [TEN], [SDT], [DIACHI], [GIOITINH], [NGAYSINH], [LUONG]) VALUES (1, 1, N'Nguyễn Thị Ý Nhi', N'0938005804', N'Quận Thủ Đức, TP.Hồ Chí Minh', 0, CAST(N'1994-01-01' AS Date), CAST(2300.4456 AS Decimal(19, 4)))
INSERT [dbo].[NHANVIEN] ([MACN], [MANV], [TEN], [SDT], [DIACHI], [GIOITINH], [NGAYSINH], [LUONG]) VALUES (2, 2, N'Nguyễn Văn Nam', N'0853444855', N'Quận 9, TP.Hồ Chí Minh', 1, CAST(N'1992-01-01' AS Date), CAST(2400.4600 AS Decimal(19, 4)))
INSERT [dbo].[NHANVIEN] ([MACN], [MANV], [TEN], [SDT], [DIACHI], [GIOITINH], [NGAYSINH], [LUONG]) VALUES (3, 3, N'Nguyễn Anh Khoa', N'0145874361', N'Quận 2, TP.Hồ Chí Minh', 1, CAST(N'1990-01-01' AS Date), CAST(2800.7300 AS Decimal(19, 4)))
INSERT [dbo].[NHANVIEN] ([MACN], [MANV], [TEN], [SDT], [DIACHI], [GIOITINH], [NGAYSINH], [LUONG]) VALUES (4, 6, N'Trần Quốc Danh', N'0321564474', N'Huyện Củ Chi', 1, CAST(N'1989-05-07' AS Date), CAST(2546.1560 AS Decimal(19, 4)))
INSERT [dbo].[NHANVIEN] ([MACN], [MANV], [TEN], [SDT], [DIACHI], [GIOITINH], [NGAYSINH], [LUONG]) VALUES (5, 7, N'Trịnh Xuân Phúc', N'0917616515', N'Quận 12, TP Hồ Chí Minh', 1, CAST(N'1987-09-07' AS Date), CAST(2456.9450 AS Decimal(19, 4)))
INSERT [dbo].[NHANVIEN] ([MACN], [MANV], [TEN], [SDT], [DIACHI], [GIOITINH], [NGAYSINH], [LUONG]) VALUES (6, 8, N'Lê Long ', N'0345675646', N'Quận 1, TP Hồ Chí Minh', 1, CAST(N'1990-10-10' AS Date), CAST(2347.4511 AS Decimal(19, 4)))
SET IDENTITY_INSERT [dbo].[NHANVIEN] OFF
GO
INSERT [dbo].[YEUCAU] ([MAKH], [MACN], [LOAINHAYEUCAU]) VALUES (1, 1, 1)
INSERT [dbo].[YEUCAU] ([MAKH], [MACN], [LOAINHAYEUCAU]) VALUES (2, 1, 2)
INSERT [dbo].[YEUCAU] ([MAKH], [MACN], [LOAINHAYEUCAU]) VALUES (3, 2, 3)
GO

ALTER TABLE [dbo].[HOPDONG]  WITH CHECK ADD  CONSTRAINT [FK_HOPDONG_KHACHHANG] FOREIGN KEY([MAKH], [MACN])
REFERENCES [dbo].[KHACHHANG] ([MAKH], [CNQUANLY])
GO
ALTER TABLE [dbo].[HOPDONG] CHECK CONSTRAINT [FK_HOPDONG_KHACHHANG]
GO

ALTER TABLE [dbo].[KEHOACHXEMNHA]  WITH CHECK ADD  CONSTRAINT [FK_KEHOACHXEMNHA_KHACHHANG] FOREIGN KEY([MAKH], [MACN])
REFERENCES [dbo].[KHACHHANG] ([MAKH], [CNQUANLY])
GO
ALTER TABLE [dbo].[KEHOACHXEMNHA] CHECK CONSTRAINT [FK_KEHOACHXEMNHA_KHACHHANG]
GO

ALTER TABLE [dbo].[KEHOACHXEMNHA]  WITH CHECK ADD  CONSTRAINT [FK_KEHOACHXEMNHA_NHANVIEN] FOREIGN KEY([MANV], [MACN])
REFERENCES [dbo].[NHANVIEN] ([MANV], [MACN])
GO
ALTER TABLE [dbo].[KEHOACHXEMNHA] CHECK CONSTRAINT [FK_KEHOACHXEMNHA_NHANVIEN]
GO

ALTER TABLE [dbo].[KHACHHANG]  WITH CHECK ADD  CONSTRAINT [FK_KHACHHANG_CHINHANH] FOREIGN KEY([CNQUANLY])
REFERENCES [dbo].[CHINHANH] ([MACN])
GO
ALTER TABLE [dbo].[KHACHHANG] CHECK CONSTRAINT [FK_KHACHHANG_CHINHANH]
GO

ALTER TABLE [dbo].[NHA]  WITH CHECK ADD  CONSTRAINT [FK_NHA_CHUNHA] FOREIGN KEY([MACNHA])
REFERENCES [dbo].[CHUNHA] ([MACNHA])
GO
ALTER TABLE [dbo].[NHA] CHECK CONSTRAINT [FK_NHA_CHUNHA]
GO

ALTER TABLE [dbo].[NHA]  WITH CHECK ADD  CONSTRAINT [FK_NHA_LOAINHA] FOREIGN KEY([MALOAI])
REFERENCES [dbo].[LOAINHA] ([MALOAI])
GO
ALTER TABLE [dbo].[NHA] CHECK CONSTRAINT [FK_NHA_LOAINHA]
GO
ALTER TABLE [dbo].[NHA]  WITH CHECK ADD  CONSTRAINT [FK_NHA_NHANVIEN] FOREIGN KEY([MANV], [MACN])
REFERENCES [dbo].[NHANVIEN] ([MANV], [MACN])
GO
ALTER TABLE [dbo].[NHA] CHECK CONSTRAINT [FK_NHA_NHANVIEN]
GO

ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_CHINHANH] FOREIGN KEY([MACN])
REFERENCES [dbo].[CHINHANH] ([MACN])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_CHINHANH]
GO

ALTER TABLE [dbo].[CHITIETNHATHUE]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETNHATHUE_NHA] FOREIGN KEY([MANHA], [MACN])
REFERENCES [dbo].[NHA] ([MANHA],[MACN])
GO
ALTER TABLE [dbo].[CHITIETNHATHUE] CHECK CONSTRAINT [FK_CHITIETNHATHUE_NHA]
GO

ALTER TABLE [dbo].[CHITIETNHABAN]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETNHABAN_NHA] FOREIGN KEY([MANHA], [MACN])
REFERENCES [dbo].[NHA] ([MANHA],[MACN])
GO
ALTER TABLE [dbo].[CHITIETNHABAN] CHECK CONSTRAINT [FK_CHITIETNHABAN_NHA]
GO

ALTER TABLE [dbo].[YEUCAU]  WITH CHECK ADD  CONSTRAINT [FK_YEUCAU_KHACHHANG] FOREIGN KEY([MAKH], [MACN])
REFERENCES [dbo].[KHACHHANG] ([MAKH],[CNQUANLY])
GO
ALTER TABLE [dbo].[YEUCAU] CHECK CONSTRAINT [FK_YEUCAU_KHACHHANG]
GO

USE [master]
GO
ALTER DATABASE [QUANLYNHADAT2] SET  READ_WRITE 
GO
