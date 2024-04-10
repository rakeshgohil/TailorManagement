using NLog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TailorManagementDB;
using TailorManagementModels;

namespace TailorManagementAPI.Controllers
{
    public class PantsController : ApiController
    {
        private static readonly Logger logger = Utilities.LoggerUtilities.GetLogger();
        private readonly IRepository<Pant> _pantRepository;
        public PantsController()
        {
        }
        public PantsController(IRepository<Pant> pantRepository)
        {
            _pantRepository = pantRepository;
        }

        // GET: api/pants
        public IEnumerable<Pant> GetPants()
        {
            try
            {
                return _pantRepository.GetAll();
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
                return null;
            }
            
        }

        // GET: api/pants/5
        [ResponseType(typeof(Pant))]
        public IHttpActionResult GetPant(int id)
        {
            try
            {
                var pant = _pantRepository.GetById(id);
                if (pant == null)
                {
                    return NotFound();
                }

                return Ok(pant);
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
                return BadRequest();
            }
        }

        // GET: api/pantbycustomerid/5
        [ResponseType(typeof(Pant))]
        [Route("api/pantbycustomerid/{customerId}")]
        public IHttpActionResult GetPantByCustomerId(int customerId)
        {
            try
            {
                var pant = ((PantRepository)_pantRepository).GetByCustomerId(customerId);
                if (pant == null)
                {
                    return NotFound();
                }

                return Ok(pant);
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
                return BadRequest();
            }
        }

        // PUT: api/pants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPant(int id, Pant pant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pant.Id)
            {
                return BadRequest();
            }

            try
            {
                _pantRepository.Update(pant);
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/pants
        [ResponseType(typeof(Pant))]
        public IHttpActionResult PostPant(Pant pant)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Pant addedPant = _pantRepository.Insert(pant);
                return CreatedAtRoute("DefaultApi", new { id = addedPant.Id }, addedPant);
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
                return BadRequest();
            }
        }

        // DELETE: api/pants/5
        [ResponseType(typeof(Pant))]
        public IHttpActionResult DeletePant(int id)
        {            
            try
            {
                _pantRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
                return BadRequest();
            }
        }
    }
}
