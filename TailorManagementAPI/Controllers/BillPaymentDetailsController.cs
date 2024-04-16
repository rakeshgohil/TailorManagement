using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TailorManagementModels;

namespace TailorManagementAPI.Controllers
{
    public class BillPaymentDetailsController : ApiController
    {
        private readonly IRepository<BillPaymentDetail> _billPaymentDetailRepository;
        public BillPaymentDetailsController()
        {
        }
        public BillPaymentDetailsController(IRepository<BillPaymentDetail> billPaymentDetailRepository)
        {
            _billPaymentDetailRepository = billPaymentDetailRepository;
        }

        // GET: api/billPaymentDetails
        public IEnumerable<BillPaymentDetail> GetBillPaymentDetails()
        {
            return _billPaymentDetailRepository.GetAll();
        }

        // GET: api/billPaymentDetails/5
        [ResponseType(typeof(BillPaymentDetail))]
        public IHttpActionResult GetBillPaymentDetail(int id)
        {
            var bill = _billPaymentDetailRepository.GetById(id);
            if (bill == null)
            {
                return NotFound();
            }

            return Ok(bill);
        }

        // PUT: api/billPaymentDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBillPaymentDetail(int id, BillPaymentDetail billPaymentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != billPaymentDetail.Id)
            {
                return BadRequest();
            }

            try
            {
                _billPaymentDetailRepository.Update(billPaymentDetail);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/billPaymentDetails
        [ResponseType(typeof(BillPaymentDetail))]
        public IHttpActionResult PostBillPaymentDetail(BillPaymentDetail billPaymentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BillPaymentDetail addedBillPaymentDetail = _billPaymentDetailRepository.Insert(billPaymentDetail);
            return CreatedAtRoute("DefaultApi", new { id = addedBillPaymentDetail.Id }, addedBillPaymentDetail);
        }

        // DELETE: api/billPaymentDetails/5
        [ResponseType(typeof(BillPaymentDetail))]
        public IHttpActionResult DeleteBillPaymentDetail(int id)
        {
            _billPaymentDetailRepository.Delete(id);
            return Ok();
        }
    }
}
