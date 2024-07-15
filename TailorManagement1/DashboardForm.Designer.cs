namespace TailorManagement1
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDeliveryDue = new System.Windows.Forms.DataGridView();
            this.lbldeliverydue = new System.Windows.Forms.Label();
            this.lblpaymentdue = new System.Windows.Forms.Label();
            this.dgvPaymentDue = new System.Windows.Forms.DataGridView();
            this.btnReceiveAmount = new System.Windows.Forms.Button();
            this.rtError = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryDue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentDue)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDeliveryDue
            // 
            this.dgvDeliveryDue.AllowUserToAddRows = false;
            this.dgvDeliveryDue.AllowUserToDeleteRows = false;
            this.dgvDeliveryDue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliveryDue.Location = new System.Drawing.Point(20, 26);
            this.dgvDeliveryDue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDeliveryDue.MultiSelect = false;
            this.dgvDeliveryDue.Name = "dgvDeliveryDue";
            this.dgvDeliveryDue.ReadOnly = true;
            this.dgvDeliveryDue.RowHeadersVisible = false;
            this.dgvDeliveryDue.RowHeadersWidth = 51;
            this.dgvDeliveryDue.RowTemplate.Height = 24;
            this.dgvDeliveryDue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeliveryDue.Size = new System.Drawing.Size(806, 213);
            this.dgvDeliveryDue.TabIndex = 81;
            this.dgvDeliveryDue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryDue_CellContentClick);
            // 
            // lbldeliverydue
            // 
            this.lbldeliverydue.AutoSize = true;
            this.lbldeliverydue.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldeliverydue.Location = new System.Drawing.Point(16, 7);
            this.lbldeliverydue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldeliverydue.Name = "lbldeliverydue";
            this.lbldeliverydue.Size = new System.Drawing.Size(105, 17);
            this.lbldeliverydue.TabIndex = 82;
            this.lbldeliverydue.Text = "Delivery Due";
            // 
            // lblpaymentdue
            // 
            this.lblpaymentdue.AutoSize = true;
            this.lblpaymentdue.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpaymentdue.Location = new System.Drawing.Point(16, 250);
            this.lblpaymentdue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblpaymentdue.Name = "lblpaymentdue";
            this.lblpaymentdue.Size = new System.Drawing.Size(110, 17);
            this.lblpaymentdue.TabIndex = 84;
            this.lblpaymentdue.Text = "Payment Due";
            // 
            // dgvPaymentDue
            // 
            this.dgvPaymentDue.AllowUserToAddRows = false;
            this.dgvPaymentDue.AllowUserToDeleteRows = false;
            this.dgvPaymentDue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentDue.Location = new System.Drawing.Point(20, 269);
            this.dgvPaymentDue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPaymentDue.MultiSelect = false;
            this.dgvPaymentDue.Name = "dgvPaymentDue";
            this.dgvPaymentDue.ReadOnly = true;
            this.dgvPaymentDue.RowHeadersVisible = false;
            this.dgvPaymentDue.RowHeadersWidth = 51;
            this.dgvPaymentDue.RowTemplate.Height = 24;
            this.dgvPaymentDue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymentDue.Size = new System.Drawing.Size(806, 213);
            this.dgvPaymentDue.TabIndex = 83;
            this.dgvPaymentDue.DoubleClick += new System.EventHandler(this.dgvPaymentDue_DoubleClick);
            this.dgvPaymentDue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvPaymentDue_KeyUp);
            // 
            // btnReceiveAmount
            // 
            this.btnReceiveAmount.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiveAmount.Location = new System.Drawing.Point(694, 487);
            this.btnReceiveAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReceiveAmount.Name = "btnReceiveAmount";
            this.btnReceiveAmount.Size = new System.Drawing.Size(130, 32);
            this.btnReceiveAmount.TabIndex = 85;
            this.btnReceiveAmount.Text = "Receive Amount";
            this.btnReceiveAmount.UseVisualStyleBackColor = true;
            this.btnReceiveAmount.Click += new System.EventHandler(this.btnReceiveAmount_Click);
            // 
            // rtError
            // 
            this.rtError.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtError.ForeColor = System.Drawing.Color.Red;
            this.rtError.Location = new System.Drawing.Point(20, 523);
            this.rtError.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtError.Name = "rtError";
            this.rtError.ReadOnly = true;
            this.rtError.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtError.Size = new System.Drawing.Size(806, 94);
            this.rtError.TabIndex = 91;
            this.rtError.Text = "";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 609);
            this.Controls.Add(this.rtError);
            this.Controls.Add(this.btnReceiveAmount);
            this.Controls.Add(this.lblpaymentdue);
            this.Controls.Add(this.dgvPaymentDue);
            this.Controls.Add(this.lbldeliverydue);
            this.Controls.Add(this.dgvDeliveryDue);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DashboardForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DashboardForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryDue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentDue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDeliveryDue;
        private System.Windows.Forms.Label lbldeliverydue;
        private System.Windows.Forms.Label lblpaymentdue;
        private System.Windows.Forms.DataGridView dgvPaymentDue;
        private System.Windows.Forms.Button btnReceiveAmount;
        private System.Windows.Forms.RichTextBox rtError;
    }
}