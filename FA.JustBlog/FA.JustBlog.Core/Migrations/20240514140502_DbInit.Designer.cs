﻿// <auto-generated />
using System;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    [DbContext(typeof(JustBlogContext))]
    [Migration("20240514140502_DbInit")]
    partial class DbInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FA.JustBlog.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Posts related to technology",
                            Name = "Technology",
                            UrlSlug = "technology"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Posts related to programming",
                            Name = "Programming",
                            UrlSlug = "programming"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Posts related to database",
                            Name = "Database",
                            UrlSlug = "database"
                        });
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommentHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Published")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RateCount")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalRate")
                        .HasColumnType("int");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Modified = new DateTime(2024, 5, 14, 21, 5, 1, 993, DateTimeKind.Local).AddTicks(5642),
                            PostContent = "Content of first post",
                            PostedOn = new DateTime(2024, 5, 14, 21, 5, 1, 993, DateTimeKind.Local).AddTicks(5641),
                            Published = new DateTime(2024, 5, 14, 21, 5, 1, 993, DateTimeKind.Local).AddTicks(5630),
                            ShortDescription = "Short description of first post",
                            Title = "First Post",
                            UrlSlug = "first-post"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Modified = new DateTime(2024, 5, 14, 21, 5, 1, 993, DateTimeKind.Local).AddTicks(5644),
                            PostContent = "Content of second post",
                            PostedOn = new DateTime(2024, 5, 14, 21, 5, 1, 993, DateTimeKind.Local).AddTicks(5644),
                            Published = new DateTime(2024, 5, 14, 21, 5, 1, 993, DateTimeKind.Local).AddTicks(5644),
                            ShortDescription = "Short description of second post",
                            Title = "Second Post",
                            UrlSlug = "second-post"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Modified = new DateTime(2024, 5, 14, 21, 5, 1, 993, DateTimeKind.Local).AddTicks(5647),
                            PostContent = "Content of third post",
                            PostedOn = new DateTime(2024, 5, 14, 21, 5, 1, 993, DateTimeKind.Local).AddTicks(5646),
                            Published = new DateTime(2024, 5, 14, 21, 5, 1, 993, DateTimeKind.Local).AddTicks(5646),
                            ShortDescription = "Short description of third post",
                            Title = "Third Post",
                            UrlSlug = "third-post"
                        });
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.PostTagMap", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTagsMap");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            TagId = 1
                        },
                        new
                        {
                            PostId = 1,
                            TagId = 2
                        },
                        new
                        {
                            PostId = 2,
                            TagId = 1
                        });
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 2,
                            Description = "Posts related to technology",
                            Name = "Technology",
                            UrlSlug = "technology"
                        },
                        new
                        {
                            Id = 2,
                            Count = 1,
                            Description = "Posts related to programming",
                            Name = "Programming",
                            UrlSlug = "programming"
                        },
                        new
                        {
                            Id = 3,
                            Count = 1,
                            Description = "Posts related to database",
                            Name = "Database",
                            UrlSlug = "database"
                        });
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Comment", b =>
                {
                    b.HasOne("FA.JustBlog.Core.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Post", b =>
                {
                    b.HasOne("FA.JustBlog.Core.Models.Category", null)
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.PostTagMap", b =>
                {
                    b.HasOne("FA.JustBlog.Core.Models.Post", "Post")
                        .WithMany("PostTagMaps")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FA.JustBlog.Core.Models.Tag", "Tag")
                        .WithMany("PostTagMaps")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Post", b =>
                {
                    b.Navigation("PostTagMaps");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Tag", b =>
                {
                    b.Navigation("PostTagMaps");
                });
#pragma warning restore 612, 618
        }
    }
}
