using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TailorManagementModels;

namespace TailorManagementAPI.Controllers
{
    public class PantConfigurationsController : ApiController
    {
        private readonly IRepository<PantConfiguration> _pantConfigurationRepository;
        public PantConfigurationsController()
        {
        }
        public PantConfigurationsController(IRepository<PantConfiguration> pantConfigurationRepository)
        {
            _pantConfigurationRepository = pantConfigurationRepository;
        }

        // GET: api/PantConfigurations
        public IEnumerable<PantConfiguration> GetPantConfigurations()
        {
            return _pantConfigurationRepository.GetAll();
        }

        // GET: api/PantConfigurations/5
        [ResponseType(typeof(PantConfiguration))]
        public IHttpActionResult GetPantConfiguration(int id)
        {
            var pantConfiguration = _pantConfigurationRepository.GetById(id);
            if (pantConfiguration == null)
            {
                return NotFound();
            }

            return Ok(pantConfiguration);
        }

        // PUT: api/PantConfigurations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPantConfiguration(int id, PantConfiguration pantConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pantConfiguration.Id)
            {
                return BadRequest();
            }

            try
            {
                _pantConfigurationRepository.Update(pantConfiguration);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PantConfigurations
        [ResponseType(typeof(PantConfiguration))]
        public IHttpActionResult PostPantConfiguration(PantConfiguration pantConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PantConfiguration addedPantConfiguration = _pantConfigurationRepository.Insert(pantConfiguration);
            return CreatedAtRoute("DefaultApi", new { id = addedPantConfiguration.Id }, addedPantConfiguration);
        }

        // DELETE: api/PantConfigurations/5
        [ResponseType(typeof(PantConfiguration))]
        public IHttpActionResult DeletePantConfiguration(int id)
        {
            _pantConfigurationRepository.Delete(id);
            return Ok();
        }
    }
}
