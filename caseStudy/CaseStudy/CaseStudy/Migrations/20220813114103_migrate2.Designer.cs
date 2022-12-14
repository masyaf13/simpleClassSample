// <auto-generated />
using System;
using CaseStudy.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaseStudy.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220813114103_migrate2")]
    partial class migrate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CaseStudy.Models.ClassRoom", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Düzenleme Tarihi");

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Durum");

                    b.HasKey("ID");

                    b.ToTable("Sınıflar");
                });

            modelBuilder.Entity("CaseStudy.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassRoomID")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Sınıfı");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime")
                        .HasColumnName("Doğum Tarihi");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Adı");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Soyadı");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Düzenleme Tarihi");

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Durum");

                    b.HasKey("ID");

                    b.HasIndex("ClassRoomID");

                    b.ToTable("Öğrenciler");
                });

            modelBuilder.Entity("CaseStudy.Models.Teacher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassRoomID")
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Adı");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Soyadı");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Düzenleme Tarihi");

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Durum");

                    b.HasKey("ID");

                    b.HasIndex("ClassRoomID")
                        .IsUnique()
                        .HasFilter("[ClassRoomID] IS NOT NULL");

                    b.ToTable("Sınıf Öğretmenleri");
                });

            modelBuilder.Entity("CaseStudy.Models.Student", b =>
                {
                    b.HasOne("CaseStudy.Models.ClassRoom", "ClassRoom")
                        .WithMany("Students")
                        .HasForeignKey("ClassRoomID");

                    b.Navigation("ClassRoom");
                });

            modelBuilder.Entity("CaseStudy.Models.Teacher", b =>
                {
                    b.HasOne("CaseStudy.Models.ClassRoom", "ClassRoom")
                        .WithOne("Teacher")
                        .HasForeignKey("CaseStudy.Models.Teacher", "ClassRoomID");

                    b.Navigation("ClassRoom");
                });

            modelBuilder.Entity("CaseStudy.Models.ClassRoom", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
