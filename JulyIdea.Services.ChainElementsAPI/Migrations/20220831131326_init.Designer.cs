﻿// <auto-generated />
using System;
using JulyIdea.Services.ChainElementsAPI.DbStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JulyIdea.Services.ChainElementsAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220831131326_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JulyIdea.Services.ChainElementsAPI.DbStuff.Models.ChainElement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfCreating")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<long>("RootIdeaId")
                        .HasColumnType("bigint");

                    b.Property<long>("RootIdeaOwnerId")
                        .HasColumnType("bigint");

                    b.Property<bool>("isConfirmed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ChainElements");
                });
#pragma warning restore 612, 618
        }
    }
}
