using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TailorManagement1.Utilities;
using TailorManagementModels;

namespace TailorManagement1
{
    public partial class ShirtConfigurationForm : Form
    {
        private enum EnumShirtConfiguration
        {
            Id,
            Description,
            LocalDescription
        }

        ShirtConfiguration shirtConfiguration = null;
        public ShirtConfigurationForm()
        {
            InitializeComponent();
        }

        private void ShirtConfigurationForm_Load(object sender, EventArgs e)
        {
            LanguageUtilities.ChangeLanguage(this, ConfigUtilities.companyLanguageCode);
            ClearControls();
            LoadAllShirtConfigurations();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveShirtConfiguration();
        }

        private async void SaveShirtConfiguration()
        {
            rtError.Text = "";
            if(shirtConfiguration == null)
            {
                shirtConfiguration = new ShirtConfiguration();
            }
            shirtConfiguration.Description = txtDescription.Text.Trim();
            shirtConfiguration.LocalDescription = txtLocalDescription.Text.Trim();

            StringBuilder error;
            if (!shirtConfiguration.isValid(out error))
            {
                rtError.Text = error.ToString();
                return;
            }

            if(shirtConfiguration.Id == 0)
            {
                ShirtConfiguration addedShirtConfiguration = await ApiClient.GetApiClient().PostAsync(shirtConfiguration, "api/shirtconfigurations");
                shirtConfiguration.Id = addedShirtConfiguration.Id;
            }
            else
            {
                await ApiClient.GetApiClient().PutAsync(shirtConfiguration, $"api/shirtconfigurations/{shirtConfiguration.Id}");
            }
            ClearControls();
        }

        private void ClearControls()
        {
            shirtConfiguration = new ShirtConfiguration();

            btnDelete.Enabled = false;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                //else if (c is CheckBox)
                //    ((CheckBox)c).Checked = false;
                //else if (c is RadioButton)
                //    ((RadioButton)c).Checked = false;
                //else if (c is ComboBox)
                //    ((ComboBox)c).SelectedIndex = -1;
                //else if (c is ListBox)
                //    ((ListBox)c).ClearSelected();
                //else if (c is DataGridView)
                //    ((DataGridView)c).Rows.Clear();                    
            }
        }

        private void ClearGrid()
        {
            dgvShirtConfiguration.AutoGenerateColumns = false;
            dgvShirtConfiguration.ColumnCount = 3;
            dgvShirtConfiguration.Rows.Clear();

            dgvShirtConfiguration.Columns[(int)EnumShirtConfiguration.Id].HeaderText = "Id";
            dgvShirtConfiguration.Columns[(int)EnumShirtConfiguration.Description].HeaderText = "Description";
            dgvShirtConfiguration.Columns[(int)EnumShirtConfiguration.LocalDescription].HeaderText = "LocalDescription";

            dgvShirtConfiguration.Columns[(int)EnumShirtConfiguration.Id].Width = 0;
            dgvShirtConfiguration.Columns[(int)EnumShirtConfiguration.Description].Width = 150;
            dgvShirtConfiguration.Columns[(int)EnumShirtConfiguration.LocalDescription].Width = 300;
        }

        private async void LoadAllShirtConfigurations()
        {
            ClearGrid();
            List<ShirtConfiguration> shirtConfigurations = await ApiClient.GetApiClient().GetAsync<List<ShirtConfiguration>>("api/ShirtConfigurations");
            if (shirtConfigurations != null)
            {
                foreach(ShirtConfiguration shirtConfiguration in shirtConfigurations)
                {
                    int index = dgvShirtConfiguration.Rows.Add();
                    dgvShirtConfiguration.Rows[index].Cells[(int)EnumShirtConfiguration.Id].Value = shirtConfiguration.Id;
                    dgvShirtConfiguration.Rows[index].Cells[(int)EnumShirtConfiguration.Description].Value = shirtConfiguration.Description;
                    dgvShirtConfiguration.Rows[index].Cells[(int)EnumShirtConfiguration.LocalDescription].Value = shirtConfiguration.LocalDescription;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void dgvShirtConfiguration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                shirtConfiguration = new ShirtConfiguration()
                {
                    Id = (int) row.Cells[(int)EnumShirtConfiguration.Id].Value,
                    Description = row.Cells[(int)EnumShirtConfiguration.Description].Value.ToString(),
                    LocalDescription = row.Cells[(int)EnumShirtConfiguration.LocalDescription].Value.ToString()
                };

                txtDescription.Text = shirtConfiguration.Description;
                txtLocalDescription.Text = shirtConfiguration.LocalDescription;
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteShirtConfiguration();
        }

        private async void DeleteShirtConfiguration()
        {
            await ApiClient.GetApiClient().DeleteAsync($"api/shirtconfigurations/{shirtConfiguration.Id}");
            ClearControls();
            LoadAllShirtConfigurations();
        }
    }
}
