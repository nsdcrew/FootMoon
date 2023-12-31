﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web;

#nullable disable

namespace Web.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230716201252_create")]
    partial class create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Web.Watcher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailSent1")
                        .HasColumnType("bit");

                    b.Property<bool>("EmailSent2")
                        .HasColumnType("bit");

                    b.Property<bool>("EmailSent3")
                        .HasColumnType("bit");

                    b.Property<bool>("EmailSent4")
                        .HasColumnType("bit");

                    b.Property<bool>("EmailSent5")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Watchers");
                });
#pragma warning restore 612, 618
        }
    }
}
