using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TailorManagementModels;

namespace TailorManagementAPI.Controllers
{
    public class BillsController : ApiController
    {
        private readonly IRepository<Bill> _billRepository;
        public BillsController()
        {
        }
        public BillsController(IRepository<Bill> billRepository)
        {
            _billRepository = billRepository;
        }

        // GET: api/bills
        public IEnumerable<Bill> GetBills()
        {
            return _billRepository.GetAll();
        }

        // GET: api/bills/5
        [ResponseType(typeof(Bill))]
        public IHttpActionResult GetBill(int id)
        {
            var bill = _billRepository.GetById(id);
            if (bill == null)
            {
                return NotFound();
            }

            return Ok(bill);
        }

        // PUT: api/bills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBill(int id, Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bill.Id)
            {
                return BadRequest();
            }

            try
            {
                _billRepository.Update(bill);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/bills
        [ResponseType(typeof(Bill))]
        public IHttpActionResult PostBill(Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int addedId = _billRepository.Insert(bill);
            return CreatedAtRoute("DefaultApi", new { id = addedId }, bill);
        }

        // DELETE: api/bills/5
        [ResponseType(typeof(Bill))]
        public IHttpActionResult DeleteBill(int id)
        {
            _billRepository.Delete(id);
            return Ok();
        }
    }
}
