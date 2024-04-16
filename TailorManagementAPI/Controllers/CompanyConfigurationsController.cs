using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TailorManagementModels;

namespace TailorManagementAPI.Controllers
{
    public class CompanyConfigurationsController : ApiController
    {
        private readonly IRepository<CompanyConfiguration> _companyConfigurationRepository;
        public CompanyConfigurationsController()
        {
        }
        public CompanyConfigurationsController(IRepository<CompanyConfiguration> companyConfigurationRepository)
        {
            _companyConfigurationRepository = companyConfigurationRepository;
        }

        // GET: api/CompanyConfigurations
        public IEnumerable<CompanyConfiguration> GetCompanyConfigurations()
        {
            return _companyConfigurationRepository.GetAll();
        }

        // GET: api/CompanyConfigurations/5
        [ResponseType(typeof(CompanyConfiguration))]
        public IHttpActionResult GetCompanyConfiguration(int id)
        {
            var companyConfiguration = _companyConfigurationRepository.GetById(id);
            if (companyConfiguration == null)
            {
                return NotFound();
            }

            return Ok(companyConfiguration);
        }

        // PUT: api/CompanyConfigurations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyConfiguration(int id, CompanyConfiguration companyConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyConfiguration.Id)
            {
                return BadRequest();
            }

            try
            {
                _companyConfigurationRepository.Update(companyConfiguration);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CompanyConfigurations
        [ResponseType(typeof(CompanyConfiguration))]
        public IHttpActionResult PostCompanyConfiguration(CompanyConfiguration companyConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CompanyConfiguration addedCompanyConfiguration = _companyConfigurationRepository.Insert(companyConfiguration);
            return CreatedAtRoute("DefaultApi", new { id = addedCompanyConfiguration.Id }, addedCompanyConfiguration);
        }

        // DELETE: api/CompanyConfigurations/5
        [ResponseType(typeof(CompanyConfiguration))]
        public IHttpActionResult DeleteCompanyConfiguration(int id)
        {
            _companyConfigurationRepository.Delete(id);
            return Ok();
        }
    }
}
