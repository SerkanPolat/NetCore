using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Interfaces
{
	public interface IGenericRepository<TEntity> where TEntity :class,new()
	{
		void Add(TEntity table);
		void Update(TEntity table);
		List<TEntity> getAll();
	}
}
