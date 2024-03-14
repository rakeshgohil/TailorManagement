using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TailorManagementModels;

namespace TailorManagement1
{
    public partial class BillForm : Form
    {
        private Bill bill = null;
        private List<Product> products = new List<Product>();
        private Product shirtProduct = null;
        private Product pantProduct = null;

        public BillForm()
        {
            InitializeComponent();
            bill = new Bill
            {
                Pant = new Pant(),
                Shirt = new Shirt(),
                BillDetails = new List<BillDetail>()
            };

            GetAllProducts();
        }

        private async void GetAllProducts()
        {
            products = await ApiClient.GetApiClient().GetAsync<List<Product>>("api/Products");
            if (products != null)
            {
                shirtProduct = products.Where(x => x.Name.ToLower() == "shirt").FirstOrDefault();
                pantProduct = products.Where(x => x.Name.ToLower() == "pant").FirstOrDefault();                
            }
        }

        private async void SaveBill()
        {            
            if(bill == null)
            {
                bill = new Bill();
                bill.Pant = new Pant();
                bill.Shirt = new Shirt();
                bill.BillDetails = new List<BillDetail>();
            }
            bill.BillDate = dtBillDate.Value;
            bill.BillNo = Convert.ToInt32(txtBillNo.Text);
            bill.DeliveryDate = dtDeliveryDate.Value;
            bill.ExtraCost = Convert.ToDecimal(mskExtraCost.Text);
            bill.PaidAmount = Convert.ToDecimal(mskPaidAmount.Text);
            bill.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
            bill.TrialDate = dtTrailDate.Value;

            bill.BillDetails = GetBillDetails();
            bill.Customer = GetCustomerDetails();
            bill.Shirt = GetShirtDetails();
            bill.Pant = GetPantDetails();

            StringBuilder error;
            if (bill.isValid(out error))
            {
                rtError.Text = error.ToString();
            }

                //Customer customer = await ApiClient.GetApiClient().PostAsync(bill, "api/Customer");
                Bill addedBill = await ApiClient.GetApiClient().PostAsync(bill, "api/Bill");
                bill.Id = addedBill.Id;
        }

        private Pant GetPantDetails()
        {
            Pant pant = new Pant
            {

                Gothan1 = txtGothan1.Text.Trim(),
                Gothan2 = txtGothan2.Text.Trim(),
                Gothan3 = txtGothan3.Text.Trim(),
                Gothan4 = txtGothan4.Text.Trim(),
                Gothan5 = txtGothan5.Text.Trim(),
                Jangh1 = txtJangh1.Text.Trim(),
                Jangh2 = txtJangh2.Text.Trim(),
                Jangh3 = txtJangh3.Text.Trim(),
                Jangh4 = txtJangh4.Text.Trim(),
                Jangh5 = txtJangh5.Text.Trim(),
                Jolo1 = txtJolo1.Text.Trim(),
                Jolo2 = txtJolo2.Text.Trim(),
                Jolo3 = txtJolo3.Text.Trim(),
                Jolo4 = txtJolo4.Text.Trim(),
                Jolo5 = txtJolo5.Text.Trim(),
                Kamar1 = txtKamar1.Text.Trim(),
                Kamar2 = txtKamar2.Text.Trim(),
                Kamar3 = txtKamar3.Text.Trim(),
                Kamar4 = txtKamar4.Text.Trim(),
                Kamar5 = txtKamar5.Text.Trim(),
                Moli1 = txtMoli1.Text.Trim(),
                Moli2 = txtMoli2.Text.Trim(),
                Moli3 = txtMoli3.Text.Trim(),
                Moli4 = txtMoli4.Text.Trim(),
                Moli5 = txtMoli5.Text.Trim(),
                Length1 = txtPantLambai1.Text.Trim(),
                Length2 = txtPantLambai2.Text.Trim(),
                Length3 = txtPantLambai3.Text.Trim(),
                Length4 = txtPantLambai4.Text.Trim(),
                Length5 = txtPantLambai5.Text.Trim(),
                Notes = rtPantNotes.Text.Trim(),
                Seat1 = txtSeat1.Text.Trim(),
                Seat2 = txtSeat2.Text.Trim(),
                Seat3 = txtSeat3.Text.Trim(),
                Seat4 = txtSeat4.Text.Trim(),
                Seat5 = txtSeat5.Text.Trim()
            };
            return pant;
        }

        private Customer GetCustomerDetails()
        {
            Customer customer = new Customer()
            {
                Name = txtName.Text.Trim(),
                Mobile = txtMobile.Text.Trim()
            };
            return customer;
        }

        private Shirt GetShirtDetails()
        {
            Shirt shirt = new Shirt
            {
                Bye1 = txtBye1.Text.Trim(),
                Bye2 = txtBye2.Text.Trim(),
                Bye3 = txtBye3.Text.Trim(),
                Bye4 = txtBye4.Text.Trim(),
                Bye5 = txtBye5.Text.Trim(),
                Chati1 = txtChati1.Text.Trim(),
                Chati2 = txtChati2.Text.Trim(),
                Chati3 = txtChati3.Text.Trim(),
                Chati4 = txtChati4.Text.Trim(),
                Chati5 = txtChati5.Text.Trim(),
                Cuff1 = txtCuff1.Text.Trim(),
                Cuff2 = txtCuff2.Text.Trim(),
                Cuff3 = txtCuff3.Text.Trim(),
                Cuff4 = txtCuff4.Text.Trim(),
                Cuff5 = txtCuff5.Text.Trim(),
                Front1 = txtFront1.Text.Trim(),
                Front2 = txtFront2.Text.Trim(),
                Front3 = txtFront3.Text.Trim(),
                Front4 = txtFront4.Text.Trim(),
                Front5 = txtFront5.Text.Trim(),
                Kolor1 = txtKolor1.Text.Trim(),
                Kolor2 = txtKolor2.Text.Trim(),
                Kolor3 = txtKolor3.Text.Trim(),
                Kolor4 = txtKolor4.Text.Trim(),
                Kolor5 = txtKolor5.Text.Trim(),
                Length1 = txtShirtLambai1.Text.Trim(),
                Length2 = txtShirtLambai2.Text.Trim(),
                Length3 = txtShirtLambai3.Text.Trim(),
                Length4 = txtShirtLambai4.Text.Trim(),
                Length5 = txtShirtLambai5.Text.Trim(),
                Notes = rtShirtNotes.Text.Trim(),
                Solder1 = txtSolder1.Text.Trim(),
                Solder2 = txtSolder2.Text.Trim(),
                Solder3 = txtSolder3.Text.Trim(),
                Solder4 = txtSolder4.Text.Trim(),
                Solder5 = txtSolder5.Text.Trim()
            };
            return shirt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveBill();
        }

        private List<BillDetail> GetBillDetails()
        {
            List<BillDetail> billDetails = new List<BillDetail>();
            billDetails.Add(new BillDetail() { Product = shirtProduct, Price = shirtProduct.Price, Qty = Convert.ToInt32(txtShirtQty.Text) });
            billDetails.Add(new BillDetail() { Product = pantProduct, Price = pantProduct.Price, Qty = Convert.ToInt32(txtPantQty.Text) });
            return billDetails;
        }
    }
}
