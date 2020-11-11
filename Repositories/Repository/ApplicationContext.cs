using System;
using System.Collections.Generic;
using System.Text;
using DomainEntities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Vehicule> Categories { get; set; }
        public DbSet<ModelVehicule> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ModelVehicule>().HasData(new ModelVehicule()
            {
               Id = 1,
               Description = "Model 1 description",
               Model = "Model1"
            });
            modelBuilder.Entity<ModelVehicule>().HasData(new ModelVehicule()
            {
               Id = 2,
               Description = "Model 2 description",
               Model = "Model2"
            });
            modelBuilder.Entity<ModelVehicule>().HasData(new ModelVehicule()
            {
               Id = 3,
               Description = "Model 3 description",
               Model = "Model3"
            });   
            
            modelBuilder.Entity<Vehicule>().HasData(new Vehicule() { Id = 1, Nom = "Vehicule1", Matricule = "1111111", Description = "Description vehicule1", Annee = "2016", Couleur = "Rouge", Prix = 1100, Disponibilite = true, ModelId = 1});
            modelBuilder.Entity<Vehicule>().HasData(new Vehicule() { Id = 2, Nom = "Vehicule2", Matricule = "2222222", Description = "Description vehicule2", Annee = "2017", Couleur = "Vert", Prix = 1200, Disponibilite = true, ModelId = 1});
            modelBuilder.Entity<Vehicule>().HasData(new Vehicule() { Id = 3, Nom = "Vehicule3", Matricule = "3333333", Description = "Description vehicule3", Annee = "2018", Couleur = "Blanc", Prix = 1300, Disponibilite = true, ModelId = 2});
            modelBuilder.Entity<Vehicule>().HasData(new Vehicule() { Id = 4, Nom = "Vehicule4", Matricule = "4444444", Description = "Description vehicule4", Annee = "2019", Couleur = "Rouge", Prix = 1400, Disponibilite = true, ModelId = 3});
            modelBuilder.Entity<Vehicule>().HasData(new Vehicule() { Id = 5, Nom = "Vehicule5", Matricule = "5555555", Description = "Description vehicule5", Annee = "2020", Couleur = "Noir", Prix = 1500, Disponibilite = true, ModelId = 3});
        }
    }
}
