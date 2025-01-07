using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class SalesSubRegionDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _salesSubRegionId;
        private Guid? salesSubRegionDetailSalesRegionIdOriginalValue;
        private string salesSubRegionDetailSalesSubRegionOriginalValue;
        private bool salesSubRegionDetailActiveStatusOriginalValue;

        public SalesSubRegionDetail(Guid salesSubRegionId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            _salesSubRegionId = salesSubRegionId;
            salesSubRegionDetailToggleEditModeButton.Click += salesSubRegionDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private void InitializeCustomComponents()
        {
            salesSubRegionDetailSalesRegionComboBox.DropDown += new EventHandler(SalesSubRegionDetailSalesRegionComboBox_DropDown);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task SalesSubRegionDetailLoadSalesRegionAsync(Guid salesRegionId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable salesRegionData = await executor.ExecuteAsync("[dbo].[spGetAllSalesRegion]");
                var salesRegionList = salesRegionData.AsEnumerable()
                    .Select(row => new
                    {
                        SalesRegionId = row.Field<Guid>("Sales Region Id"),
                        SalesRegion = row.Field<string>("Sales Region")
                    })
                    .OrderBy(item => item.SalesRegion)
                    .ToList();
                salesSubRegionDetailSalesRegionComboBox.DataSource = salesRegionList;
                salesSubRegionDetailSalesRegionComboBox.DisplayMember = "SalesRegion";
                salesSubRegionDetailSalesRegionComboBox.ValueMember = "SalesRegionId";
                salesSubRegionDetailSalesRegionComboBox.SelectedValue = salesRegionId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Region data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SalesSubRegionDetailSalesRegionComboBox_DropDown(object sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void ViewSalesSubRegionDetailSalesSubRegionInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@salesSubRegionId", _salesSubRegionId)
                };

                DataTable salesSubRegionDataTable = await executor.ExecuteAsync("[dbo].[spGetSalesSubRegion]", parameters);

                if (salesSubRegionDataTable != null)
                {
                    DataRow salesSubRegionDataRow = salesSubRegionDataTable.Rows[0];
                    salesSubRegionDetailSalesSubRegionIdTextbox.Text = salesSubRegionDataRow["Sales Sub Region ID"].ToString();
                    salesSubRegionDetailSalesSubRegionTextbox.Text = salesSubRegionDataRow["Sales Sub Region"].ToString();
                    await SalesSubRegionDetailLoadSalesRegionAsync((Guid)salesSubRegionDataRow["Sales Region Id"]);
                    salesSubRegionDetailCreatedByTextbox.Text = salesSubRegionDataRow["Created By"].ToString();
                    salesSubRegionDetailCreatedTimestampTextbox.Text = salesSubRegionDataRow["Created Timestamp"].ToString();
                    salesSubRegionDetailLastUpdatedByTextbox.Text = salesSubRegionDataRow["Modified By"].ToString();
                    salesSubRegionDetailLastUpdatedTimestampTextbox.Text = salesSubRegionDataRow["Modified Timestamp"].ToString();
                    salesSubRegionDetailActiveStatusCheckbox.Checked = (bool)salesSubRegionDataRow["Active Status"];

                    salesSubRegionDetailSalesRegionIdOriginalValue = (Guid)salesSubRegionDataRow["Sales Region Id"];
                    salesSubRegionDetailSalesSubRegionOriginalValue = salesSubRegionDataRow["Sales Sub Region"].ToString();
                    salesSubRegionDetailActiveStatusOriginalValue = (bool)salesSubRegionDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Sales Sub Region.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Sub Region details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string salesSubRegion = salesSubRegionDetailSalesSubRegionTextbox.Text.TrimEnd();

            if (salesSubRegion.Length > 50)
            {
                validationErrors.AppendLine($"Sales Sub Region cannot be longer than 50 characters. Submitted length is {salesSubRegion.Length} characters.");
            }

            if (SQLInjectionRiskCheck.ContainsSqlInjectionRisk(salesSubRegion))
            {
                validationErrors.AppendLine("Input contains potentially dangerous characters that could lead to SQL injection.");
            }

            if (validationErrors.Length > 0)
            {
                MessageBox.Show(validationErrors.ToString(), "Validation Error: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void salesSubRegionDetailUpdateSalesSubRegionButton_Click(object sender, EventArgs e)
        {
            Guid salesRegionId = (Guid)salesSubRegionDetailSalesRegionComboBox.SelectedValue;
            string salesSubRegion = salesSubRegionDetailSalesSubRegionTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput())
            {
                return;
            }

            var result = MessageBox.Show("Are you sure that you want to update the following values?\n\n" +
                $"Sales Sub Region Original Value: {salesSubRegionDetailSalesSubRegionOriginalValue}" + $"\nSales Sub Region New Value: {salesSubRegion}\n" +
                $"Sales Region Original Value: {salesSubRegionDetailSalesRegionIdOriginalValue}" + $"\nSales Region New Value: {salesRegionId.ToString()}\n" +
                $"Active Status Original Value: {salesSubRegionDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {salesSubRegionDetailActiveStatusCheckbox.Checked}\n\n" +
                "This action cannot be undone.", "Update Sales Sub Region Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the customer type details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@activeStatus", salesSubRegionDetailActiveStatusCheckbox.Checked),
                        new SqlParameter("@salesRegionId", salesSubRegionDetailSalesRegionComboBox.SelectedValue),
                        new SqlParameter("@salesSubRegion", salesSubRegion),
                        new SqlParameter("@salesSubRegionId", _salesSubRegionId)
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdateSalesSubRegion]", parameters);
                    MessageBox.Show("Sales Sub Region details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Sales Sub Region details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Update details were cancelled, no changes have been made to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            ViewSalesSubRegionDetailSalesSubRegionInformation_Load(this, EventArgs.Empty);
        }

        private void salesSubRegionDetailToggleEditModeButton_Click(object sender, EventArgs e)
        {
            salesSubRegionDetailSalesSubRegionTextbox.Enabled = !salesSubRegionDetailSalesSubRegionTextbox.Enabled;
            salesSubRegionDetailSalesRegionComboBox.Enabled = !salesSubRegionDetailSalesRegionComboBox.Enabled;
            salesSubRegionDetailActiveStatusCheckbox.Enabled = !salesSubRegionDetailActiveStatusCheckbox.Enabled;
            salesSubRegionDetailUpdateSalesSubRegionButton.Enabled = !salesSubRegionDetailUpdateSalesSubRegionButton.Enabled;
        }
    }
}