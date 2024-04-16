using System.Collections.Generic;
using System.Web.Http;
using TailorManagementDB;
using TailorManagementModels;

namespace TailorManagementAPI.Controllers
{
    public class DashboardController : ApiController
    {
        private readonly DashboardRepository _dashboardRepository;
        public DashboardController()
        {
        }
        public DashboardController(DashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        // GET: api/DashBoard/DeliveryDues
        [HttpGet]
        [Route("api/DeliveryDues/{DelDueDays}")]
        public IEnumerable<DashboardModel> GetDeliveryDues(int DelDueDays)
        {
            return _dashboardRepository.GetDeliveryDues(DelDueDays);
        }

        // GET: api/DashBoard/PaymentDues
        [HttpGet]
        [Route("api/PaymentDues/{PayDueDays}")]
        public IEnumerable<DashboardModel> GetPaymentDues(int PayDueDays)
        {
            return _dashboardRepository.GetPaymentDues(PayDueDays);
        }
    }
}
