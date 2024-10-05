using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TailorManagementModels;
using System.Drawing.Printing;
using System.Drawing;
using TailorManagement1.Utilities;
using System.Threading;
using System.Text.RegularExpressions;
using System.Drawing.Text;
using System.Reflection;

namespace TailorManagement1
{
    public partial class BillForm : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        private string previousmobile = "";
        private static readonly Logger logger = Utilities.LoggerUtilities.GetLogger();
        private Bill bill = null;
        private List<Product> products = new List<Product>();
        private Product shirtProduct = null;
        private Product pantProduct = null;
        private List<ShirtConfiguration> shirtConfigurations = null;
        private List<PantConfiguration> pantConfigurations = null;
        private int configShirtQty = 1;
        private int configPantQty = 1;
        private decimal configShirtPrice = 300;
        private decimal configPantPrice = 300;
        private int configDeliveryDays = 15;
        private int configTrialDays = 15;

        public BillForm()
        {
            InitializeComponent();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printPreviewDialog.Document = printDocument;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintUtilities.PrintBill(bill, e.Graphics);
            e.HasMorePages = false;
        }



        private async void GetAllProducts()
        {
            try
            {
                if (products != null)
                {
                    products = await ApiClient.GetApiClient().GetAsync<List<Product>>("api/Products");
                    shirtProduct = products.Where(x => x.Name.ToLower() == "shirt").FirstOrDefault();
                    pantProduct = products.Where(x => x.Name.ToLower() == "pant").FirstOrDefault();
                }
                GetAmounts();
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private async void SaveBill(bool isPrint = false)
        {
            try
            {
                rtError.Text = "";
                if (bill == null)
                {
                    bill = new Bill();
                    bill.Pant = new Pant();
                    bill.Shirt = new Shirt();
                    bill.BillDetails = new List<BillDetail>();
                }
                bill.BillDate = dtBillDate.Value;
                //bill.BillNo = Convert.ToInt32(txtBillNo.Text);
                bill.DeliveryDate = dtDeliveryDate.Value;
                bill.ExtraCost = Convert.ToDecimal(txtExtraCost.Text);
                bill.Discount = Convert.ToDecimal(txtDiscount.Text);
                bill.PaidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                bill.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                bill.TrialDate = dtTrailDate.Value;

                bill.BillDetails = GetBillDetails();
                bill.Customer = GetCustomerDetails();
                bill.Shirt = GetShirtDetails();
                bill.Pant = GetPantDetails();

                StringBuilder error;
                if (!bill.isValid(out error))
                {
                    rtError.Text = error.ToString();
                    return;
                }

                GetAmounts();
                Bill addedBill = await ApiClient.GetApiClient().PostAsync(bill, "api/bills");
                if (addedBill == null)
                {
                    rtError.Text = "Some error occured while creating bill, please contact system administrator for more details";
                    return;
                }
                bill.Id = addedBill.Id;
                bill.BillNo = addedBill.BillNo;
                txtBillNo.Text = addedBill.BillNo.ToString();
                ResetButtons(false);
                MessageBox.Show($"Bill {addedBill.BillNo} is created successfully.");
                if (isPrint)
                {
                    PrintBill();
                }
            }
            catch (Exception ex)
            {
                rtError.Text = "Some error occured while creating bill, please contact system administrator for more details";
                logger.Error($"{ex}");
            }
        }

        private Pant GetPantDetails()
        {
            try
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
                    Notes = Regex.Replace(rtPantNotes.Text.Trim(), @"\s+", " "),
                    Seat1 = txtSeat1.Text.Trim(),
                    Seat2 = txtSeat2.Text.Trim(),
                    Seat3 = txtSeat3.Text.Trim(),
                    Seat4 = txtSeat4.Text.Trim(),
                    Seat5 = txtSeat5.Text.Trim()
                };
                return pant;
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
                return null;
            }
        }

