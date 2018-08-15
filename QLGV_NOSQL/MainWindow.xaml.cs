using QLGV_NOSQL.Code;
using QLGV_NOSQL.DO.GiangVien;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLGV_NOSQL
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<BO.GiangVien.GiangVien> dsGiangVien;
		string preSearch = "";
		
		
		public MainWindow()
		{
			InitializeComponent();
			GiangVien doGiangVien = new GiangVien();
			dsGiangVien = doGiangVien.GetListOnLyGiangVien();

			listview.ItemsSource = dsGiangVien;

			
		}

		

		private void listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			BO.GiangVien.GiangVien giangVien = (BO.GiangVien.GiangVien)listview.SelectedItem;
			GiangVien doGiangVien = new GiangVien();

			listviewMh.ItemsSource = doGiangVien.GetGiangVien(giangVien.MaGv).DSLopHoc;
		}

		

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (search.Text.Trim() != preSearch)
			{
				GiangVien doGiangVien = new GiangVien();
				listview.ItemsSource = doGiangVien.GetGiangVienByName(search.Text);
				preSearch = search.Text;
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			ThemDuLieu themDuLieu = new ThemDuLieu();
			themDuLieu.ShowDialog();
		}
	}
}
