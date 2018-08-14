using QLGV_NOSQL.BO;
using QLGV_NOSQL.BO.GiangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGV_NOSQL.Code
{
	class LuuDuLieu
	{
		static void LuuCSDL(object[,] dt,DateTime ngayBatDau,DateTime ngayKetThuc,int soBuoi)
		{
			ConfigSystem config = new ConfigSystem()
			{
				NgayBatDau = ngayBatDau,
				NgayKetThuc = ngayKetThuc,
				SoBuoi = soBuoi
			};
			//save 
			MongoDB<ConfigSystem>.GetCollection(Config.CONFIG_COLLECTION).InsertOne(config);

			//Luu thong tin buôi hoc
			for (int i = 2; i < dt.GetLength(0); i++)
			{
				//các thự tự column trong excel
				/*column:
                1 : thứ
                2 : tiết bắt đầu
                3 : số tiết
                4 : phòng
                5 : mã môn học
                6 : mã nhân viên
                7 : tên môn học
                8 : họ lót nhân viên
                9 : tên nhân viên
                10: mã lớp(của sinh viên)
                13: mã lớp học
                */
				if (string.IsNullOrEmpty(dt[i, 6].ToString())) continue;
				int thu = int.Parse(dt[i, 1].ToString());
				int tietBatDau = int.Parse(dt[i, 2].ToString());
				int soTiet = int.Parse(dt[i, 3].ToString());
				string phong = dt[i, 4].ToString();
				string maMonHoc = dt[i, 5].ToString();
				string maGv = dt[i, 6].ToString();
				string tenMh = dt[i, 7].ToString();
				string hoLotGv = dt[i, 8].ToString();
				string tenGv = dt[i, 9].ToString();
				string maLop = dt[i, 10].ToString();
				int maLopHoc = int.Parse(dt[i, 13].ToString());
				//new GiangVien(họ lót, tên , mã)
				
				GiangVien gv = new GiangVien()
				{
					HoGv = hoLotGv,
					TenGv = tenGv,
					MaGv = maGv,
					DSLopHoc = new List<LopHoc>()
				};
				//Lưu giảng viên

				
				LopHoc lh = new LopHoc()
				{
					Lop = maLop,
					MaLopHoc = maLopHoc,
					SoTiet = soTiet,
					TenMonHoc = tenMh,
					Thu = thu,
					TietBd = tietBatDau,
					Phong = phong,
					DSBuoiHoc = new List<BuoiHoc>()

				};


				

				saveLopHoc(gv, lh);
			}
			//// new MonHoc(Mã môn học, tên môn học)
			// MonHoc mh = new MonHoc(maMonHoc, tenMh);
			// MonHocDAO.Instance.ThemDuLieu(mh);

			// //public LopHoc (int maLopHoc, int thu, int tietBd, int soTiet, string lop, GiangVien gv, MonHoc mh)
			// LopHoc lh = new LopHoc(maLopHoc,thu,tietBatDau,soTiet,maLop,phong,gv,mh);


			// LopHocDAO.Instance.ThemDuLieu(lh);

			// TietHocDAO.Instance.TaoTietHoc(lh,soBuoiHoc,ngayNhapHoc,ngayKetThuc,phong,tietBatDau);


		}
		static GiangVien saveGV(GiangVien gv)
		{
			var collection = MongoDB<GiangVien>.GetCollection("GiangVien");
			GiangVien gvv = collection.Find(x => x.MaGv == gv.MaGv).SingleOrDefault();
			if (gvv == null)
			{
				collection.InsertOne(gv);
				return gv;
			}
			return gvv;
		}
		static void saveLopHoc(GiangVien gv, LopHoc lh)
		{

			var collection = MongoDB<GiangVien>.GetCollection("GiangVien");
			var filter = Builders<GiangVien>.Filter.Eq(s => s.MaGv, gv.MaGv);
			var update = Builders<GiangVien>.Update.Push<LopHoc>(x => x.DSLopHoc, lh);


			collection.FindOneAndUpdate(filter, update);
		}

		static object[,] LayDuLieu(string path)
		{
			var xlApp = new Excel.Application();
			xlApp.Visible = false;
			var xlWorkBook = xlApp.Workbooks.Open(path);
			var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets.get_Item(1);
			Excel.Range xlRange = xlWorkSheet.UsedRange;
			object[,] dt = (object[,])xlRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);
			xlApp.Quit();
			return dt;
		}
		static public string DocExcel(string path)
		{

			object[,] dt = LayDuLieu(path);
			LuuCSDL(dt);
			return "";
		}

	}
}
}
