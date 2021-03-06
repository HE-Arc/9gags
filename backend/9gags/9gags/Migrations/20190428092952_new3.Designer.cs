﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _9gags.Models;

namespace _9gags.Migrations
{
    [DbContext(typeof(GagsContext))]
    [Migration("20190428092952_new3")]
    partial class new3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_9gags.Models.Article", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Path");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title");

                    b.Property<int>("points");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("_9gags.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ArticleId");

                    b.Property<string>("Comments");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("_9gags.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Auth0");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("_9gags.Models.View", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ArticleId");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("View");
                });

            modelBuilder.Entity("_9gags.Models.Vote", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ArticleId");

                    b.Property<int>("Point");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Vote");
                });

            modelBuilder.Entity("_9gags.Models.Comment", b =>
                {
                    b.HasOne("_9gags.Models.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId");

                    b.HasOne("_9gags.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("_9gags.Models.View", b =>
                {
                    b.HasOne("_9gags.Models.Article", "Article")
                        .WithMany("Views")
                        .HasForeignKey("ArticleId");

                    b.HasOne("_9gags.Models.User", "User")
                        .WithMany("Views")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("_9gags.Models.Vote", b =>
                {
                    b.HasOne("_9gags.Models.Article", "Article")
                        .WithMany("Votes")
                        .HasForeignKey("ArticleId");

                    b.HasOne("_9gags.Models.User", "User")
                        .WithMany("Votes")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
