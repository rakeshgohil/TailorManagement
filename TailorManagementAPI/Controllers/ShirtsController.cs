using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TailorManagementModels;

namespace TailorManagementAPI.Controllers
{
    public class ShirtsController : ApiController
    {
        private readonly IRepository<Shirt> _shirtRepository;
        public ShirtsController()
        {
        }
        public ShirtsController(IRepository<Shirt> shirtRepository)
        {
            _shirtRepository = shirtRepository;
        }

        // GET: api/shirts
        public IEnumerable<Shirt> GetShirts()
        {
            return _shirtRepository.GetAll();
        }

        // GET: api/shirts/5
        [ResponseType(typeof(Shirt))]
        public IHttpActionResult GetShirt(int id)
        {
            var shirt = _shirtRepository.GetById(id);
            if (shirt == null)
            {
                return NotFound();
            }

            return Ok(shirt);
        }

        // PUT: api/shirts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShirt(int id, Shirt shirt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shirt.Id)
            {
                return BadRequest();
            }

            try
            {
                _shirtRepository.Update(shirt);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/shirts
        [ResponseType(typeof(Shirt))]
        public IHttpActionResult PostShirt(Shirt shirt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int addedId = _shirtRepository.Insert(shirt);
            return CreatedAtRoute("DefaultApi", new { id = addedId }, shirt);
        }

        // DELETE: api/shirts/5
        [ResponseType(typeof(Shirt))]
        public IHttpActionResult DeleteShirt(int id)
        {
            _shirtRepository.Delete(id);
            return Ok();
        }
    }
}
