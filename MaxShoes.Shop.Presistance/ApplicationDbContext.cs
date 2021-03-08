using MaxShoes.Shop.Domain.Common;
using MaxShoes.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace MaxShoes.Shop.Presistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //modelBuilder.Entity<User>(b =>
            //{
            //    b.HasData(new User
            //    {
            //        Id = "37846734-172e-4149-8cec-6f43d1eb3f60",
            //        UserName = "Employee1",
            //        IsEmailConfirmed = true,
            //        Email = "Employee1@test.pl",
            //        Password = BC.HashPassword("Employee1"),
            //        Role = UserRoles.Employee
            //    });
            //    b.OwnsOne(e => e.Contact).HasData(new Contact
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        UserId = "37846734-172e-4149-8cec-6f43d1eb3f60",
            //        City = "Czestochowa",
            //        PhoneNumber = "666111222",
            //        ZipCode = "42-200",
            //        ApartmentNumber = 23,
            //        State = "Polska",
            //        FirstName = "Piter",
            //        LastName = "Blukacz",
            //        HouseNumber = 45,
            //        Street = "Zielona"
            //    });
            //});
            //modelBuilder.Entity<User>(c =>
            //{
            //    c.HasData(new User
            //    {
            //        Id = "37846734-172e-4149-8cec-6f43d1eb3f61",
            //        UserName = "Employee2",
            //        IsEmailConfirmed = true,
            //        Email = "Employee2@test.pl",
            //        Password = BC.HashPassword("Employee2"),
            //        Role = UserRoles.Employee
            //    });
            //    c.OwnsOne(e => e.Contact).HasData(new Contact
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        UserId = "37846734-172e-4149-8cec-6f43d1eb3f61",
            //        City = "Czestochowa",
            //        PhoneNumber = "666111223",
            //        ZipCode = "42-202",
            //        State = "Polska",
            //        FirstName = "Jan",
            //        LastName = "Oko",
            //        HouseNumber = 2,
            //        Street = "Liliowa"
            //    });
            //});

        }
        public override Task<int> SaveChangesAsync(CancellationToken cencelationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cencelationToken);
        }
    }
}