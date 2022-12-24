using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Task3.Store.Models;
using Task3.ViewModels;

namespace Task3.Store
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //forum tables
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<ModeratedSections> ModeratedSections { get; set; }

        //rent app tables
        public DbSet<School> Schools { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryType> InventoryTypes { get; set; }
        public DbSet<AllocatedInventory> AllocatedInventories { get; set; }
        public DbSet<PlannedInventory> PlannedInventories { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ReturnRequest> ReturnRequests { get; set; }
        public DbSet<UnloadRequest> UnloadRequests { get; set; }
        public DbSet<RentRequest> RentRequests { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //forum modelbuilders

            modelBuilder.Entity<ModeratedSections>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Attachment>()
                .HasOne(x => x.Message)
                .WithMany(x => x.Attachments)
                .HasForeignKey(x => x.MessageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.Topic)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Topic>()
                .HasOne(x => x.Section)
                .WithMany(x => x.Topics)
                .HasForeignKey(x => x.SectionId)
                .OnDelete(DeleteBehavior.Cascade);

            //rent app modelbuilders

            modelBuilder.Entity<Inventory>()
                .HasOne(x => x.School)
                .WithMany(x => x.Inventories)
                .HasForeignKey(x => x.SchoolId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Inventory>()
                .HasOne(x => x.InventoryType)
                .WithMany(x => x.Inventories)
                .HasForeignKey(x => x.TypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlannedInventory>()
                .HasOne(x => x.InventoryType)
                .WithMany(x => x.PlannedInventories)
                .HasForeignKey(x => x.InventoryTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlannedInventory>()
                .HasOne(x => x.Event)
                .WithMany(x => x.PlannedInventories)
                .HasForeignKey(x => x.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlannedInventory>()
                .HasOne(x => x.RentRequest)
                .WithMany(x => x.PlannedInventories)
                .HasForeignKey(x => x.RentRequestId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RentRequest>()
                .HasOne(x => x.Event)
                .WithMany(x => x.RentRequests)
                .HasForeignKey(x => x.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RentRequest>()
                .HasOne(x => x.School)
                .WithMany(x => x.RentRequests)
                .HasForeignKey(x => x.SchoolId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AllocatedInventory>()
                .HasOne(x => x.Event)
                .WithMany(x => x.AllocatedInventories)
                .HasForeignKey(x => x.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AllocatedInventory>()
                .HasOne(x => x.PlannedInventory)
                .WithMany(x => x.AllocatedInventories)
                .HasForeignKey(x => x.PlannedInventoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AllocatedInventory>()
                .HasOne(x => x.RentRequest)
                .WithMany(x => x.AllocatedInventories)
                .HasForeignKey(x => x.RentRequestId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AllocatedInventory>()
                .HasOne(x => x.Inventory)
                .WithMany(x => x.AllocatedInventories)
                .HasForeignKey(x => x.InventoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RequestedInventory>()
                .HasOne(x => x.InventoryType)
                .WithMany(x => x.RequestedInventories)
                .HasForeignKey(x => x.InventoryTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RequestedInventory>()
                .HasOne(x => x.RentRequest)
                .WithMany(x => x.RequestedInventories)
                .HasForeignKey(x => x.RentRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReturnRequest>()
                .HasMany(x => x.AllocatedInventories)
                .WithOne(x => x.ReturnRequest)
                .HasForeignKey(x => x.ReturnRequestId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ReturnRequest>()
                .HasOne(x => x.RentRequest)
                .WithMany(x => x.ReturnRequests)
                .HasForeignKey(x => x.RentRequestId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UnloadRequest>()
                .HasOne(x => x.RentRequest)
                .WithMany(x => x.UnloadRequests)
                .HasForeignKey(x => x.RentRequestId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Event>()
                .Property(u => u.EventStatus)
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder.Entity<Inventory>()
                .Property(u => u.MeasurementUnit)
                .HasConversion<string>()
                .HasMaxLength(50);

        }
    }
}
