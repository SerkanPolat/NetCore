using NetCore.Context;
using NetCore.Entities;
using NetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Repositories
{
	//Generic tip icin kosullar class olmasi ve new ile olusturulabiliyor olmasi gerekmektedir.
	public class EFGenericRepository<TEntity> where TEntity:class, ILocalEntity, new()
	{
		public void Add(TEntity table)
		{
			using var context = new YoutubeContext();
			context.Set<TEntity>().Add(table);
			context.SaveChanges();
		}
		public void Update(TEntity table)
		{
			using var context = new YoutubeContext();
			context.Set<TEntity>().Update(table);
			context.SaveChanges();
		}
		public List<TEntity> getAll()
		{
			using var context = new YoutubeContext();
			return context.Set<TEntity>().OrderByDescending(c => c.Id).ToList();
		}
	}
}
