using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGV_NOSQL.Code
{

	class MongoDB<T>
	{
		static MongoClient client = new MongoClient("mongodb://localhost:27017");
		static IMongoDatabase db = client.GetDatabase("QLGV");

		public static IMongoCollection<T> GetCollection(string collectionName)
		{
			return db.GetCollection<T>(collectionName);
		}
		public static void XoaData()
		{
			client.DropDatabase("QLGV");
		}
	}
}
