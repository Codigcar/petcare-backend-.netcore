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
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SuscriptionPlan> SuscriptionPlans { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ProviderJoinService> ProviderJoinServices { get; set; }
        public DbSet<ServiType> ServiTypes{ get; set; }

        public DbSet<ProviderRepresentative> ProviderRepresentatives { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            new CustomerConfig(builder.Entity<Customer>());
            new ServicesProviderConfig(builder.Entity<Provider>());
            new PetConfig(builder.Entity<Pet>());
            new PaymentConfig(builder.Entity<Payment>());
            new ProviderRepresentativeConfig(builder.Entity<ProviderRepresentative>());


            //SuscriptionPlan
            builder.Entity<SuscriptionPlan>().HasMany(x => x.ListServicesProvider).
                WithOne(p => p.SuscriptionPlan).HasForeignKey(x => x.SuscriptionPlanId);
            //Customer
            builder.Entity<Customer>().HasMany(x => x.Pets).
                WithOne(p => p.Customer).HasForeignKey(x => x.CustomerId);
            //Provider
            builder.Entity<Provider>().HasOne(x => x.Payment)
                .WithOne(p => p.ServicesProvider)
                .HasForeignKey<Payment>(b => b.ServicesProviderForeignKey);
            
            //ProviderService
            builder.Entity<ProviderJoinService>()
            .HasKey(ps => new { ps.ProviderId, ps.ServiceId});

            builder.Entity<ProviderJoinService>()
                .HasOne(ps => ps.Provider)
                .WithMany(wm => wm.ProviderServices)
                .HasForeignKey(fk => fk.ProviderId);

            builder.Entity<ProviderJoinService>()
                .HasOne(ps => ps.Service)
                .WithMany(wm => wm.ProviderServices)
                .HasForeignKey(fk => fk.ServiceId);

            //TypeService

            builder.Entity<ServiType>()
                .HasMany(t => t.ListServices)
                .WithOne(s => s.ServiType)
                .HasForeignKey(fk => fk.ServiTypeId);

            //ProviderRepresentative
            builder.Entity<Provider>().HasMany(x => x.ProviderRepresentatives).
                WithOne(p => p.Provider).HasForeignKey(x => x.ProviderId);



            builder.Entity<SuscriptionPlan>().HasData
            (
                new SuscriptionPlan { Id = 1, Name = "Basica", Description = "Plan Basico", Price = 19.90, Duration = 1 },
                new SuscriptionPlan { Id = 2, Name = "Premium", Description = "Plan Premium", Price = 39.90, Duration = 1 }
            );
           /* builder.Entity<Service>().HasData
           (
               new Service { Id = 1, Name="Baño" }
             
           );*/
        }
    }
}
