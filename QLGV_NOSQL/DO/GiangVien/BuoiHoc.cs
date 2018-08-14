using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGV_NOSQL.DO.GiangVien
{
	class BuoiHoc
	{
		public List<BuoiHoc> TaoBuoiHoc()
		{
			DateTime ngayNhapHoc = new DateTime(2018, 1, 2);
			int thuNgayNhapHoc = thu;

			if (lh.Thu < thuNgayNhapHoc)
			{
				ngayNhapHoc = ngayNhapHoc.AddDays(7 - lh.Thu);
			}
			else ngayNhapHoc = ngayNhapHoc.AddDays(lh.Thu - thuNgayNhapHoc);

			for (int j = 0; j < 15; j++)
			{
				BuoiHoc th = new BuoiHoc()
				{
					NgayHoc = ngayNhapHoc,
					Phong = tenPhong,
					SoTiet = soTiet,
					TietBatDau = tietBatDau,
					Thu = thu,
					TrangThai = "BINH_THUONG",
					TuanHoc = j + 1,

				};

				lh.DSBuoiHoc.Add(th);
				ngayNhapHoc = ngayNhapHoc.AddDays(7);
			}
		}
	}
}
