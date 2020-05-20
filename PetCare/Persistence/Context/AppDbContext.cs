using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Models;
using PetCare.Persistence.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Provider> ServicesProviders { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<SuscriptionPlan> SuscriptionPlans { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            new CustomerConfig(builder.Entity<Customer>());
            new ServicesProviderConfig(builder.Entity<Provider>());
            new PetConfig(builder.Entity<Pet>());
            new CardConfig(builder.Entity<Card>());



            builder.Entity<SuscriptionPlan>().HasMany(x => x.ListServicesProvider).
                WithOne(p => p.SuscriptionPlan).HasForeignKey(x => x.SuscriptionPlanId);

            builder.Entity<Customer>().HasMany(x => x.Pets).
                WithOne(p => p.Customer).HasForeignKey(x => x.CustomerId);

            builder.Entity<Provider>().HasOne(x => x.Card)
                .WithOne(p => p.ServicesProvider)
                .HasForeignKey<Card>(b => b.ServicesProviderForeignKey);
                /*
                modelBuilder.Entity<Blog>()
            .HasOne(b => b.BlogImage)
            .WithOne(i => i.Blog)
            .HasForeignKey<BlogImage>(b => b.BlogForeignKey);*/

            builder.Entity<SuscriptionPlan>().HasData
            (
                new SuscriptionPlan { Id = 1, Name = "Basica", Description = "Plan Basico", Price = 19.90, Duration = 1 },
                new SuscriptionPlan { Id = 2, Name = "Premium", Description = "Plan Premium", Price = 39.90, Duration = 1 }
            );
        }
    }
}
