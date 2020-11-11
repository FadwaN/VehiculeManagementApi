using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainEntities
{
    public class ModelVehicule: BaseEntity
    {
        [Display(Name = "Nom du model")]
        public string Model { get; set; }

        [Display(Name = "Description du model")]
        public string Description { get; set; }
    }
}
