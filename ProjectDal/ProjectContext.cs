using Microsoft.EntityFrameworkCore;
using Project.Dto;
using Project.Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> db) : base(db)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketDetail>()
                .HasKey(basket => new { basket.Id, basket.ProductId }); 
        }
        public DbSet<BasketDetail> BasketDetails { get; set; }
        public DbSet<BasketMaster> BasketMasters { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Vat> Vats { get; set; }


    }
}
