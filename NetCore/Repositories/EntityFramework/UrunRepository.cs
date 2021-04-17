using NetCore.Entities;
using NetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Repositories
{
	public class UrunRepository:EFGenericRepository<Urun>,IUrunRepository
	{
	}
}
