using MongoDB.Bson;
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




		[BsonElement("so_buoi_day")]
		public int SoBuoiDay { get; set; }
		[BsonElement("vang")]
		public int Vang { get; set; }
		[BsonElement("di_tre")]
		public int DiTre { get; set; }
		[BsonElement("ve_som")]
		public int VeSom { get; set; }
		[BsonElement("nghi_le")]
		public int NghiLe { get; set; }
		
		[BsonElement("tong_so_buoi_day")]
		public int TongSoBuoiDay { get; set; }

		public int Thieu { get => TongSoBuoiDay - (Vang + NghiLe + SoBuoiDay); }





		public string TrangThai { get => Thieu != 0 ? string.Format("Số buổi vắng: {0} | Số buổi bù: {1} | Thiếu {2}", Vang + NghiLe, TongSoBuoiDay - SoBuoiDay, Thieu) : string.Format("Số buổi vắng: {0} | Số buổi bù: {1} | Đủ", Vang + NghiLe, TongSoBuoiDay - SoBuoiDay); }

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
		public List<string> DSBuoiHoc { get; set; }


		[BsonElement("so_buoi_day")]
		public int SoBuoiDay { get; set; }
		[BsonElement("vang")]
		public int Vang { get; set; }
		[BsonElement("di_tre")]
		public int DiTre { get; set; }
		[BsonElement("ve_som")]
		public int VeSom { get; set; }
		[BsonElement("nghi_le")]
		public int NghiLe { get; set; }
		[BsonElement("tong_so_buoi_day")]
		public int TongSoBuoiDay { get; set; }



		public int Thieu { get => TongSoBuoiDay - (Vang + NghiLe + SoBuoiDay); }


		public string TrangThai { get => Thieu != 0 ? string.Format("Số buổi vắng: {0} | Số buổi bù: {1} | Thiếu {2}", Vang + NghiLe, TongSoBuoiDay - SoBuoiDay, Thieu) : string.Format("Số buổi vắng: {0} | Số buổi bù: {1} | Đủ", Vang + NghiLe, TongSoBuoiDay - SoBuoiDay); }
		public string NoiDung { get => "Thứ " + Thu + " Tiết " + TietBd + " Phòng " + Phong; }
		public string NoiDungLop { get => "Lớp " + Lop; }




	}
	
	
}
