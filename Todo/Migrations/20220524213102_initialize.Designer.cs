// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todo.DataAccess;

#nullable disable

namespace Todo.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220524213102_initialize")]
    partial class initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Todo.Entities.DailyTodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TodoDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TodoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TodoStatus")
                        .HasColumnType("int");

                    b.Property<int>("TodoTag")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DailyTodos");
                });

            modelBuilder.Entity("Todo.Entities.MonthlyTodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TodoDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TodoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TodoStatus")
                        .HasColumnType("int");

                    b.Property<int>("TodoTag")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MonthlyTodos");
                });

            modelBuilder.Entity("Todo.Entities.WeeklyTodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TodoDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TodoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TodoStatus")
                        .HasColumnType("int");

                    b.Property<int>("TodoTag")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WeeklyTodos");
                });
#pragma warning restore 612, 618
        }
    }
}
