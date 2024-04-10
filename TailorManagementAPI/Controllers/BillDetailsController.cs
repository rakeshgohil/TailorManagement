using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TailorManagementModels;

namespace TailorManagementAPI.Controllers
{
    public class BillDetailsController : ApiController
    {
        private readonly IRepository<BillDetail> _billDetailRepository;
        public BillDetailsController()
        {
        }
        public BillDetailsController(IRepository<BillDetail> billDetailRepository)
        {
            _billDetailRepository = billDetailRepository;
        }

        // GET: api/billdetails
        public IEnumerable<BillDetail> GetBillDetails()
        {
            return _billDetailRepository.GetAll();
        }

        // GET: api/billdetails/5
        [ResponseType(typeof(BillDetail))]
        public IHttpActionResult GetBillDetail(int id)
        {
            var bill = _billDetailRepository.GetById(id);
            if (bill == null)
            {
                return NotFound();
            }

            return Ok(bill);
        }

        // PUT: api/billdetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBillDetail(int id, BillDetail billDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != billDetail.Id)
            {
                return BadRequest();
            }

            try
            {
                _billDetailRepository.Update(billDetail);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/billdetails
        [ResponseType(typeof(BillDetail))]
        public IHttpActionResult PostBillDetail(BillDetail billDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BillDetail addedBillDetail = _billDetailRepository.Insert(billDetail);
            return CreatedAtRoute("DefaultApi", new { id = addedBillDetail.Id }, addedBillDetail);
        }

        // DELETE: api/billdetails/5
        [ResponseType(typeof(BillDetail))]
        public IHttpActionResult DeleteBillDetail(int id)
        {
            _billDetailRepository.Delete(id);
            return Ok();
        }
    }
}
