/* DIRTY READ 1 ======================================================*/
/*t1 :chủ nhà xóa nhà cần bán/thuê*/
USE QUANLYNHADAT
GO

CREATE PROC USP_USER_DeleteHouse(@houseId int)
AS
begin
	-- Bắt đầu trans
    begin tran
    declare @foundHouse int;
    declare @houseType int;
	declare @outOfDate datetime;
	set @outOfDate = (SELECT NGAYHETHAN    from NHA where MANHA = @houseId)
    set @foundHouse =  (select top 1
        N.MANHA
		from NHA N
		where N.MANHA = @houseId
		)
	delete from CHITIETNHABAN where MANHA = @houseId
	delete from CHITIETNHATHUE where MANHA = @houseId
	delete from NHA where  MANHA = @houseId
		
		WAITFOR delay '00:00:10'
    if (@outOfDate  < getdate())
     begin
        commit
    end
    else 
	begin
	RAISERROR('Nha con trong thoi han ban', 16, 1)
	rollback tran
	end
END
GO
/*t2 Chi nhánh coi danh sách nhà quản lý*/
CREATE PROC USP_TEST_AGENCY_GetHouse(@agency int)
as
begin
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
    select *
    from NHA N
    where N.MACN = @agency
end
go

/* DIRTY READ 2 ======================================================*/
/*t1 : chủ nhà cập nhập thông tin nhà*/
GO
create proc USP_TEST_AGENCY_UpdateHouseInformation(
    @houseID int,
    @ngayhethan datetime,
    @ngaydang datetime,
    @tinhtrang nvarchar(20))
as
begin
	BEGIN TRAN
	declare @outOfDate datetime;
	set @outOfDate = (SELECT NGAYHETHAN    from NHA where MANHA = @houseId)

    UPDATE NHA
    set NGAYHETHAN = @ngayhethan, NGAYDANG = @ngaydang, TINHTRANG = @tinhtrang
    where MANHA = @houseId
	WAITFOR delay '00:00:10'

	 if (@outOfDate  < getdate())
     begin
        commit
    end
    else 
	begin
	RAISERROR('Nha con trong thoi han ban', 16, 1)
	rollback tran
	end

end
GO
/*t2 Chi nhánh coi thông tin nhà quản lý*/
go
/* UNREPEATABLE READ 1 / UNREPEATABLE READ 2 ======================================================*/
-- hàm hỗ trợ
CREATE  PROCEDURE USP_UpdateSaleHouseHouseInPrice_Test
@ratio float, @minium int, @agency int
AS
BEGIN
	UPDATE CHITIETNHABAN set GIABAN = GIABAN * @ratio 
		WHERE MACN =@agency and MANHA in (select MANHA from NHA 
						  where MALOAI in (select MALOAI from NHA 
									      WHERE MACN = @agency
										  group by MALOAI having MALOAI < @minium));
END
go

CREATE PROCEDURE USP_UpdateRentHouseHouseInPrice_Test
@ratio float, @minium int, @agency INT
AS
BEGIN
	UPDATE CHITIETNHATHUE set GIATHUE = GIATHUE * @ratio 
		WHERE MACN =@agency and  MANHA in (select MANHA from NHA 
							where MALOAI in (select MALOAI from NHA 
											WHERE MACN = @agency
											group by MALOAI having MALOAI < @minium));
END
go
--UNREPEATABLE READ 1
/* t1 Chi Nhanh TĂNG GIÁ NHÀ (UNREPEATABLE READ 1)  (PHANTOM 1) */
CREATE PROCEDURE USP_IsPriceIncreases
@ratio float, @minium int, @agency INT
AS
BEGIN
	begin Tran
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	declare @HouseTypeList table(MALOAI int)

	insert into @HouseTypeList
	SELECT N.MALOAI
	from NHA N where N.MACN = @agency group by MALOAI having COUNT(*) < @minium

	if exists (select MALOAI from @HouseTypeList)
		begin
		EXEC USP_UpdateRentHouseHouseInPrice_Test @ratio , @minium,@agency
		EXEC USP_UpdateSaleHouseHouseInPrice_Test @ratio , @minium, @agency
		end
	WAITFOR DELAY '00:00:10'
	/* t2 DÔ UPDATE LOẠI NHÀ (NVIEN/CHU NHA)*/

	/* THỐNG KÊ BỊ SAI*/
	SELECT COUNT(*) AS SLUONGNHA, MALOAI 
	FROM NHA WHERE MACN= @agency 
					AND MALOAI IN 
					(select MALOAI from @HouseTypeList) 
			GROUP BY MALOAI
	commit Tran
