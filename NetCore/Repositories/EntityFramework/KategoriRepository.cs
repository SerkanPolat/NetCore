using NetCore.Context;
using NetCore.Entities;
using NetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Repositories
{
	public class KategoriRepository : EFGenericRepository<Kategori>,IKategoriRepository
	{
		
	}
}
