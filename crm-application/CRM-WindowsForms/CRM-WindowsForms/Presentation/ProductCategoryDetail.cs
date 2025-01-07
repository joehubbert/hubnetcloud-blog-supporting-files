using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class ProductCategoryDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _productCategoryId;
        private bool ?productCategoryDetailActiveStatusOriginalValue;
        private string ?productCategoryDetailProductCategoryOriginalValue;

        public ProductCategoryDetail(Guid productCategoryId)
        {
            InitializeComponent();
            _productCategoryId = productCategoryId;
            productCategoryDetailToggleEditModeButton.Click += productCategoryDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewProductCategoryDetailProductCategoryInformation_Load(object sender, EventArgs e)
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
                    new SqlParameter("@productCategoryId", _productCategoryId)
                };

                DataTable productCategoryDataTable = await executor.ExecuteAsync("[dbo].[spGetProductCategory]", parameters);

                if (productCategoryDataTable != null)
                {
                    DataRow productCategoryDataRow = productCategoryDataTable.Rows[0];
                    productCategoryDetailProductCategoryIdTextbox.Text = productCategoryDataRow["Product Category ID"].ToString();
                    productCategoryDetailProductCategoryTextbox.Text = productCategoryDataRow["Product Category"].ToString();
                    productCategoryDetailCreatedByTextbox.Text = productCategoryDataRow["Created By"].ToString();
                    productCategoryDetailCreatedTimestampTextbox.Text = productCategoryDataRow["Created Timestamp"].ToString();
                    productCategoryDetailLastUpdatedByTextbox.Text = productCategoryDataRow["Modified By"].ToString();
                    productCategoryDetailLastUpdatedTimestampTextbox.Text = productCategoryDataRow["Modified Timestamp"].ToString();
                    productCategoryDetailActiveStatusCheckbox.Checked = (bool)productCategoryDataRow["Active Status"];

                    productCategoryDetailProductCategoryOriginalValue = productCategoryDataRow["Product Category"].ToString();
                    productCategoryDetailActiveStatusOriginalValue = (bool)productCategoryDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Product Category.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Product Category details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string productCategory = productCategoryDetailProductCategoryTextbox.Text.TrimEnd();

            if (productCategory.Length > 50)
            {
                validationErrors.AppendLine($"Product Category cannot be longer than 50 characters. Submitted length is {productCategory.Length} characters.");
            }

            if (ContainsSqlInjectionRisk(productCategory))
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

        private async void productCategoryDetailUpdateProductCategoryButton_Click(object sender, EventArgs e)
        {
            string productCategory = productCategoryDetailProductCategoryTextbox.Text.TrimEnd();

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
                $"Product Category Original Value: {productCategoryDetailProductCategoryOriginalValue}" + $"\nProduct Category New Value: {productCategory}\n" +
                $"Active Status Original Value: {productCategoryDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {productCategoryDetailActiveStatusCheckbox.Checked}\n\n" +
                "This action cannot be undone.", "Update Product Category Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the customer type details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@activeStatus", productCategoryDetailActiveStatusCheckbox.Checked),
                        new SqlParameter("@productCategory", productCategory),
                        new SqlParameter("@productCategoryId", _productCategoryId)
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdateProductCategory]", parameters);
                    MessageBox.Show("Product Category details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Product Category details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ViewProductCategoryDetailProductCategoryInformation_Load(this, EventArgs.Empty);
        }

        private void productCategoryDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            productCategoryDetailProductCategoryTextbox.Enabled = !productCategoryDetailProductCategoryTextbox.Enabled;
            productCategoryDetailActiveStatusCheckbox.Enabled = !productCategoryDetailActiveStatusCheckbox.Enabled;
            productCategoryDetailUpdateProductCategoryButton.Enabled = !productCategoryDetailUpdateProductCategoryButton.Enabled;
        }
    }
}