        private Customer GetCustomerDetails()
        {
            try
            {
                Customer customer = new Customer()
                {
                    Name = txtName.Text.Trim(),
                    Mobile = txtMobile.Text.Trim()
                };
                return customer;
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
                return null;
            }
        }

        private Shirt GetShirtDetails()
        {
            try
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
                    Notes = Regex.Replace(rtShirtNotes.Text.Trim(), @"\s+", " "),
                    Solder1 = txtSolder1.Text.Trim(),
                    Solder2 = txtSolder2.Text.Trim(),
                    Solder3 = txtSolder3.Text.Trim(),
                    Solder4 = txtSolder4.Text.Trim(),
                    Solder5 = txtSolder5.Text.Trim()
                };
                return shirt;
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
                return null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveBill();
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private List<BillDetail> GetBillDetails()
        {
            try
            {
                //Please confirm the following code while testing as it takes price from product table but I am going to change it from config file
                //List<BillDetail> billDetails = new List<BillDetail>
                //{
                //    new BillDetail() { Product = shirtProduct, Price = shirtProduct.Price, Qty = Convert.ToInt32(txtShirtQty.Text) },
                //    new BillDetail() { Product = pantProduct, Price = pantProduct.Price, Qty = Convert.ToInt32(txtPantQty.Text) }
                //};
                List<BillDetail> billDetails = new List<BillDetail>
                {
                    new BillDetail() { Product = shirtProduct, Price = configShirtPrice, Qty = Convert.ToInt32(txtShirtQty.Text) },
                    new BillDetail() { Product = pantProduct, Price = configPantPrice, Qty = Convert.ToInt32(txtPantQty.Text) }
                };
                return billDetails;
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
                return null;
            }
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            try
            {
                LanguageUtilities.ChangeLanguage(this, ConfigUtilities.companyLanguageCode);
                LoadCompanyConfiguration();
                GetCustomers();
                NewBill();
                GetAllProducts();
                LoadAllShirtConfigurations();
                LoadAllPantConfigurations();
                Thread.Sleep(2000);
                GetAmounts();
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private async void GetCustomers()
        {
            try
            {
                IEnumerable<Customer> customers = await ApiClient.GetApiClient().GetAsync<IEnumerable<Customer>>($"api/customers");
                if (customers != null)
                {
                    List<string> mobiles = customers.Select(x => x.Mobile).Distinct().ToList();
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                    autoCompleteCollection.AddRange(mobiles.ToArray());

                    txtMobile.AutoCompleteCustomSource = autoCompleteCollection;
                    txtMobile.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtMobile.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private async void LoadCompanyConfiguration()
        {
            configPantQty = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTQTY, "1"));
            configShirtQty = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTQTY, "1"));
            configPantPrice = Convert.ToDecimal(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTPRICE, "300.00"));
            configShirtPrice = Convert.ToDecimal(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTPRICE, "300.00"));
            configDeliveryDays = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.DELIVERYDAYS, "15"));
            configTrialDays = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.TRIALDAYS, "14"));

            int configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTLAMBAI, "1"));
            VisibleMeasureMents("txtPantLambai", configValue, panelPant);
            configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTKAMAR, "1"));
            VisibleMeasureMents("txtKamar", configValue, panelPant);
            configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTSEAT, "1"));
            VisibleMeasureMents("txtSeat", configValue, panelPant);
            configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTJANGH, "1"));
            VisibleMeasureMents("txtJangh", configValue, panelPant);
            configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTGOTHAN, "1"));
            VisibleMeasureMents("txtGothan", configValue, panelPant);
            configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTJOLO, "1"));
            VisibleMeasureMents("txtJolo", configValue, panelPant);
            configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PANTMOLI, "1"));
            VisibleMeasureMents("txtMoli", configValue, panelPant);

            configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTLAMBAI, "1"));
            VisibleMeasureMents("txtShirtLambai", configValue, panelShirt);
            configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTCHATI, "1"));
            VisibleMeasureMents("txtChati", configValue, panelShirt);
            configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTSOLDER, "1"));
            VisibleMeasureMents("txtSolder", configValue, panelShirt);
            configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTBYE, "1"));
            VisibleMeasureMents("txtBye", configValue, panelShirt);
            configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTFRONT, "1"));
            VisibleMeasureMents("txtFront", configValue, panelShirt);
            configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTKOLOR, "1"));
            VisibleMeasureMents("txtKolor", configValue, panelShirt);
            configValue = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.SHIRTCUFF, "1"));
            VisibleMeasureMents("txtCuff", configValue, panelShirt);
        }

        private void VisibleMeasureMents(string controlName, int configValue, Control parent)
        {
            Control.ControlCollection controlCollection = null;
            if (parent == null)
            {
                controlCollection = this.Controls;
            }
            else 
            {
                controlCollection = parent.Controls;
            }

            for(int i = 5; i > 1; i--) 
            {
                if(configValue < i)
                {
                    TextBox textBox = controlCollection[$"{controlName}{i}"] as TextBox;
                    if(textBox != null)
                    {
                        textBox.Visible = false;
                    }
                }
            }
        }

        private void NewBill()
        {
            try
            {
                bill = new Bill
                {
                    Pant = new Pant(),
                    Shirt = new Shirt(),
                    BillDetails = new List<BillDetail>()
                };

                ClearControls(this);
                FillBillConfiguration();
                ResetButtons(true);
                previousmobile = "";
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private void ResetButtons(bool isNew)
        {
            try
            {
                btnSave.Enabled = isNew;
                btnSaveAndPrint.Enabled = isNew;
                btnPrint.Enabled = !isNew;
                btnPreview.Enabled = !isNew;
                btnNew.Enabled = !isNew;
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private void FillBillConfiguration()
        {
            try
            {

                txtShirtQty.Text = configShirtQty.ToString();
                txtPantQty.Text = configPantQty.ToString();
                dtDeliveryDate.Value = DateTime.Now.AddDays(configDeliveryDays);
                dtTrailDate.Value = DateTime.Now.AddDays(configTrialDays);
                txtExtraCost.Text = "0.00";
                txtDiscount.Text = "0.00";
                txtPaidAmount.Text = "0.00";
                return;

                //txtBye1.Text = "B1";
                //txtBye2.Text = "B2";
                //txtBye3.Text = "B3";
                //txtBye4.Text = "B4";
                //txtBye5.Text = "B5";
                //txtChati1.Text = "C1";
                //txtChati2.Text = "C2";
                //txtChati3.Text = "C3";
                //txtChati4.Text = "C4";
                //txtChati5.Text = "C5";
                //txtCuff1.Text = "CF1";
                //txtCuff2.Text = "CF2";
                //txtCuff3.Text = "CF3";
                //txtCuff4.Text = "CF4";
                //txtCuff5.Text = "CF5";
                //txtFront1.Text = "F1";
                //txtFront2.Text = "F2";
                //txtFront3.Text = "F3";
                //txtFront4.Text = "F4";
                //txtFront5.Text = "F5";
                //txtGothan1.Text = "G1";
                //txtGothan2.Text = "G2";
                //txtGothan3.Text = "G3";
                //txtGothan4.Text = "G4";
                //txtGothan5.Text = "G5";
                //txtJangh1.Text = "J1";
                //txtJangh2.Text = "J2";
                //txtJangh3.Text = "J3";
                //txtJangh4.Text = "J4";
                //txtJangh5.Text = "J5";
                //txtJolo1.Text = "JL1";
                //txtJolo2.Text = "JL2";
                //txtJolo3.Text = "JL3";
                //txtJolo4.Text = "JL4";
                //txtJolo5.Text = "JL5";
                //txtKamar1.Text = "K1";
                //txtKamar2.Text = "K2";
                //txtKamar3.Text = "K3";
                //txtKamar4.Text = "K4";
                //txtKamar5.Text = "K5";
                //txtKolor1.Text = "KL1";
                //txtKolor2.Text = "KL2";
                //txtKolor3.Text = "KL3";
                //txtKolor4.Text = "KL4";
                //txtKolor5.Text = "KL5";
                //txtMobile.Text = "7698784947";
                //txtMoli1.Text = "M1";
                //txtMoli2.Text = "M2";
                //txtMoli3.Text = "M3";
                //txtMoli4.Text = "M4";
                //txtMoli5.Text = "M5";
                //txtName.Text = "RAKESH";
                //txtPantLambai1.Text = "PL1";
                //txtPantLambai2.Text = "PL2";
                //txtPantLambai3.Text = "PL3";
                //txtPantLambai4.Text = "PL4";
                //txtPantLambai5.Text = "PL5";
                //txtSeat1.Text = "S1";
                //txtSeat2.Text = "S2";
                //txtSeat3.Text = "S3";
                //txtSeat4.Text = "S4";
                //txtSeat5.Text = "S5";
                //txtShirtLambai1.Text = "SL1";
                //txtShirtLambai2.Text = "SL2";
                //txtShirtLambai3.Text = "SL3";
                //txtShirtLambai4.Text = "SL4";
                //txtShirtLambai5.Text = "SL5";
                //txtSolder1.Text = "SO1";
                //txtSolder2.Text = "SO2";
                //txtSolder3.Text = "SO3";
                //txtSolder4.Text = "SO4";
                //txtSolder5.Text = "SO5";
                //rtPantNotes.Text = "Pant Notes";
                //rtShirtNotes.Text = "Shirt Notes";
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private void ClearControls(Control control)
        {
            try
            {
                foreach (Control subControl in control.Controls)
                {
                    if (subControl is TextBox)
                    {
                        TextBox textBox = (TextBox)subControl;
                        textBox.Text = "";
                    }
                    else if (subControl is RichTextBox)
                    {
                        RichTextBox richTextBox = (RichTextBox)subControl;
                        richTextBox.Text = "";
                    }
                    else if (subControl is CheckedListBox)
                    {
                        CheckedListBox checkedListBox = (CheckedListBox)subControl;
                        for (int i = 0; i < checkedListBox.Items.Count; i++)
                        {
                            checkedListBox.SetItemChecked(i, false);
                        }
                    }
                    else if (subControl is Panel)
                    {
                        this.ClearControls(subControl);
                    }
                }
            }
            catch (Exception)
            {
                // Handle any exceptions here
            }
        }


        private void GetAmounts()
        {
            try
            {
                //Please confirm the following code while testing as it takes price from product table but I am going to change it from config file
                //decimal pantPrice = pantProduct.Price;
                //decimal shirtPrice = shirtProduct.Price;
                decimal pantPrice = configPantPrice;
                decimal shirtPrice = configShirtPrice;
                decimal pantQty = Convert.ToDecimal(txtPantQty.Text);
                decimal shirtQty = Convert.ToDecimal(txtShirtQty.Text);
                decimal extraCost = Convert.ToDecimal(txtExtraCost.Text);
                decimal discount = Convert.ToDecimal(txtDiscount.Text);

                decimal totalAmount = (pantPrice * pantQty) + (shirtPrice * shirtQty) + extraCost - discount;
                txtTotalAmount.Text = totalAmount.ToString("F2");

                decimal paidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                decimal dueAmount = totalAmount - paidAmount;
                txtDueAmount.Text = dueAmount.ToString("F2");
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private async void LoadAllShirtConfigurations()
        {
            try
            {
                shirtConfigurations = await ApiClient.GetApiClient().GetAsync<List<ShirtConfiguration>>("api/ShirtConfigurations");
                if (shirtConfigurations != null)
                {
                    foreach (ShirtConfiguration shirtConfiguration in shirtConfigurations)
                    {
                        chkListShirt.Items.Add(shirtConfiguration.LocalDescription);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private async void LoadAllPantConfigurations()
        {
            try
            {
                pantConfigurations = await ApiClient.GetApiClient().GetAsync<List<PantConfiguration>>("api/PantConfigurations");
                if (pantConfigurations != null)
                {
                    foreach (PantConfiguration PantConfiguration in pantConfigurations)
                    {
                        chkListPant.Items.Add(PantConfiguration.LocalDescription);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private void BillForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormUtilities.FormKeyPress(sender, e);
        }

        private void chkListPant_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (e.NewValue == CheckState.Checked)
                {
                    string selectedItemText = chkListPant.Items[e.Index].ToString();
                    if (!rtPantNotes.Text.Contains(selectedItemText))
                    {
                        rtPantNotes.Text = selectedItemText + Environment.NewLine + rtPantNotes.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private void chkListShirt_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                string selectedItemText = chkListShirt.Items[e.Index].ToString();
                if (e.NewValue == CheckState.Checked)
                {
                    if (!rtShirtNotes.Text.Contains(selectedItemText))
                    {
                        rtShirtNotes.Text = selectedItemText + Environment.NewLine + rtShirtNotes.Text;
                    }
                }
                else
                {
                    if (!rtShirtNotes.Text.Contains(selectedItemText))
                    {
                        rtShirtNotes.Text = rtShirtNotes.Text.Replace(selectedItemText, "");
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private void txtShirtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                FormUtilities.NumericControlKeyPress(sender, e, true);
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private void txtPantQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                FormUtilities.NumericControlKeyPress(sender, e, true);
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }
                
        private void txtMobile_Leave(object sender, EventArgs e)
        {
            try
            {
                CheckCustomerExist(txtMobile.Text.Trim());
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private async void CheckCustomerExist(string mobile)
        {
            try
            {
                if(previousmobile == mobile)
                {
                    return;
                }
                Customer customer = await ApiClient.GetApiClient().GetAsync<Customer>($"api/customerbymobile/{mobile}");
                if (customer != null)
                {
                    DialogResult result = MessageBox.Show($"Existing customer found with mobile no {mobile}, do you want to load the existing measurements?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        previousmobile = mobile;
                        int customerId = customer.Id;
                        txtName.Text = customer.Name;

                        Pant pant = await ApiClient.GetApiClient().GetAsync<Pant>($"api/pantbycustomerid/{customerId}");
                        if (pant != null)
                        {
                            FillPantControls(pant);
                        }
                        Shirt shirt = await ApiClient.GetApiClient().GetAsync<Shirt>($"api/shirtbycustomerid/{customerId}");
                        if (shirt != null)
                        {
                            FillShirtControls(shirt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private void FillPantControls(Pant pant)
        {
            try
            {
                txtPantLambai1.Text = pant.Length1;
                txtPantLambai2.Text = pant.Length2;
                txtPantLambai3.Text = pant.Length3;
                txtPantLambai4.Text = pant.Length4;
                txtPantLambai5.Text = pant.Length5;
                txtKamar1.Text = pant.Kamar1;
                txtKamar2.Text = pant.Kamar2;
                txtKamar3.Text = pant.Kamar3;
                txtKamar4.Text = pant.Kamar4;
                txtKamar5.Text = pant.Kamar5;
                txtSeat1.Text = pant.Seat1;
                txtSeat2.Text = pant.Seat2;
                txtSeat3.Text = pant.Seat3;
                txtSeat4.Text = pant.Seat4;
                txtSeat5.Text = pant.Seat5;
                txtJangh1.Text = pant.Jangh1;
                txtJangh2.Text = pant.Jangh2;
                txtJangh3.Text = pant.Jangh3;
                txtJangh4.Text = pant.Jangh4;
                txtJangh5.Text = pant.Jangh5;
                txtGothan1.Text = pant.Gothan1;
                txtGothan2.Text = pant.Gothan2;
                txtGothan3.Text = pant.Gothan3;
                txtGothan4.Text = pant.Gothan4;
                txtGothan5.Text = pant.Gothan5;
                txtJolo1.Text = pant.Jolo1;
                txtJolo2.Text = pant.Jolo2;
                txtJolo3.Text = pant.Jolo3;
                txtJolo4.Text = pant.Jolo4;
                txtJolo5.Text = pant.Jolo5;
                txtMoli1.Text = pant.Moli1;
                txtMoli2.Text = pant.Moli2;
                txtMoli3.Text = pant.Moli3;
                txtMoli4.Text = pant.Moli4;
                txtMoli5.Text = pant.Moli5;
                rtPantNotes.Text = pant.Notes;
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private void FillShirtControls(Shirt shirt)
        {
            try
            {
                txtShirtLambai1.Text = shirt.Length1;
                txtShirtLambai2.Text = shirt.Length2;
                txtShirtLambai3.Text = shirt.Length3;
                txtShirtLambai4.Text = shirt.Length4;
                txtShirtLambai5.Text = shirt.Length5;
                txtChati1.Text = shirt.Chati1;
                txtChati2.Text = shirt.Chati2;
                txtChati3.Text = shirt.Chati3;
                txtChati4.Text = shirt.Chati4;
                txtChati5.Text = shirt.Chati5;
                txtSolder1.Text = shirt.Solder1;
                txtSolder2.Text = shirt.Solder2;
                txtSolder3.Text = shirt.Solder3;
                txtSolder4.Text = shirt.Solder4;
                txtSolder5.Text = shirt.Solder5;
                txtBye1.Text = shirt.Bye1;
                txtBye2.Text = shirt.Bye2;
                txtBye3.Text = shirt.Bye3;
                txtBye4.Text = shirt.Bye4;
                txtBye5.Text = shirt.Bye5;
                txtFront1.Text = shirt.Front1;
                txtFront2.Text = shirt.Front2;
                txtFront3.Text = shirt.Front3;
                txtFront4.Text = shirt.Front4;
                txtFront5.Text = shirt.Front5;
                txtKolor1.Text = shirt.Kolor1;
                txtKolor2.Text = shirt.Kolor2;
                txtKolor3.Text = shirt.Kolor3;
                txtKolor4.Text = shirt.Kolor4;
                txtKolor5.Text = shirt.Kolor5;
                txtCuff1.Text = shirt.Cuff1;
                txtCuff2.Text = shirt.Cuff2;
                txtCuff3.Text = shirt.Cuff3;
                txtCuff4.Text = shirt.Cuff4;
                txtCuff5.Text = shirt.Cuff5;
                rtShirtNotes.Text = shirt.Notes;
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                NewBill();
                GetAmounts();
                txtMobile.Focus();
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintBill();
        }

        private void PrintBill()
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            printDocument.Print();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog.WindowState = FormWindowState.Maximized;
            printPreviewDialog.ShowDialog();
        }

        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            try
            {
                SaveBill(true);                
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        private void txtPantQty_Leave(object sender, EventArgs e)
        {
            FormUtilities.NumericControlLeave(sender, e, true);
            GetAmounts();
        }

        private void txtShirtQty_Leave(object sender, EventArgs e)
        {
            FormUtilities.NumericControlLeave(sender, e, true);
            GetAmounts();
        }

        private void txtExtraCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormUtilities.NumericControlKeyPress(sender, e);
        }

        private void txtExtraCost_Leave(object sender, EventArgs e)
        {
            FormUtilities.NumericControlLeave(sender, e);
            GetAmounts();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormUtilities.NumericControlKeyPress(sender, e);
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            FormUtilities.NumericControlLeave(sender, e);
            GetAmounts();
        }

        private void txtPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormUtilities.NumericControlKeyPress(sender, e);
        }

        private void txtPaidAmount_Leave(object sender, EventArgs e)
        {
            FormUtilities.NumericControlLeave(sender, e);
            GetAmounts();
        }

        private void txtMobile_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
    }
}
