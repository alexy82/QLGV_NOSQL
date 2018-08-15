using QLGV_NOSQL.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGV_NOSQL.DO
{
	class ConfigSystem
	{
		public void LuuConfigSystem(BO.ConfigSystem config)
		{
			MongoDB<BO.ConfigSystem>.GetCollection(Config.CONFIG_COLLECTION).InsertOne(config);
		}
	}
}
