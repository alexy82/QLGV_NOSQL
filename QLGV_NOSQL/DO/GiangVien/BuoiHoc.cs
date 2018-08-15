using QLGV_NOSQL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLGV_NOSQL.Code;
using MongoDB.Driver;

namespace QLGV_NOSQL.DO.GiangVien
{
	class BuoiHoc
	{
		public void TaoBuoiHoc(BO.GiangVien.LopHoc lh)
		{
			var configCollection = MongoDB<BO.ConfigSystem>.GetCollection(Config.CONFIG_COLLECTION);
			BO.ConfigSystem config = configCollection.Find(x => true).SingleOrDefault();

			DateTime ngayHoc = config.NgayBatDau;
			int thuNgayNhapHoc = Common.GetIntDayByDate(config.NgayBatDau);

			if (lh.Thu < thuNgayNhapHoc)
			{
				ngayHoc = ngayHoc.AddDays(7 - lh.Thu);
			}
			else ngayHoc = ngayHoc.AddDays(lh.Thu - thuNgayNhapHoc);

			for (int j = 0; j < config.SoBuoi; j++)
			{
				BO.GiangVien.BuoiHoc th = new BO.GiangVien.BuoiHoc()
				{
					NgayHoc = ngayHoc,
					Phong = lh.Phong,
					SoTiet = lh.SoTiet,
					Thu = lh.Thu,
					TuanHoc = j + 1,
					TietBatDau = lh.TietBd
					

				};

				lh.DSBuoiHoc.Add(th);
				ngayHoc = ngayHoc.AddDays(7);
			}
		}
	}
}
