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
	/// Interaction logic for BuoiHoc.xaml
	/// </summary>
	public partial class BuoiHoc : Window
	{
		public BuoiHoc(string tenGiangVien,string maGiangVien,BO.GiangVien.LopHoc lh)
		{
			InitializeComponent();


		}
	}
}
