using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGV_NOSQL.BO
{
	class ConfigSystem
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("ngay_bat_dau")]
		public DateTime NgayBatDau { get; set; }

		[BsonElement("ngay_ket_thuc")]
		public DateTime NgayKetThuc{ get; set; }
		[BsonElement("so_buoi")]
		public int SoBuoi { get; set; }
	}
}
