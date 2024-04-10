using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TailorManagementDB;
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

        // GET: api/shirtbycustomerid/5
        [ResponseType(typeof(Shirt))]
        [Route("api/shirtbycustomerid/{customerId}")]
        public IHttpActionResult GetShirtByCustomerId(int customerId)
        {
            var shirt = ((ShirtRepository)_shirtRepository).GetByCustomerId(customerId);
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

            Shirt addedShirt = _shirtRepository.Insert(shirt);
            return CreatedAtRoute("DefaultApi", new { id = addedShirt.Id }, addedShirt);
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