END
GO

-- UNREPEATABLE READ 2
/*T1 CHI NHÁNH tìm nhà phù hợp loại nhà yêu cầu (UNREPEATABLE READ 2) (PHANTOM 2)*/
CREATE PROCEDURE USP_GetCustomerSuitableHouse
@houseType int, @agency int
AS
BEGIN
	begin Tran
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	if exists (select * from NHA WHERE MALOAI = @houseType and MACN = @agency) /* KIỂM TRA CÓ TỒN TẠI NHA PHU HỢP Ở CHI NHÁNH KO*/
		begin
		select * from NHA WHERE MALOAI = @houseType and MACN = @agency
		end
	else 
		begin
		waitfor delay '00:00:10'
		select * from NHA WHERE MALOAI = @houseType ORDER BY MACN /* TRẢ RA NHÀ PHÙ HỢP MK CÔNG TY CÓ*/
		end
	
	/*t2 CAP NHAT LOAI NHA*/
	commit Tran
END
GO

	
/* t2 Chu Nha CAP NHAT LOAI NHA (UNREPEATABLE READ 1 / UNREPEATABLE READ 2 )*/
CREATE PROCEDURE USP_UpdateHouseInHouseType_Test
@houseCode int, @newHouseType int
AS
BEGIN
	begin Tran
	UPDATE NHA set MALOAI = @newHouseType WHERE MANHA = @houseCode 
	commit Tran
END
GO


/* PHANTOM 1 ======================================================*/
/* T1 : Chi nhánh
EXEC PROCEDURE USP_IsPriceIncreases*/

/*chủ nhà thêm nhà thuê mới PHANTOM 1*/
CREATE PROCEDURE USP_AddHouseForRent
@MaChiNhanh INT, @MaChuNha INT, @MaNhanVien INT, @MaLoai INT,  @SoLuongPhongO INT, @NgayHetHan DATETIME, @NgayDang DATETIME, @Duong NVARCHAR(40), @Quan NVARCHAR(40), @KhuVuc NVARCHAR(40), @ThanhPho NVARCHAR(40), @TinhTrang NVARCHAR(20), @SoLuotXem INT, @GiaThue INT
AS
BEGIN
	BEGIN TRAN
	DECLARE @MANHA INT
	
	INSERT INTO NHA (MACN, MACNHA, MANV, MALOAI,  SOLUONGPHONGO, NGAYHETHAN, NGAYDANG, DUONG, QUAN, KHUVUC, THANHPHO, TINHTRANG, SOLUOTXEM)
	OUTPUT Inserted.MANHA
	VALUES (@MaChiNhanh, @MaChuNha, @MaNhanVien, @MaLoai, @SoLuongPhongO, @NgayHetHan, @NgayDang, @Duong, @Quan, @KhuVuc, @ThanhPho, @TinhTrang, @SoLuotXem)

	SET @MANHA = (SELECT SCOPE_IDENTITY())

	INSERT INTO CHITIETNHATHUE(MANHA, MACN, GIATHUE)
	VALUES (@MANHA, @MaChiNhanh,  @GiaThue)
	COMMIT
END
GO

/* PHANTOM 2 ======================================================*/
/* T1: CHI NHÁNH tìm nhà phù hợp yêu cầu
EXEC PROCEDURE USP_GetCustomerSuitableHouse*/

/*chủ nhà thêm nhà bán mới PHANTOM 2*/
CREATE PROCEDURE USP_AddHouseForSale
@MaChiNhanh INT, @MaChuNha INT, @MaNhanVien INT, @MaLoai INT,  @SoLuongPhongO INT, @NgayHetHan DATETIME, @NgayDang DATETIME, @Duong NVARCHAR(40), @Quan NVARCHAR(40), @KhuVuc NVARCHAR(40), @ThanhPho NVARCHAR(40), @TinhTrang NVARCHAR(20), @SoLuotXem INT, @GiaBan INT, @DieuKien nvarchar(100)
AS
begin
	BEGIN TRAN
	DECLARE @MANHA INT
	INSERT INTO NHA (MACN, MACNHA, MANV, MALOAI, SOLUONGPHONGO, NGAYHETHAN, NGAYDANG, DUONG, QUAN, KHUVUC, THANHPHO, TINHTRANG, SOLUOTXEM)
	OUTPUT Inserted.MANHA
	VALUES (@MaChiNhanh, @MaChuNha, @MaNhanVien, @MaLoai, @SoLuongPhongO, @NgayHetHan, @NgayDang, @Duong, @Quan, @KhuVuc, @ThanhPho, @TinhTrang, @SoLuotXem)

	SET @MANHA = (SELECT SCOPE_IDENTITY())

	INSERT INTO CHITIETNHABAN(MANHA, MACN, GIABAN, DIEUKIEN)
	VALUES (@MANHA, @MaChiNhanh, @GiaBan, @DieuKien)
	COMMIT
