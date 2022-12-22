﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task3.Store;

namespace Task3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Task3.Store.Models.AllocatedInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<float>("AmountUsed")
                        .HasColumnType("real");

                    b.Property<bool>("Analogous")
                        .HasColumnType("bit");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("MeasurementUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Missing")
                        .HasColumnType("real");

                    b.Property<int?>("PlannedInventoryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("RentRequestId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ReturnRequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("PlannedInventoryId");

                    b.HasIndex("RentRequestId");

                    b.HasIndex("ReturnRequestId");

                    b.ToTable("AllocatedInventories");
                });

            modelBuilder.Entity("Task3.Store.Models.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MessageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Task3.Store.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Task3.Store.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<bool>("Analogous")
                        .HasColumnType("bit");

                    b.Property<string>("MeasurementUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Missing")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rented")
                        .HasColumnType("real");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Task3.Store.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("TopicId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Task3.Store.Models.ModeratedSections", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.HasIndex("UserId");

                    b.ToTable("ModeratedSections");
                });

            modelBuilder.Entity("Task3.Store.Models.PlannedInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<bool>("Analogous")
                        .HasColumnType("bit");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("MeasurementUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Missing")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RentRequestId")
                        .HasColumnType("int");

                    b.Property<float>("Rented")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("RentRequestId");

                    b.ToTable("PlannedInventories");
                });

            modelBuilder.Entity("Task3.Store.Models.RentRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Approval")
                        .HasColumnType("int");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SchoolId");

                    b.ToTable("RentRequests");
                });

            modelBuilder.Entity("Task3.Store.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("DeliverymanId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PickupTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeliverymanId");

                    b.ToTable("Requests");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Request");
                });

            modelBuilder.Entity("Task3.Store.Models.RequestedInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int?>("RentRequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.HasIndex("RentRequestId");

                    b.ToTable("RequestedInventory");
                });

            modelBuilder.Entity("Task3.Store.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Task3.Store.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Task3.Store.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("SectionId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Task3.Store.Models.ReturnRequest", b =>
                {
                    b.HasBaseType("Task3.Store.Models.Request");

                    b.Property<int?>("RentRequestId")
                        .HasColumnType("int");

                    b.HasIndex("RentRequestId");

                    b.HasDiscriminator().HasValue("ReturnRequest");
                });

            modelBuilder.Entity("Task3.Store.Models.UnloadRequest", b =>
                {
                    b.HasBaseType("Task3.Store.Models.Request");

                    b.Property<int?>("RentRequestId")
                        .HasColumnName("UnloadRequest_RentRequestId")
                        .HasColumnType("int");

                    b.HasIndex("RentRequestId");

                    b.HasDiscriminator().HasValue("UnloadRequest");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Task3.Store.Models.AllocatedInventory", b =>
                {
                    b.HasOne("Task3.Store.Models.Event", "Event")
                        .WithMany("AllocatedInventories")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Task3.Store.Models.Inventory", "Inventory")
                        .WithMany("AllocatedInventories")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Task3.Store.Models.PlannedInventory", "PlannedInventory")
                        .WithMany("AllocatedInventories")
                        .HasForeignKey("PlannedInventoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Task3.Store.Models.RentRequest", "RentRequest")
                        .WithMany("AllocatedInventories")
                        .HasForeignKey("RentRequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Task3.Store.Models.ReturnRequest", "ReturnRequest")
                        .WithMany("AllocatedInventories")
                        .HasForeignKey("ReturnRequestId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Task3.Store.Models.Attachment", b =>
                {
                    b.HasOne("Task3.Store.Models.Message", "Message")
                        .WithMany("Attachments")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Task3.Store.Models.Inventory", b =>
                {
                    b.HasOne("Task3.Store.Models.School", "School")
                        .WithMany("Inventories")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Task3.Store.Models.Message", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Task3.Store.Models.Topic", "Topic")
                        .WithMany("Messages")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Task3.Store.Models.ModeratedSections", b =>
                {
                    b.HasOne("Task3.Store.Models.Section", "Section")
                        .WithMany("Moderators")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Task3.Store.Models.PlannedInventory", b =>
                {
                    b.HasOne("Task3.Store.Models.Event", "Event")
                        .WithMany("PlannedInventories")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Task3.Store.Models.RentRequest", "RentRequest")
                        .WithMany("PlannedInventories")
                        .HasForeignKey("RentRequestId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Task3.Store.Models.RentRequest", b =>
                {
                    b.HasOne("Task3.Store.Models.Event", "Event")
                        .WithMany("RentRequests")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Task3.Store.Models.School", "School")
                        .WithMany("RentRequests")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Task3.Store.Models.Request", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Deliveryman")
                        .WithMany()
                        .HasForeignKey("DeliverymanId");
                });

            modelBuilder.Entity("Task3.Store.Models.RequestedInventory", b =>
                {
                    b.HasOne("Task3.Store.Models.Inventory", "Inventory")
                        .WithMany("RequestedInventories")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Task3.Store.Models.RentRequest", "RentRequest")
                        .WithMany("RequestedInventories")
                        .HasForeignKey("RentRequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Task3.Store.Models.Topic", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Task3.Store.Models.Section", "Section")
                        .WithMany("Topics")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Task3.Store.Models.ReturnRequest", b =>
                {
                    b.HasOne("Task3.Store.Models.RentRequest", "RentRequest")
                        .WithMany("ReturnRequests")
                        .HasForeignKey("RentRequestId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Task3.Store.Models.UnloadRequest", b =>
                {
                    b.HasOne("Task3.Store.Models.RentRequest", "RentRequest")
                        .WithMany("UnloadRequests")
                        .HasForeignKey("RentRequestId")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}
