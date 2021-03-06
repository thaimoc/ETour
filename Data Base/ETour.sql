USE [Etour]
GO
/****** Object:  Table [dbo].[Tour]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenTour] [nvarchar](100) NOT NULL,
	[XuatPhat] [nvarchar](100) NOT NULL,
	[TrangThai] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Tour] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tour] ON
INSERT [dbo].[Tour] ([ID], [TenTour], [XuatPhat], [TrangThai]) VALUES (8, N'Hà Nội - Puket', N'Hà Nội', N'Đang mở')
INSERT [dbo].[Tour] ([ID], [TenTour], [XuatPhat], [TrangThai]) VALUES (10, N'Tp.HCM - Puket', N'Tp.HCM', N'Đang mở')
INSERT [dbo].[Tour] ([ID], [TenTour], [XuatPhat], [TrangThai]) VALUES (13, N'Đà Nẵng - Puket', N'Đà Nẵng', N'Đang mở')
INSERT [dbo].[Tour] ([ID], [TenTour], [XuatPhat], [TrangThai]) VALUES (16, N'Tp.HCM - Puket', N'Tp.HCM', N'Đang mở')
INSERT [dbo].[Tour] ([ID], [TenTour], [XuatPhat], [TrangThai]) VALUES (20, N'Tp.HCM - Đà Lạt', N'Tp.HCM', N'Đang mở')
SET IDENTITY_INSERT [dbo].[Tour] OFF
/****** Object:  StoredProcedure [dbo].[SearchByCondition]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchByCondition]
(
	@tableName nvarchar(30),
	@condition nvarchar(100)
)	
AS
	declare @query as nvarchar (200);
	set @query = 'SELECT * FROM ' + @tableName + ' WHERE ' + @condition;
	exec (@query);
GO
/****** Object:  Table [dbo].[Login]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[User] [nvarchar](100) NOT NULL,
	[Pass] [nvarchar](100) NOT NULL,
	[Powers] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Login_1] PRIMARY KEY CLUSTERED 
(
	[User] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Login] ([User], [Pass], [Powers]) VALUES (N'Administrator', N'123456&', N'Administrator')
INSERT [dbo].[Login] ([User], [Pass], [Powers]) VALUES (N'Kim', N'12#', N'User')
INSERT [dbo].[Login] ([User], [Pass], [Powers]) VALUES (N'Nguyen', N'12@', N'Saler')
INSERT [dbo].[Login] ([User], [Pass], [Powers]) VALUES (N'Ping', N'123*', N'Designer')
/****** Object:  Table [dbo].[NCCPTien]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCCPTien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](150) NULL,
	[DienThoai] [nvarchar](24) NULL,
 CONSTRAINT [PK_NCCPTien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[NCCPTien] ON
INSERT [dbo].[NCCPTien] ([ID], [TenNCC], [DiaChi], [DienThoai]) VALUES (1, N'VietNam Airline', N'Tp.HCM', N'012567890')
INSERT [dbo].[NCCPTien] ([ID], [TenNCC], [DiaChi], [DienThoai]) VALUES (2, N'Viet Jet Air', N'Tp.HCM', N'05678922')
INSERT [dbo].[NCCPTien] ([ID], [TenNCC], [DiaChi], [DienThoai]) VALUES (3, N'Jet Start', N'Tp.HCM', N'12377722')
INSERT [dbo].[NCCPTien] ([ID], [TenNCC], [DiaChi], [DienThoai]) VALUES (4, N'Kim Nguyen Airline', N'58-Hoàng Diệu-Ba Đình - Hà Nội', N'023355889')
INSERT [dbo].[NCCPTien] ([ID], [TenNCC], [DiaChi], [DienThoai]) VALUES (5, N'Hoàng My AirLine', N'12-Hai Bà Trưng-Ba Đình- Hà Nội', N'023566123')
INSERT [dbo].[NCCPTien] ([ID], [TenNCC], [DiaChi], [DienThoai]) VALUES (6, N'Vũ Hoàng AirLine', N'52/6-Hai Bà Trưng-Ba Đình-Hà Nội', N'023665465')
INSERT [dbo].[NCCPTien] ([ID], [TenNCC], [DiaChi], [DienThoai]) VALUES (7, N'Indo-chinal Airline', N'2/3-P8.Q5.Tp.HCM', N'0365499')
INSERT [dbo].[NCCPTien] ([ID], [TenNCC], [DiaChi], [DienThoai]) VALUES (8, N'Kim Airline', N'2 - Hoàng Diệu - Q1. TP.HCM', N'0331654')
INSERT [dbo].[NCCPTien] ([ID], [TenNCC], [DiaChi], [DienThoai]) VALUES (9, N'Any Airline', N'2-554ds4a5dfa', N'003551')
INSERT [dbo].[NCCPTien] ([ID], [TenNCC], [DiaChi], [DienThoai]) VALUES (11, N'America Airline', N'2-3 - New York', N'1532416516')
SET IDENTITY_INSERT [dbo].[NCCPTien] OFF
/****** Object:  Table [dbo].[KhachSan]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachSan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenKS] [nvarchar](50) NOT NULL,
	[SoSao] [real] NOT NULL,
	[DiaChi] [nvarchar](150) NOT NULL,
	[SoDienThoai] [nvarchar](24) NULL,
 CONSTRAINT [PK_KhachSan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[KhachSan] ON
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (2, N'Impiana Resort Patong', 4, N'41, Taweewongse Road, Phu Kẹt, Thái Lan', N'012356789')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (3, N'Karon Beach Resort', 4, N'51 Karon Road, Tambon Karon Muang District, Phu Kẹt, Thái Lan', N'023456684')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (4, N'Silver Resortel', 3, N'3/37 Sawatdirak Road, Phu Kẹt, Thái Lan', N'123892353')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (5, N'Goodstay December Hotel', 2, N'Yeon-dong, Jeju-si, Sân bay quốc tế thành phố Jeju, Jeju-do, Hàn Quốc', N'025688466')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (6, N'Ocean Suite Jeju Hotel', 4, N'1260, Sando2-dong, Sân bay quốc tế thành phố Jeju, Jeju-do, Hàn Quốc', N'056322156')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (7, N'The Kahala Hotel and Resort', 4, N'5000 Kahala Avenue, Hawaii (HI), Hoa Kỳ', N'123065654')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (8, N'Best Western Plus Coconut Waikiki Hotel', 3, N'450 Lewers Street, Hawaii (HI), Hoa Kỳ', N'023542355')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (9, N'Trump International Hotel Waikiki Beach Walk', 5, N'223 Saratoga Road, Hawaii (HI), Hoa Kỳ', N'026546987')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (10, N'Hawaii Prince Waikiki Hotel', 4, N'100 Holomoana St., Hawaii (HI), Hoa Kỳ', N'026545598')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (11, N'Ewa Hotel Waikiki', 2, N'2555 Cartwright Road, Waikiki, Hawaii (HI), Hoa Kỳ ', N'056486556')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (12, N'Holiday Inn Hotel', 3, N'2300 Kalakaua Avenue Honolulu, Hawaii, Waikiki, Hawaii (HI), Hoa Kỳ', N'032346654')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (13, N'Kim Nguyen''s Hotel', 2, N'58-Hai Bà Trưng-Ba Đình-Hà Nội', N'165665456')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (14, N'Kim Nguyen''s Hotel', 2, N'58-Hai Bà Trưng-Ba Đình-Hà Nội', N'165665456')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (22, N'Hương giang hotel', 5, N'38-Hai Bà Trưng - Ba Đình - Hà Nội', N'0651216')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (23, N'Wat Chalong Hotel', 0, N'3/2 - Wat Chalong - Puket - ThaiLand', N'12310063')
INSERT [dbo].[KhachSan] ([ID], [TenKS], [SoSao], [DiaChi], [SoDienThoai]) VALUES (24, N'Quang Dung Hotel', 3, N'28-Trần Phú - Phường 9 - Đà Lạt', N'12346688')
SET IDENTITY_INSERT [dbo].[KhachSan] OFF
/****** Object:  Table [dbo].[KhachHang]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[ID] [nchar](7) NOT NULL,
	[Ho] [nvarchar](20) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[NgaySinh] [datetime] NULL,
	[GTinh] [bit] NOT NULL,
	[SoDT] [nvarchar](24) NULL,
	[SoTaiKhoan] [nvarchar](30) NULL,
	[DiaChi] [nvarchar](150) NULL,
	[ThanhPho] [nvarchar](30) NULL,
	[QuocGia] [nvarchar](24) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[KhachHang] ([ID], [Ho], [Ten], [NgaySinh], [GTinh], [SoDT], [SoTaiKhoan], [DiaChi], [ThanhPho], [QuocGia]) VALUES (N'KH00005', N'Kim Trọng', N'A', CAST(0x0000806800000000 AS DateTime), 1, N'09856499', N'16459888799', N'58- Quán Sứ', N'Hà Nội', N'Việt Nam')
INSERT [dbo].[KhachHang] ([ID], [Ho], [Ten], [NgaySinh], [GTinh], [SoDT], [SoTaiKhoan], [DiaChi], [ThanhPho], [QuocGia]) VALUES (N'KH00006', N'Phạm Tôn', N'Nhi', CAST(0x000080F800000000 AS DateTime), 1, N'06554998', N'06654989984', N'5/3-Võ Văn Kệt', N'Tp.HCM', N'Việt Nam')
INSERT [dbo].[KhachHang] ([ID], [Ho], [Ten], [NgaySinh], [GTinh], [SoDT], [SoTaiKhoan], [DiaChi], [ThanhPho], [QuocGia]) VALUES (N'KH00009', N'Trần Anh', N'Thư', CAST(0x000080E700757B00 AS DateTime), 1, N'06321612123', N'02165415641650216513', N'35-6-Hoàng Diệu-Hai Bà Trưng - Hà Nội', N'Hà Nội', N'Việt Nam')
INSERT [dbo].[KhachHang] ([ID], [Ho], [Ten], [NgaySinh], [GTinh], [SoDT], [SoTaiKhoan], [DiaChi], [ThanhPho], [QuocGia]) VALUES (N'KH00010', N'Kim', N'A', CAST(0x0000810300859800 AS DateTime), 1, N'4465514645', N'16564', N'58- Quán Thánh', N'Hà Nội', N'Việt Nam')
INSERT [dbo].[KhachHang] ([ID], [Ho], [Ten], [NgaySinh], [GTinh], [SoDT], [SoTaiKhoan], [DiaChi], [ThanhPho], [QuocGia]) VALUES (N'KH00011', N'Kim', N'A', CAST(0x0000810300861438 AS DateTime), 1, N'1564564564', N'465', N'58- Quán Sứ', N'Hà Nội', N'Việt Nam')
INSERT [dbo].[KhachHang] ([ID], [Ho], [Ten], [NgaySinh], [GTinh], [SoDT], [SoTaiKhoan], [DiaChi], [ThanhPho], [QuocGia]) VALUES (N'KH00012', N'Kim', N'A', CAST(0x0000810300B89DB8 AS DateTime), 1, N'167978645', N'54645', N'38 - Lê Hữu Trác', N'', N'Việt Nam')
INSERT [dbo].[KhachHang] ([ID], [Ho], [Ten], [NgaySinh], [GTinh], [SoDT], [SoTaiKhoan], [DiaChi], [ThanhPho], [QuocGia]) VALUES (N'KH00013', N'Kim', N'BA', CAST(0x0000810300B95488 AS DateTime), 1, N'7945645646', N'54654564', N'2 - Lý Thái Tổ', N'Hà Nội', N'Việt Nam')
INSERT [dbo].[KhachHang] ([ID], [Ho], [Ten], [NgaySinh], [GTinh], [SoDT], [SoTaiKhoan], [DiaChi], [ThanhPho], [QuocGia]) VALUES (N'KH00014', N'Trần', N'An', CAST(0x0000806800000000 AS DateTime), 0, N'14161321656', N'123565465', N'12-Hai Bà Trưng - Phường 9', N'Hà Nội', N'Việt Nam')
/****** Object:  Table [dbo].[HDV]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HDV](
	[ID] [nchar](7) NOT NULL,
	[Ho] [nvarchar](20) NOT NULL,
	[Ten] [nvarchar](20) NOT NULL,
	[NgaySinh] [datetime] NULL,
	[GioiTinh] [bit] NOT NULL,
	[DiaChi] [nvarchar](150) NULL,
	[QuocGia] [nvarchar](24) NULL,
	[DienThoai] [nvarchar](24) NULL,
	[TrangThai] [bit] NOT NULL,
 CONSTRAINT [PK_HDV] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[HDV] ([ID], [Ho], [Ten], [NgaySinh], [GioiTinh], [DiaChi], [QuocGia], [DienThoai], [TrangThai]) VALUES (N'HDV0000', N'Kim ANa', N'Nguyễn', CAST(0x000086B100000000 AS DateTime), 1, N'45/4-Hoàng Diệu-Hà Nội', N'Việt Nam', N'', 1)
INSERT [dbo].[HDV] ([ID], [Ho], [Ten], [NgaySinh], [GioiTinh], [DiaChi], [QuocGia], [DienThoai], [TrangThai]) VALUES (N'HDV0001', N'Tran', N'Anh', CAST(0x000080DF00000000 AS DateTime), 1, N'51C-Trần Phú-Ba Đình-Hà Nội', N'Việt Nam', N'012345678', 0)
INSERT [dbo].[HDV] ([ID], [Ho], [Ten], [NgaySinh], [GioiTinh], [DiaChi], [QuocGia], [DienThoai], [TrangThai]) VALUES (N'HDV0002', N'Nguyễn Tuyết', N'Như', CAST(0x000080DD00000000 AS DateTime), 1, N'38-Trần Phú-Ba Đình-Hà Nội', N'Việt Nam', N'012356789', 1)
INSERT [dbo].[HDV] ([ID], [Ho], [Ten], [NgaySinh], [GioiTinh], [DiaChi], [QuocGia], [DienThoai], [TrangThai]) VALUES (N'HDV0003', N'Hoàng', N'Như', CAST(0x0000808800000000 AS DateTime), 1, N'28/6-Nguyễn Thị Nghĩa-P.2-Đà Lạt', N'Việt Nam', N'013456789', 0)
INSERT [dbo].[HDV] ([ID], [Ho], [Ten], [NgaySinh], [GioiTinh], [DiaChi], [QuocGia], [DienThoai], [TrangThai]) VALUES (N'HDV0004', N'Kim', N'Hoàng', CAST(0x0000810300000000 AS DateTime), 1, N'Hà Nội', N'Việt Nam', N'032103132', 1)
INSERT [dbo].[HDV] ([ID], [Ho], [Ten], [NgaySinh], [GioiTinh], [DiaChi], [QuocGia], [DienThoai], [TrangThai]) VALUES (N'HDV0005', N'Kim', N'Nguyen', CAST(0x0000810200000000 AS DateTime), 1, N'58 - Hai Bà Trưng - Ba Đình - Hà Nội', N'Việt Nam', N'0321321063', 1)
INSERT [dbo].[HDV] ([ID], [Ho], [Ten], [NgaySinh], [GioiTinh], [DiaChi], [QuocGia], [DienThoai], [TrangThai]) VALUES (N'HDV0006', N'Trần', N'Vũ', CAST(0x000080A100000000 AS DateTime), 0, N'28 - Hoàng Diệu - Hà Nội', N'Việt Nam', N'1234516', 1)
INSERT [dbo].[HDV] ([ID], [Ho], [Ten], [NgaySinh], [GioiTinh], [DiaChi], [QuocGia], [DienThoai], [TrangThai]) VALUES (N'HDV0007', N'Nguyễn', N'Hoàng', CAST(0x000080A100000000 AS DateTime), 1, N'28 - Lý Quốc Oai - Hà Nội', N'Việt Nam', N'1234699', 1)
INSERT [dbo].[HDV] ([ID], [Ho], [Ten], [NgaySinh], [GioiTinh], [DiaChi], [QuocGia], [DienThoai], [TrangThai]) VALUES (N'HDV0008', N'Hoàng', N'Vũ Minh', CAST(0x000080A100000000 AS DateTime), 1, N'3/8 - Hoàng Diệu - Phường 9 - Hai Bà Trưng - Hà Nội', N'Việt Nam', N'12341651632', 1)
/****** Object:  Table [dbo].[DiaDiem]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiaDiem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenDD] [nvarchar](50) NOT NULL,
	[QuocGia] [nvarchar](24) NOT NULL,
 CONSTRAINT [PK_DiaDiem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DiaDiem] ON
INSERT [dbo].[DiaDiem] ([ID], [TenDD], [QuocGia]) VALUES (1, N'Puket', N'Thái Lan')
INSERT [dbo].[DiaDiem] ([ID], [TenDD], [QuocGia]) VALUES (2, N'Hawaii', N'Hoa Kỳ')
INSERT [dbo].[DiaDiem] ([ID], [TenDD], [QuocGia]) VALUES (3, N'Seoul – đảo Jeju', N'Hàn Quốc')
INSERT [dbo].[DiaDiem] ([ID], [TenDD], [QuocGia]) VALUES (4, N'BALI', N'Indonesia')
INSERT [dbo].[DiaDiem] ([ID], [TenDD], [QuocGia]) VALUES (5, N'Hồng Kông', N'Trung Quốc')
INSERT [dbo].[DiaDiem] ([ID], [TenDD], [QuocGia]) VALUES (6, N'New York', N'Hoa Kỳ')
INSERT [dbo].[DiaDiem] ([ID], [TenDD], [QuocGia]) VALUES (8, N'Quảng Ninh', N'Việt Nam')
INSERT [dbo].[DiaDiem] ([ID], [TenDD], [QuocGia]) VALUES (9, N'Da Lat', N'Việt Nam')
INSERT [dbo].[DiaDiem] ([ID], [TenDD], [QuocGia]) VALUES (10, N'Canifonia', N'Hoa Kỳ')
SET IDENTITY_INSERT [dbo].[DiaDiem] OFF
/****** Object:  StoredProcedure [dbo].[DiaDiem_Update]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiaDiem_Update]
	@ID int,
	@TenDD nvarchar(50),
	@QuocGia nvarchar(24)
AS
BEGIN
    -- Insert statements for procedure here
	UPDATE DiaDiem
	SET TenDD = @TenDD,
		QuocGia = @QuocGia
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DiaDiem_Single]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiaDiem_Single]
	@ID int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM DiaDiem WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DiaDiem_SearchKey]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiaDiem_SearchKey]
	@Key nvarchar(50)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM DiaDiem WHERE ID LIKE '%' + @Key + '%' OR TenDD LIKE '%' + @Key + '%' OR QuocGia LIKE '%' + @Key + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[DiaDiem_FindByTenDiem]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyen>
-- Create date: <Create Date,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiaDiem_FindByTenDiem]
	@TenDD nvarchar(50)
AS
BEGIN
	SELECT * FROM DiaDiem WHERE TenDD LIKE '%' + @TenDD + '%' ORDER BY TenDD
END
GO
/****** Object:  StoredProcedure [dbo].[DiaDiem_FindByTenDD_QuocGia]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiaDiem_FindByTenDD_QuocGia]
	@TenDD nvarchar(50),
	@QuocGia nvarchar(24)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM DiaDiem WHERE TenDD = @TenDD AND QuocGia = @QuocGia
END
GO
/****** Object:  StoredProcedure [dbo].[DiaDiem_FindByCountry]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiaDiem_FindByCountry]
	@QuocGia nvarchar(24)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM DiaDiem WHERE QuocGia = @QuocGia
END
GO
/****** Object:  StoredProcedure [dbo].[DiaDiem_AllCountries]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiaDiem_AllCountries]
AS
BEGIN
    -- Insert statements for procedure here
	SELECT DISTINCT QuocGia FROM DiaDiem
END
GO
/****** Object:  StoredProcedure [dbo].[DiaDiem_All]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiaDiem_All]
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM DiaDiem
END
GO
/****** Object:  StoredProcedure [dbo].[DiaDiem_Add]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiaDiem_Add]
	@ID int output,
	@TenDD nvarchar(50),
	@QuocGia nvarchar(24)
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO DiaDiem(TenDD, QuocGia)
	VALUES(@TenDD, @QuocGia)
	SET @ID = SCOPE_IDENTITY()
END
GO
/****** Object:  Table [dbo].[Chuyen]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chuyen](
	[MChuyen] [int] IDENTITY(1,1) NOT NULL,
	[MTour] [int] NOT NULL,
	[NgayDi] [datetime] NOT NULL,
	[NgayVe] [datetime] NOT NULL,
	[Gia] [real] NOT NULL,
	[TrangThai] [smallint] NOT NULL,
 CONSTRAINT [PK_Chuyen] PRIMARY KEY CLUSTERED 
(
	[MChuyen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Chuyen] ON
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (5, 8, CAST(0x0000A0440087A1AB AS DateTime), CAST(0x0000A0440087A1AB AS DateTime), 12, -1)
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (6, 8, CAST(0x0000A044009D09E8 AS DateTime), CAST(0x0000A044009D09E8 AS DateTime), 25.03, 0)
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (7, 10, CAST(0x0000A04400A24547 AS DateTime), CAST(0x0000A04400A24547 AS DateTime), 21, 0)
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (9, 8, CAST(0x0000A0440087A1AB AS DateTime), CAST(0x0000A0440087A1AB AS DateTime), 12, 0)
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (10, 8, CAST(0x0000A04600E543E6 AS DateTime), CAST(0x0000A04600E543E6 AS DateTime), 123, 0)
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (11, 10, CAST(0x0000A0620091BEF0 AS DateTime), CAST(0x0000A06B0091BE28 AS DateTime), 123.616, 1)
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (12, 10, CAST(0x0000A0610091BE28 AS DateTime), CAST(0x0000A06B0091BE28 AS DateTime), 111.8, 1)
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (13, 10, CAST(0x0000A06200932C92 AS DateTime), CAST(0x0000A06200932C63 AS DateTime), 123.6, 0)
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (14, 10, CAST(0x0000A0620093AA30 AS DateTime), CAST(0x0000A0620093AA03 AS DateTime), 123.25, 0)
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (15, 10, CAST(0x0000A0620094375E AS DateTime), CAST(0x0000A0620094372F AS DateTime), 123, 0)
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (17, 10, CAST(0x0000A06201043573 AS DateTime), CAST(0x0000A06201043565 AS DateTime), 132, 0)
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (18, 8, CAST(0x0000A06700F9EE25 AS DateTime), CAST(0x0000A06A00F9ECDC AS DateTime), 58.8, 1)
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (19, 8, CAST(0x0000A06700F9EE25 AS DateTime), CAST(0x0000A06D00F9ECDC AS DateTime), 63.8, 1)
INSERT [dbo].[Chuyen] ([MChuyen], [MTour], [NgayDi], [NgayVe], [Gia], [TrangThai]) VALUES (20, 20, CAST(0x0000A17200FCDF94 AS DateTime), CAST(0x0000A17800FCDF8C AS DateTime), 1200, 1)
SET IDENTITY_INSERT [dbo].[Chuyen] OFF
/****** Object:  Table [dbo].[DiemDL]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemDL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenDiem] [nvarchar](50) NOT NULL,
	[MaDD] [int] NOT NULL,
	[DiaChi] [nvarchar](150) NULL,
 CONSTRAINT [PK_DiemDL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DiemDL] ON
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (1, N'Thiên đường giải trí Phuket', 1, N'Puket-Thái Lan')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (2, N'Công viên bướm ở Phuket', 1, N'Puket-Thái Lan')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (3, N'Đền Chalong', 1, N'Puket-Thái Lan')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (4, N'Chùa Chalong tại Phuket', 1, N'Puket-Thái Lan')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (5, N'Wat Chalong', 1, N'Puket-Thái Lan')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (6, N'Phuket FantaSeas', 1, N'Kamala-Puket-Thái Lan')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (7, N'Đảo Phi Phi', 1, N'Puket-Thái Lan')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (8, N'Công viên quốc gia Sirinat', 1, N'Puket-Thái Lan')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (9, N'Trung tâm văn hóa Polynesia', 2, N'Wahu-Hawaii-Hoa Kỳ')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (10, N'Bãi biển Yuchang', 2, N'Wahu-Hawaii-Hoa Kỳ')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (11, N'Bãi biển Huanda', 2, N'Wahu-Hawaii-Hoa Kỳ')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (12, N'Bãi biểni Huajiji', 2, N'Wahu-Hawaii-Hoa Kỳ')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (13, N'Trân Châu Cảng', 2, N'Phía nam thủ phủ Honolulu-Hawaii-Hoa Kỳ')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (14, N'Yongduam Dragon Head Rock', 3, N'Đảo Jeju - Hàn Quốc')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (15, N'Mysterious Road', 3, N'Đảo Jeju - Hàn Quốc')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (16, N'Love Land', 3, N'Đảo Jeju - Hàn Quốc')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (17, N'ghjg', 2, N'gfdsg')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (18, N'Thiên đường tình yêu', 4, N'Bali - Indonesia')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (19, N'Xuân Hương Valey', 9, N'Xuân Hương Valey - 12-Trần Phú- Phường 9 - Đà Lạt ')
INSERT [dbo].[DiemDL] ([ID], [TenDiem], [MaDD], [DiaChi]) VALUES (20, N'Xuân Hương Lake', 9, N'12 - Trần Phú - Phường 9 - Đà Lạt')
SET IDENTITY_INSERT [dbo].[DiemDL] OFF
/****** Object:  Table [dbo].[HDV_Tour]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HDV_Tour](
	[MHDV] [nchar](7) NOT NULL,
	[MTour] [int] NOT NULL,
 CONSTRAINT [PK_HDV_Tour] PRIMARY KEY CLUSTERED 
(
	[MHDV] ASC,
	[MTour] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0000', 10)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0000', 13)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0000', 16)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0001', 8)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0001', 10)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0001', 16)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0001', 20)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0002', 8)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0002', 10)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0002', 16)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0003', 10)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0003', 13)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0003', 16)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0004', 8)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0004', 10)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0004', 13)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0004', 16)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0005', 8)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0005', 10)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0005', 13)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0005', 20)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0006', 13)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0006', 16)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0006', 20)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0007', 10)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0007', 13)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0007', 16)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0007', 20)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0008', 10)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0008', 13)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0008', 16)
INSERT [dbo].[HDV_Tour] ([MHDV], [MTour]) VALUES (N'HDV0008', 20)
/****** Object:  StoredProcedure [dbo].[HDV_Single]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_Single]
	-- Add the parameters for the stored procedure here
	@MaSo nchar(7)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM HDV WHERE ID = @MaSo
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_Search]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_Search]
	@Word nvarchar(150)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM HDV WHERE ID LIKE '%' + @Word + '%'
	OR Ho LIKE '%' + @Word + '%' OR Ten LIKE '%' + @Word + '%'
	OR NgaySinh LIKE '%' + @Word + '%' OR GioiTinh LIKE '%' + @Word + '%'
	OR GioiTinh LIKE '%' + @Word + '%' OR DiaChi LIKE '%' + @Word + '%' 
	OR QuocGia LIKE '%' + @Word + '%' OR DienThoai LIKE '%' + @Word + '%' 
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_FindGender]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_FindGender]
	@GioiTinh bit
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM HDV WHERE GioiTinh = @GioiTinh
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_FindByStatus]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_FindByStatus]
	@TrangThai bit
AS
BEGIN
   SELECT * FROM HDV WHERE TrangThai = @TrangThai
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_FindByNameSingle]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_FindByNameSingle]
	@Ho nvarchar(20),
	@Ten nvarchar(20)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM HDV WHERE Ten = @Ten AND Ho = @Ho
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_FindByName]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_FindByName]
	@Ten nvarchar(20)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM HDV WHERE Ten LIKE '%' + @Ten + '%' OR Ho LIKE '%' + @Ten + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_FindAllCountries]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_FindAllCountries]
AS
BEGIN
    -- Insert statements for procedure here
	SELECT DISTINCT QuocGia FROM HDV
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_FindByGenderAndCountry]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_FindByGenderAndCountry]
	@GioiTinh bit,
	@QuocGia nvarchar(24)
AS
BEGIN
   SELECT * FROM HDV WHERE GioiTinh = @GioiTinh AND QuocGia = @QuocGia 
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_FindByCountry]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_FindByCountry]
	@QuocGia nvarchar(24)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM HDV WHERE QuocGia = @QuocGia
END
GO
/****** Object:  StoredProcedure [dbo].[KhachHang_FindByGender]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachHang_FindByGender] 
	@Gender Bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM KhachHang WHERE GTinh = @Gender
END
GO
/****** Object:  StoredProcedure [dbo].[KhachHang_FindByCountry]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachHang_FindByCountry] 
	@County nvarchar(24)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM KhachHang WHERE QuocGia = @County ORDER BY Ten
END
GO
/****** Object:  StoredProcedure [dbo].[KhachHang_FindByCity]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachHang_FindByCity] 
	@City nvarchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM KhachHang WHERE ThanhPho = @City ORDER BY Ten
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_All]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_All]
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM HDV
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_Add]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,22/04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_Add]
	@ID nchar(7),
	@Ho nvarchar(20),
	@Ten nvarchar(20),
	@NgaySinh datetime,
	@GioiTinh nvarchar(15),
	@DiaChi nvarchar(150),
	@QuocGia nvarchar(24),
	@DienThoai nvarchar(24),
	@TrangThai bit
AS
BEGIN
    -- Insert statements for procedure here
	IF NOT EXISTS(SELECT * FROM HDV WHERE ID = @ID)
	BEGIN
		INSERT INTO HDV(ID, Ho, Ten, NgaySinh, GioiTinh, DiaChi, QuocGia, DienThoai, TrangThai)
		VALUES(@ID, @Ho, @Ten, @NgaySinh, @GioiTinh, @DiaChi, @QuocGia, @DienThoai, @TrangThai)	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_Update]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,22/04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_Update]
	@ID nchar(7),
	@Ho nvarchar(20),
	@Ten nvarchar(20),
	@NgaySinh datetime,
	@GioiTinh nvarchar(15),
	@DiaChi nvarchar(150),
	@QuocGia nvarchar(24),
	@DienThoai nvarchar(24),
	@TrangThai bit
AS
BEGIN
    -- Insert statements for procedure here
	UPDATE HDV
	SET
		Ho = @Ho, 
		Ten = @Ten, 
		NgaySinh = @NgaySinh, 
		GioiTinh = @GioiTinh, 
		DiaChi = @DiaChi, 
		QuocGia = @QuocGia, 
		DienThoai = @DienThoai,
		TrangThai = @TrangThai
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[KhachHang_UPDATE]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachHang_UPDATE] 
	@MaKH nchar(7),
	@Ho nvarchar(20),
	@Ten nvarchar(50),
	@NgaySinh datetime,
	@GTinh bit,
	@SoDT nvarchar(24),
	@SoTaiKhoan nvarchar(30),
	@DiaChi nvarchar(150),
	@ThanhPho nvarchar(30),
	@QuocGia nvarchar(24)
AS
BEGIN
	UPDATE KhachHang 
	SET ID = @MaKH, Ho = @Ho, Ten = @Ten, NgaySinh = @NgaySinh, GTinh = @GTinh, 
		SoDT = @SoDT, SoTaiKhoan = @SoTaiKhoan, DiaChi = @DiaChi, ThanhPho = @ThanhPho, QuocGia = @QuocGia
	WHERE ID = @MaKH
END
GO
/****** Object:  StoredProcedure [dbo].[KhachHang_Single]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachHang_Single] 
	@MaKH nchar(7)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM KhachHang WHERE ID = @MaKH
END
GO
/****** Object:  StoredProcedure [dbo].[KhachHang_FindMothCurrentBirthDay]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachHang_FindMothCurrentBirthDay]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM KhachHang WHERE MONTH(NgaySinh) = MONTH(GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[KhachHang_FindCountries]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachHang_FindCountries] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT QuocGia FROM KhachHang ORDER BY QuocGia
END
GO
/****** Object:  StoredProcedure [dbo].[KhachHang_FindCities]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachHang_FindCities] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT ThanhPho FROM KhachHang ORDER BY ThanhPho
END
GO
/****** Object:  StoredProcedure [dbo].[KhachHang_FindByName]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachHang_FindByName] 
	@Ten nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM KhachHang WHERE Ten LIKE '%' + @Ten + '%' ORDER BY Ten
END
GO
/****** Object:  StoredProcedure [dbo].[KhachSan_All]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachSan_All]
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM KhachSan
END
GO
/****** Object:  StoredProcedure [dbo].[KhachSan_Add]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachSan_Add]
	@ID int output,
	@TenKS nvarchar(50),
	@SoSao real,
	@DiaChi nvarchar(150),
	@SoDienThoai nvarchar(24)
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO KhachSan(TenKS, SoSao, DiaChi, SoDienThoai)
	VALUES(@TenKS, @SoSao, @DiaChi, @SoDienThoai)
	SET @ID = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[KhachHang_All]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachHang_All]
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM KhachHang
END
GO
/****** Object:  StoredProcedure [dbo].[KhachHang_Add]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachHang_Add] 
	@MaKH nchar(7),
	@Ho nvarchar(20),
	@Ten nvarchar(50),
	@NgaySinh datetime,
	@GTinh Bit,
	@SoDT nvarchar(24),
	@SoTaiKhoan nvarchar(30),
	@DiaChi nvarchar(150),
	@ThanhPho nvarchar(30),
	@QuocGia nvarchar(24)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM KhachHang WHERE ID = @MaKH)
	BEGIN
		INSERT INTO KhachHang (ID, Ho, Ten, NgaySinh, GTinh, SoDT, SoTaiKhoan, DiaChi, ThanhPho, QuocGia)
		VALUES (@MaKH, @Ho, @Ten, @NgaySinh, @GTinh, @SoDT, @SoTaiKhoan, @DiaChi, @ThanhPho, @QuocGia)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[KhachSan_Update]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachSan_Update]
	@ID int,
	@TenKS nvarchar(50),
	@SoSao real,
	@DiaChi nvarchar(150),
	@SoDienThoai nvarchar(24)
AS
BEGIN
    -- Insert statements for procedure here
	UPDATE KhachSan
	SET TenKS = @TenKS, SoSao = @SoSao, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[KhachSan_Single]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachSan_Single]
	@ID int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM KhachSan
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[KhachSan_SearchKey]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachSan_SearchKey]
	@Key nvarchar(150)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM KhachSan WHERE ID LIKE @Key OR TenKS LIKE @Key OR SoSao LIKE @Key OR DiaChi LIKE @Key OR SoDienThoai LIKE @Key
END
GO
/****** Object:  StoredProcedure [dbo].[Login_Update]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Login_Update]
	@Powers nvarchar(50),
	@User nvarchar(100),
	@Pass nvarchar(100)	
AS
	IF (NOT EXISTS (SELECT * FROM [Login] WHERE [User] = @User))
	BEGIN
		UPDATE [Login]
		SET Pass = @Pass, Powers = @Powers
		WHERE [User] = @User
	END
GO
/****** Object:  StoredProcedure [dbo].[Login_Single]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Login_Single]
	@User nvarchar(100)
AS
BEGIN
	SELECT * FROM [Login] WHERE [User] = @User
END
GO
/****** Object:  StoredProcedure [dbo].[Login_Log]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Login_Log]
	@Powers nvarchar(50),
	@User nvarchar(100),
	@Pass nvarchar(100)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Login WHERE [User] = @User AND Pass = @Pass
END
GO
/****** Object:  StoredProcedure [dbo].[Login_Delete]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Login_Delete]
	@User nvarchar(100)
AS
BEGIN
	IF EXISTS (SELECT * FROM [Login] WHERE Powers = 'Administrator' AND [User] <> @User)
	BEGIN
		DELETE FROM [Login] WHERE [User] = @User
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Login_All]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Login_All]
AS
BEGIN
	SELECT * FROM [Login]
END
GO
/****** Object:  StoredProcedure [dbo].[Login_Add]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Login_Add]
	@Powers nvarchar(50),
	@User nvarchar(100),
	@Pass nvarchar(100)	
AS
	IF (NOT EXISTS (SELECT * FROM [Login] WHERE [User] = @User))
	BEGIN
		INSERT INTO [Login]([User], Pass, Powers)
		VALUES(@User, @Pass, @Powers)
	END
GO
/****** Object:  StoredProcedure [dbo].[NCCPTien_FindByTenNCC]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date ,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NCCPTien_FindByTenNCC]
	@TenNCC nvarchar(50)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM NCCPTien WHERE TenNCC LIKE '%' + @TenNCC + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[NCCPTien_FindByKeyWord]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date ,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NCCPTien_FindByKeyWord]
	@Key nvarchar(50)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM NCCPTien WHERE ID LIKE '%' + @Key + '%' OR TenNCC LIKE '%' + @Key + '%' OR DiaChi LIKE '%' + @Key + '%' OR DienThoai LIKE '%' + @Key + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[NCCPTien_All]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NCCPTien_All]
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM NCCPTien
END
GO
/****** Object:  StoredProcedure [dbo].[NCCPTien_Add]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date ,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NCCPTien_Add]
	@MaSo int output,
	@TenNCC nvarchar(50),
	@DiaChi nvarchar(150),
	@DienThoai nvarchar(24)
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO NCCPTien(TenNCC, DiaChi, DienThoai)
	VALUES (@TenNCC, @DiaChi, @DienThoai)
END
GO
/****** Object:  StoredProcedure [dbo].[KhachSan_FindByTenKS]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachSan_FindByTenKS]
	@TenKS nvarchar(50)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM KhachSan WHERE TenKS LIKE '%' + @TenKS + '%' ORDER BY TenKS
END
GO
/****** Object:  StoredProcedure [dbo].[KhachSan_FindByName]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachSan_FindByName]
	@TenKS nvarchar(50),
	@DiaChi nvarchar(150)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM KhachSan WHERE TenKS = @TenKS AND DiaChi = @DiaChi
END
GO
/****** Object:  StoredProcedure [dbo].[NCCPTien_Update]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date ,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NCCPTien_Update]
	@MaSo int,
	@TenNCC nvarchar(50),
	@DiaChi nvarchar(150),
	@DienThoai nvarchar(24)
AS
BEGIN
    -- Insert statements for procedure here
	UPDATE NCCPTien 
	SET TenNCC = @TenNCC, DiaChi = @DiaChi, DienThoai = @DienThoai
	WHERE ID = @MaSo
END
GO
/****** Object:  StoredProcedure [dbo].[NCCPTien_Single]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date ,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NCCPTien_Single]
	@MaSo int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM NCCPTien 
	WHERE ID = @MaSo
END
GO
/****** Object:  Table [dbo].[PTien]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PTien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenPT] [nvarchar](25) NOT NULL,
	[TienNghi] [nvarchar](100) NULL,
	[SoChoToiDa] [int] NOT NULL,
	[SoChoToiThieu] [int] NOT NULL,
	[NhaCungCap] [int] NOT NULL,
 CONSTRAINT [PK_PTien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PTien] ON
INSERT [dbo].[PTien] ([ID], [TenPT], [TienNghi], [SoChoToiDa], [SoChoToiThieu], [NhaCungCap]) VALUES (1, N'Máy bay: A380', N'5 Sao', 853, 1, 1)
INSERT [dbo].[PTien] ([ID], [TenPT], [TienNghi], [SoChoToiDa], [SoChoToiThieu], [NhaCungCap]) VALUES (2, N'Máy bay: A737', N'2 - 3 Sao', 340, 1, 1)
INSERT [dbo].[PTien] ([ID], [TenPT], [TienNghi], [SoChoToiDa], [SoChoToiThieu], [NhaCungCap]) VALUES (3, N'May bay boeing 767-300ER', N'2-3 Sao', 351, 1, 3)
INSERT [dbo].[PTien] ([ID], [TenPT], [TienNghi], [SoChoToiDa], [SoChoToiThieu], [NhaCungCap]) VALUES (8, N'Máy bay boeing 767-250ER', N'1-2 Sao', 259, 1, 1)
INSERT [dbo].[PTien] ([ID], [TenPT], [TienNghi], [SoChoToiDa], [SoChoToiThieu], [NhaCungCap]) VALUES (10, N'Ô tô 16 chỗ ford', N'Máy lạnh-Toilet', 16, 15, 1)
INSERT [dbo].[PTien] ([ID], [TenPT], [TienNghi], [SoChoToiDa], [SoChoToiThieu], [NhaCungCap]) VALUES (11, N'Ô tô ford 46 chỗ', N'Máy lạnh', 46, 45, 1)
INSERT [dbo].[PTien] ([ID], [TenPT], [TienNghi], [SoChoToiDa], [SoChoToiThieu], [NhaCungCap]) VALUES (12, N'Máy bay 525', N'1 Sao', 150, 1, 1)
INSERT [dbo].[PTien] ([ID], [TenPT], [TienNghi], [SoChoToiDa], [SoChoToiThieu], [NhaCungCap]) VALUES (14, N'Máy bay Boeing 737', N'4 Sao', 165, 1, 4)
INSERT [dbo].[PTien] ([ID], [TenPT], [TienNghi], [SoChoToiDa], [SoChoToiThieu], [NhaCungCap]) VALUES (15, N'Máy bay boeng 737', N'2 sao', 170, 120, 2)
SET IDENTITY_INSERT [dbo].[PTien] OFF
/****** Object:  StoredProcedure [dbo].[Tour_All]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tour_All]
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM Tour
END
GO
/****** Object:  StoredProcedure [dbo].[Tour_Add]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tour_Add]
	@ID int output,
	@TenTour nvarchar(100),
	@XuatPhat nvarchar(100),
	@TrangThai nvarchar(30)
AS
BEGIN
    -- Insert statements for procedure here
	IF NOT EXISTS (SELECT * FROM Tour WHERE TenTour = @TenTour)
	BEGIN 
		INSERT INTO Tour (TenTour, XuatPhat, TrangThai)
		VALUES (@TenTour, @XuatPhat, @TrangThai)
		SET @ID = SCOPE_IDENTITY();
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Tour_FindByName]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tour_FindByName]
	@TenTour nvarchar(100)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM Tour WHERE TenTour = @TenTour
END
GO
/****** Object:  StoredProcedure [dbo].[Tour_Update]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tour_Update]
	@ID int,
	@TenTour nvarchar(100),
	@XuatPhat nvarchar(100),
	@TrangThai nvarchar(30)
AS
BEGIN
    -- Insert statements for procedure here
	UPDATE Tour
	SET TenTour = @TenTour, XuatPhat = @XuatPhat, TrangThai = @TrangThai
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[Tour_StatusAll]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tour_StatusAll]
AS
BEGIN
    -- Insert statements for procedure here
	SELECT DISTINCT TrangThai FROM Tour
END
GO
/****** Object:  StoredProcedure [dbo].[Tour_Single]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tour_Single]
	@MaTour int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM Tour WHERE ID = @MaTour
END
GO
/****** Object:  StoredProcedure [dbo].[Tour_SearchByKey]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date 28,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tour_SearchByKey]
	@Key nvarchar(100)
AS
BEGIN
    -- Insert statements for procedure here
	IF Len(@Key) <= 100
	BEGIN
		SELECT * FROM Tour WHERE ID LIKE @Key OR TenTour LIKE @Key OR XuatPhat LIKE @Key OR TrangThai LIKE @Key
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Tour_FindStatus]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tour_FindStatus]
	@TrangThai nvarchar(30)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM Tour WHERE TrangThai = @TrangThai
END
GO
/****** Object:  View [dbo].[View_Chuyen_Tour]    Script Date: 02/27/2013 22:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Chuyen_Tour]
AS
SELECT     dbo.Tour.TenTour, dbo.Chuyen.MChuyen, dbo.Chuyen.MTour, dbo.Chuyen.NgayDi, dbo.Chuyen.NgayVe, dbo.Chuyen.Gia, dbo.Chuyen.TrangThai, 
                      dbo.Tour.XuatPhat
FROM         dbo.Chuyen INNER JOIN
                      dbo.Tour ON dbo.Chuyen.MTour = dbo.Tour.ID
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
         Begin Table = "Chuyen"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tour"
            Begin Extent = 
               Top = 18
               Left = 533
               Bottom = 137
               Right = 693
            End
            DisplayFlags = 280
            TopColumn = 0
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Chuyen_Tour'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Chuyen_Tour'
GO
/****** Object:  StoredProcedure [dbo].[PTien_Update]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date ,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PTien_Update]
	@MaPT int,
	@TenPT nvarchar(25),
	@TienNghi nvarchar(100),
	@SoChoToiDa int,
	@SoChoToiThieu int,
	@NhaCungCap int
AS
BEGIN
    -- Insert statements for procedure here
	UPDATE PTien 
	SET TenPT = @TenPT,
		TienNghi = @TienNghi,
		SoChoToiDa = @SoChoToiDa,
		SoChoToiThieu = @SoChoToiThieu,
		NhaCungCap = @NhaCungCap
	WHERE ID = @MaPT
END
GO
/****** Object:  Table [dbo].[PhanCongHDV]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCongHDV](
	[MChuyen] [int] NOT NULL,
	[MHDV] [nchar](7) NOT NULL,
	[MTour] [int] NOT NULL,
 CONSTRAINT [PK_PhanCongHDV] PRIMARY KEY CLUSTERED 
(
	[MChuyen] ASC,
	[MHDV] ASC,
	[MTour] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (5, N'HDV0002', 16)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (5, N'HDV0003', 16)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (6, N'HDV0002', 8)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (7, N'HDV0000', 10)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (7, N'HDV0001', 10)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (7, N'HDV0002', 10)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (9, N'HDV0001', 8)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (10, N'HDV0002', 8)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (11, N'HDV0002', 10)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (12, N'HDV0000', 10)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (12, N'HDV0002', 10)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (14, N'HDV0000', 10)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (18, N'HDV0005', 8)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (19, N'HDV0004', 8)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (20, N'HDV0006', 20)
INSERT [dbo].[PhanCongHDV] ([MChuyen], [MHDV], [MTour]) VALUES (20, N'HDV0007', 20)
/****** Object:  StoredProcedure [dbo].[PTien_FindByTen_NCC]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PTien_FindByTen_NCC]
	@TenPT nvarchar(25),
	@NhaCungCap int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM PTien WHERE TenPT = @TenPT AND NhaCungCap = @NhaCungCap
END
GO
/****** Object:  StoredProcedure [dbo].[PTien_FindByTienNghi]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date 27,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PTien_FindByTienNghi]
	@TienNghi nvarchar(100)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM PTien WHERE TienNghi LIKE '%' + @TienNghi + '%' ORDER BY TienNghi
END
GO
/****** Object:  StoredProcedure [dbo].[PTien_Add]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PTien_Add]
	@ID int output,
	@TenPT nvarchar(25),
	@TienNghi nvarchar(100),
	@SoChoToiDa int,
	@SoChoToiThieu int,
	@NhaCungCap int
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO PTien(TenPT, TienNghi, SoChoToiDa, SoChoToiThieu, NhaCungCap)
	VALUES (@TenPT, @TienNghi, @SoChoToiDa, @SoChoToiThieu, @NhaCungCap)
	SET @ID = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[PTien_FindByMaNCC]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PTien_FindByMaNCC]
	@NhaCungCap int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM PTien WHERE NhaCungCap = @NhaCungCap
END
GO
/****** Object:  StoredProcedure [dbo].[PTien_Delete]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date ,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PTien_Delete]
	@MaPT int
AS
BEGIN
    -- Insert statements for procedure here
	DELETE FROM PTien 
	WHERE ID = @MaPT
END
GO
/****** Object:  StoredProcedure [dbo].[NCCPTien_FindByVehicleCode]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date ,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NCCPTien_FindByVehicleCode]
	@MaPt int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM NCCPTien WHERE ID IN (SELECT NhaCungCap FROM PTien WHERE ID = @MaPt)
END
GO
/****** Object:  Table [dbo].[KSanDLich]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KSanDLich](
	[MKS] [int] NOT NULL,
	[MDiemDL] [int] NOT NULL,
 CONSTRAINT [PK_KSanDLich] PRIMARY KEY CLUSTERED 
(
	[MKS] ASC,
	[MDiemDL] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (2, 2)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (2, 4)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (2, 6)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (2, 8)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (3, 8)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (4, 5)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (5, 5)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (5, 8)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (5, 11)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (5, 12)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (5, 13)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (5, 14)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (5, 15)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (6, 4)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (6, 5)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (6, 8)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (6, 14)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (6, 16)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (7, 12)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (8, 1)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (8, 11)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (9, 10)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (11, 5)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (11, 8)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (11, 9)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (12, 4)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (12, 7)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (12, 8)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (12, 11)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (13, 3)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (13, 5)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (13, 6)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (13, 7)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (14, 2)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (14, 6)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (14, 10)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (22, 2)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (22, 4)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (22, 7)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (23, 3)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (23, 4)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (23, 5)
INSERT [dbo].[KSanDLich] ([MKS], [MDiemDL]) VALUES (24, 19)
/****** Object:  StoredProcedure [dbo].[HDV_Tour_NotFindByMHDV]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,22/04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_Tour_NotFindByMHDV]
	@MHDV nchar(7)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM Tour WHERE Tour.ID NOT IN (SELECT MTour FROM HDV_Tour WHERE HDV_Tour.MHDV = @MHDV)
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_Tour_FindByMHDV]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,22/04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_Tour_FindByMHDV]
	@MHDV nchar(7)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM Tour WHERE Tour.ID IN (SELECT MTour FROM HDV_Tour WHERE HDV_Tour.MHDV = @MHDV)
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_Tour_Add]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,22/04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_Tour_Add]
	@MHDV nchar(7),
	@MTour int
AS
BEGIN
    -- Insert statements for procedure here
	IF NOT EXISTS (SELECT * FROM HDV_Tour WHERE MHDV = @MHDV AND MTour = @MTour)
	BEGIN
		INSERT INTO HDV_Tour(MHDV, MTour)
		VALUES(@MHDV, @MTour)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DiemDL_Add]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyen>
-- Create date: <Create Date,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiemDL_Add]
	@ID int output,
	@TenDiem nvarchar(50),
	@MaDD int,
	@DiaChi nvarchar(150)
AS
BEGIN
	INSERT INTO DiemDL(TenDiem, MaDD, DiaChi)
	VALUES(@TenDiem, @MaDD, @DiaChi)
	SET @ID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[Chuyen_Add]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 26,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Chuyen_Add] 
	@MChuyen int output,
	@MTour int,
	@NgayDi datetime,
	@NgayVe datetime,
	@Gia real,
	@TrangThai smallint
AS
BEGIN
	INSERT INTO Chuyen(MTour, NgayDi, NgayVe, Gia, TrangThai)
	VALUES(@MTour, @NgayDi, @NgayVe, @Gia, @TrangThai)
	SET @MChuyen = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[DiemDL_Update]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyen>
-- Create date: <Create Date,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiemDL_Update]
	@ID int,
	@TenDiem nvarchar(50),
	@MaDD int,
	@DiaChi nvarchar(150)
AS
BEGIN
	UPDATE DiemDL
	SET TenDiem = @TenDiem, MaDD = @MaDD, DiaChi = @DiaChi
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DiemDL_Single]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyen>
-- Create date: <Create Date,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiemDL_Single]
	@ID int
AS
BEGIN
	SELECT * FROM DiemDL WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DiemDL_FindByTenD_MaDD]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyen>
-- Create date: <Create Date,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiemDL_FindByTenD_MaDD]
	@TenDiem nvarchar(50),
	@MaDD int
AS
BEGIN
	SELECT * FROM DiemDL WHERE TenDiem = @TenDiem AND MaDD = @MaDD
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_FindByMTour]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_FindByMTour]
	-- Add the parameters for the stored procedure here
	@MTour int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
    -- Insert statements for procedure here
	SELECT * FROM HDV WHERE ID IN (SELECT MHDV FROM HDV_Tour WHERE MTour = @MTour)
END
GO
/****** Object:  Table [dbo].[DatCho]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatCho](
	[MChuyen] [int] NOT NULL,
	[MKHang] [nchar](7) NOT NULL,
 CONSTRAINT [PK_DatCho] PRIMARY KEY CLUSTERED 
(
	[MChuyen] ASC,
	[MKHang] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DatCho] ([MChuyen], [MKHang]) VALUES (5, N'KH00005')
INSERT [dbo].[DatCho] ([MChuyen], [MKHang]) VALUES (11, N'KH00010')
INSERT [dbo].[DatCho] ([MChuyen], [MKHang]) VALUES (11, N'KH00014')
/****** Object:  StoredProcedure [dbo].[Chuyen_Update]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 26,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Chuyen_Update] 
	@MChuyen int,
	@MTour int,
	@NgayDi datetime,
	@NgayVe datetime,
	@Gia real,
	@TrangThai smallint
AS
BEGIN
	UPDATE Chuyen
	SET MTour = @MTour, NgayDi = @NgayDi, NgayVe = @NgayVe, Gia = @Gia, TrangThai = @TrangThai
	WHERE MChuyen = @MChuyen
END
GO
/****** Object:  View [dbo].[View_DiemDL]    Script Date: 02/27/2013 22:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_DiemDL]
AS
SELECT     dbo.DiemDL.*, dbo.DiaDiem.TenDD
FROM         dbo.DiaDiem INNER JOIN
                      dbo.DiemDL ON dbo.DiaDiem.ID = dbo.DiemDL.MaDD
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
         Begin Table = "DiaDiem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 110
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DiemDL"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 125
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DiemDL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DiemDL'
GO
/****** Object:  View [dbo].[View_PhuongTien]    Script Date: 02/27/2013 22:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_PhuongTien]
AS
SELECT     dbo.NCCPTien.TenNCC, dbo.PTien.*
FROM         dbo.NCCPTien INNER JOIN
                      dbo.PTien ON dbo.NCCPTien.ID = dbo.PTien.NhaCungCap
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
         Begin Table = "NCCPTien"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PTien"
            Begin Extent = 
               Top = 9
               Left = 455
               Bottom = 128
               Right = 615
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_PhuongTien'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_PhuongTien'
GO
/****** Object:  StoredProcedure [dbo].[View_DiemDL_Search]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[View_DiemDL_Search]
	@Word nvarchar(150)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_DiemDL WHERE ID LIKE '%' + @Word + '%'
	OR TenDiem LIKE '%' + @Word + '%' OR DiaChi LIKE '%' + @Word + '%' OR TenDD LIKE '%' + @Word + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[DatCho_DeleteByMKHang]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,02/05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DatCho_DeleteByMKHang]
	@MKHang nchar(7)
AS
BEGIN
	DELETE FROM DatCho WHERE MKHang = @MKHang
END
GO
/****** Object:  StoredProcedure [dbo].[DatCho_Delete]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,02/05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DatCho_Delete]
	@MChuyen int,
	@MKHang nchar(7)
AS
BEGIN
		DELETE DatCho WHERE MChuyen = @MChuyen AND MKHang = @MKHang
END
GO
/****** Object:  StoredProcedure [dbo].[DatCho_All]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,02/05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DatCho_All]
AS
BEGIN
	SELECT * FROM DatCho
END
GO
/****** Object:  StoredProcedure [dbo].[DatCho_Add]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,02/05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DatCho_Add]
	@MChuyen int,
	@MKHang nchar(7)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM DatCho WHERE MChuyen = @MChuyen AND MKHang = @MKHang)
	INSERT INTO DatCho (MChuyen, MKHang) VALUES (@MChuyen, @MKHang)	
END
GO
/****** Object:  StoredProcedure [dbo].[Chuyen_Single]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 26,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Chuyen_Single] 
	@MChuyen int
AS
BEGIN
	SELECT * FROM View_Chuyen_Tour WHERE MChuyen = @MChuyen
END
GO
/****** Object:  StoredProcedure [dbo].[Chuyen_FindByStatus]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 26,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Chuyen_FindByStatus] 
	@TrangThai smallint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM View_Chuyen_Tour WHERE TrangThai = @TrangThai
END
GO
/****** Object:  StoredProcedure [dbo].[Chuyen_FindByNameTour]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 26,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Chuyen_FindByNameTour] 
	@TenTour nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM View_Chuyen_Tour WHERE TenTour LIKE '%' + @TenTour + '%' ORDER BY TenTour
END
GO
/****** Object:  StoredProcedure [dbo].[Chuyen_FindByMTour]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 26,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Chuyen_FindByMTour] 
	@MTour int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM View_Chuyen_Tour WHERE MTour = @MTour
END
GO
/****** Object:  StoredProcedure [dbo].[Chuyen_FindByMaKH]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Chuyen_FindByMaKH] 
	@MKHang nchar(7)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM View_Chuyen_Tour WHERE MChuyen IN (SELECT MChuyen FROM DatCho WHERE MKHang = @MKHang)
END
GO
/****** Object:  StoredProcedure [dbo].[Chuyen_FindByHDVien]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 26,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Chuyen_FindByHDVien] 
	@MHDV nchar(7)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM View_Chuyen_Tour WHERE MChuyen IN (SELECT MChuyen FROM PhanCongHDV WHERE MHDV = @MHDV)
END
GO
/****** Object:  StoredProcedure [dbo].[Chuyen_FindByGia]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Chuyen_FindByGia] 
	@Gia real
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM View_Chuyen_Tour WHERE Gia <= @Gia ORDER BY Gia
END
GO
/****** Object:  StoredProcedure [dbo].[Chuyen_Delete]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 26,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Chuyen_Delete] 
	@MChuyen int
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Chuyen WHERE MChuyen = @MChuyen AND TrangThai = 1)
	BEGIN 
		DELETE FROM DatCho WHERE MChuyen = @MChuyen
		DELETE FROM PhanCongHDV WHERE MChuyen = @MChuyen
		DELETE FROM Chuyen WHERE MChuyen = @MChuyen
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Chuyen_All]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 26,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Chuyen_All] 
AS
BEGIN
	SELECT * FROM View_Chuyen_Tour
END
GO
/****** Object:  Table [dbo].[DiemDen]    Script Date: 02/27/2013 22:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemDen](
	[MTour] [int] NOT NULL,
	[MDiemDL] [int] NOT NULL,
	[MaKS] [int] NOT NULL,
	[MaPT] [int] NOT NULL,
 CONSTRAINT [PK_DiemDen] PRIMARY KEY CLUSTERED 
(
	[MTour] ASC,
	[MDiemDL] ASC,
	[MaKS] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DiemDen] ([MTour], [MDiemDL], [MaKS], [MaPT]) VALUES (8, 2, 14, 8)
INSERT [dbo].[DiemDen] ([MTour], [MDiemDL], [MaKS], [MaPT]) VALUES (8, 3, 13, 8)
INSERT [dbo].[DiemDen] ([MTour], [MDiemDL], [MaKS], [MaPT]) VALUES (8, 5, 13, 8)
INSERT [dbo].[DiemDen] ([MTour], [MDiemDL], [MaKS], [MaPT]) VALUES (10, 2, 2, 8)
INSERT [dbo].[DiemDen] ([MTour], [MDiemDL], [MaKS], [MaPT]) VALUES (10, 5, 13, 10)
INSERT [dbo].[DiemDen] ([MTour], [MDiemDL], [MaKS], [MaPT]) VALUES (10, 7, 12, 8)
INSERT [dbo].[DiemDen] ([MTour], [MDiemDL], [MaKS], [MaPT]) VALUES (13, 2, 2, 8)
INSERT [dbo].[DiemDen] ([MTour], [MDiemDL], [MaKS], [MaPT]) VALUES (13, 3, 13, 2)
INSERT [dbo].[DiemDen] ([MTour], [MDiemDL], [MaKS], [MaPT]) VALUES (16, 5, 4, 3)
INSERT [dbo].[DiemDen] ([MTour], [MDiemDL], [MaKS], [MaPT]) VALUES (20, 19, 24, 11)
/****** Object:  StoredProcedure [dbo].[HDV_FindByMChuyen]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_FindByMChuyen]
	@MChuyen int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM HDV WHERE ID IN (SELECT MHDV FROM PhanCongHDV WHERE MChuyen = @MChuyen)
END
GO
/****** Object:  StoredProcedure [dbo].[DiemDL_FindByNotMaKS]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiemDL_FindByNotMaKS]
	@MKS int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_DiemDL WHERE ID NOT IN (SELECT MDiemDL FROM KSanDLich WHERE MKS = @MKS)
END
GO
/****** Object:  StoredProcedure [dbo].[DiemDL_FindByName]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiemDL_FindByName]
	@TenDiem nvarchar(50)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_DiemDL WHERE TenDiem LIKE '%' + @TenDiem + '%' ORDER BY TenDiem
END
GO
/****** Object:  StoredProcedure [dbo].[KhachHang_Delete]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachHang_Delete] 
	@MaKH nchar(7)
AS
BEGIN
	IF NOT EXISTS (SELECT MChuyen FROM Chuyen WHERE TrangThai = 1 and MChuyen IN (SELECT MChuyen FROM Datcho WHERE MKHang = @MaKH))
	BEGIN
		DELETE FROM DatCho WHERE MKHang = @MaKH
		DELETE FROM KhachHang WHERE ID = @MaKH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[HDV_FindBy_MTour_NotBusy]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_FindBy_MTour_NotBusy]
	-- Add the parameters for the stored procedure here
	@MTour int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
    -- Insert statements for procedure here
	SELECT * FROM HDV WHERE TrangThai = 1 AND ID IN (SELECT MHDV FROM HDV_Tour WHERE MTour = @MTour) AND ID NOT IN
	(SELECT ID FROM HDV WHERE ID IN 
		(SELECT MHDV FROM PhanCongHDV WHERE MChuyen IN (SELECT MChuyen FROM Chuyen WHERE TrangThai >= 1 )))
	

END
GO
/****** Object:  StoredProcedure [dbo].[HDV_Delete]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HDV_Delete]
	@MHDV nchar(7)
AS
BEGIN
    -- Insert statements for procedure here
	DELETE FROM PhanCongHDV
	WHERE MHDV = @MHDV
	DELETE FROM HDV_Tour
	WHERE MHDV = @MHDV
	DELETE FROM HDV
	WHERE ID = @MHDV
END
GO
/****** Object:  StoredProcedure [dbo].[DiemDL_FindByMaKS]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiemDL_FindByMaKS]
	@MKS int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_DiemDL WHERE ID IN (SELECT MDiemDL FROM KSanDLich WHERE MKS = @MKS)
END
GO
/****** Object:  StoredProcedure [dbo].[DiemDL_FindByMaDD]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiemDL_FindByMaDD]
	@MaDD int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_DiemDL WHERE MaDD = @MaDD
END
GO
/****** Object:  StoredProcedure [dbo].[DiemDL_All]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiemDL_All]
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_DiemDL
END
GO
/****** Object:  StoredProcedure [dbo].[KhachSan_FindMDiemDL]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachSan_FindMDiemDL]
	@MDiemDL int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM KhachSan WHERE ID IN (SELECT MKS FROM KSanDLich WHERE MDiemDL = @MDiemDL)
END
GO
/****** Object:  StoredProcedure [dbo].[KhachHang_FindByMChuyen]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 01,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachHang_FindByMChuyen] 
	@MChuyen int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM KhachHang WHERE ID IN (SELECT MKHang FROM DatCho WHERE MChuyen = @MChuyen)
END
GO
/****** Object:  StoredProcedure [dbo].[KSanDLich_FindByMKS]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KSanDLich_FindByMKS]
	@MKS int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM KSanDLich WHERE MKS = @MKS
END
GO
/****** Object:  StoredProcedure [dbo].[KSanDLich_Delete]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KSanDLich_Delete]
	@MKS int,
	@MDiemDL int
AS
BEGIN
    -- Insert statements for procedure here
	DELETE FROM KSanDLich WHERE MKS = @MKS AND MDiemDL = @MDiemDL
END
GO
/****** Object:  StoredProcedure [dbo].[KSanDLich_Add]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KSanDLich_Add]
	@MKS int,
	@MDiemDL int
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO KSanDLich(MKS, MDiemDL)
	VALUES(@MKS, @MDiemDL)
END
GO
/****** Object:  StoredProcedure [dbo].[PhanCongHDV_FindByMHDV]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Kim,Nguyen>
-- Create date: <Create Date 24,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PhanCongHDV_FindByMHDV] 
	-- Add the parameters for the stored procedure here
	@MHDV nchar(7)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- Insert statements for procedure here
	SELECT * FROM PhanCongHDV WHERE MHDV = @MHDV
END
GO
/****** Object:  StoredProcedure [dbo].[PhanCongHDV_DeleteByMHDV]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Kim,Nguyen>
-- Create date: <Create Date 24,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PhanCongHDV_DeleteByMHDV] 
	-- Add the parameters for the stored procedure here
	@MHDV nchar(7)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- Insert statements for procedure here
	DELETE FROM PhanCongHDV
	WHERE MHDV = @MHDV
END
GO
/****** Object:  StoredProcedure [dbo].[PhanCongHDV_DeleteByMChuyen]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Kim,Nguyen>
-- Create date: <Create Date 24,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PhanCongHDV_DeleteByMChuyen] 
	-- Add the parameters for the stored procedure here
	@MChuyen int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- Insert statements for procedure here
	DELETE FROM PhanCongHDV
	WHERE MChuyen = @MChuyen
END
GO
/****** Object:  StoredProcedure [dbo].[PhanCongHDV_Delete]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Kim,Nguyen>
-- Create date: <Create Date 24,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PhanCongHDV_Delete] 
	-- Add the parameters for the stored procedure here
	@MChuyen int,
	@MHDV nchar(7),
	@MTour int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- Insert statements for procedure here
	DELETE FROM PhanCongHDV WHERE MChuyen = @MChuyen AND MHDV = @MHDV AND MTour = @MTour
END
GO
/****** Object:  StoredProcedure [dbo].[PhanCongHDV_Add]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Kim,Nguyen>
-- Create date: <Create Date 24,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PhanCongHDV_Add] 
	-- Add the parameters for the stored procedure here
	@MChuyen int,
	@MHDV nchar(7),
	@MTour int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- Insert statements for procedure here
	INSERT INTO PhanCongHDV(MChuyen, MHDV, MTour)
	VALUES (@MChuyen, @MHDV, @MTour)
END
GO
/****** Object:  StoredProcedure [dbo].[PTien_All]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PTien_All]
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_PhuongTien
END
GO
/****** Object:  StoredProcedure [dbo].[KhachSan_Delete]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachSan_Delete]
	@ID int
AS
BEGIN
    -- Insert statements for procedure here
	DELETE KSanDLich WHERE MKS = @ID
	DELETE KhachSan
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[PTien_FindByTenPT]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PTien_FindByTenPT]
	@TenPT nvarchar(25)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_PhuongTien WHERE TenPT LIKE '%' + @TenPT + '%' ORDER BY TenPT
END
GO
/****** Object:  StoredProcedure [dbo].[PTien_SoChoTD_TT]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date 27,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PTien_SoChoTD_TT]
	@SoChoToiDa int,
	@SoChoToiThieu int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_PhuongTien WHERE SoChoToiDa <= @SoChoToiDa AND SoChoToiThieu >= @SoChoToiThieu ORDER BY SoChoToiDa
END
GO
/****** Object:  StoredProcedure [dbo].[PTien_SearchKey]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date 27,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PTien_SearchKey]
	@Key nvarchar(100)
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_PhuongTien 
	WHERE ID LIKE '%' + @Key + '%' OR TenPT LIKE '%' + @Key + '%'
	OR TienNghi LIKE '%' + @Key + '%' OR SoChoToiDa LIKE '%' + @Key + '%'
	OR SoChoToiThieu LIKE '%' + @Key + '%' OR TenNCC LIKE '%' + @Key + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[PTien_FindMaPT]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date ,,27/04/2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PTien_FindMaPT]
	@MaPT int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_PhuongTien WHERE ID = @MaPT
END
GO
/****** Object:  StoredProcedure [dbo].[Tour_FindMDiemDL]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date 28,05,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tour_FindMDiemDL]
	@MDiemDL int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM Tour WHERE ID IN (SELECT MTour FROM DiemDen WHERE MDiemDL = @MDiemDL)
END
GO
/****** Object:  StoredProcedure [dbo].[Tour_FindByVehicleCode]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tour_FindByVehicleCode]
	@MaPT int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM Tour WHERE ID IN (SELECT MTour FROM DiemDen WHERE MaPT = @MaPT)
END
GO
/****** Object:  StoredProcedure [dbo].[Tour_FindByMKSan]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tour_FindByMKSan]
	@MaKS int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM Tour WHERE ID IN (SELECT MTour FROM DiemDen WHERE MaKS = @MaKS)
END
GO
/****** Object:  StoredProcedure [dbo].[Tour_Delete]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tour_Delete]
	@MTour int
AS
BEGIN
    -- Insert statements for procedure here
	IF NOT EXISTS(SELECT * FROM Chuyen WHERE MTour = @MTour AND TrangThai = 1)
	BEGIN
		DELETE FROM DiemDen WHERE MTour = @MTour
		DELETE FROM DatCho WHERE MChuyen IN (SELECT MChuyen FROM Chuyen WHERE MTour = @MTour)
		DELETE FROM PhanCongHDV WHERE MChuyen IN (SELECT MChuyen FROM Chuyen WHERE MTour = @MTour)
		DELETE FROM Chuyen WHERE MTour = @MTour
		DELETE FROM HDV_Tour WHERE MTour = @MTour
		DELETE FROM Tour WHERE ID = @MTour
	END
END
GO
/****** Object:  StoredProcedure [dbo].[PTien_FindByMTour]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PTien_FindByMTour]
	@MTour int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_PhuongTien WHERE ID IN (SELECT MaPT FROM DiemDen WHERE MTour = @MTour)
END
GO
/****** Object:  StoredProcedure [dbo].[KhachSan_FindByMTour]    Script Date: 02/27/2013 22:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KhachSan_FindByMTour]
	@MTour int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM KhachSan WHERE ID IN (SELECT MaKS FROM DiemDen WHERE MTour = @MTour)
END
GO
/****** Object:  StoredProcedure [dbo].[DiemDen_DeleteByMTour]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiemDen_DeleteByMTour]
	@MTour int
AS
BEGIN
    -- Insert statements for procedure here
	DELETE FROM DiemDen WHERE MTour = @MTour
END
GO
/****** Object:  StoredProcedure [dbo].[DiemDen_Add]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiemDen_Add]
	@MTour int,
	@MDiemDL int,
	@MaKS int,
	@MaPT int
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM DiemDen WHERE MTour = @MTour AND MDiemDL = @MDiemDL AND MaKS = @MaKS)
	BEGIN
		INSERT INTO DiemDen (MTour, MDiemDL, MaKS, MaPT)
		VALUES (@MTour, @MDiemDL, @MaKS, @MaPT)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DiemDL_FindByMTour]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiemDL_FindByMTour]
	@MTour int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_DiemDL WHERE ID IN (SELECT MDiemDL FROM DiemDen WHERE MTour = @MTour)
END
GO
/****** Object:  View [dbo].[View_DiemDen]    Script Date: 02/27/2013 22:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_DiemDen]
AS
SELECT     dbo.DiemDen.MTour, dbo.DiemDen.MDiemDL, dbo.DiemDen.MaKS, dbo.DiemDen.MaPT, dbo.PTien.TenPT, dbo.Tour.TenTour, dbo.NCCPTien.TenNCC, 
                      dbo.KhachSan.TenKS, dbo.DiemDL.TenDiem, dbo.DiaDiem.TenDD
FROM         dbo.DiemDen INNER JOIN
                      dbo.PTien ON dbo.DiemDen.MaPT = dbo.PTien.ID INNER JOIN
                      dbo.Tour ON dbo.DiemDen.MTour = dbo.Tour.ID INNER JOIN
                      dbo.NCCPTien ON dbo.PTien.NhaCungCap = dbo.NCCPTien.ID INNER JOIN
                      dbo.KSanDLich ON dbo.DiemDen.MaKS = dbo.KSanDLich.MKS AND dbo.DiemDen.MDiemDL = dbo.KSanDLich.MDiemDL INNER JOIN
                      dbo.KhachSan ON dbo.KSanDLich.MKS = dbo.KhachSan.ID INNER JOIN
                      dbo.DiemDL ON dbo.KSanDLich.MDiemDL = dbo.DiemDL.ID INNER JOIN
                      dbo.DiaDiem ON dbo.DiemDL.MaDD = dbo.DiaDiem.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[68] 4[6] 2[11] 3) )"
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
         Begin Table = "DiemDen"
            Begin Extent = 
               Top = 199
               Left = 0
               Bottom = 318
               Right = 160
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PTien"
            Begin Extent = 
               Top = 245
               Left = 552
               Bottom = 364
               Right = 712
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tour"
            Begin Extent = 
               Top = 0
               Left = 197
               Bottom = 119
               Right = 357
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "NCCPTien"
            Begin Extent = 
               Top = 244
               Left = 868
               Bottom = 363
               Right = 1028
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "KSanDLich"
            Begin Extent = 
               Top = 43
               Left = 424
               Bottom = 132
               Right = 584
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "KhachSan"
            Begin Extent = 
               Top = 7
               Left = 794
               Bottom = 126
               Right = 954
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DiemDL"
            Begin Extent = 
               Top = 126
               Left = 695
               Bottom = 245
               Right = 855
            End
            DisplayFlags = 280
 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DiemDen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'           TopColumn = 0
         End
         Begin Table = "DiaDiem"
            Begin Extent = 
               Top = 173
               Left = 1132
               Bottom = 277
               Right = 1292
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 11
         Width = 284
         Width = 1500
         Width = 1500
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DiemDen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DiemDen'
GO
/****** Object:  StoredProcedure [dbo].[View_DiemDen_FindByMaPT]    Script Date: 02/27/2013 22:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author Kim,,Nguyen>
-- Create date: <Create Date 26,04,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[View_DiemDen_FindByMaPT]
	@MaPT int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM View_DiemDen WHERE MaPT = @MaPT
END
GO
/****** Object:  StoredProcedure [dbo].[DiemDen_FindByMTour]    Script Date: 02/27/2013 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kim Nguyễn>
-- Create date: <Create Date,38/02,2012>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DiemDen_FindByMTour]
	@MTour int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM View_DiemDen WHERE MTour = @MTour
END
GO
/****** Object:  Check [CK_Login]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [CK_Login] CHECK  (([Powers]='Designer' OR [Powers]='Saler' OR [Powers]='User' OR [Powers]='Administrator'))
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [CK_Login]
GO
/****** Object:  ForeignKey [FK_Chuyen_Tour]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[Chuyen]  WITH CHECK ADD  CONSTRAINT [FK_Chuyen_Tour] FOREIGN KEY([MTour])
REFERENCES [dbo].[Tour] ([ID])
GO
ALTER TABLE [dbo].[Chuyen] CHECK CONSTRAINT [FK_Chuyen_Tour]
GO
/****** Object:  ForeignKey [FK_DatCho_Chuyen]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[DatCho]  WITH CHECK ADD  CONSTRAINT [FK_DatCho_Chuyen] FOREIGN KEY([MChuyen])
REFERENCES [dbo].[Chuyen] ([MChuyen])
GO
ALTER TABLE [dbo].[DatCho] CHECK CONSTRAINT [FK_DatCho_Chuyen]
GO
/****** Object:  ForeignKey [FK_DatCho_KhachHang]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[DatCho]  WITH CHECK ADD  CONSTRAINT [FK_DatCho_KhachHang] FOREIGN KEY([MKHang])
REFERENCES [dbo].[KhachHang] ([ID])
GO
ALTER TABLE [dbo].[DatCho] CHECK CONSTRAINT [FK_DatCho_KhachHang]
GO
/****** Object:  ForeignKey [FK_DiemDen_KSanDLich1]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[DiemDen]  WITH CHECK ADD  CONSTRAINT [FK_DiemDen_KSanDLich1] FOREIGN KEY([MaKS], [MDiemDL])
REFERENCES [dbo].[KSanDLich] ([MKS], [MDiemDL])
GO
ALTER TABLE [dbo].[DiemDen] CHECK CONSTRAINT [FK_DiemDen_KSanDLich1]
GO
/****** Object:  ForeignKey [FK_DiemDen_PTien]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[DiemDen]  WITH CHECK ADD  CONSTRAINT [FK_DiemDen_PTien] FOREIGN KEY([MaPT])
REFERENCES [dbo].[PTien] ([ID])
GO
ALTER TABLE [dbo].[DiemDen] CHECK CONSTRAINT [FK_DiemDen_PTien]
GO
/****** Object:  ForeignKey [FK_DiemDen_Tour]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[DiemDen]  WITH CHECK ADD  CONSTRAINT [FK_DiemDen_Tour] FOREIGN KEY([MTour])
REFERENCES [dbo].[Tour] ([ID])
GO
ALTER TABLE [dbo].[DiemDen] CHECK CONSTRAINT [FK_DiemDen_Tour]
GO
/****** Object:  ForeignKey [FK_DiemDL_DiaDiem]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[DiemDL]  WITH CHECK ADD  CONSTRAINT [FK_DiemDL_DiaDiem] FOREIGN KEY([MaDD])
REFERENCES [dbo].[DiaDiem] ([ID])
GO
ALTER TABLE [dbo].[DiemDL] CHECK CONSTRAINT [FK_DiemDL_DiaDiem]
GO
/****** Object:  ForeignKey [FK_HDV_Tour_HDV]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[HDV_Tour]  WITH CHECK ADD  CONSTRAINT [FK_HDV_Tour_HDV] FOREIGN KEY([MHDV])
REFERENCES [dbo].[HDV] ([ID])
GO
ALTER TABLE [dbo].[HDV_Tour] CHECK CONSTRAINT [FK_HDV_Tour_HDV]
GO
/****** Object:  ForeignKey [FK_HDV_Tour_Tour]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[HDV_Tour]  WITH CHECK ADD  CONSTRAINT [FK_HDV_Tour_Tour] FOREIGN KEY([MTour])
REFERENCES [dbo].[Tour] ([ID])
GO
ALTER TABLE [dbo].[HDV_Tour] CHECK CONSTRAINT [FK_HDV_Tour_Tour]
GO
/****** Object:  ForeignKey [FK_KSanDLich_DiemDL1]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[KSanDLich]  WITH CHECK ADD  CONSTRAINT [FK_KSanDLich_DiemDL1] FOREIGN KEY([MDiemDL])
REFERENCES [dbo].[DiemDL] ([ID])
GO
ALTER TABLE [dbo].[KSanDLich] CHECK CONSTRAINT [FK_KSanDLich_DiemDL1]
GO
/****** Object:  ForeignKey [FK_KSanDLich_KhachSan1]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[KSanDLich]  WITH CHECK ADD  CONSTRAINT [FK_KSanDLich_KhachSan1] FOREIGN KEY([MKS])
REFERENCES [dbo].[KhachSan] ([ID])
GO
ALTER TABLE [dbo].[KSanDLich] CHECK CONSTRAINT [FK_KSanDLich_KhachSan1]
GO
/****** Object:  ForeignKey [FK_PhanCongHDV_Chuyen]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[PhanCongHDV]  WITH CHECK ADD  CONSTRAINT [FK_PhanCongHDV_Chuyen] FOREIGN KEY([MChuyen])
REFERENCES [dbo].[Chuyen] ([MChuyen])
GO
ALTER TABLE [dbo].[PhanCongHDV] CHECK CONSTRAINT [FK_PhanCongHDV_Chuyen]
GO
/****** Object:  ForeignKey [FK_PhanCongHDV_HDV_Tour]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[PhanCongHDV]  WITH CHECK ADD  CONSTRAINT [FK_PhanCongHDV_HDV_Tour] FOREIGN KEY([MHDV], [MTour])
REFERENCES [dbo].[HDV_Tour] ([MHDV], [MTour])
GO
ALTER TABLE [dbo].[PhanCongHDV] CHECK CONSTRAINT [FK_PhanCongHDV_HDV_Tour]
GO
/****** Object:  ForeignKey [FK_PTien_NCCPTien]    Script Date: 02/27/2013 22:46:29 ******/
ALTER TABLE [dbo].[PTien]  WITH CHECK ADD  CONSTRAINT [FK_PTien_NCCPTien] FOREIGN KEY([NhaCungCap])
REFERENCES [dbo].[NCCPTien] ([ID])
GO
ALTER TABLE [dbo].[PTien] CHECK CONSTRAINT [FK_PTien_NCCPTien]
GO
