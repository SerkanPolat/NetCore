using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Entities
{
	public class Kategori: ILocalEntity
	{
		public int Id { get; set; }
		[MaxLength(110)]
		public string Ad { get; set; }

		public List<UrunKategori> UrunKategoriler { get; set; }
	}
}
