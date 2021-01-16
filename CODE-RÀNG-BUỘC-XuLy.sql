use QUANLYNHADAT2
go
--Chi nhánh
ALTER TABLE DBO.CHINHANH
ADD CONSTRAINT UniqueConstraintChiNhanh UNIQUE(SDT, DIACHI, FAX);
--Nhân viên
ALTER TABLE DBO.NHANVIEN
ADD CONSTRAINT UniqueConstraintNhanVien UNIQUE(SDT);
--Chủ nhà
ALTER TABLE DBO.CHUNHA
ADD CONSTRAINT UniqueConstraintChuNha UNIQUE(SDT);
--Chi tiết nhà thuê
ALTER TABLE dbo.CHITIETNHATHUE
ADD CONSTRAINT C_CHITIETNHATHUE_GIATHUE CHECK(GIATHUE > 0);
--Nhà
ALTER TABLE dbo.NHA
ADD CONSTRAINT C_NHA_SOLUONGPHONGO CHECK(SOLUONGPHONGO > 0);
ALTER TABLE dbo.NHA
ADD CONSTRAINT C_NHA_TINHTRANG CHECK(TINHTRANG = 0
                                                OR TINHTRANG = 1);
ALTER TABLE dbo.NHA
ADD CONSTRAINT C_NHA_NGAYDANG CHECK(TINHTRANG = 1 AND NGAYDANG < NGAYHETHAN OR TINHTRANG=0 AND	NGAYHETHAN IS NULL);


ALTER TABLE dbo.NHA
ADD CONSTRAINT C_NHA_NGAYHETHAN CHECK((TINHTRANG = 0
                                                  AND NGAYHETHAN IS NULL)
                                                 OR (TINHTRANG = 1
                                                     AND NGAYHETHAN > NGAYDANG));
ALTER TABLE dbo.NHA
ADD CONSTRAINT C_NHA_SOLUOTXEM CHECK(SOLUOTXEM > 0);
--Chi tiết nhà bán
ALTER TABLE dbo.CHITIETNHABAN
ADD CONSTRAINT C_CHITIETNHABAN_GIABAN CHECK(GIABAN > 0);

--Khách hàng
ALTER TABLE dbo.KHACHHANG
ADD CONSTRAINT UniqueConstraintSdt UNIQUE(SDT);

--Kế hoạch xem nhà
GO
CREATE TRIGGER Prevent_Duplicate_Time_KEHOACHXEMNHA ON KEHOACHXEMNHA
INSTEAD OF INSERT
AS
     BEGIN
         DECLARE @MANHA INT;
         DECLARE @MACN INT;
         DECLARE @TINHTRANG INT;
         DECLARE @NGAYXEM DATETIME;
         SELECT @MANHA = MANHA, 
                @MACN = MACN
         FROM inserted;
         SELECT TOP (1) @NGAYXEM = NGAYXEM
         FROM dbo.KEHOACHXEMNHA
         WHERE MACN = @MACN
               AND MANHA = @MACN
         ORDER BY NGAYXEM DESC;

		 SELECT @TINHTRANG = TINHTRANG
         FROM dbo.NHA
         WHERE MANHA = @MANHA
              AND MACN = @MACN;

         IF(@TINHTRANG = 1)
             BEGIN
                 RETURN;
             END;
         IF(@NGAYXEM =
         (
             SELECT TOP(1) NGAYXEM
             FROM inserted
			 ORDER BY Inserted.NGAYXEM
         ))
             BEGIN
                 RETURN;
             END;
         IF(@TINHTRANG = 0)
             BEGIN
                 INSERT INTO dbo.KEHOACHXEMNHA
                 (MAKH, 
                  MANV, 
                  MANHA, 
                  MACN, 
                  NGAYXEM, 
                  NHANXET
                 )
                        SELECT Inserted.MAKH,
                               Inserted.MANV,
                               Inserted.MANHA,
                               Inserted.MACN,
                               Inserted.NGAYXEM,
                               Inserted.NHANXET
                        FROM inserted;
             END;
     END;
GO
--Hợp đồng 
CREATE TRIGGER Check_Insert_HOPDONG ON HOPDONG
INSTEAD OF INSERT
AS
     BEGIN
         DECLARE @MANHA INT;
         DECLARE @MACN INT;
         DECLARE @TINHTRANG INT;
         DECLARE @NGAYLAP DATETIME;
         DECLARE @NGAYDANG DATETIME;
         SELECT @MANHA = MANHA, 
                @MACN = MACN, 
                @NGAYLAP = NGAYLAP
         FROM inserted;
		SELECT @TINHTRANG = TINHTRANG, 
                    @NGAYDANG = NGAYDANG
             FROM dbo.NHA
             WHERE MANHA = @MANHA
                   AND MACN = @MACN;
         IF(@TINHTRANG = 1)
             BEGIN
                 RETURN;
             END;
         IF(@TINHTRANG = 0)
             BEGIN
                 INSERT INTO dbo.HOPDONG
                 (MAHD, 
                  MAKH, 
                  MANHA, 
                  MACN, 
                  NGAYLAP, 
                  GHICHU
                 )
                        SELECT Inserted.MAHD,
                               Inserted.MAKH,
                               Inserted.MANHA,
                               Inserted.MACN,
                               Inserted.NGAYLAP,
                               Inserted.GHICHU
                        FROM inserted;
                 IF(@NGAYDANG > @NGAYLAP)
                     BEGIN
                         RETURN;
                     END;
                 IF EXISTS(SELECT * FROM dbo.CHITIETNHATHUE WHERE MANHA = @MANHA AND MACN = @MACN)
                     BEGIN
                         UPDATE dbo.NHA
                           SET 
                               TINHTRANG = 1, 
                               NGAYHETHAN = @NGAYLAP
                         WHERE MANHA = @MANHA
                               AND MACN = @MACN;
                     END;
             END;
     END;
GO