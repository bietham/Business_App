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
        }
    }
}
