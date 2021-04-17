using Microsoft.EntityFrameworkCore;
using NetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Context
{
	public class YoutubeContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;database=testCore;Integrated Security=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Coka cok iliskiler tanimlaniyor.

			modelBuilder.Entity<Urun>().HasMany(I => I.UrunKategoriler).WithOne(I => I.Urun).HasForeignKey(I => I.UrunId);
			modelBuilder.Entity<Kategori>().HasMany(I => I.UrunKategoriler).WithOne(I => I.Kategori).HasForeignKey(I => I.KategoriId);
			
			//Ayni Satirdan 2 Tane Eklenmesi Engelleniyor.
			modelBuilder.Entity<UrunKategori>().HasIndex(I => new
			{
				I.KategoriId,
				I.UrunId
			}).IsUnique();
		}
		public DbSet<UrunKategori> UrunKategoriler { get; set; }
		public DbSet<Urun> Urunler { get; set; }
		public DbSet<Kategori> Kategoriler { get; set; }
	}
}
