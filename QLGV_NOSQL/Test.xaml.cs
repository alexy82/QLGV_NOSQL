using QLGV_NOSQL.Code;
using QLGV_NOSQL.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLGV_NOSQL
{
	/// <summary>
	/// Interaction logic for Test.xaml
	/// </summary>
	public partial class Test : Window
	{
		public Test()
		{

			DateTime ngayBatDau = new DateTime(2018, 1, 2);

			DateTime ngayKetThuc = new DateTime(2018,6, 2);
			int buoiHoc = 15;

			BO.ConfigSystem config = new BO.ConfigSystem()
			{
				NgayBatDau = ngayBatDau,
				NgayKetThuc = ngayKetThuc,
				SoBuoi = buoiHoc
			};
			ConfigSystem doConfigSystem = new ConfigSystem();
			doConfigSystem.LuuConfigSystem(config);
			
			LuuDuLieu.DocExcel(@"D:\Project\T_Manager\T_Manager\bin\Debug\gvv.xlsx");
			InitializeComponent();
		}
	}
}
