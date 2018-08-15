using MongoDB.Driver;
using QLGV_NOSQL.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGV_NOSQL.DO.GiangVien
{
	class LopHoc
	{
		public void LuuLopHoc(BO.GiangVien.GiangVien gv , BO.GiangVien.LopHoc lh)
		{
			var collection = MongoDB<BO.GiangVien.GiangVien>.GetCollection(Config.GIANG_VIEN_COLLECTION);
			var filter = Builders<BO.GiangVien.GiangVien>.Filter.Eq(s => s.MaGv, gv.MaGv);
			var update = Builders<BO.GiangVien.GiangVien>.Update.Push<BO.GiangVien.LopHoc>(x => x.DSLopHoc, lh);


			collection.FindOneAndUpdate(filter, update);
		}
	}
}
