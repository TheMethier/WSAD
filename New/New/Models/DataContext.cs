using Microsoft.EntityFrameworkCore;

namespace New.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gra>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<NowyKomentarz>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Element_koszyka>()
                .HasKey(x => x.ElementId);
            modelBuilder.Entity<Gra>()
                .HasMany(x => x.NowyKomentarz)
                .WithOne(x => x.Gra)
                .HasForeignKey(x => x.GraId);
            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<OrderDetails>().HasKey(x => x.Id);
        }
        public DbSet<Gra> Gra { get; set; }
        public DbSet<NowyKomentarz> NowyKomentarz { get; set; }
        public DbSet<Element_koszyka> Element_koszyka { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        //Przeprowadź update-databases 
    }
}
