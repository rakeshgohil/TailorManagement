using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TailorManagement1.Utilities;
using TailorManagementModels;

namespace TailorManagement1
{
    public partial class DashboardForm : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        private int checkBoxColumnIndex = (int)EnumDashBoard.DueAmount + 1;
        private int btnDeleteColumnIndex = (int)EnumDashBoard.DueAmount + 1;
        private int btnPreviewColumnIndex = (int)EnumDashBoard.DueAmount + 2;
        private Bill bill;

        private enum EnumDashBoard
        {
            BillId,
            BillNo,
            CustomerMobile,
            CustomerName,
            BillDate,
            DeliveryDate,
            TotalAmount,
            PaidAmount,
            DueAmount
        }

        public DashboardForm()
        {
            InitializeComponent(); 
            printDocument.PrintPage += PrintDocument_PrintPage;
            printPreviewDialog.Document = printDocument;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LanguageUtilities.ChangeLanguage(this, ConfigUtilities.companyLanguageCode);
            FillDeliveryDueGrid();
            FillPaymentDueGrid();
        }
        private async void FillDeliveryDueGrid() 
        {
            dgvDeliveryDue.AutoGenerateColumns = false;
            dgvDeliveryDue.ColumnCount = 9;
            dgvDeliveryDue.Rows.Clear();

            dgvDeliveryDue.Columns[(int)EnumDashBoard.BillDate].HeaderText = "Bill Date";
            dgvDeliveryDue.Columns[(int)EnumDashBoard.BillId].HeaderText = "Id";
            dgvDeliveryDue.Columns[(int)EnumDashBoard.BillNo].HeaderText = "Bill No";
            dgvDeliveryDue.Columns[(int)EnumDashBoard.CustomerMobile].HeaderText = "Mobile";
            dgvDeliveryDue.Columns[(int)EnumDashBoard.CustomerName].HeaderText = "Name";
            dgvDeliveryDue.Columns[(int)EnumDashBoard.DeliveryDate].HeaderText = "Delivery Date";
            dgvDeliveryDue.Columns[(int)EnumDashBoard.DueAmount].HeaderText = "Due Amount";
            dgvDeliveryDue.Columns[(int)EnumDashBoard.PaidAmount].HeaderText = "Paid Amount";
            dgvDeliveryDue.Columns[(int)EnumDashBoard.TotalAmount].HeaderText = "Total Amount";

            dgvDeliveryDue.Columns[(int)EnumDashBoard.BillDate].Width = 130;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.BillId].Width = 0;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.BillNo].Width = 50;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.CustomerMobile].Width = 130;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.CustomerName].Width = 130;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.DeliveryDate].Width = 130;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.DueAmount].Width = 130;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.PaidAmount].Width = 130;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.TotalAmount].Width = 130;
            
            int configDeliveryDays = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.DELIVERYDAYS, "15"));
            List<DashboardModel> deliveryDues = await ApiClient.GetApiClient().GetAsync<List<DashboardModel>>($"api/DeliveryDues/{configDeliveryDays}");
            if (deliveryDues != null)
            {
                DataGridViewButtonColumn btnPreviewColumn = new DataGridViewButtonColumn();
                btnPreviewColumn.HeaderText = "Preview";
                btnPreviewColumn.Width = 100;
                dgvDeliveryDue.Columns.Add(btnPreviewColumn);

                DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn();
                btnDeleteColumn.HeaderText = "Delete";
                btnDeleteColumn.Width = 100;
                dgvDeliveryDue.Columns.Add(btnDeleteColumn);

                foreach (DashboardModel deliveryDue in deliveryDues)
                {
                    int index = dgvDeliveryDue.Rows.Add();
                    dgvDeliveryDue.Rows[index].Cells[(int)EnumDashBoard.BillId].Value = deliveryDue.BillId;
                    dgvDeliveryDue.Rows[index].Cells[(int)EnumDashBoard.CustomerName].Value = deliveryDue.CustomerName;
                    dgvDeliveryDue.Rows[index].Cells[(int)EnumDashBoard.BillDate].Value = deliveryDue.BillDate;
                    dgvDeliveryDue.Rows[index].Cells[(int)EnumDashBoard.BillNo].Value = deliveryDue.BillNo;
                    dgvDeliveryDue.Rows[index].Cells[(int)EnumDashBoard.CustomerMobile].Value = deliveryDue.CustomerMobile;
                    dgvDeliveryDue.Rows[index].Cells[(int)EnumDashBoard.DeliveryDate].Value = deliveryDue.DeliveryDate;
                    dgvDeliveryDue.Rows[index].Cells[(int)EnumDashBoard.PaidAmount].Value = deliveryDue.PaidAmount;
                    dgvDeliveryDue.Rows[index].Cells[(int)EnumDashBoard.TotalAmount].Value = deliveryDue.TotalAmount;
                    dgvDeliveryDue.Rows[index].Cells[(int)EnumDashBoard.DueAmount].Value = deliveryDue.DueAmount;

                    DataGridViewButtonCell buttonDelete = new DataGridViewButtonCell();
                    buttonDelete.Value = "Delete";
                    dgvDeliveryDue.Rows[index].Cells[btnDeleteColumnIndex] = buttonDelete;

                    DataGridViewButtonCell buttonPreview = new DataGridViewButtonCell();
                    buttonPreview.Value = "Preview";
                    dgvDeliveryDue.Rows[index].Cells[btnPreviewColumnIndex] = buttonPreview;
                }
            }
        }

        private async void FillPaymentDueGrid()
        {
            dgvPaymentDue.AutoGenerateColumns = false;
            dgvPaymentDue.ColumnCount = 9;
            dgvPaymentDue.Rows.Clear();

            dgvPaymentDue.Columns[(int)EnumDashBoard.BillDate].HeaderText = "Bill Date";
            dgvPaymentDue.Columns[(int)EnumDashBoard.BillId].HeaderText = "Id";
            dgvPaymentDue.Columns[(int)EnumDashBoard.BillNo].HeaderText = "Bill No";
            dgvPaymentDue.Columns[(int)EnumDashBoard.CustomerMobile].HeaderText = "Mobile";
            dgvPaymentDue.Columns[(int)EnumDashBoard.CustomerName].HeaderText = "Name";
            dgvPaymentDue.Columns[(int)EnumDashBoard.DeliveryDate].HeaderText = "Delivery Date";
            dgvPaymentDue.Columns[(int)EnumDashBoard.DueAmount].HeaderText = "Due Amount";
            dgvPaymentDue.Columns[(int)EnumDashBoard.PaidAmount].HeaderText = "Paid Amount";
            dgvPaymentDue.Columns[(int)EnumDashBoard.TotalAmount].HeaderText = "Total Amount";

            dgvPaymentDue.Columns[(int)EnumDashBoard.BillDate].Width = 150;
            dgvPaymentDue.Columns[(int)EnumDashBoard.BillId].Width = 0;
            dgvPaymentDue.Columns[(int)EnumDashBoard.BillNo].Width = 150;
            dgvPaymentDue.Columns[(int)EnumDashBoard.CustomerMobile].Width = 150;
            dgvPaymentDue.Columns[(int)EnumDashBoard.CustomerName].Width = 150;
            dgvPaymentDue.Columns[(int)EnumDashBoard.DeliveryDate].Width = 150;
            dgvPaymentDue.Columns[(int)EnumDashBoard.DueAmount].Width = 150;
            dgvPaymentDue.Columns[(int)EnumDashBoard.PaidAmount].Width = 150;
            dgvPaymentDue.Columns[(int)EnumDashBoard.TotalAmount].Width = 150;

            int configPaymentDays = Convert.ToInt32(await ConfigUtilities.GetConfigurationValue(ConfigUtilities.PAYMENTDAYS, "30"));
            List<DashboardModel> paymentDues = await ApiClient.GetApiClient().GetAsync<List<DashboardModel>>($"api/PaymentDues/{configPaymentDays}");
            if (paymentDues != null)
            {
                DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
                chkColumn.HeaderText = "Paid";
                chkColumn.Width = 50;
                dgvPaymentDue.Columns.Add(chkColumn);

                foreach (DashboardModel paymentdue in paymentDues)
                {
                    int index = dgvPaymentDue.Rows.Add();
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.BillId].Value = paymentdue.BillId;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.CustomerName].Value = paymentdue.CustomerName;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.BillDate].Value = paymentdue.BillDate;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.BillNo].Value = paymentdue.BillNo;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.CustomerMobile].Value = paymentdue.CustomerMobile;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.DeliveryDate].Value = paymentdue.DeliveryDate;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.PaidAmount].Value = paymentdue.PaidAmount;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.TotalAmount].Value = paymentdue.TotalAmount;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.DueAmount].Value = paymentdue.DueAmount;
                    dgvPaymentDue.Rows[index].Cells[checkBoxColumnIndex].Value = false;

                }
            }
        }

        private void dgvPaymentDue_DoubleClick(object sender, EventArgs e)
        {
            CheckPaymentCheckBox();
        }

        private void dgvPaymentDue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckPaymentCheckBox();
            }
        }

        private void CheckPaymentCheckBox()
        {
            int index = dgvPaymentDue.SelectedRows[0].Index;
            
            if (index >= 0)
            {
                // Toggle the checkbox state
                bool isChecked = Convert.ToBoolean(dgvPaymentDue.Rows[index].Cells[checkBoxColumnIndex].Value);
                dgvPaymentDue.Rows[index].Cells[checkBoxColumnIndex].Value = !isChecked;
            }
        }

        private void btnReceiveAmount_Click(object sender, EventArgs e)
        {
            UpdatePaidAmount();
        }

        private async void UpdatePaidAmount()
        {
            List<BillPaymentDetail> billPaymentDetails = new List<BillPaymentDetail>();
            foreach (DataGridViewRow row in dgvPaymentDue.Rows)
            {
                // Ensure the row has a checkbox and it is checked
                if (Convert.ToBoolean(row.Cells[checkBoxColumnIndex].Value) == true)
                {
                    BillPaymentDetail billPaymentDetail = new BillPaymentDetail();
                    billPaymentDetail.BillId = Convert.ToInt32(row.Cells[(int)EnumDashBoard.BillId].Value);
                    billPaymentDetail.BillNo = Convert.ToInt32(row.Cells[(int)EnumDashBoard.BillNo].Value);
                    billPaymentDetail.PaidAmount = Convert.ToDecimal(row.Cells[(int)EnumDashBoard.DueAmount].Value);
                    billPaymentDetails.Add(billPaymentDetail);
                }
            }

            if(billPaymentDetails.Count > 0)
            {
                StringBuilder error = new StringBuilder();
                foreach (BillPaymentDetail billPaymentDetail in billPaymentDetails)
                {
                    BillPaymentDetail addedBillPaymentDetail = await ApiClient.GetApiClient().PostAsync(billPaymentDetail, "api/billpaymentdetails");
                    if (addedBillPaymentDetail == null)
                    {
                        error.AppendLine($"Bill payment was not added for Bill No {billPaymentDetail.BillNo}");
                    }
                }
                if (!string.IsNullOrWhiteSpace(error.ToString()))
                {
                    error.AppendLine("Some Error occurs while updating the payment in following Bills, please contact system administrator for more details");
                    rtError.Text = error.ToString();
                }
                else
                {

                    MessageBox.Show("Payment Received Succesfully.");
                }
                FillPaymentDueGrid();
            }
        }

        private async void dgvDeliveryDue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == btnPreviewColumnIndex && e.RowIndex >= 0)
            {
                int billId = Convert.ToInt32(dgvDeliveryDue.Rows[e.RowIndex].Cells[(int)EnumDashBoard.BillId].Value);
                bill = await ApiClient.GetApiClient().GetAsync<Bill>($"api/bills/{billId}");
                PrintBillPreview();
            }
            else if (e.ColumnIndex == btnDeleteColumnIndex && e.RowIndex >= 0)
            {
                int billId = Convert.ToInt32(dgvDeliveryDue.Rows[e.RowIndex].Cells[(int)EnumDashBoard.BillId].Value);
                int billNo = Convert.ToInt32(dgvDeliveryDue.Rows[e.RowIndex].Cells[(int)EnumDashBoard.BillNo].Value);

                DialogResult dialog = MessageBox.Show($"Are you sure you want to delete the bill {billNo}?", "Delete Bill", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    bool isDeleteBill = await ApiClient.GetApiClient().DeleteAsync($"api/bills/{billId}");
                    if (isDeleteBill)
                    {
                        FillDeliveryDueGrid();
                    }
                }                
            }
        }

        private void PrintBillPreview()
        {
            printPreviewDialog.WindowState = FormWindowState.Maximized;
            printPreviewDialog.ShowDialog();            
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if(bill != null)
            {
                PrintUtilities.PrintBill(bill, e.Graphics);
                e.HasMorePages = false;
            }
        }
    }
}
