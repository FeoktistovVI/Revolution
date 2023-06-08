﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Revolution.Data;

#nullable disable

namespace Revolution.Data.Migrations
{
    [DbContext(typeof(AplicationContext))]
    partial class AplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Revolution.Data.Area", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("Revolution.Data.Events", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AreaId")
                        .HasColumnType("bigint");

                    b.Property<string>("EventsData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EventsName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VenueName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Revolution.Data.EventsResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CertificateNumber")
                        .HasColumnType("bigint");

                    b.Property<long>("EventsId")
                        .HasColumnType("bigint");

                    b.Property<string>("EventsResultName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EventsId");

                    b.HasIndex("StudentId");

                    b.ToTable("EventsResults");
                });

            modelBuilder.Entity("Revolution.Data.Grades", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Grade")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long>("SubjectId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Revolution.Data.Parents", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("Revolution.Data.School", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AreaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AreaId")
                        .IsUnique();

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Revolution.Data.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("EventsResultId")
                        .HasColumnType("bigint");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Grade")
                        .HasColumnType("bigint");

                    b.Property<long?>("GradesId")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("SchoolId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SubjectId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EventsResultId");

                    b.HasIndex("GradesId");

                    b.HasIndex("SchoolId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Revolution.Data.Subject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Revolution.Data.Events", b =>
                {
                    b.HasOne("Revolution.Data.Area", "Area")
                        .WithMany("Events")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("Revolution.Data.EventsResult", b =>
                {
                    b.HasOne("Revolution.Data.Events", "Events")
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Revolution.Data.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Events");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Revolution.Data.Grades", b =>
                {
                    b.HasOne("Revolution.Data.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Revolution.Data.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Revolution.Data.Parents", b =>
                {
                    b.HasOne("Revolution.Data.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Revolution.Data.School", b =>
                {
                    b.HasOne("Revolution.Data.Area", "Area")
                        .WithOne("Schools")
                        .HasForeignKey("Revolution.Data.School", "AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("Revolution.Data.Student", b =>
                {
                    b.HasOne("Revolution.Data.EventsResult", null)
                        .WithMany("Students")
                        .HasForeignKey("EventsResultId");

                    b.HasOne("Revolution.Data.Grades", null)
                        .WithMany("Students")
                        .HasForeignKey("GradesId");

                    b.HasOne("Revolution.Data.School", "School")
                        .WithMany("Students")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Revolution.Data.Subject", null)
                        .WithMany("Students")
                        .HasForeignKey("SubjectId");

                    b.Navigation("School");
                });

            modelBuilder.Entity("Revolution.Data.Area", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Schools")
                        .IsRequired();
                });

            modelBuilder.Entity("Revolution.Data.EventsResult", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Revolution.Data.Grades", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Revolution.Data.School", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Revolution.Data.Subject", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
