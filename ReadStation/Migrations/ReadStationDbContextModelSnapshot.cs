﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReadStation.Context;

#nullable disable

namespace ReadStation.Migrations
{
    [DbContext(typeof(ReadStationDbContext))]
    partial class ReadStationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReadStation.Models.Entities.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DownloadingCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PublishingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Content", null, t =>
                        {
                            t.HasCheckConstraint("CH_Content_DownloadingCount", "DownloadingCount>=0");
                        });
                });

            modelBuilder.Entity("ReadStation.Models.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentNameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("ReadStation.Models.Entities.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("DownloadableContentPerMonth")
                        .HasColumnType("int");

                    b.Property<string>("DurationInDays")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Thirty");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("MembershipTier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PricePerMonth")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Subscription", null, t =>
                        {
                            t.HasCheckConstraint("CH_Subscription_DownloadableContentPerMonth", "DownloadableContentPerMonth>=15");

                            t.HasCheckConstraint("CH_Subscription_PricePerMonth", "PricePerMonth>=4.99");
                        });
                });

            modelBuilder.Entity("ReadStation.Models.Entities.SubscriptionContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("SubscriptionContent", (string)null);
                });

            modelBuilder.Entity("ReadStation.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 2, 3, 47, 28, 757, DateTimeKind.Local).AddTicks(8492));

                    b.Property<float?>("Salary")
                        .HasColumnType("real");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.HasIndex("UserTypeId");

                    b.ToTable("User", null, t =>
                        {
                            t.HasCheckConstraint("CH_User_Age", "Age >= 1");

                            t.HasCheckConstraint("CH_User_Email", "EMAIL LIKE '%@___%.COM'");

                            t.HasCheckConstraint("CH_User_FullName", "LEN(FullName) >= 5");

                            t.HasCheckConstraint("CH_User_Phone", "Phone LIKE '00%' AND LEN(Phone) = 14");

                            t.HasCheckConstraint("CH_User_Salary", "Salary >= 260");
                        });
                });

            modelBuilder.Entity("ReadStation.Models.Entities.UserContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContentCounter")
                        .HasColumnType("int");

                    b.Property<int>("ContentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserContent", (string)null);
                });

            modelBuilder.Entity("ReadStation.Models.Entities.UserSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DownloadCounter")
                        .HasColumnType("int");

                    b.Property<int>("DurationInMonths")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("MembershipCounter")
                        .HasColumnType("int");

                    b.Property<float>("NetPrice")
                        .HasColumnType("real");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("Promotion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(1f);

                    b.Property<DateTime>("SubscriptionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSubscription", null, t =>
                        {
                            t.HasCheckConstraint("CH_SubscriptionContent_DownloadCounter", "DownloadCounter>=0");

                            t.HasCheckConstraint("CH_UserSubscription_DurationInMonths", "DurationInMonths<= 12");

                            t.HasCheckConstraint("CH_UserSubscription_NetPrice", "NetPrice>= 0");

                            t.HasCheckConstraint("CH_UserSubscription_Price", "Price>= 0");

                            t.HasCheckConstraint("CH_UserSubscription_Promotion", "Promotion>=0.05 AND Promotion<=1 ");
                        });
                });

            modelBuilder.Entity("ReadStation.Models.Entities.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserType", (string)null);
                });

            modelBuilder.Entity("ReadStation.Models.Entities.SubscriptionContent", b =>
                {
                    b.HasOne("ReadStation.Models.Entities.Content", "Content")
                        .WithMany("SubscriptionContents")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReadStation.Models.Entities.Subscription", "Subscription")
                        .WithMany("SubscriptionContents")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("ReadStation.Models.Entities.User", b =>
                {
                    b.HasOne("ReadStation.Models.Entities.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("ReadStation.Models.Entities.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("ReadStation.Models.Entities.UserContent", b =>
                {
                    b.HasOne("ReadStation.Models.Entities.Content", "Content")
                        .WithMany("UserContents")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReadStation.Models.Entities.User", "User")
                        .WithMany("UserContents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReadStation.Models.Entities.UserSubscription", b =>
                {
                    b.HasOne("ReadStation.Models.Entities.Subscription", "Subscription")
                        .WithMany("UserSubscriptions")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReadStation.Models.Entities.User", "User")
                        .WithMany("UserSubscriptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReadStation.Models.Entities.Content", b =>
                {
                    b.Navigation("SubscriptionContents");

                    b.Navigation("UserContents");
                });

            modelBuilder.Entity("ReadStation.Models.Entities.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ReadStation.Models.Entities.Subscription", b =>
                {
                    b.Navigation("SubscriptionContents");

                    b.Navigation("UserSubscriptions");
                });

            modelBuilder.Entity("ReadStation.Models.Entities.User", b =>
                {
                    b.Navigation("UserContents");

                    b.Navigation("UserSubscriptions");
                });

            modelBuilder.Entity("ReadStation.Models.Entities.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
