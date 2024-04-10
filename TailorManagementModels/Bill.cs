using System;
using System.Collections.Generic;
using System.Text;

namespace TailorManagementModels
{
    public class Bill
    {
        public int Id { get; set; }
        public int BillNo { get; set; }
        public DateTime BillDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime TrialDate { get; set; }

        public decimal ExtraCost { get; set; }
        public decimal Discount { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal DueAmount { get { return TotalAmount - PaidAmount; } }
        public Customer Customer { get; set; }
        public Shirt Shirt { get; set; }
        public Pant Pant { get; set; }
        public List<BillDetail> BillDetails { get; set; }

        public bool isValid(out StringBuilder error)
        {
            error = new StringBuilder();
            
            StringBuilder customerError;
            Customer.isValid(out customerError);
            error.Append(customerError.ToString());

            StringBuilder pantError;
            Pant.isValid(out pantError);
            error.Append(pantError.ToString());

            StringBuilder shirtError;
            Shirt.isValid(out shirtError);
            error.Append(shirtError.ToString());

            //todo billdetails validation
            //todo bill validation

            if (string.IsNullOrWhiteSpace(error.ToString()))
            {
                return false;
            }
            return true;
        }
    }


    public class BillDetail
    {
        public int Id { get; set; }

        public int BillId { get; set; }

        public Product Product { get; set; }

        public decimal Qty { get; set; }

        public decimal Price { get; set; }
    }

}
