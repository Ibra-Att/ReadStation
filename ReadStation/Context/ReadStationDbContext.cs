
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System;
using ReadStation.Models.Entities;
using ReadStation.Models.EntityConfigurations;

namespace ReadStation.Context
{
    public class ReadStationDbContext : DbContext
    {
        public ReadStationDbContext(DbContextOptions<ReadStationDbContext> dbOptions) : base(dbOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContentConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionContentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserSubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());







        }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<User> Users  { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<UserSubscription> UserSubscriptions { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<SubscriptionContent> SubscriptionContents { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

    }
}