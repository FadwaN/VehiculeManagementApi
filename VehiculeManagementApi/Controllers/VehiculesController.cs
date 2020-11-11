using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainEntities;
using InterfaceService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace VehiculeManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculesController : ControllerBase
    {

        private readonly ILogger<VehiculesController> _logger;
        private readonly IVehiculeService _vehiculeService;

        public VehiculesController(ILogger<VehiculesController> logger, IVehiculeService vehiculeService)
        {
            _logger = logger;
            _vehiculeService = vehiculeService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Vehicule>> GetAll()
        {
            return _vehiculeService.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Vehicule> Get(long id)
        {
            return _vehiculeService.Get(id);
        }

        [HttpPost]
        public IActionResult Insert([FromBody]Vehicule vehicule)
        {
            _vehiculeService.Insert(vehicule);
            return  Ok(vehicule);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]Vehicule vehicule)
        {
            var vehiculeToUpdate = _vehiculeService.Get(id);
            if (vehiculeToUpdate is null)
            {
                return NotFound();
            }
            // mapping 
            vehiculeToUpdate.Disponibilite = vehicule.Disponibilite;
            vehiculeToUpdate.Description = vehicule.Description;
            vehiculeToUpdate.Annee = vehicule.Annee;
            vehiculeToUpdate.Couleur = vehicule.Couleur;
            vehiculeToUpdate.Nom = vehicule.Nom;
            vehiculeToUpdate.Prix = vehicule.Prix;
            vehiculeToUpdate.ModelId = vehicule.ModelId;
            vehiculeToUpdate.Matricule = vehicule.Matricule;


            _vehiculeService.Update(vehiculeToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var vehiculeToDelete = _vehiculeService.Get(id);
            if (vehiculeToDelete is null)
            {
                return NotFound();
            }
            _vehiculeService.Delete(vehiculeToDelete);
            return NoContent();
        }
    }
}
