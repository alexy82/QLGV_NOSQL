using MongoDB.Driver;
using QLGV_NOSQL.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGV_NOSQL.DO.GiangVien
{
	class GiangVien
	{
		public  BO.GiangVien.GiangVien LuuGiangVien(BO.GiangVien.GiangVien gv)
		{
			var collection = MongoDB<BO.GiangVien.GiangVien>.GetCollection(Config.GIANG_VIEN_COLLECTION);
			BO.GiangVien.GiangVien gvv = collection.Find(x => x.MaGv == gv.MaGv).SingleOrDefault();
			if (gvv == null)
			{
				collection.InsertOne(gv);
				return gv;
			}
			return gvv;
		}
		public List<BO.GiangVien.GiangVien> GetListOnLyGiangVien()
		{
			List<BO.GiangVien.GiangVien> dsGiangVien = new List<BO.GiangVien.GiangVien>();
			dsGiangVien = MongoDB<BO.GiangVien.GiangVien>.GetCollection(Config.GIANG_VIEN_COLLECTION)
							.Find(x => true)
							.Project<BO.GiangVien.GiangVien>("{ ho_gv:1, ten_gv:1, _id:1}")
							.ToList();
			return dsGiangVien;
		}
		public List<BO.GiangVien.GiangVien> GetGiangVienByName(string ten)
		{
			return MongoDB<BO.GiangVien.GiangVien>.GetCollection(Config.GIANG_VIEN_COLLECTION).Find(@"{ ""ten_gv"": /"+ten.Trim()+"/i}").Project<BO.GiangVien.GiangVien>("{ ho_gv:1, ten_gv:1, _id:1}")
							.ToList(); ;
		}
		public BO.GiangVien.GiangVien GetGiangVien(string id)
		{
			return MongoDB<BO.GiangVien.GiangVien>.GetCollection(Config.GIANG_VIEN_COLLECTION).Find(x => x.MaGv == id).SingleOrDefault();
		}
		public BO.GiangVien.GiangVien GetGiangVienDSLopHoc(string id)
		{
			return MongoDB<BO.GiangVien.GiangVien>.GetCollection(Config.GIANG_VIEN_COLLECTION).Find(x => x.MaGv == id).Project<BO.GiangVien.GiangVien>(@"{""danh_sach_lop_hoc.danh_sach_buoi_hoc"":0}").SingleOrDefault();
		}
	}
}
