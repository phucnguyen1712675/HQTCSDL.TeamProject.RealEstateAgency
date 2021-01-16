﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HQTCSDL.TeamProject.RealEstateAgency
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QUANLYNHADATEntities : DbContext
    {
        public QUANLYNHADATEntities()
            : base("name=QUANLYNHADATEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CHINHANH> CHINHANHs { get; set; }
        public virtual DbSet<CHITIETNHABAN> CHITIETNHABANs { get; set; }
        public virtual DbSet<CHITIETNHATHUE> CHITIETNHATHUEs { get; set; }
        public virtual DbSet<CHUNHA> CHUNHAs { get; set; }
        public virtual DbSet<HOPDONG> HOPDONGs { get; set; }
        public virtual DbSet<KEHOACHXEMNHA> KEHOACHXEMNHAs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAINHA> LOAINHAs { get; set; }
        public virtual DbSet<NHA> NHAs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<YEUCAU> YEUCAUs { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<USP_Temp_Result> USP_Temp()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_Temp_Result>("USP_Temp");
        }
    
        public virtual ObjectResult<USP_Temp2_Result> USP_Temp2(Nullable<int> @int)
        {
            var intParameter = @int.HasValue ?
                new ObjectParameter("int", @int) :
                new ObjectParameter("int", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_Temp2_Result>("USP_Temp2", intParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> USP_AddHouseForRent(Nullable<int> maChiNhanh, Nullable<int> maChuNha, Nullable<int> maNhanVien, Nullable<int> maLoai, Nullable<int> soLuongPhongO, Nullable<System.DateTime> ngayHetHan, Nullable<System.DateTime> ngayDang, string duong, string quan, string khuVuc, string thanhPho, string tinhTrang, Nullable<int> soLuotXem, Nullable<int> giaThue)
        {
            var maChiNhanhParameter = maChiNhanh.HasValue ?
                new ObjectParameter("MaChiNhanh", maChiNhanh) :
                new ObjectParameter("MaChiNhanh", typeof(int));
    
            var maChuNhaParameter = maChuNha.HasValue ?
                new ObjectParameter("MaChuNha", maChuNha) :
                new ObjectParameter("MaChuNha", typeof(int));
    
            var maNhanVienParameter = maNhanVien.HasValue ?
                new ObjectParameter("MaNhanVien", maNhanVien) :
                new ObjectParameter("MaNhanVien", typeof(int));
    
            var maLoaiParameter = maLoai.HasValue ?
                new ObjectParameter("MaLoai", maLoai) :
                new ObjectParameter("MaLoai", typeof(int));
    
            var soLuongPhongOParameter = soLuongPhongO.HasValue ?
                new ObjectParameter("SoLuongPhongO", soLuongPhongO) :
                new ObjectParameter("SoLuongPhongO", typeof(int));
    
            var ngayHetHanParameter = ngayHetHan.HasValue ?
                new ObjectParameter("NgayHetHan", ngayHetHan) :
                new ObjectParameter("NgayHetHan", typeof(System.DateTime));
    
            var ngayDangParameter = ngayDang.HasValue ?
                new ObjectParameter("NgayDang", ngayDang) :
                new ObjectParameter("NgayDang", typeof(System.DateTime));
    
            var duongParameter = duong != null ?
                new ObjectParameter("Duong", duong) :
                new ObjectParameter("Duong", typeof(string));
    
            var quanParameter = quan != null ?
                new ObjectParameter("Quan", quan) :
                new ObjectParameter("Quan", typeof(string));
    
            var khuVucParameter = khuVuc != null ?
                new ObjectParameter("KhuVuc", khuVuc) :
                new ObjectParameter("KhuVuc", typeof(string));
    
            var thanhPhoParameter = thanhPho != null ?
                new ObjectParameter("ThanhPho", thanhPho) :
                new ObjectParameter("ThanhPho", typeof(string));
    
            var tinhTrangParameter = tinhTrang != null ?
                new ObjectParameter("TinhTrang", tinhTrang) :
                new ObjectParameter("TinhTrang", typeof(string));
    
            var soLuotXemParameter = soLuotXem.HasValue ?
                new ObjectParameter("SoLuotXem", soLuotXem) :
                new ObjectParameter("SoLuotXem", typeof(int));
    
            var giaThueParameter = giaThue.HasValue ?
                new ObjectParameter("GiaThue", giaThue) :
                new ObjectParameter("GiaThue", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("USP_AddHouseForRent", maChiNhanhParameter, maChuNhaParameter, maNhanVienParameter, maLoaiParameter, soLuongPhongOParameter, ngayHetHanParameter, ngayDangParameter, duongParameter, quanParameter, khuVucParameter, thanhPhoParameter, tinhTrangParameter, soLuotXemParameter, giaThueParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> USP_AddHouseForSale(Nullable<int> maChiNhanh, Nullable<int> maChuNha, Nullable<int> maNhanVien, Nullable<int> maLoai, Nullable<int> soLuongPhongO, Nullable<System.DateTime> ngayHetHan, Nullable<System.DateTime> ngayDang, string duong, string quan, string khuVuc, string thanhPho, string tinhTrang, Nullable<int> soLuotXem, Nullable<int> giaBan, string dieuKien)
        {
            var maChiNhanhParameter = maChiNhanh.HasValue ?
                new ObjectParameter("MaChiNhanh", maChiNhanh) :
                new ObjectParameter("MaChiNhanh", typeof(int));
    
            var maChuNhaParameter = maChuNha.HasValue ?
                new ObjectParameter("MaChuNha", maChuNha) :
                new ObjectParameter("MaChuNha", typeof(int));
    
            var maNhanVienParameter = maNhanVien.HasValue ?
                new ObjectParameter("MaNhanVien", maNhanVien) :
                new ObjectParameter("MaNhanVien", typeof(int));
    
            var maLoaiParameter = maLoai.HasValue ?
                new ObjectParameter("MaLoai", maLoai) :
                new ObjectParameter("MaLoai", typeof(int));
    
            var soLuongPhongOParameter = soLuongPhongO.HasValue ?
                new ObjectParameter("SoLuongPhongO", soLuongPhongO) :
                new ObjectParameter("SoLuongPhongO", typeof(int));
    
            var ngayHetHanParameter = ngayHetHan.HasValue ?
                new ObjectParameter("NgayHetHan", ngayHetHan) :
                new ObjectParameter("NgayHetHan", typeof(System.DateTime));
    
            var ngayDangParameter = ngayDang.HasValue ?
                new ObjectParameter("NgayDang", ngayDang) :
                new ObjectParameter("NgayDang", typeof(System.DateTime));
    
            var duongParameter = duong != null ?
                new ObjectParameter("Duong", duong) :
                new ObjectParameter("Duong", typeof(string));
    
            var quanParameter = quan != null ?
                new ObjectParameter("Quan", quan) :
                new ObjectParameter("Quan", typeof(string));
    
            var khuVucParameter = khuVuc != null ?
                new ObjectParameter("KhuVuc", khuVuc) :
                new ObjectParameter("KhuVuc", typeof(string));
    
            var thanhPhoParameter = thanhPho != null ?
                new ObjectParameter("ThanhPho", thanhPho) :
                new ObjectParameter("ThanhPho", typeof(string));
    
            var tinhTrangParameter = tinhTrang != null ?
                new ObjectParameter("TinhTrang", tinhTrang) :
                new ObjectParameter("TinhTrang", typeof(string));
    
            var soLuotXemParameter = soLuotXem.HasValue ?
                new ObjectParameter("SoLuotXem", soLuotXem) :
                new ObjectParameter("SoLuotXem", typeof(int));
    
            var giaBanParameter = giaBan.HasValue ?
                new ObjectParameter("GiaBan", giaBan) :
                new ObjectParameter("GiaBan", typeof(int));
    
            var dieuKienParameter = dieuKien != null ?
                new ObjectParameter("DieuKien", dieuKien) :
                new ObjectParameter("DieuKien", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("USP_AddHouseForSale", maChiNhanhParameter, maChuNhaParameter, maNhanVienParameter, maLoaiParameter, soLuongPhongOParameter, ngayHetHanParameter, ngayDangParameter, duongParameter, quanParameter, khuVucParameter, thanhPhoParameter, tinhTrangParameter, soLuotXemParameter, giaBanParameter, dieuKienParameter);
        }
    
        public virtual ObjectResult<USP_IsPriceIncreases_Result> USP_IsPriceIncreases(Nullable<double> ratio, Nullable<int> minium, Nullable<int> agency)
        {
            var ratioParameter = ratio.HasValue ?
                new ObjectParameter("ratio", ratio) :
                new ObjectParameter("ratio", typeof(double));
    
            var miniumParameter = minium.HasValue ?
                new ObjectParameter("minium", minium) :
                new ObjectParameter("minium", typeof(int));
    
            var agencyParameter = agency.HasValue ?
                new ObjectParameter("agency", agency) :
                new ObjectParameter("agency", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_IsPriceIncreases_Result>("USP_IsPriceIncreases", ratioParameter, miniumParameter, agencyParameter);
        }
    
        public virtual int USP_UpdateHouseInHouseType_Test(Nullable<int> houseCode, Nullable<int> newHouseType)
        {
            var houseCodeParameter = houseCode.HasValue ?
                new ObjectParameter("houseCode", houseCode) :
                new ObjectParameter("houseCode", typeof(int));
    
            var newHouseTypeParameter = newHouseType.HasValue ?
                new ObjectParameter("newHouseType", newHouseType) :
                new ObjectParameter("newHouseType", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_UpdateHouseInHouseType_Test", houseCodeParameter, newHouseTypeParameter);
        }
    
        public virtual ObjectResult<USP_TEST_AGENCY_GetHouse_Result> USP_TEST_AGENCY_GetHouse(Nullable<int> agency)
        {
            var agencyParameter = agency.HasValue ?
                new ObjectParameter("agency", agency) :
                new ObjectParameter("agency", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_TEST_AGENCY_GetHouse_Result>("USP_TEST_AGENCY_GetHouse", agencyParameter);
        }
    
        public virtual int USP_TEST_AGENCY_UpdateHouseInformation(Nullable<int> houseID, Nullable<System.DateTime> ngayhethan, Nullable<System.DateTime> ngaydang, string tinhtrang)
        {
            var houseIDParameter = houseID.HasValue ?
                new ObjectParameter("houseID", houseID) :
                new ObjectParameter("houseID", typeof(int));
    
            var ngayhethanParameter = ngayhethan.HasValue ?
                new ObjectParameter("ngayhethan", ngayhethan) :
                new ObjectParameter("ngayhethan", typeof(System.DateTime));
    
            var ngaydangParameter = ngaydang.HasValue ?
                new ObjectParameter("ngaydang", ngaydang) :
                new ObjectParameter("ngaydang", typeof(System.DateTime));
    
            var tinhtrangParameter = tinhtrang != null ?
                new ObjectParameter("tinhtrang", tinhtrang) :
                new ObjectParameter("tinhtrang", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_TEST_AGENCY_UpdateHouseInformation", houseIDParameter, ngayhethanParameter, ngaydangParameter, tinhtrangParameter);
        }
    
        public virtual int USP_USER_DeleteHouse(Nullable<int> houseId)
        {
            var houseIdParameter = houseId.HasValue ?
                new ObjectParameter("houseId", houseId) :
                new ObjectParameter("houseId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_USER_DeleteHouse", houseIdParameter);
        }
    
        public virtual int USP_UpdateRentHouseHouseInPrice_Test(Nullable<double> ratio, Nullable<int> minium, Nullable<int> agency)
        {
            var ratioParameter = ratio.HasValue ?
                new ObjectParameter("ratio", ratio) :
                new ObjectParameter("ratio", typeof(double));
    
            var miniumParameter = minium.HasValue ?
                new ObjectParameter("minium", minium) :
                new ObjectParameter("minium", typeof(int));
    
            var agencyParameter = agency.HasValue ?
                new ObjectParameter("agency", agency) :
                new ObjectParameter("agency", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_UpdateRentHouseHouseInPrice_Test", ratioParameter, miniumParameter, agencyParameter);
        }
    
        public virtual int USP_UpdateSaleHouseHouseInPrice_Test(Nullable<double> ratio, Nullable<int> minium, Nullable<int> agency)
        {
            var ratioParameter = ratio.HasValue ?
                new ObjectParameter("ratio", ratio) :
                new ObjectParameter("ratio", typeof(double));
    
            var miniumParameter = minium.HasValue ?
                new ObjectParameter("minium", minium) :
                new ObjectParameter("minium", typeof(int));
    
            var agencyParameter = agency.HasValue ?
                new ObjectParameter("agency", agency) :
                new ObjectParameter("agency", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_UpdateSaleHouseHouseInPrice_Test", ratioParameter, miniumParameter, agencyParameter);
        }
    
        public virtual ObjectResult<USP_GetCustomerSuitableHouse_Result> USP_GetCustomerSuitableHouse(Nullable<int> houseType, Nullable<int> agency)
        {
            var houseTypeParameter = houseType.HasValue ?
                new ObjectParameter("houseType", houseType) :
                new ObjectParameter("houseType", typeof(int));
    
            var agencyParameter = agency.HasValue ?
                new ObjectParameter("agency", agency) :
                new ObjectParameter("agency", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GetCustomerSuitableHouse_Result>("USP_GetCustomerSuitableHouse", houseTypeParameter, agencyParameter);
        }
    
        public virtual int USP_UpdateHousePrice(Nullable<int> agency, Nullable<int> houseId, Nullable<int> newPrice)
        {
            var agencyParameter = agency.HasValue ?
                new ObjectParameter("agency", agency) :
                new ObjectParameter("agency", typeof(int));
    
            var houseIdParameter = houseId.HasValue ?
                new ObjectParameter("houseId", houseId) :
                new ObjectParameter("houseId", typeof(int));
    
            var newPriceParameter = newPrice.HasValue ?
                new ObjectParameter("newPrice", newPrice) :
                new ObjectParameter("newPrice", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_UpdateHousePrice", agencyParameter, houseIdParameter, newPriceParameter);
        }
    
        public virtual int USP_UpdateHouseTypeInHouse(Nullable<int> houseCode, Nullable<int> newHouseType)
        {
            var houseCodeParameter = houseCode.HasValue ?
                new ObjectParameter("houseCode", houseCode) :
                new ObjectParameter("houseCode", typeof(int));
    
            var newHouseTypeParameter = newHouseType.HasValue ?
                new ObjectParameter("newHouseType", newHouseType) :
                new ObjectParameter("newHouseType", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_UpdateHouseTypeInHouse", houseCodeParameter, newHouseTypeParameter);
        }
    
        public virtual int USP_UpdateSalaryStaff(Nullable<int> staffCode, Nullable<double> newSalary)
        {
            var staffCodeParameter = staffCode.HasValue ?
                new ObjectParameter("staffCode", staffCode) :
                new ObjectParameter("staffCode", typeof(int));
    
            var newSalaryParameter = newSalary.HasValue ?
                new ObjectParameter("newSalary", newSalary) :
                new ObjectParameter("newSalary", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_UpdateSalaryStaff", staffCodeParameter, newSalaryParameter);
        }
    
        public virtual ObjectResult<USP_UpdateCustomerDemand_Result> USP_UpdateCustomerDemand(Nullable<int> customerCode, Nullable<int> newHouseType, Nullable<int> oldHouseType, Nullable<int> agency)
        {
            var customerCodeParameter = customerCode.HasValue ?
                new ObjectParameter("customerCode", customerCode) :
                new ObjectParameter("customerCode", typeof(int));
    
            var newHouseTypeParameter = newHouseType.HasValue ?
                new ObjectParameter("newHouseType", newHouseType) :
                new ObjectParameter("newHouseType", typeof(int));
    
            var oldHouseTypeParameter = oldHouseType.HasValue ?
                new ObjectParameter("oldHouseType", oldHouseType) :
                new ObjectParameter("oldHouseType", typeof(int));
    
            var agencyParameter = agency.HasValue ?
                new ObjectParameter("agency", agency) :
                new ObjectParameter("agency", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_UpdateCustomerDemand_Result>("USP_UpdateCustomerDemand", customerCodeParameter, newHouseTypeParameter, oldHouseTypeParameter, agencyParameter);
        }
    
        public virtual ObjectResult<USP_UpdateCustomerDetail_Result> USP_UpdateCustomerDetail(Nullable<int> customerCode, Nullable<int> agency, string customerName, string address, string detail)
        {
            var customerCodeParameter = customerCode.HasValue ?
                new ObjectParameter("customerCode", customerCode) :
                new ObjectParameter("customerCode", typeof(int));
    
            var agencyParameter = agency.HasValue ?
                new ObjectParameter("agency", agency) :
                new ObjectParameter("agency", typeof(int));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var detailParameter = detail != null ?
                new ObjectParameter("detail", detail) :
                new ObjectParameter("detail", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_UpdateCustomerDetail_Result>("USP_UpdateCustomerDetail", customerCodeParameter, agencyParameter, customerNameParameter, addressParameter, detailParameter);
        }
    }
}
