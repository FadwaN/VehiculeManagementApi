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
    public class ModelsController : ControllerBase
    {

        private readonly ILogger<VehiculesController> _logger;
        private readonly IModelService _modelService;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="logger">loggeur</param>
        /// <param name="modelService">Service pour effectuer des operations crud sur les modèles des véhicules.</param>
        public ModelsController(ILogger<VehiculesController> logger, IModelService modelService)
        {
            _logger = logger;
            _modelService = modelService;
        }

        /// <summary>
        /// Retourner la liste de tous les modèles des véhicules dans la base.
        /// </summary>
        /// <returns>List des modèles des véhicules</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ModelVehicule>> GetAll()
        {
            return _modelService.GetAll();
        }

        /// <summary>
        /// Retourner le modèle de véhicule dont l'identifiant est id.
        /// </summary>
        /// <param name="id">identifiant</param>
        /// <returns>Le model de véhicule cherché</returns>
        [HttpGet("{id}")]
        public ActionResult<ModelVehicule> Get(long id)
        {
            return _modelService.Get(id);
        }

        /// <summary>
        /// Inserer un modèle de véhicule.
        /// </summary>
        /// <param name="model">le modèle a inserer</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert([FromBody]ModelVehicule model)
        {
            _modelService.Insert(model);
            return Ok(model);
        }

        /// <summary>
        /// Mettre à jour un modèle de véhicule.
        /// </summary>
        /// <param name="id">identifiant du modèle a mettre a jour</param>
        /// <param name="model">le modèle a jour</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]ModelVehicule model)
        {
            var modelToUpdate = _modelService.Get(id);
            if (modelToUpdate is null)
            {
                return NotFound();
            }
            // mapping 
            modelToUpdate.Description = model.Description;
            modelToUpdate.Model = model.Model;

            _modelService.Update(modelToUpdate);
            return NoContent();
        }

        /// <summary>
        /// Supprimer le modèle dont l'identifiant est id
        /// </summary>
        /// <param name="id">Identifiant</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var modelToDelete = _modelService.Get(id);
            if (modelToDelete is null)
            {
                return NotFound();
            }
            _modelService.Delete(modelToDelete);
            return NoContent();
        }
    }
}
