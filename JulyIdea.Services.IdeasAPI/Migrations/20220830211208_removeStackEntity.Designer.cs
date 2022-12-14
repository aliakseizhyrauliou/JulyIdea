// <auto-generated />
using System;
using JulyIdea.Services.IdeasAPI.DbStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JulyIdea.Services.IdeasAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220830211208_removeStackEntity")]
    partial class removeStackEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JulyIdea.Services.IdeasAPI.DbStuff.Models.ChainElement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Descriptions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RootIdeaId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RootIdeaId");

                    b.ToTable("ChainElements");
                });

            modelBuilder.Entity("JulyIdea.Services.IdeasAPI.DbStuff.Models.Idea", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackFullString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Ideas");
                });

            modelBuilder.Entity("JulyIdea.Services.IdeasAPI.DbStuff.Models.ChainElement", b =>
                {
                    b.HasOne("JulyIdea.Services.IdeasAPI.DbStuff.Models.Idea", "RootIdea")
                        .WithMany("ChainElements")
                        .HasForeignKey("RootIdeaId");

                    b.Navigation("RootIdea");
                });

            modelBuilder.Entity("JulyIdea.Services.IdeasAPI.DbStuff.Models.Idea", b =>
                {
                    b.Navigation("ChainElements");
                });
#pragma warning restore 612, 618
        }
    }
}
