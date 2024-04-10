using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TailorManagementModels;

namespace TailorManagementAPI.Controllers
{
    public class ShirtConfigurationsController : ApiController
    {
        private readonly IRepository<ShirtConfiguration> _shirtConfigurationRepository;
        public ShirtConfigurationsController()
        {
        }
        public ShirtConfigurationsController(IRepository<ShirtConfiguration> shirtConfigurationRepository)
        {
            _shirtConfigurationRepository = shirtConfigurationRepository;
        }

        // GET: api/ShirtConfigurations
        public IEnumerable<ShirtConfiguration> GetShirtConfigurations()
        {
            return _shirtConfigurationRepository.GetAll();
        }

        // GET: api/ShirtConfigurations/5
        [ResponseType(typeof(ShirtConfiguration))]
        public IHttpActionResult GetShirtConfiguration(int id)
        {
            var shirtConfiguration = _shirtConfigurationRepository.GetById(id);
            if (shirtConfiguration == null)
            {
                return NotFound();
            }

            return Ok(shirtConfiguration);
        }

        // PUT: api/ShirtConfigurations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShirtConfiguration(int id, ShirtConfiguration shirtConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shirtConfiguration.Id)
            {
                return BadRequest();
            }

            try
            {
                _shirtConfigurationRepository.Update(shirtConfiguration);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/shirtConfigurations
        [ResponseType(typeof(ShirtConfiguration))]
        public IHttpActionResult PostShirtConfiguration(ShirtConfiguration shirtConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShirtConfiguration addedShirtConfiguration = _shirtConfigurationRepository.Insert(shirtConfiguration);
            return CreatedAtRoute("DefaultApi", new { id = addedShirtConfiguration.Id }, addedShirtConfiguration);
        }

        // DELETE: api/shirtConfigurations/5
        [ResponseType(typeof(ShirtConfiguration))]
        public IHttpActionResult DeleteShirtConfiguration(int id)
        {
            _shirtConfigurationRepository.Delete(id);
            return Ok();
        }
    }
}
