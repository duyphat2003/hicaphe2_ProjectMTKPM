USE master
DROP DATABASE HiCaPhe

Create database HiCaPhe
Go
Use HiCaPhe
GO
--CREATE TABLE NGUYENLIEU (
--MaNL INT IDENTITY(1,1),
--MaSP INT IDENTITY(1,1),
--TenNL nvarchar(50) NOT NULL,
--HinhAnh VARCHAR(50),
--DonGia Money check (DonGia>=0),
--DonViTinh NVARCHAR(50),
--SoLuongTon INT CHECK(SoLuongTon>=0),
--NgayNhap SMALLDATETIME,
--CONSTRAINT PK_NguyenLieu PRIMARY KEY(MaNL)
--)
--GO
Create Table LOAISP
(
MaLoaiSP int Identity(1,1),
TenLoaiSP nvarchar(50) NOT NULL, 
CONSTRAINT PK_LOAISP PRIMARY KEY (MaLoaiSP)
)
GO

CREATE TABLE SANPHAM
(
MaSP VARCHAR(6),
TenSP NVARCHAR(100) NOT NULL,
Kichthuoc VARCHAR(1),
Donvitinh NVARCHAR(50), 
Dongia MONEY CHECK (Dongia>=0), 
Mota NTEXT, 
Hinhminhhoa VARCHAR(50), 
MaLoaiSP INT, 
Soluongban INT CHECK(Soluongban>0), 
CONSTRAINT PK_SanPham PRIMARY KEY (MaSP)
)
GO



CREATE TABLE TAIKHOANKHACHHANG (
MaTK INT IDENTITY(1,1),
HoTenKH nvarchar(50) NOT NULL, 
Email Varchar(50) UNIQUE,
DiachiKH nvarchar(50),
SDT Varchar(10),
Matkhau Varchar(15) NOT NULL,
Ngaysinh SMALLDATETIME,
Daduyet Bit Default 0,
CONSTRAINT PK_KhachHang PRIMARY KEY(MaTK)
)
GO

CREATE TABLE CTDATHANG
(
SODH INT,
Soluong Int Check(Soluong>0),
MaSP VARCHAR(6),
Dongia Decimal(9,2) Check(Dongia>=0), 
Thanhtien AS SoLuong*Dongia
CONSTRAINT PK_CTDatHang PRIMARY KEY(SODH, MaSP)
)
GO

CREATE TABLE DONDATHANG
(
SODH INT IDENTITY(1,1), 
MaTK INT,
NgayDH SMALLDATETIME,
Dagiao Bit Default 0,
Dahuy Bit Default 0,
Ngaygiaohang SMALLDATETIME,
Tennguoinhan nvarchar(50), 
Diachinhan nvarchar(50),
Trigia Money Check (Trigia>0), 
Dienthoainhan Varchar(15), 
HTThanhtoan Bit Default 0, 
HTGiaohang Bit Default 0,
CONSTRAINT PK_DonDatHang PRIMARY KEY(SODH)
)
GO

ALTER TABLE SANPHAM ADD CONSTRAINT FK_SanPham_LoaiSP FOREIGN KEY (MaLoaiSP) REFERENCES LOAISP(MaLoaiSP)
ALTER TABLE DONDATHANG ADD CONSTRAINT FK_DonDatHang_TaikhoanKhachHang FOREIGN KEY (MaTK) REFERENCES TAIKHOANKHACHHANG(MaTK)
ALTER TABLE CTDATHANG ADD CONSTRAINT FK_CTDatHang_DonDatHang FOREIGN KEY (SoDH) REFERENCES DONDATHANG(SoDH)
ALTER TABLE CTDATHANG ADD CONSTRAINT FK_CTDatHang_SanPham FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP)
GO

SET IDENTITY_INSERT [dbo].[LoaiSP] ON
INSERT [dbo].[LoaiSP] ([MaLoaiSP], [TenLoaiSP]) VALUES (1, N'Cà phê')
INSERT [dbo].[LoaiSP] ([MaLoaiSP], [TenLoaiSP]) VALUES (2, N'Trà')
INSERT [dbo].[LoaiSP] ([MaLoaiSP], [TenLoaiSP]) VALUES (3, N'Thức uống khác')
INSERT [dbo].[LoaiSP] ([MaLoaiSP], [TenLoaiSP]) VALUES (4, N'Quà tặng')
INSERT [dbo].[LoaiSP] ([MaLoaiSP], [TenLoaiSP]) VALUES (5, N'Hạt')
INSERT [dbo].[LoaiSP] ([MaLoaiSP], [TenLoaiSP]) VALUES (6, N'Bánh')
SET IDENTITY_INSERT [dbo].[LoaiSP] OFF


