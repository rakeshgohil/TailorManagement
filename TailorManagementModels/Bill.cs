using System;

namespace TailorManagementModels
{
    public class Bill
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int BillNo { get; set; }

        public DateTime BillDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime TrialDate { get; set; }

        public decimal ExtraCost { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal DueAmount { get { return TotalAmount - PaidAmount; } }
    }


    public class BillDetail
    {
        public int Id { get; set; }

        public int BillId { get; set; }

        public int MenuId { get; set; }

        public decimal Qty { get; set; }

        public decimal Price { get; set; }

        public decimal Total => Qty * Price;
    }

}
