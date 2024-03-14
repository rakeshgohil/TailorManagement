using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TailorManagementModels;

namespace TailorManagementAPI.Controllers
{
    public class PantsController : ApiController
    {
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
            return _pantRepository.GetAll();
        }

        // GET: api/pants/5
        [ResponseType(typeof(Pant))]
        public IHttpActionResult GetPant(int id)
        {
            var pant = _pantRepository.GetById(id);
            if (pant == null)
            {
                return NotFound();
            }

            return Ok(pant);
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
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/pants
        [ResponseType(typeof(Pant))]
        public IHttpActionResult PostPant(Pant pant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int addedId = _pantRepository.Insert(pant);
            return CreatedAtRoute("DefaultApi", new { id = addedId }, pant);
        }

        // DELETE: api/pants/5
        [ResponseType(typeof(Pant))]
        public IHttpActionResult DeletePant(int id)
        {
            _pantRepository.Delete(id);
            return Ok();
        }
    }
}
