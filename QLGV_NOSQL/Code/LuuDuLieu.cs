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
		static void LuuCSDL(object[,] dt)
		{
			//ConfigSystem config = new ConfigSystem()
			//{
			//	NgayBatDau = ngayBatDau,
			//	NgayKetThuc = ngayKetThuc,
			//	SoBuoi = soBuoi
			//};
			////save 
			//MongoDB<ConfigSystem>.GetCollection(Config.CONFIG_COLLECTION).InsertOne(config);
			DO.GiangVien.BuoiHoc doBuoiHoc= new DO.GiangVien.BuoiHoc();
			DO.GiangVien.LopHoc doLopHoc = new DO.GiangVien.LopHoc();
			DO.GiangVien.GiangVien doGiangVien = new DO.GiangVien.GiangVien();

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
				doBuoiHoc.TaoBuoiHoc(lh);



				gv = doGiangVien.LuuGiangVien(gv);
				doLopHoc.LuuLopHoc(gv, lh);





			}
			


		}
	
		

		static object[,] LayDuLieu(string path)
		{
			var xlApp = new Microsoft.Office.Interop.Excel.Application();
			xlApp.Visible = false;
			var xlWorkBook = xlApp.Workbooks.Open(path);
			var xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Sheets.get_Item(1);
			Microsoft.Office.Interop.Excel.Range xlRange = xlWorkSheet.UsedRange;
			object[,] dt = (object[,])xlRange.get_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault);
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

