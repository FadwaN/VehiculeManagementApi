﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.Repository;

namespace Repositories.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201111161307_UpdateValidation")]
    partial class UpdateValidation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainEntities.ModelVehicule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Model 1 description",
                            Model = "Model1"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Model 2 description",
                            Model = "Model2"
                        },
                        new
                        {
                            Id = 3L,
                            Description = "Model 3 description",
                            Model = "Model3"
                        });
                });

            modelBuilder.Entity("DomainEntities.Vehicule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Annee")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Couleur")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("Disponibilite")
                        .HasColumnType("bit");

                    b.Property<string>("Matricule")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("ModelId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Annee = "2016",
                            Couleur = "Rouge",
                            Description = "Description vehicule1",
                            Disponibilite = true,
                            Matricule = "1111111",
                            ModelId = 1L,
                            Nom = "Vehicule1",
                            Prix = 1100.0
                        },
                        new
                        {
                            Id = 2L,
                            Annee = "2017",
                            Couleur = "Vert",
                            Description = "Description vehicule2",
                            Disponibilite = true,
                            Matricule = "2222222",
                            ModelId = 1L,
                            Nom = "Vehicule2",
                            Prix = 1200.0
                        },
                        new
                        {
                            Id = 3L,
                            Annee = "2018",
                            Couleur = "Blanc",
                            Description = "Description vehicule3",
                            Disponibilite = true,
                            Matricule = "3333333",
                            ModelId = 2L,
                            Nom = "Vehicule3",
                            Prix = 1300.0
                        },
                        new
                        {
                            Id = 4L,
                            Annee = "2019",
                            Couleur = "Rouge",
                            Description = "Description vehicule4",
                            Disponibilite = true,
                            Matricule = "4444444",
                            ModelId = 3L,
                            Nom = "Vehicule4",
                            Prix = 1400.0
                        },
                        new
                        {
                            Id = 5L,
                            Annee = "2020",
                            Couleur = "Noir",
                            Description = "Description vehicule5",
                            Disponibilite = true,
                            Matricule = "5555555",
                            ModelId = 3L,
                            Nom = "Vehicule5",
                            Prix = 1500.0
                        });
                });

            modelBuilder.Entity("DomainEntities.Vehicule", b =>
                {
                    b.HasOne("DomainEntities.ModelVehicule", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
