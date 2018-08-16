using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGV_NOSQL.BO.BuoiHoc
{
	
	public class BuoiHoc
	{
		[BsonId]
		public string _id { get; set; }
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
		[BsonElement("ma_gv")]
		public string MaGiangVien { get; set; }
		[BsonElement("ho_ten_gv")]
		public string HoTenGiangVien { get; set; }
		[BsonElement("ten_mon_hoc")]
		public string TenMonHoc { get; set; }

		public BuoiHoc()
		{
			_id =  "BuoiHoc_" + Guid.NewGuid().ToString();
		}
		


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
