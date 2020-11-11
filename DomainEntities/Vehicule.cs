using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DomainEntities
{
    public class Vehicule : BaseEntity
    {
        [StringLength(100)]
        [Display(Name = "Matricule")]
        public string Matricule { get; set; }

        [StringLength(100)]
        [Display(Name = "Nom du vehicule.")]
        public string Nom { get; set; } 
        
        [StringLength(250)]
        [Display(Name = "Descrition du vehicule.")]
        public string Description { get; set; }

        [StringLength(100)]
        [Display(Name = "Annee du vehicule.")]
        public string Annee { get; set; }

        [StringLength(100)]
        [Display(Name = "Couleur du vehicule.")]
        public string Couleur { get; set; }
       
        [Required]
        [Display(Name = "Prix du vehicule.")]
        public double Prix { get; set; }

        [Required]
        [Display(Name = "Vehicule disponible pour achat.")]
        public bool Disponibilite { get; set; }



        // foreign tables
        public ModelVehicule Model { get; set; }
        [ForeignKey("ModelId")]
        public Int64 ModelId { get; set; }
    }
}
