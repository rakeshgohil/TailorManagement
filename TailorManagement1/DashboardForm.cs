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
    public partial class DashboardForm : Form
    {
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
            DueAmount,
            CheckBox
        }

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
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

            dgvDeliveryDue.Columns[(int)EnumDashBoard.BillDate].Width = 150;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.BillId].Width = 0;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.BillNo].Width = 150;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.CustomerMobile].Width = 150;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.CustomerName].Width = 150;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.DeliveryDate].Width = 150;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.DueAmount].Width = 150;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.PaidAmount].Width = 150;
            dgvDeliveryDue.Columns[(int)EnumDashBoard.TotalAmount].Width = 150;

            List<DashboardModel> deliveryDues = await ApiClient.GetApiClient().GetAsync<List<DashboardModel>>("api/DeliveryDues/1");
            if (deliveryDues != null)
            {
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
            
            List<DashboardModel> paymentDues = await ApiClient.GetApiClient().GetAsync<List<DashboardModel>>("api/PaymentDues/1");
            if (paymentDues != null)
            {
                DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
                chkColumn.HeaderText = "Paid";
                chkColumn.Width = 50;
                dgvPaymentDue.Columns.Add(chkColumn);

                foreach (DashboardModel deliveryDue in paymentDues)
                {
                    int index = dgvPaymentDue.Rows.Add();
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.BillId].Value = deliveryDue.BillId;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.CustomerName].Value = deliveryDue.CustomerName;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.BillDate].Value = deliveryDue.BillDate;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.BillNo].Value = deliveryDue.BillNo;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.CustomerMobile].Value = deliveryDue.CustomerMobile;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.DeliveryDate].Value = deliveryDue.DeliveryDate;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.PaidAmount].Value = deliveryDue.PaidAmount;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.TotalAmount].Value = deliveryDue.TotalAmount;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.DueAmount].Value = deliveryDue.DueAmount;
                    dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.CheckBox].Value = false;
                }
            }
        }

        private void dgvPaymentDue_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void dgvPaymentDue_DoubleClick(object sender, EventArgs e)
        {
            CheckPaymentCheckBox();
        }

        private void dgvPaymentDue_KeyDown(object sender, KeyEventArgs e)
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
                bool isChecked = Convert.ToBoolean(dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.CheckBox].Value);
                dgvPaymentDue.Rows[index].Cells[(int)EnumDashBoard.CheckBox].Value = !isChecked;
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
                if (Convert.ToBoolean(row.Cells[(int)EnumDashBoard.CheckBox].Value) == true)
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
    }
}
