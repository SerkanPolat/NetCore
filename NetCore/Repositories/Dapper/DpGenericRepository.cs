using Dapper.Contrib.Extensions;
using NetCore.Entities;
using NetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Repositories.Dapper
{
	public class DpGenericRepository<TEntity> where TEntity : class, ILocalEntity, new()
	{
		public void Add(TEntity table)
		{
			return ;
		}

		public List<TEntity> getAll()
		{
			using var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;database=testCore;Integrated Security=True;");
			return connection.GetAll<TEntity>().OrderByDescending(p=>p.Id).ToList();
		}

		public void Update(TEntity table)
		{
			return;
		}
	}
}
