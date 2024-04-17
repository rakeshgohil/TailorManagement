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

    public partial class PantConfigurationForm : Form
    {
        private enum EnumPantConfiguration
        {
            Id,
            Description,
            LocalDescription
        }

        PantConfiguration pantConfiguration = null;
        public PantConfigurationForm()
        {
            InitializeComponent();
        }

        private void PantConfigurationForm_Load(object sender, EventArgs e)
        {
            LanguageUtilities.ChangeLanguage(this, ConfigUtilities.companyLanguageCode);
            ClearControls();
            LoadAllPantConfigurations();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePantConfiguration();
        }

        private async void SavePantConfiguration()
        {
            rtError.Text = "";
            if(pantConfiguration == null)
            {
                pantConfiguration = new PantConfiguration();
            }
            pantConfiguration.Description = txtDescription.Text.Trim();
            pantConfiguration.LocalDescription = txtLocalDescription.Text.Trim();

            StringBuilder error;
            if (!pantConfiguration.isValid(out error))
            {
                rtError.Text = error.ToString();
                return;
            }

            if(pantConfiguration.Id == 0)
            {
                PantConfiguration addedPantConfiguration = await ApiClient.GetApiClient().PostAsync(pantConfiguration, "api/Pantconfigurations");
                pantConfiguration.Id = addedPantConfiguration.Id;
            }
            else
            {
                await ApiClient.GetApiClient().PutAsync(pantConfiguration, $"api/Pantconfigurations/{pantConfiguration.Id}");
            }
            ClearControls();
        }

        private void ClearControls()
        {
            pantConfiguration = new PantConfiguration();

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
            dgvPantConfiguration.AutoGenerateColumns = false;
            dgvPantConfiguration.ColumnCount = 3;
            dgvPantConfiguration.Rows.Clear();

            dgvPantConfiguration.Columns[(int)EnumPantConfiguration.Id].HeaderText = "Id";
            dgvPantConfiguration.Columns[(int)EnumPantConfiguration.Description].HeaderText = "Description";
            dgvPantConfiguration.Columns[(int)EnumPantConfiguration.LocalDescription].HeaderText = "LocalDescription";

            dgvPantConfiguration.Columns[(int)EnumPantConfiguration.Id].Width = 0;
            dgvPantConfiguration.Columns[(int)EnumPantConfiguration.Description].Width = 150;
            dgvPantConfiguration.Columns[(int)EnumPantConfiguration.LocalDescription].Width = 300;

        }

        private async void LoadAllPantConfigurations()
        {

            List<PantConfiguration> pantConfigurations = await ApiClient.GetApiClient().GetAsync<List<PantConfiguration>>("api/PantConfigurations");
            if (pantConfigurations != null)
            {
                foreach(PantConfiguration PantConfiguration in pantConfigurations)
                {
                    int index = dgvPantConfiguration.Rows.Add();
                    dgvPantConfiguration.Rows[index].Cells[(int)EnumPantConfiguration.Id].Value = PantConfiguration.Id;
                    dgvPantConfiguration.Rows[index].Cells[(int)EnumPantConfiguration.Description].Value = PantConfiguration.Description;
                    dgvPantConfiguration.Rows[index].Cells[(int)EnumPantConfiguration.LocalDescription].Value = PantConfiguration.LocalDescription;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void dgvPantConfiguration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                pantConfiguration = new PantConfiguration()
                {
                    Id = (int)row.Cells[(int)EnumPantConfiguration.Id].Value,
                    Description = row.Cells[(int)EnumPantConfiguration.Description].Value.ToString(),
                    LocalDescription = row.Cells[(int)EnumPantConfiguration.LocalDescription].Value.ToString()
                };

                txtDescription.Text = pantConfiguration.Description;
                txtLocalDescription.Text = pantConfiguration.LocalDescription;
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePantConfiguration();
        }

        private async void DeletePantConfiguration()
        {
            await ApiClient.GetApiClient().DeleteAsync($"api/Pantconfigurations/{pantConfiguration.Id}");
            ClearControls();
            LoadAllPantConfigurations();
        }
    }
}
