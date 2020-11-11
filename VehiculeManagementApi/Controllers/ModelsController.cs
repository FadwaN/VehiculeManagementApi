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

        public ModelsController(ILogger<VehiculesController> logger, IModelService modelService)
        {
            _logger = logger;
            _modelService = modelService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ModelVehicule>> GetAll()
        {
            return _modelService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ModelVehicule> Get(long id)
        {
            return _modelService.Get(id);
        }

        [HttpPost]
        public IActionResult Insert([FromBody]ModelVehicule model)
        {
            _modelService.Insert(model);
            return Ok(model);
        }

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
