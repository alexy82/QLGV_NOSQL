using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGV_NOSQL.BO.GiangVien
{
	public class GiangVien
	{

		[BsonId]
		public string MaGv { get; set; }
		[BsonElement("ho_gv")]
		public string HoGv { get; set; }
		[BsonElement("ten_gv")]
		public string TenGv { get; set; }
		[BsonElement("danh_sach_lop_hoc")]
		public List<LopHoc> DSLopHoc { get; set; }

	


		public string IsActive { get; set; }
		public string HoTenGV { get => HoGv + " " + TenGv; }
	
		


	}
	public class LopHoc
	{

		[BsonElement("ma_lop_hoc")]
		public int MaLopHoc { get; set; }
		[BsonElement("so_tiet")]
		public int SoTiet { get; set; }
		[BsonElement("lop")]
		public string Lop { get; set; }
		[BsonElement("thu")]
		public int Thu { get; set; }
		[BsonElement("tiet_bat_dau")]
		public int TietBd { get; set; }
		[BsonElement("ten_mon_hoc")]
		public string TenMonHoc { get; set; }
		[BsonElement("nhom")]
		public int Nhom { get; set; }
		[BsonElement("so_tin_chi")]
		public int SoTinChi { get; set; }
		[BsonElement("phong")]
		public string Phong { get; set; }
		[BsonElement("danh_sach_buoi_hoc")]
		public List<BuoiHoc> DSBuoiHoc { get; set; }

		public string NoiDung { get => "Thứ " + Thu + " Tiết " + TietBd + " Phòng " + Phong; }
		public string NoiDungLop { get => "Lớp " + Lop; }




	}
	public class BuoiHoc
	{
		[BsonElement("ngay_hoc")]
		public DateTime NgayHoc { get; set; }
		[BsonElement("trang_thai")]
		public string TrangThai { get; set; }
		[BsonElement("ghi_chu")]
		public string GhiChu { get; set; }
		[BsonElement("tiet_bat_dau")]
		public int TietBatDau { get; set; }
		[BsonElement("phong")]
		public string Phong { get; set; }
		[BsonElement("thu")]
		public int Thu { get; set; }
		[BsonElement("tuan_hoc")]
		public int TuanHoc { get; set; }
		[BsonElement("so_tiet")]
		public int SoTiet { get; set; }
		[BsonElement("buoi_hoc_bu")]
		public BuoiHocBu BuoiHocBu { get; set; }


	}
	public class BuoiHocBu
	{
		[BsonElement("ngay_hoc")]
		public DateTime NgayHoc { get; set; }
		[BsonElement("trang_thai")]
		public string TrangThai { get; set; }
		[BsonElement("ghi_chu")]
		public string GhiChu { get; set; }
		[BsonElement("tiet_bat_dau")]
		public int TietBatDau { get; set; }
		[BsonElement("phong")]
		public string Phong { get; set; }
		[BsonElement("thu")]
		public int Thu { get; set; }
		[BsonElement("tuan_hoc")]
		public int TuanHoc { get; set; }
		[BsonElement("so_tiet")]
		public int SoTiet { get; set; }


	}
	
}
