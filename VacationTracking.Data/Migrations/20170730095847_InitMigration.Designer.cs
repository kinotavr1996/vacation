using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VacationTracking.Data.Context;

namespace VacationTracking.Data.Migrations
{
    [DbContext(typeof(VacationContext))]
    [Migration("20170730095847_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VacationTracking.Data.Models.CompanyHoliday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("HolidayDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CompanyHolidays");
                });

            modelBuilder.Entity("VacationTracking.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AutoLogon");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<DateTime?>("EndDate")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PasswordClear")
                        .IsRequired();

                    b.Property<byte[]>("PasswordHash");

                    b.Property<string>("Phone");

                    b.Property<int>("RoleId");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("VacationTracking.Data.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Role");
                });

            modelBuilder.Entity("VacationTracking.Data.Models.VacationPolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Days");

                    b.Property<int>("ServiceYears");

                    b.HasKey("Id");

                    b.ToTable("VacationPolicy");
                });

            modelBuilder.Entity("VacationTracking.Data.Models.VacationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Approved");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("VacationRequest");
                });

            modelBuilder.Entity("VacationTracking.Data.Models.Role", b =>
                {
                    b.HasOne("VacationTracking.Data.Models.Employee", "Employee")
                        .WithOne("Role")
                        .HasForeignKey("VacationTracking.Data.Models.Role", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VacationTracking.Data.Models.VacationRequest", b =>
                {
                    b.HasOne("VacationTracking.Data.Models.Employee", "Employee")
                        .WithMany("Requests")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
