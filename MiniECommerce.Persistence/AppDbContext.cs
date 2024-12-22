using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Encryption;
using MiniECommerce.Domain.Baskets;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Orders;
using MiniECommerce.Domain.Products;
using MiniECommerce.Domain.Users;

namespace MiniECommerce.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options, IHashingHelper hashingHelper) : DbContext(options), IAppDbContext, IUnitOfWork
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SeedData hata verdiği için uyarıyı bastırdım.
            optionsBuilder
        .ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey((x => new { x.UserId, x.RoleId }));

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void UpdateAuditableEntities()
        {
            foreach (EntityEntry<IAuditableEntity> entityEntry in ChangeTracker.Entries<IAuditableEntity>())
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property(nameof(IAuditableEntity.CreatedDate)).CurrentValue = DateTime.Now;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property(nameof(IAuditableEntity.UpdatedDate)).CurrentValue = DateTime.Now;
                }
            }
        }

        #region UnitOfWork

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditableEntities();

            return base.SaveChangesAsync(cancellationToken);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
            => Database.BeginTransactionAsync(cancellationToken);

        #endregion

        #region AppDbContext

        public new DbSet<TEntity> Set<TEntity>()
            where TEntity : Entity
            => base.Set<TEntity>();

        #endregion

        #region Entities

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        #endregion

        #region SeedData

        public void SeedData(ModelBuilder builder)
        {
            int adminRoleId = 1;
            int userRoleId = 2;

            builder.Entity<Role>().HasData(new Role()
            {
                Id = adminRoleId,
                Name = "Admin"
            });

            builder.Entity<Role>().HasData(new Role()
            {
                Id = userRoleId,
                Name = "User"
            });

            Guid adminUserId = Guid.NewGuid();
            Guid testUserId = Guid.NewGuid();

            hashingHelper.CreatePasswordHash("123456", out byte[] pwHash, out byte[] pwSalt);

            builder.Entity<User>().HasData(new User()
            {
                Id = adminUserId,
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin",
                CreatedDate = DateTime.Now,
                PWHash = pwHash,
                PWSalt = pwSalt
            });

            builder.Entity<User>().HasData(new User()
            {
                Id = testUserId,
                FirstName = "Test",
                LastName = "Test",
                UserName = "test",
                CreatedDate = DateTime.Now,
                PWHash = pwHash,
                PWSalt = pwSalt
            });

            builder.Entity<UserRole>().HasData(new UserRole()
            {
                RoleId = adminRoleId,
                UserId = adminUserId,
            });

            builder.Entity<UserRole>().HasData(new UserRole()
            {
                RoleId = userRoleId,
                UserId = testUserId,
            });

            builder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Laptop",
                CreatedDate = DateTime.Now,
                Price = 50000,
                Stock = 10
            });

            builder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Telefon",
                CreatedDate = DateTime.Now,
                Price = 20000,
                Stock = 12
            });

            builder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Tablet",
                CreatedDate = DateTime.Now,
                Price = 8000,
                Stock = 7
            });
        }
        #endregion
    }
}
