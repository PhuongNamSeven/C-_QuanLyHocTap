USE [master]
GO
/****** Object:  Database [WebQuanLyHocTap]    Script Date: 6/29/2020 10:05:47 PM ******/
CREATE DATABASE [WebQuanLyHocTap]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebQuanLyHocTap', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WebQuanLyHocTap.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebQuanLyHocTap_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WebQuanLyHocTap_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WebQuanLyHocTap] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebQuanLyHocTap].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebQuanLyHocTap] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebQuanLyHocTap] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebQuanLyHocTap] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebQuanLyHocTap] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebQuanLyHocTap] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET RECOVERY FULL 
GO
ALTER DATABASE [WebQuanLyHocTap] SET  MULTI_USER 
GO
ALTER DATABASE [WebQuanLyHocTap] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebQuanLyHocTap] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebQuanLyHocTap] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebQuanLyHocTap] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebQuanLyHocTap] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WebQuanLyHocTap', N'ON'
GO
ALTER DATABASE [WebQuanLyHocTap] SET QUERY_STORE = OFF
GO
USE [WebQuanLyHocTap]
GO
/****** Object:  Table [dbo].[DanhSachSVLHP]    Script Date: 6/29/2020 10:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhSachSVLHP](
	[diemTk1] [float] NOT NULL,
	[diemTk2] [float] NULL,
	[giuaKy] [float] NULL,
	[cuoiKy] [float] NULL,
	[LopHPID] [int] NULL,
	[SinhVienID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiangVien]    Script Date: 6/29/2020 10:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiangVien](
	[GiangVienID] [int] NOT NULL,
	[UserName] [nvarchar](250) NULL,
	[PassWord] [nvarchar](250) NULL,
	[TenGV] [nvarchar](250) NULL,
 CONSTRAINT [PK_GiangVien] PRIMARY KEY CLUSTERED 
(
	[GiangVienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopHocPhan]    Script Date: 6/29/2020 10:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHocPhan](
	[LopHPID] [int] NOT NULL,
	[MonHocID] [int] NULL,
	[GiangVienID] [int] NULL,
	[trangthai] [bit] NULL,
	[tenHocPhan] [nvarchar](50) NULL,
 CONSTRAINT [PK_LopHocPhan] PRIMARY KEY CLUSTERED 
(
	[LopHPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 6/29/2020 10:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MonHocID] [int] NOT NULL,
	[TenMonHoc] [nvarchar](250) NULL,
	[isLock] [bit] NULL,
 CONSTRAINT [PK_MonHoc] PRIMARY KEY CLUSTERED 
(
	[MonHocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanTri]    Script Date: 6/29/2020 10:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanTri](
	[AdminID] [int] NOT NULL,
	[UserName] [nvarchar](250) NULL,
	[PassWord] [nvarchar](250) NULL,
	[FirstName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
 CONSTRAINT [PK_QuanTri] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 6/29/2020 10:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[SinhVienID] [int] NOT NULL,
	[UserName] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[TenSV] [nvarchar](250) NULL,
	[QueQuan] [nvarchar](250) NULL,
	[NgayDiemDanh] [datetime] NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[SinhVienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[GiangVien] ([GiangVienID], [UserName], [PassWord], [TenGV]) VALUES (1, N'namkunpro', N'123', N'PhuongNam 3')
INSERT [dbo].[GiangVien] ([GiangVienID], [UserName], [PassWord], [TenGV]) VALUES (2, N'gv2', NULL, N'Hằng 2')
INSERT [dbo].[LopHocPhan] ([LopHPID], [MonHocID], [GiangVienID], [trangthai], [tenHocPhan]) VALUES (190, 10, 2, NULL, N'lớp thực tập')
INSERT [dbo].[LopHocPhan] ([LopHPID], [MonHocID], [GiangVienID], [trangthai], [tenHocPhan]) VALUES (1490, 10, 1, NULL, N'lớp thực tập')
INSERT [dbo].[LopHocPhan] ([LopHPID], [MonHocID], [GiangVienID], [trangthai], [tenHocPhan]) VALUES (57465343, 456, 1, NULL, N'Lớp Tư Tưởng')
INSERT [dbo].[LopHocPhan] ([LopHPID], [MonHocID], [GiangVienID], [trangthai], [tenHocPhan]) VALUES (865756432, 456, 1, NULL, N'Lớp Tư Tưởng')
INSERT [dbo].[MonHoc] ([MonHocID], [TenMonHoc], [isLock]) VALUES (10, N'Thực tập', 1)
INSERT [dbo].[MonHoc] ([MonHocID], [TenMonHoc], [isLock]) VALUES (123, N'Đường lối', 0)
INSERT [dbo].[MonHoc] ([MonHocID], [TenMonHoc], [isLock]) VALUES (456, N'Tư tưởng', 1)
INSERT [dbo].[MonHoc] ([MonHocID], [TenMonHoc], [isLock]) VALUES (789, N'WWW', 1)
INSERT [dbo].[QuanTri] ([AdminID], [UserName], [PassWord], [FirstName], [LastName], [Email]) VALUES (0, N'namkunpro', NULL, N'nam', N'Le', NULL)
INSERT [dbo].[QuanTri] ([AdminID], [UserName], [PassWord], [FirstName], [LastName], [Email]) VALUES (1, N'nam', N'123na', NULL, NULL, NULL)
INSERT [dbo].[QuanTri] ([AdminID], [UserName], [PassWord], [FirstName], [LastName], [Email]) VALUES (2, N'namkunpro', NULL, N'nam', N'123na', NULL)
INSERT [dbo].[QuanTri] ([AdminID], [UserName], [PassWord], [FirstName], [LastName], [Email]) VALUES (3, N'namhang', NULL, N'nam', N'123na', NULL)
INSERT [dbo].[QuanTri] ([AdminID], [UserName], [PassWord], [FirstName], [LastName], [Email]) VALUES (4, N'hanghang2', N'123na', N'nam', NULL, NULL)
INSERT [dbo].[SinhVien] ([SinhVienID], [UserName], [Password], [TenSV], [QueQuan], [NgayDiemDanh]) VALUES (1, N'dung', N'123', N'dung', NULL, NULL)
INSERT [dbo].[SinhVien] ([SinhVienID], [UserName], [Password], [TenSV], [QueQuan], [NgayDiemDanh]) VALUES (2, N'namkunpro3', N'123', N'PhuongNam 3', NULL, NULL)
INSERT [dbo].[SinhVien] ([SinhVienID], [UserName], [Password], [TenSV], [QueQuan], [NgayDiemDanh]) VALUES (3, N'asd', N'asd', N'asd', NULL, NULL)
ALTER TABLE [dbo].[DanhSachSVLHP]  WITH CHECK ADD  CONSTRAINT [FK_DanhSachSVLHP_LopHocPhan] FOREIGN KEY([LopHPID])
REFERENCES [dbo].[LopHocPhan] ([LopHPID])
GO
ALTER TABLE [dbo].[DanhSachSVLHP] CHECK CONSTRAINT [FK_DanhSachSVLHP_LopHocPhan]
GO
ALTER TABLE [dbo].[DanhSachSVLHP]  WITH CHECK ADD  CONSTRAINT [FK_DanhSachSVLHP_SinhVien] FOREIGN KEY([SinhVienID])
REFERENCES [dbo].[SinhVien] ([SinhVienID])
GO
ALTER TABLE [dbo].[DanhSachSVLHP] CHECK CONSTRAINT [FK_DanhSachSVLHP_SinhVien]
GO
ALTER TABLE [dbo].[LopHocPhan]  WITH CHECK ADD  CONSTRAINT [FK_LopHocPhan_GiangVien] FOREIGN KEY([GiangVienID])
REFERENCES [dbo].[GiangVien] ([GiangVienID])
GO
ALTER TABLE [dbo].[LopHocPhan] CHECK CONSTRAINT [FK_LopHocPhan_GiangVien]
GO
ALTER TABLE [dbo].[LopHocPhan]  WITH CHECK ADD  CONSTRAINT [FK_LopHocPhan_MonHoc] FOREIGN KEY([MonHocID])
REFERENCES [dbo].[MonHoc] ([MonHocID])
GO
ALTER TABLE [dbo].[LopHocPhan] CHECK CONSTRAINT [FK_LopHocPhan_MonHoc]
GO
USE [master]
GO
ALTER DATABASE [WebQuanLyHocTap] SET  READ_WRITE 
GO
