CREATE PROCEDURE SuaDV(
	@MaDV char(10),
	@TenDV nvarchar(50),
	@DonGia float
	)
as
begin
	update DICHVU
	set TenDV = @TenDV, DonGia = @DonGia
	where MaDV = @MaDV
end

create procedure ThemDV(
	@MaDV char(10),
	@TenDV nvarchar(50),
	@DonGia float)
as
begin 
	insert into DICHVU(MaDV, TenDV, DonGia) values (@MaDV, @TenDV, @DonGia)
end

create procedure XoaDV(
	@MaDV char(10))
as
begin
	delete from DICHVU
	where MaDV = @MaDV
end

alter procedure TimkiemDV(
	@MaDV char(10),
	@TenDV nvarchar(50),
	@DonGia float)
as
begin
	select * 
	from DICHVU
	where (@MaDV is null or MaDV like '%' + @MaDV +'%')
		and (@TenDV is null or TenDV like '%' + @TenDV +'%')
		and (@DonGia is null or DonGia = @DonGia )
end

ThemDV '1','2','3'
select *from DICHVU

alter proc ThemPSDDV(
	@MaPhieuSDDV char(10),
	@TongTienDV float,
	@ThangSD date,
	@SoDV int,
	@MaHopDong char(10),
	@MaHoaDonDV char(10))
as
begin
	insert into PHIEUSDDV(MaPhieuSDDV, TongTienDV, ThangSD, SoDV, MaHopDong, MaHoaDonDV) values (@MaPhieuSDDV, @TongTienDV, @ThangSD, @SoDV, @MaHopDong, @MaHoaDonDV)
end

alter proc SuaPSDDV(
	@MaPhieuSDDV char(10),
	@TongTienDV float,
	@ThangSD date,
	@SoDV int,
	@MaHopDong char(10),
	@MaHoaDonDV char(10))
as
begin
	update PHIEUSDDV
	set TongTienDV = @TongTienDV,
		ThangSD = @ThangSD,
		SoDV = @SoDV,
		MaHopDong = @MaHopDong,
		MaHoaDonDV = @MaHoaDonDV
	where MaPhieuSDDV = @MaPhieuSDDV
end

alter proc XoaPSDDV(@MaPhieuSDDV char(10))
as
begin 
	delete from PHIEUSDDV
	where MaPhieuSDDV = @MaPhieuSDDV
end

alter procedure TimkiemPSDDV(
	@MaPhieuSDDV char(10),
	@TongTienDV float,
	@ThangSD date,
	@SoDV int,
	@MaHopDong char(10),
	@MaHoaDonDV char(10))
as
begin
	select * 
	from PHIEUSDDV
	where (@MaPhieuSDDV is null or MaPhieuSDDV like '%' + @MaPhieuSDDV +'%')
		and (@TongTienDV is null or TongTienDV =  @TongTienDV)
		and (@ThangSD is null or ThangSD = @ThangSD  )
		and (@SoDV is null or SoDV = @SoDV)
		and (@MaHopDong is null or MaHopDong like '%' + @MaHopDong +'%')
		and (@MaHoaDonDV is null or MaHoaDonDV like '%' + @MaHoaDonDV +'%')
end
select * from PHIEUSDDV
insert into HOPDONG(MaHopDong) values ('4'),('5'),('6')
insert into HOADONDICHVU(MaHoaDonDV) values ('5'),('6'),('7')

alter proc ThemPSDNuoc(
	@MaPhieuSDNuoc char(10),
	@CSCu int,
	@CSMoi int,
	@DonGia float,
	@ThangSD date,
	@MaHopDong char(10),
	@MaHoaDonDV char(10))
as
begin
	insert into PHIEUSDNUOC(MaPhieuSDNuoc, CSCu, CSMoi, DonGia, ThangSD, MaHopDong, MaHoaDonDV) values (@MaPhieuSDNuoc, @CSCu, @CSMoi, @DonGia, @ThangSD, @MaHopDong, @MaHoaDonDV)
end

alter proc SuaPSDNuoc(
	@MaPhieuSDNuoc char(10),
	@CSCu int,
	@CSMoi int,
	@DonGia float,
	@ThangSD date,
	@MaHopDong char(10),
	@MaHoaDonDV char(10))
as
begin 
	update PHIEUSDNUOC
	set 
	CSCu = @CSCu,
	CSMoi = @CSMoi,
	DonGia = @DonGia,
	ThangSD = @ThangSD,
	MaHopDong = @MaHopDong,
	MaHoaDonDV = @MaHoaDonDV
	where MaPhieuSDNuoc = @MaPhieuSDNuoc
end

create proc XoaPSDNuoc( @MaPhieuSDNuoc char(10))
as
begin
	delete from PHIEUSDNUOC
	where MaPhieuSDNuoc = @MaPhieuSDNuoc
