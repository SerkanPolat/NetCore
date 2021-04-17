using NetCore.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using NetCore.Interfaces;

namespace NetCore.Repositories.Dapper
{
	public class DpUrunRepository:DpGenericRepository<Urun>,IUrunRepository
	{
	}
}
  