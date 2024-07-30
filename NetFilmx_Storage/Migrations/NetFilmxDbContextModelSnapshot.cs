﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetFilmx_Storage;

#nullable disable

namespace NetFilmx_Storage.Migrations
{
    [DbContext(typeof(NetFilmxDbContext))]
    partial class NetFilmxDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NetFilmx_Storage.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories", "NetFilmx_noweEntities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Podziwiaj niesamowity świat natury",
                            Name = "Zwierzęta"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Filmy edukacyjne",
                            Name = "Rozwój"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Zabawne i edukacyjne filmy",
                            Name = "Rozrywka"
                        });
                });

            modelBuilder.Entity("NetFilmx_Storage.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoId");

                    b.ToTable("Comments", "NetFilmx_noweEntities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is a comment for the first video.",
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7704),
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7707),
                            UserId = 1,
                            VideoId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "This is a comment for the second video.",
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7710),
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7723),
                            UserId = 2,
                            VideoId = 2
                        });
                });

            modelBuilder.Entity("NetFilmx_Storage.Entities.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoId");

                    b.ToTable("Likes", "NetFilmx_noweEntities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7730),
                            UserId = 1,
                            VideoId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7734),
                            UserId = 2,
                            VideoId = 2
                        });
                });

            modelBuilder.Entity("NetFilmx_Storage.Entities.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Series", "NetFilmx_noweEntities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2501),
                            Description = "Kup zestaw oryginalnych 9 filmów dostępnych na platformie",
                            Name = "Pakiet wszystkich startowych filmów",
                            Price = 149.99m,
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2547)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2551),
                            Description = "Zestaw zawierający 6 filmów poświęconych zwierzętom",
                            Name = "Pakiet świata zwierząt",
                            Price = 49.99m,
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2552)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2554),
                            Description = "Zestaw zawierający 3 filmy edukacyjne",
                            Name = "Pakiet rozwoju",
                            Price = 59.99m,
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2568)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2571),
                            Description = "Zestaw zawierający 3 filmy promocyjne, po jednym z każdej kategorii",
                            Name = "Pakiet promocyjny",
                            Price = 19.99m,
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2573)
                        });
                });

            modelBuilder.Entity("NetFilmx_Storage.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Tags", "NetFilmx_noweEntities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Zwierzęta"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Koty"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rozrywka"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Zabawne"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Edukacyjne"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Rozwój"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Programowanie"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Lockpicking"
                        });
                });

            modelBuilder.Entity("NetFilmx_Storage.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users", "NetFilmx_noweEntities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 242, DateTimeKind.Local).AddTicks(7312),
                            Email = "user1@example.com",
                            PasswordHash = "$2a$11$PPjK1Tnp1mGAzhRqkVbfHOaRG8KS16GLYEZeBa7ny7ZA6otz/pgoC",
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 242, DateTimeKind.Local).AddTicks(7353),
                            Username = "User1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7636),
                            Email = "user2@example.com",
                            PasswordHash = "$2a$11$DCZKLmZVTMToZf9V5UjK7OuVbxKao5Q0X8PaqIXwfk0tfqY2cOn1C",
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7693),
                            Username = "User2"
                        });
                });

            modelBuilder.Entity("NetFilmx_Storage.Entities.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Videos", "NetFilmx_noweEntities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Discover amazing wildlife and relax! ...",
                            Price = 9.99m,
                            ThumbnailUrl = "https://i.ytimg.com/vi/5kozt0uDa4c/hqdefault.jpg",
                            Title = "Amazing Scene of Wild Animals In 4K",
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2594),
                            VideoUrl = "https://www.youtube.com/watch?v=5kozt0uDa4c",
                            Views = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ultimate Wild Animals Collection in 8K ULTRA HD ...",
                            Price = 4.99m,
                            ThumbnailUrl = "https://i.ytimg.com/vi/Zv11L-ZfrSg/hqdefault.jpg",
                            Title = "Ultimate Wild Animals Collection in 8K ULTRA HD",
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2601),
                            VideoUrl = "https://www.youtube.com/watch?v=Zv11L-ZfrSg",
                            Views = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sit back and relax while enjoying this scenic film ...",
                            Price = 6.99m,
                            ThumbnailUrl = "https://i.ytimg.com/vi/oRDRfikj2z8/hqdefault.jpg",
                            Title = "Baby Animals 4K - Amazing World Of Young Animals",
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2609),
                            VideoUrl = "https://www.youtube.com/watch?v=oRDRfikj2z8",
                            Views = 0
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2616),
                            Description = "Cute, cuddly, and utterly chaotic! ...",
                            Price = 14.99m,
                            ThumbnailUrl = "https://i.ytimg.com/vi/y0sF5xhGreA/hqdefault.jpg",
                            Title = "20 Minutes of Adorable Kittens",
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2642),
                            VideoUrl = "https://www.youtube.com/watch?v=y0sF5xhGreA",
                            Views = 0
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2649),
                            Description = "Watching funny baby cats is the hardest try not to laugh challenge.",
                            Price = 19.99m,
                            ThumbnailUrl = "https://i.ytimg.com/vi/cytJLvf-eVs/hqdefault.jpg",
                            Title = "Baby Cats - Cute and Funny Cat Videos Compilation",
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2650),
                            VideoUrl = "https://www.youtube.com/watch?v=cytJLvf-eVs",
                            Views = 0
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2655),
                            Description = "Hoomans! Rufus here! ...",
                            Price = 12.99m,
                            ThumbnailUrl = "https://i.ytimg.com/vi/tpiyEe_CqB4/hqdefault.jpg",
                            Title = "Cute and Funny Cat Videos to Keep You Smiling!",
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2657),
                            VideoUrl = "https://www.youtube.com/watch?v=tpiyEe_CqB4",
                            Views = 0
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2662),
                            Description = "Asp.net core MVC 6.0 tutorial for beginners.",
                            Price = 14.99m,
                            ThumbnailUrl = "https://i.ytimg.com/vi/fFY9nxfILJQ/hqdefault.jpg",
                            Title = "Entity Framework Core Migration",
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2664),
                            VideoUrl = "https://www.youtube.com/watch?v=fFY9nxfILJQ",
                            Views = 0
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2669),
                            Description = "This video explores a significant security flaw discussed by LockPickingLawyer.",
                            Price = 19.99m,
                            ThumbnailUrl = "https://i.ytimg.com/vi/U5-qy2tbDG8/hqdefault.jpg",
                            Title = "The Most Significant Security Flaw in North America",
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2671),
                            VideoUrl = "https://www.youtube.com/watch?v=U5-qy2tbDG8",
                            Views = 0
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2676),
                            Description = "Unity is an amazingly powerful game engine - but it can be hard to learn ...",
                            Price = 12.99m,
                            ThumbnailUrl = "https://i.ytimg.com/vi/XtQMytORBmM/hqdefault.jpg",
                            Title = "The Unity Tutorial For Complete Beginners",
                            UpdatedAt = new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2678),
                            VideoUrl = "https://www.youtube.com/watch?v=XtQMytORBmM",
                            Views = 0
                        });
                });

            modelBuilder.Entity("VideoCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "VideoId");

                    b.HasIndex("VideoId");

                    b.ToTable("VideoCategory", "NetFilmx_noweEntities");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            VideoId = 1
                        },
                        new
                        {
                            CategoryId = 3,
                            VideoId = 1
                        },
                        new
                        {
                            CategoryId = 1,
                            VideoId = 2
                        },
                        new
                        {
                            CategoryId = 3,
                            VideoId = 2
                        },
                        new
                        {
                            CategoryId = 1,
                            VideoId = 3
                        },
                        new
                        {
                            CategoryId = 3,
                            VideoId = 3
                        },
                        new
                        {
                            CategoryId = 1,
                            VideoId = 4
                        },
                        new
                        {
                            CategoryId = 3,
                            VideoId = 4
                        },
                        new
                        {
                            CategoryId = 1,
                            VideoId = 5
                        },
                        new
                        {
                            CategoryId = 3,
                            VideoId = 5
                        },
                        new
                        {
                            CategoryId = 1,
                            VideoId = 6
                        },
                        new
                        {
                            CategoryId = 3,
                            VideoId = 6
                        },
                        new
                        {
                            CategoryId = 2,
                            VideoId = 7
                        },
                        new
                        {
                            CategoryId = 2,
                            VideoId = 8
                        },
                        new
                        {
                            CategoryId = 3,
                            VideoId = 8
                        },
                        new
                        {
                            CategoryId = 2,
                            VideoId = 9
                        });
                });

            modelBuilder.Entity("VideoSeries", b =>
                {
                    b.Property<int>("SeriesId")
                        .HasColumnType("int");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("SeriesId", "VideoId");

                    b.HasIndex("VideoId");

                    b.ToTable("VideoSeries", "NetFilmx_noweEntities");

                    b.HasData(
                        new
                        {
                            SeriesId = 1,
                            VideoId = 1
                        },
                        new
                        {
                            SeriesId = 1,
                            VideoId = 2
                        },
                        new
                        {
                            SeriesId = 1,
                            VideoId = 3
                        },
                        new
                        {
                            SeriesId = 1,
                            VideoId = 4
                        },
                        new
                        {
                            SeriesId = 1,
                            VideoId = 5
                        },
                        new
                        {
                            SeriesId = 1,
                            VideoId = 6
                        },
                        new
                        {
                            SeriesId = 2,
                            VideoId = 1
                        },
                        new
                        {
                            SeriesId = 2,
                            VideoId = 2
                        },
                        new
                        {
                            SeriesId = 2,
                            VideoId = 3
                        },
                        new
                        {
                            SeriesId = 2,
                            VideoId = 4
                        },
                        new
                        {
                            SeriesId = 2,
                            VideoId = 5
                        },
                        new
                        {
                            SeriesId = 2,
                            VideoId = 6
                        },
                        new
                        {
                            SeriesId = 3,
                            VideoId = 7
                        },
                        new
                        {
                            SeriesId = 3,
                            VideoId = 8
                        },
                        new
                        {
                            SeriesId = 3,
                            VideoId = 9
                        },
                        new
                        {
                            SeriesId = 4,
                            VideoId = 7
                        },
                        new
                        {
                            SeriesId = 4,
                            VideoId = 8
                        },
                        new
                        {
                            SeriesId = 4,
                            VideoId = 9
                        });
                });

            modelBuilder.Entity("VideoTag", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("TagId", "VideoId");

                    b.HasIndex("VideoId");

                    b.ToTable("VideoTag", "NetFilmx_noweEntities");

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            VideoId = 1
                        },
                        new
                        {
                            TagId = 5,
                            VideoId = 1
                        },
                        new
                        {
                            TagId = 1,
                            VideoId = 2
                        },
                        new
                        {
                            TagId = 5,
                            VideoId = 2
                        },
                        new
                        {
                            TagId = 1,
                            VideoId = 3
                        },
                        new
                        {
                            TagId = 5,
                            VideoId = 3
                        },
                        new
                        {
                            TagId = 2,
                            VideoId = 4
                        },
                        new
                        {
                            TagId = 4,
                            VideoId = 4
                        },
                        new
                        {
                            TagId = 2,
                            VideoId = 5
                        },
                        new
                        {
                            TagId = 4,
                            VideoId = 5
                        },
                        new
                        {
                            TagId = 2,
                            VideoId = 6
                        },
                        new
                        {
                            TagId = 4,
                            VideoId = 6
                        },
                        new
                        {
                            TagId = 1,
                            VideoId = 6
                        },
                        new
                        {
                            TagId = 1,
                            VideoId = 5
                        },
                        new
                        {
                            TagId = 1,
                            VideoId = 4
                        },
                        new
                        {
                            TagId = 7,
                            VideoId = 7
                        },
                        new
                        {
                            TagId = 8,
                            VideoId = 8
                        },
                        new
                        {
                            TagId = 6,
                            VideoId = 9
                        },
                        new
                        {
                            TagId = 7,
                            VideoId = 9
                        },
                        new
                        {
                            TagId = 6,
                            VideoId = 7
                        });
                });

            modelBuilder.Entity("NetFilmx_Storage.Entities.Comment", b =>
                {
                    b.HasOne("NetFilmx_Storage.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetFilmx_Storage.Entities.Video", "Video")
                        .WithMany("Comments")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("NetFilmx_Storage.Entities.Like", b =>
                {
                    b.HasOne("NetFilmx_Storage.Entities.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetFilmx_Storage.Entities.Video", "Video")
                        .WithMany("Likes")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("VideoCategory", b =>
                {
                    b.HasOne("NetFilmx_Storage.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetFilmx_Storage.Entities.Video", null)
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VideoSeries", b =>
                {
                    b.HasOne("NetFilmx_Storage.Entities.Series", null)
                        .WithMany()
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetFilmx_Storage.Entities.Video", null)
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VideoTag", b =>
                {
                    b.HasOne("NetFilmx_Storage.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetFilmx_Storage.Entities.Video", null)
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetFilmx_Storage.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("NetFilmx_Storage.Entities.Video", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