end
go

/* DEADLOCK CONVERSION 1 / DEADLOCK CONVERSION 2 / DEADLOCK CONVERSION 3 ======================================================*/
/* DEADLOCK CONVERSION 1
t1 : chi nhánh 
t2 : công ty
cập nhật lương nhân viên cụ thể*/
CREATE PROCEDURE USP_UpdateSalaryStaff
@staffCode int, @newSalary float
AS
BEGIN
    set Tran isolation level serializable
	begin Tran
	declare @salary float;
	set @salary = (select LUONG from NHANVIEN where manv = @staffCode)
	waitfor delay '00:00:10'
	/* t2 : EXEC USP_UpdateSalaryStaff*/
	set @salary = @newSalary
	update NHANVIEN set LUONG = @salary where MANV = @staffCode
	commit Tran
END
GO

/* DEADLOCK CONVERSION 2
t1 : chi nhánh 
t2 : công ty
cập nhật loại nhà của nhà cụ thể*/
CREATE PROCEDURE USP_UpdateHouseTypeInHouse
@houseCode INT, @newHouseType INT
AS
BEGIN
	set Tran isolation level serializable
	begin Tran
	declare @houseType INT;
	set @houseType = (select MALOAI from NHA where MANHA = @houseCode)
	waitfor delay '00:00:10'
	/* t2 : công ty dô đổi*/
	set @houseType = @newHouseType
	update NHA set MALOAI = @houseType where MANHA = @houseCode
	commit Tran
END
GO

/* DEADLOCK CONVERSION 3
t1 : chi nhánh 
t2 : công ty
cập nhật giá nhà của nhà cụ thể*/
create proc USP_UpdateHousePrice(@agency int,
    @houseId int,
    @newPrice int)
as
begin
    set TRANSACTION ISOLATION LEVEL SERIALIZABLE
    begin tran
    declare @housePrice int;
    set @housePrice = (select GIATHUE
    from CHITIETNHATHUE
    where MANHA = @houseId and MACN = @agency)
    WAITFOR delay '00:00:10'
    set @housePrice = @newPrice
    update CHITIETNHATHUE set GIATHUE = @housePrice where MANHA = @houseId and MACN = @agency
    commit tran
end
GO

/* DEADLOCK CYCLE ======================================================*/
/*t1 : chi nhánh đổi loại nhà yêu cầu của khách*/
CREATE PROCEDURE USP_UpdateCustomerDemand
@customerCode int, @newHouseType int, @oldHouseType int, @agency int
AS
BEGIN
	set Tran isolation level serializable
	BEGIN Tran
	update YEUCAU set LOAINHAYEUCAU =  @newHouseType where MAKH =  @customerCode and LOAINHAYEUCAU = @oldHouseType and MACN = @agency

	waitfor delay '00:00:10'
	select kh.MAKH, kh.TEN, kh.DIACHI, kh.SDT , kh.CHITIET, yc.LOAINHAYEUCAU
	from KHACHHANG kh join YEUCAU yc on kh.MAKH = yc.MAKH and kh.MAKH = @customerCode
	COMMIT Tran
END
GO

/* t2 : công ty đổi thông tin khách hàng*/
CREATE  PROCEDURE USP_UpdateCustomerDetail
@customerCode int,@agency int, @CustomerName nvarchar(20), @address nvarchar(40), @detail nvarchar(50)
AS
BEGIN
	set Tran isolation level serializable
	BEGIN Tran
	update KHACHHANG set TEN =  @CustomerName , DIACHI =  @address ,  CHITIET = @detail where MAKH = @customerCode

	waitfor delay '00:00:10'
	select kh.MAKH, kh.TEN, kh.DIACHI, kh.SDT , kh.CHITIET, yc.LOAINHAYEUCAU
	from KHACHHANG kh inner join YEUCAU yc on kh.MAKH = yc.MAKH and kh.MAKH = @customerCode
	COMMIT Tran
END
GO