SET IDENTITY_INSERT [dbo].[TAIKHOANKHACHHANG] ON
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (1,  N'Nguyễn Tiến Luân',     N'Trần Huy Liệu',     N'0918062755', N'123',    CAST(0x59310000 AS SmallDateTime), 1, N'pvkhoa@hcmuns.edu.vn')
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (2,  N'Nguyễn Tiến Luân',     N'Quận 6',            N'0912758923', N'123456', CAST(0x6A570000 AS SmallDateTime), 1, N'ntluan@hcmuns.edu.vn')
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (3,  N'Đặng Quốc Hòa',        N'Sư Vạn Hạnh',       N'0648919453', N'hoa',    CAST(0x5D890000 AS SmallDateTime), 1, N'dqhoa@hcmuns.edu.vn')
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (4,  N'Ngô Ngọc Ngân',        N'Khu chung cư',      N'0918544699', N'ngan',   CAST(0x42830000 AS SmallDateTime), 1, N'nnngan@hcmuns.edu.vn')
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (5,  N'Đỗ Quỳnh Hương',       N'Cống Quỳnh',        N'0908123456', N'huong',  CAST(0x75500000 AS SmallDateTime), 0, N'dqhuong@hcmuns.edu.vn')
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (6,  N'Trần Thị Thu Trang',   N'Nơ Trang Long',     N'1947562848', N'trang',  CAST(0x594D0000 AS SmallDateTime), 0, N'ttrang@yahoo.com')
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (7,  N'Nguyễn Thiên Thanh',   N'Hai Bà Trưng',      N'0908320111', N'thanh',  CAST(0x71130000 AS SmallDateTime), 0, N'ntthanh@t3h.hcmuns.edu.vn')
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (8,  N'Trần Thị Hải Yến',     N'Trần Hưng Đạo',     N'8111111124', N'yen',    CAST(0x6BC40000 AS SmallDateTime), 0, N'tthyan@vol.vnn.vn')
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (9,  N'Nguyễn Thị Thanh Mai', N'Trần Quang Diệu',   N'8111122224', N'mai',    CAST(0x75FF0000 AS SmallDateTime), 0, N'ngttmai@gmail.com')
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (10, N'Nguyễn Thành Danh',    N'Cộng Hòa',          N'8103751123', N'danh',   CAST(0x6EA00000 AS SmallDateTime), 1, N'ntdanh@yahoo.com')
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (11, N'Phạm Thị Nga',         N'Q6 - Tp.HCM',       N'0831564511', N'nga',    CAST(0x93D90000 AS SmallDateTime), 0, N'ptnhung@hcmuns.edu.vn')
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (12, N'Lê Doanh Doanh',       N'2Bis Hùng Vương',   N'0707786542', N'doanh',  CAST(0x6E590000 AS SmallDateTime), 0, N'lddoanh@yahoo.com')
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (13, N'Đòan Ngọc Minh Tâm',   N'2 Đinh Tiên Hòang', N'0909092222', N'tam',    CAST(0x6FCF0000 AS SmallDateTime), 0, N'ndmtam@yahoo.com')
INSERT [dbo].[TAIKHOANKHACHHANG] ([MaTK], [HotenKH], [DiachiKH], [SDT], [Matkhau], [Ngaysinh], [Daduyet], [Email]) VALUES (14, N'Trần Khải Nhi',        N'3 Bùi Hữu Nghĩa',   N'0909095555', N'nhi',    CAST(0x727E0000 AS SmallDateTime), 1, N'tknhi@yahoo.com')
SET IDENTITY_INSERT [dbo].[TAIKHOANKHACHHANG] OFF

--SET IDENTITY_INSERT [dbo].[NGUYENLIEU] ON
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0001', N'Cà phê hạt', 'nl0001.png', 100000, N'kg', 50, '01/09/2023', N'Tươi ngon, sử dụng cho việc rang và pha chế đồ uống cà phê.')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0002', N'Lá trà tươi', 'nl0002.png', 50000, N'gói', 100, '05/09/2023', N'Thơm ngon, sử dụng cho việc pha chế trà nóng hoặc lạnh.')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0003', N'Đường', 'nl0003.png', 20000, N'kg', 30, '10/09/2023', N'Sử dụng cho việc đường vị trong nhiều loại đồ uống và món bánh')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0004', N'Sữa đặc', 'nl0004.png', 25000, N'hộp', 40, '15/09/2023', N'Dùng trong các món bánh và thức uống.')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0005', N'Sữa tươi', 'nl0005.png', 15000, N'hộp', 40, '20/09/2023', N'Tinh khiết, sử dụng cho đồ uống và món bánh')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0006', N'Bột làm bánh', 'nl0006.png', 35000, N'gói', 30, '03/09/2023', N'Mềm mịn, dùng trong việc làm bánh.')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0007', N'Vải', 'nl0007.png', 25000, N'kg', 20, '18/09/2023', N'Tươi ngon, sử dụng làm thành phẩm trong các món tráng miệng và đồ uống.')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0008', N'Cam', 'nl0008.png', 10000, N'kg', 20, '19/09/2023', N'Tươi ngon,sử dụng làm thành phẩm trong các món tráng miệng và đồ uống.')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0009', N'Bơ', 'nl0009.png', 40000, N'kg', 20, '22/09/2023', N'Tươi ngon, sử dụng làm thành phẩm trong các loại đồ uống.')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0010', N'Dâu', 'nl0010.png', 70000, N'kg', 20, '21/09/2023', N'Tươi ngon, sử dụng làm thành phẩm trong các món tráng miệng và đồ uống.')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0011', N'Lá dứa', 'nl0011.png', 10000, N'kg', 5, '23/09/2023', N'Tươi xanh, sử dụng làm thành phẩm trong các món bánh.')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0012', N'Phô mai tươi', 'nl0012.png', 45000, N'hộp', 12, '23/09/2023', N'Thơm ngon, sử dụng làm thành phẩm trong các món ăn và chế biến làm thạch trong thức uống.')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0013', N'Chanh', 'nl0013.png', 30000, N'kg', 35, '24/09/2023', N'Màu xanh tươi, sử dụng cho việc làm nước chanh và gia vị.')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0014', N'Sô cô la', 'nl0014.png', 80000, N'gói', 20, '25/09/2023', N'Sử dụng làm thành phẩm trong các món tráng miệng và đồ uống.')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0015', N'Bột milo', 'nl0015.png', 25000, N'gói', 30, '26/09/2023', N'Sử dụng để pha chế đồ uống milo thơm ngon.')
--INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [HinhAnh], [DonGia], [DonViTinh], [SoLuongTon], [NgayNhap]) VALUES ('nl0016', N'Bột trà xanh', 'nl0016.png', 35000, N'gói', 10, '27/09/2023', N'Sử dụng để pha chế trà xanh và làm bánh.')
--SET IDENTITY_INSERT [dbo].[NGUYENLIEU] OFF

INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0001', N'Cà phê đen', N'N', 12000, N'1 Ly' , N'Đơn giản và đậm đà, cà phê đen là cà phê được pha chỉ với nước, có đường hoặc không đường', N'sp0001.png', 1, 20)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0002', N'Cà phê đen', N'L', 15000, N'1 Ly' , N'Đơn giản và đậm đà, cà phê đen là cà phê được pha chỉ với nước, có đường hoặc không đường', N'sp0002.png', 1, 20)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0003', N'Cà phê sữa', N'N', 15000, N'1 Ly' , N'Cà phê pha chế với sữa đặc có thể có ít đường, tạo ra hương vị hòa quyện giữa cà phê và sữa.', N'sp0003.png', 1, 25)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0004', N'Cà phê sữa', N'L', 18000, N'1 Ly' , N'Cà phê pha chế với sữa đặc có thể có ít đường, tạo ra hương vị hòa quyện giữa cà phê và sữa.', N'sp0004.png', 1, 25)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0005', N'Bạc xỉu', N'N', 20000, N'1 Ly' , N'Cà phê nhẹ, pha chế với một ít sữa đặc và sữa tươi có thể thêm ít đường, tạo ra một hương vị cân bằng và dễ uống', N'sp0005.png', 1, 21)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0006', N'Bạc xỉu', N'L', 25000, N'1 Ly' , N'Cà phê nhẹ, pha chế với một ít sữa đặc và sữa tươi có thể thêm ít đường, tạo ra một hương vị cân bằng và dễ uống', N'sp0006.png', 1, 21)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0007', N'Cappuccino', N'N', 22000, N'1 Ly' , N'Một loại cà phê với sữa bọt và bột cacao, tạo lớp kem sữa trên mặt cà phê.', N'sp0007.png', 1, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0008', N'Cappuccino', N'L', 27000, N'1 Ly' , N'Một loại cà phê với sữa bọt và bột cacao, tạo lớp kem sữa trên mặt cà phê.', N'sp0008.png', 1, 15)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0009', N'Latte', N'N', 22000, N'1 Ly' , N'Loại đồ uống cà phê được pha chế bằng cà phê espresso và sữa tươi, có hương vị cà phê mạnh và mềm mịn từ sữa.', N'sp0009.png', 1, 15)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0010', N'Latte', N'L', 27000, N'1 Ly' , N'Loại đồ uống cà phê được pha chế bằng cà phê espresso và sữa tươi, có hương vị cà phê mạnh và mềm mịn từ sữa.', N'sp0010.png', 1, 15)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0011', N'Trà ô long', N'N', 20000, N'1 Ly' , N'Trà ô long truyền thống với hương thơm độc đáo từ lá trà.', N'sp0011.png', 2, 17)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0012', N'Trà ô long', N'L', 25000, N'1 Ly' , N'Trà ô long truyền thống với hương thơm độc đáo từ lá trà.', N'sp0012.png', 2, 17)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0013', N'Trà vải', N'N', 20000, N'1 Ly' , N'Trà vị vải thơm ngon, có hương vị tươi mát và ngọt ngào.', N'sp0013.png', 2, 27)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0014', N'Trà vải', N'L', 25000, N'1 Ly' , N'Trà vị vải thơm ngon, có hương vị tươi mát và ngọt ngào.', N'sp0014.png', 2, 30)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0015', N'Trà sữa', N'N', 18000, N'1 Ly' , N'Trà pha chế với sữa tươi và đường, tạo ra một hương vị thơm ngon và béo ngậy.', N'sp0015.png', 2, 30)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0016', N'Trà sữa', N'L', 23000, N'1 Ly' , N'Trà pha chế với sữa tươi và đường, tạo ra một hương vị thơm ngon và béo ngậy.', N'sp0016.png', 2, 30)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0017', N'Hồng trà', N'N', 20000, N'1 Ly' , N'Hồng trà là loại trà đen với hương thơm đặc trưng từ lá hồng.', N'sp0017.png', 2, 20)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0018', N'Hồng trà', N'L', 25000, N'1 Ly' , N'Hồng trà là loại trà đen với hương thơm đặc trưng từ lá hồng.', N'sp0018.png', 2, 20)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0019', N'Trà xanh', N'N', 20000, N'1 Ly' , N'Trà xanh tươi ngon và bổ dưỡng.', N'sp0019.png', 2, 20)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0020', N'Trà xanh', N'L', 25000, N'1 Ly' , N'Trà xanh tươi ngon và bổ dưỡng.', N'sp0020.png', 2, 20)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0021', N'Nước cam', N'N', 20000, N'1 Ly' , N'Nước ép từ quả cam tươi ngon, giàu vitamin C.', N'sp0021.png', 3, 35)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0022', N'Nước cam', N'L', 25000, N'1 Ly' , N'Nước ép từ quả cam tươi ngon, giàu vitamin C.', N'sp0022.png', 3, 35)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0023', N'Sinh tố bơ', N'L', 30000, N'1 Ly' , N'Đồ uống sinh tố mát lạnh với hương vị bơ thơm ngon.', N'sp0023.png', 3, 29)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0024', N'Sinh tố dâu', N'L', 30000, N'1 Ly' , N'Đồ uống sinh tố tươi ngon với dâu tươi mọng.', N'sp0024.png', 3, 29)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0025', N'Sô cô la đá xay', N'L', 30000, N'1 Ly' , N'Đá xay với hương vị sô cô la đậm đà.', N'sp0025.png', 3, 29)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0026', N'Sô đa chanh đá', N'L', 30000, N'1 Ly' , N'Đá xay với vị chanh tươi mát.', N'sp0026.png', 3, 29)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0027', N'Sô đa sapphire', N'L', 30000, N'1 Ly' , N'Đá xay vị sapphire độc đáo và mát lạnh.', N'sp0027.png', 3, 29)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0028', N'Milo dằm', N'N', 10000, N'1 Ly' , N'Đồ uống Milo pha chế với hương vị dằm thơm ngon.', N'sp0028.png', 3, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0029', N'Milo dằm', N'L', 15000, N'1 Ly' , N'Đồ uống Milo pha chế với hương vị dằm thơm ngon.', N'sp0029.png', 3, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0030', N'Si rô sâm dứa', N'L', 10000, N'1 Ly' , N'Si rô sâm dứa độc đáo với hương vị dứa tươi ngon.', N'sp0030.png', 3, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0031', N'Sữa lắc Hi', N'N', 18000, N'1 Ly' , N'Đồ uống sữa lắc thơm ngon với thương hiệu Hi cà phê.', N'sp0031.png', 3, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0032', N'Sữa lắc Hi', N'L', 23000, N'1 Ly' , N'Đồ uống sữa lắc thơm ngon với thương hiệu Hi cà phê.', N'sp0032.png', 3, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0033', N'Bánh quy đá xay', N'L', 20000, N'1 Ly' , N'Được tạo ra bằng cách xay nhuyễn bánh quy và kết hợp với các thành phần khác tạo ra một đồ uống ngon và độc đáo.', N'sp0033.png', 3, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0034', N'Ly đổi màu', N'L', 25000, N'1 Cái' , N'Ly thay đổi màu khi đổ nước vào.', N'sp0034.png', 4, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0035', N'Bình nước thông minh', N'L', 15000, N'1 Cái' , N'Bình nước có tính năng thông minh.', N'sp0035.png', 4, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0036', N'Tách trà', N'N', 15000, N'1 Cái' , N'Tách sử dụng cho trà.', N'sp0036.png', 4, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0037', N'Ly giữ nhiệt', N'L', 30000, N'1 Cái' , N'Ly giữ nhiệt để giữ nhiệt độ đồ uống.', N'sp0037.png', 4, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0038', N'Sổ tay Hi', N'N', 9000, N'1 Cái' , N'Sổ tay với thương hiệu Hi cà phê.', N'sp0038.png', 4, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0039', N'Hạt hướng dương', N'N', 15000, N'1 Túi' , N'Hạt hướng dương rang giòn, là món ăn nhẹ ngon.', N'sp0039.png', 5, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0040', N'Hạt điều', N'N', 13000, N'1 Túi' , N'Hạt điều béo ngon, là món ăn nhẹ phổ biến.', N'sp0040.png', 5, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0041', N'Hạt dẻ', N'N', 10000, N'1 Túi' , N'Hạt dẻ sữa ngon và bổ dưỡng.', N'sp0041.png', 5, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0042', N'Bánh plăng', N'N', 5000, N'1 Cái' , N'Bánh tròn có độ giòn, thích hợp làm món ăn nhẹ.', N'sp0042.png', 6, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0043', N'Bánh quy', N'N', 10000, N'5 Cái' , N'Bánh quy thơm ngon, làm từ bột mỳ và bơ.', N'sp0043.png', 6, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0044', N'Bánh bông lan', N'N', 15000, N'1 Cái' , N'Bánh bông lan truyền thống, mềm mịn và thơm ngon.', N'sp0044.png', 6, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0045', N'Bánh Hi', N'N', 26000, N'2 Cái' , N'Loại bánh phô mai thơm ngon, dẻo mịn được chế biến theo công thức gia truyền mang thương hiệu Hi.', N'sp0045.png', 6, 22)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [Kichthuoc], [Dongia], [Donvitinh], [Mota], [Hinhminhhoa], [MaLoaiSP], [Soluongban]) VALUES ('sp0046', N'Bánh phô mai', N'N', 20000, N'1 Cái' , N'Bánh phô mai thơm ngon với lớp phô mai béo béo.', N'sp0046.png', 6, 22)

