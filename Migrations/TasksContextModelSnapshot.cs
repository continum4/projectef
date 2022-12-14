// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projectef;

#nullable disable

namespace projectef.Migrations
{
    [DbContext(typeof(TasksContext))]
    partial class TasksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("projectef.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb660be"),
                            Name = "Actividades pendientes",
                            Weight = 20
                        },
                        new
                        {
                            CategoryId = new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb66002"),
                            Name = "Actividades personales",
                            Weight = 50
                        });
                });

            modelBuilder.Entity("projectef.Models.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb66023"),
                            CategoryId = new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb660be"),
                            CreatedAt = new DateTime(2022, 9, 14, 14, 1, 53, 263, DateTimeKind.Local).AddTicks(72),
                            Priority = 1,
                            Title = "Pago de servicios"
                        },
                        new
                        {
                            TaskId = new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb66024"),
                            CategoryId = new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb66002"),
                            CreatedAt = new DateTime(2022, 9, 14, 14, 1, 53, 263, DateTimeKind.Local).AddTicks(169),
                            Priority = 0,
                            Title = "Terminar tareas"
                        });
                });

            modelBuilder.Entity("projectef.Models.Task", b =>
                {
                    b.HasOne("projectef.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("projectef.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
