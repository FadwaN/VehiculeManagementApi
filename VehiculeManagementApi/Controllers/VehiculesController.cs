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

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="logger">loggeur</param>
        /// <param name="vehiculeService">Service pour effectuer des operations crud sur les véhicules.</param>
        public VehiculesController(ILogger<VehiculesController> logger, IVehiculeService vehiculeService)
        {
            _logger = logger;
            _vehiculeService = vehiculeService;
        }

        /// <summary>
        /// Retourner la liste de tous les véhicules dans la base.
        /// </summary>
        /// <returns>List des véhicules</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Vehicule>> GetAll()
        {
            return _vehiculeService.GetAll();
        }

        /// <summary>
        /// Retourner le véhicule dont l'identifiant est id.
        /// </summary>
        /// <param name="id">identifiant</param>
        /// <returns>Le véhicule cherché</returns>
        [HttpGet("{id}")]
        public ActionResult<Vehicule> Get(long id)
        {
            return _vehiculeService.Get(id);
        }

        /// <summary>
        /// Inserer un véhicule.
        /// </summary>
        /// <param name="vehicule">le véhicule a inserer</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert([FromBody]Vehicule vehicule)
        {
            _vehiculeService.Insert(vehicule);
            return  Ok(vehicule);
        }

        /// <summary>
        /// Mettre à jour un véhicule.
        /// </summary>
        /// <param name="id">identifiant du véhicule a mettre a jour</param>
        /// <param name="vehicule">le véhicule a jour</param>
        /// <returns></returns>
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

        /// <summary>
        /// Supprimer le véhicule dont l'identifiant est id
        /// </summary>
        /// <param name="id">Identifiant</param>
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
