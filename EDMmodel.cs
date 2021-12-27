namespace DALnew
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EDMmodel : DbContext
    {
        public EDMmodel()
            : base("name=EDMmodel")
        {
        }

        public virtual DbSet<Dish> Dish { get; set; }
        public virtual DbSet<Doer> Doer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderLine> OrderLine { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<ReceiptLine> ReceiptLine { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }
        public virtual DbSet<SupplyLine> SupplyLine { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.ReceiptLine)
                .WithRequired(e => e.Dish1)
                .HasForeignKey(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.Recipe1)
                .WithRequired(e => e.Dish1)
                .HasForeignKey(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Doer>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Doer>()
                .HasMany(e => e.Order)
                .WithOptional(e => e.Doer1)
                .HasForeignKey(e => e.Doer);

            modelBuilder.Entity<Doer>()
                .HasMany(e => e.Supply)
                .WithOptional(e => e.Doer1)
                .HasForeignKey(e => e.Doer);

            modelBuilder.Entity<Order>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Priority)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Supplier)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderLine)
                .WithRequired(e => e.Order1)
                .HasForeignKey(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Supply)
                .WithOptional(e => e.Order1)
                .HasForeignKey(e => e.Order);

            modelBuilder.Entity<OrderLine>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderLine)
                .WithOptional(e => e.Product1)
                .HasForeignKey(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Recipe)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.SupplyLine)
                .WithOptional(e => e.Product1)
                .HasForeignKey(e => e.Product);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Receipt>()
                .HasMany(e => e.ReceiptLine)
                .WithRequired(e => e.Receipt1)
                .HasForeignKey(e => e.Receipt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReceiptLine>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Recipe>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<Supply>()
                .Property(e => e.Supplier)
                .IsUnicode(false);

            modelBuilder.Entity<Supply>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Supply>()
                .HasMany(e => e.SupplyLine)
                .WithRequired(e => e.Supply1)
                .HasForeignKey(e => e.Supply)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplyLine>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<SupplyLine>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);
        }
    }
}