end

CREATE PROCEDURE TimkiemPSDNuoc(
    @MaPhieuSDNuoc char(10),
	@CSCu int,
	@CSMoi int,
	@DonGia float,
	@ThangSD date,
	@ThanhTien float,
	@MaHopDong char(10),
	@MaHoaDonDV char(10))
AS
BEGIN
    SELECT *
    FROM PHIEUSDNUOC
    WHERE (@MaPhieuSDNuoc IS NULL OR MaPhieuSDNuoc like '%' +@MaPhieuSDNuoc+'%')
      AND (@CSCu IS NULL OR CSCu = @CSCu)
      AND (@CSMoi IS NULL OR CSMoi = @CSMoi)
	  and (@DonGia is null or DonGia = @DonGia)
      AND (@ThanhTien IS NULL OR ThanhTien = @ThanhTien)
      AND (@ThangSD IS NULL OR ThangSD = @ThangSD)
      AND (@MaHopDong IS NULL OR MaHopDong like '%'+ @MaHopDong+'%')
      AND (@MaHoaDonDV IS NULL OR MaHoaDonDV like '%'+ @MaHoaDonDV+'%')
END

create proc ThemPSDDien(
	@MaPhieuSDDien char(10),
	@CSCu int,
	@CSMoi int,
	@DonGia float,
	@ThangSD date,
	@ThanhTien float,
	@MaHopDong char(10),
	@MaHoaDonDV char(10))
as
begin
	insert into PHIEUSDDIEN(MaPhieuSDDien, CSCu, CSMoi, DonGia, ThangSD, ThanhTien, MaHopDong, MaHoaDonDV) values (@MaPhieuSDDien, @CSCu, @CSMoi, @DonGia, @ThangSD, @ThanhTien, @MaHopDong, @MaHoaDonDV)
end

create proc SuaPSDDien(
	@MaPhieuSDDien char(10),
	@CSCu int,
	@CSMoi int,
	@DonGia float,
	@ThangSD date,
	@ThanhTien float,
	@MaHopDong char(10),
	@MaHoaDonDV char(10))
as
begin 
	update PHIEUSDDIEN
	set
	CSCu = @CSCu,
	CSMoi = @CSMoi,
	DonGia = @DonGia,
	ThangSD = @ThangSD,
	ThanhTien = @ThanhTien,
	MaHopDong = @MaHopDong,
	MaHoaDonDV = @MaHoaDonDV
	where MaPhieuSDDien = @MaPhieuSDDien
end

create proc XoaPSDDien( @MaPhieuSDDien char(10))
as
begin
	delete from PHIEUSDDIEN
	where MaPhieuSDDien = @MaPhieuSDDien
end

CREATE PROCEDURE TimkiemPSDDien(
    @MaPhieuSDDien char(10),
	@CSCu int,
	@CSMoi int,
	@DonGia float,
	@ThangSD date,
	@ThanhTien float,
	@MaHopDong char(10),
	@MaHoaDonDV char(10))
AS
BEGIN
    SELECT *
    FROM PHIEUSDDIEN
    WHERE (@MaPhieuSDDien IS NULL OR MaPhieuSDDien like '%' +@MaPhieuSDDien+'%')
      AND (@CSCu IS NULL OR CSCu = @CSCu)
      AND (@CSMoi IS NULL OR CSMoi = @CSMoi)
	  and (@DonGia is null or DonGia = @DonGia)
      AND (@ThanhTien IS NULL OR ThanhTien = @ThanhTien)
      AND (@ThangSD IS NULL OR ThangSD = @ThangSD)
      AND (@MaHopDong IS NULL OR MaHopDong like '%'+ @MaHopDong+'%')
      AND (@MaHoaDonDV IS NULL OR MaHoaDonDV like '%'+ @MaHoaDonDV+'%')
END
delete from PHIEUSDDV

CREATE TRIGGER dbo.Trigger_ThanhTien_PHIEUSDNUOC
ON dbo.PHIEUSDNUOC
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.PHIEUSDNUOC
    SET ThanhTien = (i.CSMoi - i.CSCu) * i.DonGia
    FROM dbo.PHIEUSDNUOC p
    INNER JOIN inserted i ON p.MaPhieuSDNuoc = i.MaPhieuSDNuoc;
END

CREATE TRIGGER dbo.Trigger_ThanhTien_PHIEUSDDIEN
ON dbo.PHIEUSDDIEN
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.PHIEUSDDIEN
    SET ThanhTien = (i.CSMoi - i.CSCu) * i.DonGia
    FROM dbo.PHIEUSDDIEN p
    INNER JOIN inserted i ON p.MaPhieuSDDien = i.MaPhieuSDDien;
END;
update Phieusdnuoc
set Thanhtien = (CSmoi - cscu)*DonGia

select * from phieusddien