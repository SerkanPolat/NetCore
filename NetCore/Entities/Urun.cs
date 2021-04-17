using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Entities
{
	[Dapper.Contrib.Extensions.Table("Urunler")]
	public class Urun: ILocalEntity
	{
		[Dapper.Contrib.Extensions.Key]
		public int Id { get; set; }
		[MaxLength(110)]
		public string Ad { get; set; }
		[MaxLength(110)]
		public string Resim { get; set; }
		public decimal Fiyat { get; set; }
		public List<UrunKategori> UrunKategoriler { get; set; }
	}
}
