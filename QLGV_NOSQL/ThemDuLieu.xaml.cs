using Microsoft.Win32;
using QLGV_NOSQL.BO;
using QLGV_NOSQL.Code;
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
	/// Interaction logic for ThemDuLieu.xaml
	/// </summary>
	public partial class ThemDuLieu : Window
	{
		string linkExcel;
		public ThemDuLieu()
		{
			InitializeComponent();
		}

		private void openFile_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
			if (openFileDialog.ShowDialog() == true)
			{
				linkExcel = openFileDialog.FileName;
				string[] t = openFileDialog.FileName.Split('\\');
				excelName.Text = t[t.Length - 1];
			}
		}

		private void luu_Click(object sender, RoutedEventArgs e)
		{

			int _soBuoiHoc;

			if(string.IsNullOrEmpty(excelName.Text)|| string.IsNullOrEmpty(ngayBatDau.Text)|| string.IsNullOrEmpty(ngayKetThuc.Text) || !int.TryParse(SoBuoiHoc.Text,out _soBuoiHoc))
			{
				return;
			}
			MongoDB<int>.XoaData();
			ConfigSystem config = new ConfigSystem()
			{
				NgayBatDau = ngayBatDau.SelectedDate.Value,
				NgayKetThuc = ngayKetThuc.SelectedDate.Value,
				SoBuoi = int.Parse(SoBuoiHoc.Text)
			};
			DO.ConfigSystem doConfig = new DO.ConfigSystem();
			doConfig.LuuConfigSystem(config);
			LuuDuLieu.DocExcel(linkExcel);
		}
	}
}
