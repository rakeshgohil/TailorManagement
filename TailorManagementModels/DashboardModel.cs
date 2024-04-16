using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorManagementModels
{
    public class DashboardModel
    {
        public int BillId { get; set; }
        public int BillNo { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerName { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Decimal TotalAmount { get; set; }
        public Decimal PaidAmount { get; set; }
        public Decimal DueAmount { get; set; }
    }
}
