using QLGV_NOSQL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLGV_NOSQL.Code;
using MongoDB.Driver;

namespace QLGV_NOSQL.DO.BuoiHoc
{
	class BuoiHoc
	{
		public void TaoBuoiHoc(BO.GiangVien.LopHoc lh,BO.GiangVien.GiangVien gv)
		{
			var configCollection = MongoDB<BO.ConfigSystem>.GetCollection(Config.CONFIG_COLLECTION);
			BO.ConfigSystem config = configCollection.Find(x => true).SingleOrDefault();

			DateTime ngayHoc = config.NgayBatDau;
			int thuNgayNhapHoc = Common.GetIntDayByDate(config.NgayBatDau);
			List<BO.BuoiHoc.BuoiHoc> dsBuoiHoc = new List<BO.BuoiHoc.BuoiHoc>();

			if (lh.Thu < thuNgayNhapHoc)
			{
				ngayHoc = ngayHoc.AddDays(7 - lh.Thu);
			}
			else ngayHoc = ngayHoc.AddDays(lh.Thu - thuNgayNhapHoc);

			for (int j = 0; j < config.SoBuoi; j++)
			{
				BO.BuoiHoc.BuoiHoc th = new BO.BuoiHoc.BuoiHoc()
				{
					NgayHoc = ngayHoc,
					Phong = lh.Phong,
					SoTiet = lh.SoTiet,
					Thu = lh.Thu,
					TuanHoc = j + 1,
					TietBatDau = lh.TietBd,
					HoTenGiangVien = gv.HoTenGV,
					MaGiangVien = gv.MaGv,
					TenMonHoc = lh.TenMonHoc
					


				};

				lh.DSBuoiHoc.Add(th._id);
				ngayHoc = ngayHoc.AddDays(7);
				dsBuoiHoc.Add(th);
			}
			LuuDSBuoiHoc(dsBuoiHoc);
		}
		public void LuuDSBuoiHoc(List<BO.BuoiHoc.BuoiHoc> dsBuoiHoc)
		{
		var collection =	MongoDB<BO.BuoiHoc.BuoiHoc>.GetCollection(Config.BUOI_HOC_COLLECTION);
			collection.InsertMany(dsBuoiHoc);
		}
		public List<BO.BuoiHoc.BuoiHoc> GetListBuoiHocByLopHoc(BO.GiangVien.LopHoc lh)
		{
			var collection = MongoDB<BO.BuoiHoc.BuoiHoc>.GetCollection(Config.BUOI_HOC_COLLECTION);
			List<BO.BuoiHoc.BuoiHoc>  listBuoiHoc = collection.Find(x => lh.DSBuoiHoc.Contains(x._id)).ToList();
			return listBuoiHoc;
			
		}
	}
}