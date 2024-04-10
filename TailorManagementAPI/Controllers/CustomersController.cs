using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TailorManagementDB;
using TailorManagementModels;

namespace TailorManagementAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomersController()
        {
        }
        public CustomersController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetAll();
        }

        // GET: api/customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // GET: api/customerbymobile/7698784947
        [ResponseType(typeof(Customer))]
        [Route("api/customerbymobile/{mobile}")]
        public IHttpActionResult GetCustomerByMobile(string mobile)
        {
            var customer = ((CustomerRepository)_customerRepository).GetByMobileNo(mobile);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            try
            {
                _customerRepository.Update(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer addedCustomer = _customerRepository.Insert(customer);
            return CreatedAtRoute("DefaultApi", new { id = addedCustomer.Id }, addedCustomer);
        }

        // DELETE: api/customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
            return Ok();
        }
    }
}
