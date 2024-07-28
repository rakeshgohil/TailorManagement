
namespace TailorManagement1
{
    partial class PantConfigurationForm
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
            this.lbldescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtLocalDescription = new System.Windows.Forms.TextBox();
            this.lbllocaldescription = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvPantConfiguration = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rtError = new System.Windows.Forms.RichTextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPantConfiguration)).BeginInit();
            this.SuspendLayout();
            // 
            // lbldescription
            // 
            this.lbldescription.AutoSize = true;
            this.lbldescription.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldescription.Location = new System.Drawing.Point(14, 15);
            this.lbldescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldescription.Name = "lbldescription";
            this.lbldescription.Size = new System.Drawing.Size(95, 17);
            this.lbldescription.TabIndex = 5;
            this.lbldescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(148, 12);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(220, 24);
            this.txtDescription.TabIndex = 11;
            // 
            // txtLocalDescription
            // 
            this.txtLocalDescription.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalDescription.Location = new System.Drawing.Point(148, 50);
            this.txtLocalDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtLocalDescription.MaxLength = 500;
            this.txtLocalDescription.Name = "txtLocalDescription";
            this.txtLocalDescription.Size = new System.Drawing.Size(220, 24);
            this.txtLocalDescription.TabIndex = 13;
            // 
            // lbllocaldescription
            // 
            this.lbllocaldescription.AutoSize = true;
            this.lbllocaldescription.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllocaldescription.Location = new System.Drawing.Point(14, 52);
            this.lbllocaldescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbllocaldescription.Name = "lbllocaldescription";
            this.lbllocaldescription.Size = new System.Drawing.Size(140, 17);
            this.lbllocaldescription.TabIndex = 12;
            this.lbllocaldescription.Text = "Local Description";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(127, 89);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 32);
            this.btnSave.TabIndex = 79;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvPantConfiguration
            // 
            this.dgvPantConfiguration.AllowUserToAddRows = false;
            this.dgvPantConfiguration.AllowUserToDeleteRows = false;
            this.dgvPantConfiguration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPantConfiguration.Location = new System.Drawing.Point(16, 133);
            this.dgvPantConfiguration.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPantConfiguration.MultiSelect = false;
            this.dgvPantConfiguration.Name = "dgvPantConfiguration";
            this.dgvPantConfiguration.ReadOnly = true;
            this.dgvPantConfiguration.RowHeadersVisible = false;
            this.dgvPantConfiguration.RowHeadersWidth = 51;
            this.dgvPantConfiguration.RowTemplate.Height = 24;
            this.dgvPantConfiguration.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPantConfiguration.Size = new System.Drawing.Size(351, 214);
            this.dgvPantConfiguration.TabIndex = 80;
            this.dgvPantConfiguration.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPantConfiguration_CellClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(208, 89);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 32);
            this.btnCancel.TabIndex = 81;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rtError
            // 
            this.rtError.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtError.ForeColor = System.Drawing.Color.Red;
            this.rtError.Location = new System.Drawing.Point(16, 352);
            this.rtError.Margin = new System.Windows.Forms.Padding(2);
            this.rtError.Name = "rtError";
            this.rtError.ReadOnly = true;
            this.rtError.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtError.Size = new System.Drawing.Size(352, 79);
            this.rtError.TabIndex = 91;
            this.rtError.Text = "";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(290, 89);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(77, 32);
            this.btnDelete.TabIndex = 92;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // PantConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 441);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.rtError);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvPantConfiguration);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLocalDescription);
            this.Controls.Add(this.lbllocaldescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lbldescription);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PantConfigurationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pant Configuration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PantConfigurationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPantConfiguration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbldescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtLocalDescription;
        private System.Windows.Forms.Label lbllocaldescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvPantConfiguration;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RichTextBox rtError;
        private System.Windows.Forms.Button btnDelete;
    }
}