SET IDENTITY_INSERT [dbo].[DONDATHANG] ON
INSERT [dbo].[DONDATHANG] ([SoDH], [MaTK], [NgayDH], [Trigia], [Dagiao],[Dahuy], [Ngaygiaohang]) VALUES (1, 1, CAST(0x9D500000 AS SmallDateTime),  CAST(75000.00 AS Decimal(9, 2)), 0,0, CAST(0x9D500000 AS SmallDateTime))
INSERT [dbo].[DONDATHANG] ([SoDH], [MaTK], [NgayDH], [Trigia], [Dagiao],[Dahuy], [Ngaygiaohang]) VALUES (2, 1, CAST(0x9DA30000 AS SmallDateTime),  CAST(80000.00 AS Decimal(9, 2)), 0,0, CAST(0x9DA30000 AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[DONDATHANG] OFF

INSERT [dbo].[CTDATHANG] ([SoDH], [MaSP], [Soluong], [Dongia]) VALUES (1,'sp0019', 1, 25000)
INSERT [dbo].[CTDATHANG] ([SoDH], [MaSP], [Soluong], [Dongia]) VALUES (1, 'sp0023', 2, 25000)
INSERT [dbo].[CTDATHANG] ([SoDH], [MaSP], [Soluong], [Dongia]) VALUES (2, 'sp0001', 1, 26000)
INSERT [dbo].[CTDATHANG] ([SoDH], [MaSP], [Soluong], [Dongia]) VALUES (2, 'sp0017', 3, 18000)

CREATE TABLE ADMIN 
( 
	UserAdmin varchar(30) primary key, 
	PassAdmin varchar(30) not null, 
	HoTen nvarchar(50), 
	VaiTro varchar(30) 
) 

INSERT INTO ADMIN VALUES('admin', 'admin', N'Nguyễn Văn A', 'ADMIN') 
INSERT INTO ADMIN VALUES('user', 'user', N'Nguyễn Văn B', 'ADMIN')



CREATE OR REPLACE PROCEDURE InsertLoaiSP(
    p_TenLoaiSP IN NVARCHAR2
) AS
BEGIN
    INSERT INTO LOAISP (TenLoaiSP)
    VALUES (p_TenLoaiSP);
END;

CREATE OR REPLACE PROCEDURE UpdateLoaiSP(
    p_MaLoaiSP IN NUMBER,
    p_TenLoaiSP IN NVARCHAR2
) AS
BEGIN
    UPDATE LOAISP
    SET TenLoaiSP = p_TenLoaiSP
    WHERE MaLoaiSP = p_MaLoaiSP;
END;

CREATE OR REPLACE PROCEDURE DeleteLoaiSP(
    p_MaLoaiSP IN NUMBER
) AS
BEGIN
    DELETE FROM LOAISP
    WHERE MaLoaiSP = p_MaLoaiSP;
END;

CREATE OR REPLACE PROCEDURE GetLoaiSP AS
BEGIN
    FOR rec IN (SELECT * FROM LOAISP) LOOP
        DBMS_OUTPUT.PUT_LINE('MaLoaiSP: ' || rec.MaLoaiSP || ', TenLoaiSP: ' || rec.TenLoaiSP);
    END LOOP;
END;



CREATE OR REPLACE PROCEDURE InsertSanPham(
    p_MaSP IN VARCHAR2,
    p_TenSP IN NVARCHAR2,
    p_Kichthuoc IN VARCHAR2,
    p_Donvitinh IN NVARCHAR2,
    p_Dongia IN NUMBER,
    p_Mota IN NCLOB,
    p_Hinhminhhoa IN VARCHAR2,
    p_MaLoaiSP IN NUMBER,
    p_Soluongban IN NUMBER
) AS
BEGIN
    INSERT INTO SANPHAM (MaSP, TenSP, Kichthuoc, Donvitinh, Dongia, Mota, Hinhminhhoa, MaLoaiSP, Soluongban)
    VALUES (p_MaSP, p_TenSP, p_Kichthuoc, p_Donvitinh, p_Dongia, p_Mota, p_Hinhminhhoa, p_MaLoaiSP, p_Soluongban);
END;

CREATE OR REPLACE PROCEDURE UpdateSanPham(
    p_MaSP IN VARCHAR2,
    p_TenSP IN NVARCHAR2,
    p_Kichthuoc IN VARCHAR2,
    p_Donvitinh IN NVARCHAR2,
    p_Dongia IN NUMBER,
    p_Mota IN NCLOB,
    p_Hinhminhhoa IN VARCHAR2,
    p_MaLoaiSP IN NUMBER,
    p_Soluongban IN NUMBER
) AS
BEGIN
    UPDATE SANPHAM
    SET TenSP = p_TenSP,
        Kichthuoc = p_Kichthuoc,
        Donvitinh = p_Donvitinh,
        Dongia = p_Dongia,
        Mota = p_Mota,
        Hinhminhhoa = p_Hinhminhhoa,
        MaLoaiSP = p_MaLoaiSP,
        Soluongban = p_Soluongban
    WHERE MaSP = p_MaSP;
END;

CREATE OR REPLACE PROCEDURE DeleteSanPham(
    p_MaSP IN VARCHAR2
) AS
BEGIN
    DELETE FROM SANPHAM
    WHERE MaSP = p_MaSP;
END;

CREATE OR REPLACE PROCEDURE GetSanPham AS
BEGIN
    FOR rec IN (SELECT * FROM SANPHAM) LOOP
        DBMS_OUTPUT.PUT_LINE('MaSP: ' || rec.MaSP || ', TenSP: ' || rec.TenSP || ', Kichthuoc: ' || rec.Kichthuoc || ', ...'); -- Add other columns as needed
    END LOOP;
END;



CREATE OR REPLACE PROCEDURE InsertKhachHang(
    p_HoTenKH IN NVARCHAR2,
    p_Email IN VARCHAR2,
    p_DiachiKH IN NVARCHAR2,
    p_SDT IN VARCHAR2,
    p_Matkhau IN VARCHAR2,
    p_Ngaysinh IN DATE
) AS
BEGIN
    INSERT INTO TAIKHOANKHACHHANG (HoTenKH, Email, DiachiKH, SDT, Matkhau, Ngaysinh)
    VALUES (p_HoTenKH, p_Email, p_DiachiKH, p_SDT, p_Matkhau, p_Ngaysinh);
END;

CREATE OR REPLACE PROCEDURE UpdateKhachHang(
    p_MaTK IN NUMBER,
    p_HoTenKH IN NVARCHAR2,
    p_Email IN VARCHAR2,
    p_DiachiKH IN NVARCHAR2,
    p_SDT IN VARCHAR2,
    p_Matkhau IN VARCHAR2,
    p_Ngaysinh IN DATE
) AS
BEGIN
    UPDATE TAIKHOANKHACHHANG
    SET HoTenKH = p_HoTenKH,
        Email = p_Email,
        DiachiKH = p_DiachiKH,
        SDT = p_SDT,
        Matkhau = p_Matkhau,
        Ngaysinh = p_Ngaysinh
    WHERE MaTK = p_MaTK;
END;

CREATE OR REPLACE PROCEDURE DeleteKhachHang(
    p_MaTK IN NUMBER
) AS
BEGIN
    DELETE FROM TAIKHOANKHACHHANG
    WHERE MaTK = p_MaTK;
END;


CREATE OR REPLACE PROCEDURE GetKhachHang AS
BEGIN
    FOR rec IN (SELECT * FROM TAIKHOANKHACHHANG) LOOP
        DBMS_OUTPUT.PUT_LINE('MaTK: ' || rec.MaTK || ', HoTenKH: ' || rec.HoTenKH || ', Email: ' || rec.Email || ', ...'); -- Add other columns as needed
    END LOOP;
END;



CREATE OR REPLACE PROCEDURE InsertCTDatHang(
    p_SODH IN NUMBER,
    p_Soluong IN NUMBER,
    p_MaSP IN VARCHAR2,
    p_Dongia IN NUMBER
) AS
BEGIN
    INSERT INTO CTDATHANG (SODH, Soluong, MaSP, Dongia)
    VALUES (p_SODH, p_Soluong, p_MaSP, p_Dongia);
END;

CREATE OR REPLACE PROCEDURE UpdateCTDatHang(
    p_SODH IN NUMBER,
    p_MaSP IN VARCHAR2,
    p_Soluong IN NUMBER,
    p_Dongia IN NUMBER
) AS
BEGIN
    UPDATE CTDATHANG
    SET Soluong = p_Soluong,
        Dongia = p_Dongia
    WHERE SODH = p_SODH AND MaSP = p_MaSP;
END;

CREATE OR REPLACE PROCEDURE DeleteCTDatHang(
    p_SODH IN NUMBER,
    p_MaSP IN VARCHAR2
) AS
BEGIN
    DELETE FROM CTDATHANG
    WHERE SODH = p_SODH AND MaSP = p_MaSP;
END;


CREATE OR REPLACE PROCEDURE GetCTDatHang AS
BEGIN
    FOR rec IN (SELECT * FROM CTDATHANG) LOOP
        DBMS_OUTPUT.PUT_LINE('SODH: ' || rec.SODH || ', MaSP: ' || rec.MaSP || ', Soluong: ' || rec.Soluong || ', ...'); -- Add other columns as needed
    END LOOP;
END;



CREATE OR REPLACE PROCEDURE InsertDonDatHang(
    p_MaTK IN NUMBER,
    p_NgayDH IN DATE,
    p_Dagiao IN NUMBER,
    p_Dahuy IN NUMBER,
    p_Ngaygiaohang IN DATE,
    p_Tennguoinhan IN NVARCHAR2,
    p_Diachinhan IN NVARCHAR2,
    p_Trigia IN NUMBER,
    p_Dienthoainhan IN VARCHAR2,
    p_HTThanhtoan IN NUMBER,
    p_HTGiaohang IN NUMBER
) AS
BEGIN
    INSERT INTO DONDATHANG (MaTK, NgayDH, Dagiao, Dahuy, Ngaygiaohang, Tennguoinhan, Diachinhan, Trigia, Dienthoainhan, HTThanhtoan, HTGiaohang)
    VALUES (p_MaTK, p_NgayDH, p_Dagiao, p_Dahuy, p_Ngaygiaohang, p_Tennguoinhan, p_Diachinhan, p_Trigia, p_Dienthoainhan, p_HTThanhtoan, p_HTGiaohang);
END;

CREATE OR REPLACE PROCEDURE UpdateDonDatHang(
    p_SODH IN NUMBER,
    p_MaTK IN NUMBER,
    p_NgayDH IN DATE,
    p_Dagiao IN NUMBER,
    p_Dahuy IN NUMBER,
    p_Ngaygiaohang IN DATE,
    p_Tennguoinhan IN NVARCHAR2,
    p_Diachinhan IN NVARCHAR2,
    p_Trigia IN NUMBER,
    p_Dienthoainhan IN VARCHAR2,
    p_HTThanhtoan IN NUMBER,
    p_HTGiaohang IN NUMBER
) AS
BEGIN
    UPDATE DONDATHANG
    SET MaTK = p_MaTK,
        NgayDH = p_NgayDH,
        Dagiao = p_Dagiao,
        Dahuy = p_Dahuy,
        Ngaygiaohang = p_Ngaygiaohang,
        Tennguoinhan = p_Tennguoinhan,
        Diachinhan = p_Diachinhan,
        Trigia = p_Trigia,
        Dienthoainhan = p_Dienthoainhan,
        HTThanhtoan = p_HTThanhtoan,
        HTGiaohang = p_HTGiaohang
    WHERE SODH = p_SODH;
END;

CREATE OR REPLACE PROCEDURE DeleteDonDatHang(
    p_SODH IN NUMBER
) AS
BEGIN
    DELETE FROM DONDATHANG
    WHERE SODH = p_SODH;
END;

CREATE OR REPLACE PROCEDURE GetDonDatHang AS
BEGIN
    FOR rec IN (SELECT * FROM DONDATHANG) LOOP
        DBMS_OUTPUT.PUT_LINE('SODH: ' || rec.SODH || ', MaTK: ' || rec.MaTK || ', NgayDH: ' || rec.NgayDH || ', ...'); -- Add other columns as needed
    END LOOP;
END;


CREATE OR REPLACE TRIGGER CheckPrimaryKey_LOAISP
INSTEAD OF INSERT OR UPDATE ON LOAISP
DECLARE
    v_RecordCount NUMBER;
BEGIN
    -- Check the number of records being inserted or updated
    SELECT COUNT(*) INTO v_RecordCount FROM inserted;

    IF v_RecordCount > 1 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Cannot insert or update multiple records into LOAISP at once.');
    END IF;

    -- Check for duplicate MaLoaiSP values
    IF (SELECT COUNT(*) FROM LOAISP WHERE MaLoaiSP IN (SELECT MaLoaiSP FROM inserted)) > 0 THEN
        RAISE_APPLICATION_ERROR(-20002, 'Duplicate MaLoaiSP values are not allowed in LOAISP.');
    END IF;

    -- Proceed with the actual insert or update statement
    FOR rec IN (SELECT * FROM inserted) LOOP
        -- Use appropriate logic for insert or update based on your requirements
        IF rec.operation = 'INSERT' THEN
            INSERT INTO LOAISP (MaLoaiSP, TenLoaiSP)
            VALUES (rec.MaLoaiSP, rec.TenLoaiSP);
        ELSIF rec.operation = 'UPDATE' THEN
            UPDATE LOAISP
            SET TenLoaiSP = rec.TenLoaiSP
            WHERE MaLoaiSP = rec.MaLoaiSP;
        END IF;
    END LOOP;
END;


CREATE OR REPLACE TRIGGER CheckForeignKey_SANPHAM
INSTEAD OF INSERT OR UPDATE ON SANPHAM
DECLARE
    v_RecordCount NUMBER;
BEGIN
    -- Check the number of records being inserted or updated
    SELECT COUNT(*) INTO v_RecordCount FROM inserted;

    IF v_RecordCount > 0 THEN
        -- Check for foreign key constraint violation
        IF (SELECT COUNT(*) FROM inserted WHERE MaLoaiSP IS NOT NULL AND MaLoaiSP NOT IN (SELECT MaLoaiSP FROM LOAISP)) > 0 THEN
            RAISE_APPLICATION_ERROR(-20001, 'Foreign key constraint violation: MaLoaiSP must exist in LOAISP.');
        END IF;

        -- Proceed with the actual insert or update statement
        FOR rec IN (SELECT * FROM inserted) LOOP
            -- Use appropriate logic for insert or update based on your requirements
            IF rec.operation = 'INSERT' THEN
                INSERT INTO SANPHAM (MaSP, TenSP, Kichthuoc, Donvitinh, Dongia, Mota, Hinhminhhoa, MaLoaiSP, Soluongban)
                VALUES (rec.MaSP, rec.TenSP, rec.Kichthuoc, rec.Donvitinh, rec.Dongia, rec.Mota, rec.Hinhminhhoa, rec.MaLoaiSP, rec.Soluongban);
            ELSIF rec.operation = 'UPDATE' THEN
                UPDATE SANPHAM
                SET TenSP = rec.TenSP,
                    Kichthuoc = rec.Kichthuoc,
                    Donvitinh = rec.Donvitinh,
                    Dongia = rec.Dongia,
                    Mota = rec.Mota,
                    Hinhminhhoa = rec.Hinhminhhoa,
                    MaLoaiSP = rec.MaLoaiSP,
                    Soluongban = rec.Soluongban
                WHERE MaSP = rec.MaSP;
            END IF;
        END LOOP;
    END IF;
END;



CREATE OR REPLACE TRIGGER CheckConstraint_TAIKHOANKHACHHANG
INSTEAD OF INSERT OR UPDATE ON TAIKHOANKHACHHANG
DECLARE
    v_RecordCount NUMBER;
BEGIN
    -- Check the number of records being inserted or updated
    SELECT COUNT(*) INTO v_RecordCount FROM inserted;

    IF v_RecordCount > 0 THEN
        -- Check for constraint violation
        IF (SELECT COUNT(*) FROM inserted WHERE Daduyet NOT IN (0, 1)) > 0 THEN
            RAISE_APPLICATION_ERROR(-20001, 'Check constraint violation: Daduyet must be 0 or 1.');
        END IF;

        -- Proceed with the actual insert or update statement
        FOR rec IN (SELECT * FROM inserted) LOOP
            -- Use appropriate logic for insert or update based on your requirements
            IF rec.operation = 'INSERT' THEN
                INSERT INTO TAIKHOANKHACHHANG (HoTenKH, Email, DiachiKH, SDT, Matkhau, Ngaysinh, Daduyet)
                VALUES (rec.HoTenKH, rec.Email, rec.DiachiKH, rec.SDT, rec.Matkhau, rec.Ngaysinh, rec.Daduyet);
            ELSIF rec.operation = 'UPDATE' THEN
                UPDATE TAIKHOANKHACHHANG
                SET HoTenKH = rec.HoTenKH,
                    Email = rec.Email,
                    DiachiKH = rec.DiachiKH,
                    SDT = rec.SDT,
                    Matkhau = rec.Matkhau,
                    Ngaysinh = rec.Ngaysinh,
                    Daduyet = rec.Daduyet
                WHERE MaTK = rec.MaTK;
            END IF;
        END LOOP;
    END IF;
END;


CREATE OR REPLACE TRIGGER CheckConstraint_CTDATHANG
INSTEAD OF INSERT OR UPDATE ON CTDATHANG
DECLARE
    v_RecordCount NUMBER;
BEGIN
    -- Check the number of records being inserted or updated
    SELECT COUNT(*) INTO v_RecordCount FROM inserted;

    IF v_RecordCount > 0 THEN
        -- Check for constraint violation
        IF (SELECT COUNT(*) FROM inserted WHERE Soluong <= 0) > 0 THEN
            RAISE_APPLICATION_ERROR(-20001, 'Check constraint violation: Soluong must be greater than 0.');
        END IF;

        -- Proceed with the actual insert or update statement
        FOR rec IN (SELECT * FROM inserted) LOOP
            -- Use appropriate logic for insert or update based on your requirements
            IF rec.operation = 'INSERT' THEN
                INSERT INTO CTDATHANG (SODH, Soluong, MaSP, Dongia)
                VALUES (rec.SODH, rec.Soluong, rec.MaSP, rec.Dongia);
            ELSIF rec.operation = 'UPDATE' THEN
                UPDATE CTDATHANG
                SET Soluong = rec.Soluong,
                    MaSP = rec.MaSP,
                    Dongia = rec.Dongia
                WHERE SODH = rec.SODH AND MaSP = rec.MaSP;
            END IF;
        END LOOP;
    END IF;
END;

CREATE OR REPLACE TRIGGER CheckConstraint_DONDATHANG
INSTEAD OF INSERT OR UPDATE ON DONDATHANG
DECLARE
    v_RecordCount NUMBER;
BEGIN
    -- Check the number of records being inserted or updated
    SELECT COUNT(*) INTO v_RecordCount FROM inserted;

    IF v_RecordCount > 0 THEN
        -- Check for constraint violation
        IF (SELECT COUNT(*) FROM inserted WHERE Trigia <= 0) > 0 THEN
            RAISE_APPLICATION_ERROR(-20001, 'Check constraint violation: Trigia must be greater than 0.');
        END IF;

        -- Proceed with the actual insert or update statement
        FOR rec IN (SELECT * FROM inserted) LOOP
            -- Use appropriate logic for insert or update based on your requirements
            IF rec.operation = 'INSERT' THEN
                INSERT INTO DONDATHANG (MaTK, NgayDH, Dagiao, Dahuy, Ngaygiaohang, Tennguoinhan, Diachinhan, Trigia, Dienthoainhan, HTThanhtoan, HTGiaohang)
                VALUES (rec.MaTK, rec.NgayDH, rec.Dagiao, rec.Dahuy, rec.Ngaygiaohang, rec.Tennguoinhan, rec.Diachinhan, rec.Trigia, rec.Dienthoainhan, rec.HTThanhtoan, rec.HTGiaohang);
            ELSIF rec.operation = 'UPDATE' THEN
                UPDATE DONDATHANG
                SET MaTK = rec.MaTK,
                    NgayDH = rec.NgayDH,
                    Dagiao = rec.Dagiao,
                    Dahuy = rec.Dahuy,
                    Ngaygiaohang = rec.Ngaygiaohang,
                    Tennguoinhan = rec.Tennguoinhan,
                    Diachinhan = rec.Diachinhan,
                    Trigia = rec.Trigia,
                    Dienthoainhan = rec.Dienthoainhan,
                    HTThanhtoan = rec.HTThanhtoan,
                    HTGiaohang = rec.HTGiaohang
                WHERE SODH = rec.SODH;
            END IF;
        END LOOP;
    END IF;
END;
