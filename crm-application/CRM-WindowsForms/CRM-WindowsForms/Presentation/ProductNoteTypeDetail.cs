using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class ProductNoteTypeDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _productNoteTypeId;
        private bool productNoteTypeDetailActiveStatusOriginalValue;
        private string productNoteTypeDetailProductTypeOriginalValue;
        
        public ProductNoteTypeDetail(Guid productNoteTypeId)
        {
            InitializeComponent();
            _productNoteTypeId = productNoteTypeId;
            productNoteTypeDetailToggleEditModeButton.Click += productNoteTypeDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewProductTypeDetailProductTypeInformation_Load(object sender, EventArgs e)
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
                    new SqlParameter("@productNoteTypeId", _productNoteTypeId)
                };

                DataTable productNoteTypeDataTable = await executor.ExecuteAsync("[dbo].[spGetProductNoteType]", parameters);

                if (productNoteTypeDataTable != null)
                {
                    DataRow productNoteTypeDataRow = productNoteTypeDataTable.Rows[0];
                    productNoteTypeDetailProductTypeIdTextbox.Text = productNoteTypeDataRow["Product Note Type ID"].ToString();
                    productNoteTypeDetailProductTypeTextbox.Text = productNoteTypeDataRow["Product Note Type"].ToString();
                    productNoteTypeDetailCreatedByTextbox.Text = productNoteTypeDataRow["Created By"].ToString();
                    productNoteTypeDetailCreatedTimestampTextbox.Text = productNoteTypeDataRow["Created Timestamp"].ToString();
                    productNoteTypeDetailLastUpdatedByTextbox.Text = productNoteTypeDataRow["Modified By"].ToString();
                    productNoteTypeDetailLastUpdatedTimestampTextbox.Text = productNoteTypeDataRow["Modified Timestamp"].ToString();
                    productNoteTypeDetailActiveStatusCheckbox.Checked = (bool)productNoteTypeDataRow["Active Status"];

                    productNoteTypeDetailProductTypeOriginalValue = productNoteTypeDataRow["Product Note Type"].ToString();
                    productNoteTypeDetailActiveStatusOriginalValue = (bool)productNoteTypeDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Product Note Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Product Note Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string productNoteType = productNoteTypeDetailProductTypeTextbox.Text.Trim();

            if (productNoteType.Length > 50)
            {
                validationErrors.AppendLine($"Product Note Type cannot be longer than 50 characters. Submitted length is {productNoteType.Length} characters.");
            }

            if (ContainsSqlInjectionRisk(productNoteType))
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

        private bool ContainsSqlInjectionRisk(string input)
        {
            string[] sqlInjectionRiskCharacters = { "--", ";--", ";", "/*", "*/", "@@" };
            foreach (var riskChar in sqlInjectionRiskCharacters)
            {
                if (input.Contains(riskChar))
                {
                    return true;
                }
            }
            return false;
        }

        private async void productNoteTypeDetailUpdateProductTypeButton_Click(object sender, EventArgs e)
        {
            string productNoteType = productNoteTypeDetailProductTypeTextbox.Text.Trim();

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
                $"Product Note Type Original Value: {productNoteTypeDetailProductTypeOriginalValue}" + $"\nProduct Note Type New Value: {productNoteType}\n" +
                $"Active Status Original Value: {productNoteTypeDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {productNoteTypeDetailActiveStatusCheckbox.Checked}\n\n" +
                "This action cannot be undone.", "Update Product Note Type Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the product type details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@activeStatus", productNoteTypeDetailActiveStatusCheckbox.Checked),
                        new SqlParameter("@productNoteType", productNoteType),
                        new SqlParameter("@productNoteTypeId", _productNoteTypeId)
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdateProductType]", parameters);
                    MessageBox.Show("Product Note Type details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Product Note Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ViewProductTypeDetailProductTypeInformation_Load(this, EventArgs.Empty);
        }

        private void productNoteTypeDetailToggleEditModeButton_Click(object sender, EventArgs e)
        {
            productNoteTypeDetailProductTypeTextbox.Enabled = !productNoteTypeDetailProductTypeTextbox.Enabled;
            productNoteTypeDetailActiveStatusCheckbox.Enabled = !productNoteTypeDetailActiveStatusCheckbox.Enabled;
            productNoteTypeDetailUpdateProductTypeButton.Enabled = !productNoteTypeDetailUpdateProductTypeButton.Enabled;
        }
    }
}