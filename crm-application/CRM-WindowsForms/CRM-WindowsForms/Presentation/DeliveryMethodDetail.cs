using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace CRM_WindowsForms.Presentation
{
    public partial class DeliveryMethodDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _deliveryMethodId;
        private bool ?deliveryMethodDetailActiveStatusOriginalValue;
        private decimal ?deliveryMethodDetailDeliveryCostOriginalValue;
        private string ?deliveryMethodDetailDeliveryMethodOriginalValue;
        private int ?deliveryMethodDetailDeliveryTimeOriginalValue;
        private Guid ?deliveryMethodDetailTaxProfileIdOriginalValue;

        public DeliveryMethodDetail(Guid deliveryMethodId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            _deliveryMethodId = deliveryMethodId;
            deliveryMethodDetailToggleEditModeButton.Click += deliveryMethodDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private void InitializeCustomComponents()
        {
            deliveryMethodDetailTaxProfileComboBox.DropDown += new EventHandler(DeliveryMethodDetailTaxProfileComboBox_DropDown);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task DeliveryMethodDetailLoadTaxProfileAsync(Guid taxProfileId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable taxProfileData = await executor.ExecuteAsync("[dbo].[spGetAllTaxProfile]");
                var taxProfileList = taxProfileData.AsEnumerable()
                    .Select(row => new
                    {
                        TaxProfileId = row.Field<Guid>("Tax Profile Id"),
                        TaxProfile = row.Field<string>("Tax Profile"),
                        TaxRate = row.Field<decimal>("Tax Rate"),
                        DisplayText = $"{row.Field<string>("Tax Profile")} | {row.Field<string>("Tax Rate")}"
                    })
                    .OrderBy(item => item.TaxProfile)
                    .ToList();
                deliveryMethodDetailTaxProfileComboBox.DataSource = taxProfileList;
                deliveryMethodDetailTaxProfileComboBox.DisplayMember = "DisplayText";
                deliveryMethodDetailTaxProfileComboBox.ValueMember = "TaxProfileId";
                deliveryMethodDetailTaxProfileComboBox.SelectedValue = taxProfileId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Tax Profile data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeliveryMethodDetailTaxProfileComboBox_DropDown(object sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void ViewDeliveryMethodDetailDeliveryMethodInformation_Load(object sender, EventArgs e)
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
                    new SqlParameter("@deliveryMethodId", _deliveryMethodId)
                };

                DataTable deliveryMethodDataTable = await executor.ExecuteAsync("[dbo].[spGetDeliveryMethod]", parameters);

                if (deliveryMethodDataTable != null)
                {
                    DataRow deliveryMethodDataRow = deliveryMethodDataTable.Rows[0];
                    string deliveryCostPartA;
                    string deliveryCostPartB;

                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)deliveryMethodDataRow["Delivery Cost"], out deliveryCostPartA, out deliveryCostPartB);

                    deliveryMethodDetailDeliveryMethodIdTextbox.Text = deliveryMethodDataRow["Delivery Method ID"].ToString();
                    deliveryMethodDetailDeliveryMethodTextbox.Text = deliveryMethodDataRow["Delivery Method"].ToString();
                    deliveryMethodDetailDeliveryCostTextboxA.Text = deliveryCostPartA;
                    deliveryMethodDetailDeliveryCostTextboxB.Text = deliveryCostPartB;
                    deliveryMethodDetailDeliveryTimeTextbox.Text = deliveryMethodDataRow["Delivery Time"].ToString();
                    Guid taxProfileId = (Guid)deliveryMethodDataRow["Tax Profile Id"];
                    await DeliveryMethodDetailLoadTaxProfileAsync(taxProfileId);
                    deliveryMethodDetailCreatedByTextbox.Text = deliveryMethodDataRow["Created By"].ToString();
                    deliveryMethodDetailCreatedTimestampTextbox.Text = deliveryMethodDataRow["Created Timestamp"].ToString();
                    deliveryMethodDetailLastUpdatedByTextbox.Text = deliveryMethodDataRow["Modified By"].ToString();
                    deliveryMethodDetailLastUpdatedTimestampTextbox.Text = deliveryMethodDataRow["Modified Timestamp"].ToString();
                    deliveryMethodDetailActiveStatusCheckbox.Checked = (bool)deliveryMethodDataRow["Active Status"];

                    deliveryMethodDetailDeliveryMethodOriginalValue = deliveryMethodDataRow["Delivery Method"].ToString();
                    deliveryMethodDetailDeliveryCostOriginalValue = (decimal)deliveryMethodDataRow["Delivery Cost"];
                    deliveryMethodDetailDeliveryTimeOriginalValue = (int)deliveryMethodDataRow["Delivery Time"];
                    deliveryMethodDetailTaxProfileIdOriginalValue = (Guid)deliveryMethodDataRow["Tax Profile Id"];
                    deliveryMethodDetailActiveStatusOriginalValue = (bool)deliveryMethodDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Delivery Method.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Delivery Method details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string deliveryCostA = deliveryMethodDetailDeliveryCostTextboxA.Text.TrimEnd();
            string deliveryCostB = deliveryMethodDetailDeliveryCostTextboxB.Text.TrimEnd();
            string deliveryMethod = deliveryMethodDetailDeliveryMethodTextbox.Text.TrimEnd();
            string deliveryTime = deliveryMethodDetailDeliveryTimeTextbox.Text.TrimEnd();

            if (deliveryCostA.Length > 10)
            {
                validationErrors.AppendLine($"Delivery Cost Part A cannot be longer than 10 characters. Submitted length is {deliveryCostA.Length} characters.");
            }

            if (deliveryCostB.Length > 4)
            {
                validationErrors.AppendLine($"Delivery Cost Part B cannot be longer than 4 characters. Submitted length is {deliveryCostB.Length} characters.");
            }

            if (deliveryMethod.Length > 50)
            {
                validationErrors.AppendLine($"Delivery Method cannot be longer than 50 characters. Submitted length is {deliveryMethod.Length} characters.");
            }

            if (deliveryTime.Length > 3)
            {
                validationErrors.AppendLine($"Delivery Time cannot be longer than 3 characters. Submitted length is {deliveryTime.Length} characters.");
            }

            if (!Regex.IsMatch(deliveryCostA, @"^\d+$"))
            {
                validationErrors.AppendLine("Delivery Cost Part A must contain only numbers.");
            }

            if (!Regex.IsMatch(deliveryCostB, @"^\d+$"))
            {
                validationErrors.AppendLine("Delivery Part B must contain only numbers.");
            }

            if (!Regex.IsMatch(deliveryTime, @"^\d+$"))
            {
                validationErrors.AppendLine("Delivery Time must contain only numbers.");
            }

            if (SQLInjectionRiskCheck.ContainsSqlInjectionRisk(deliveryCostA) ||
                SQLInjectionRiskCheck.ContainsSqlInjectionRisk(deliveryCostB) ||
                SQLInjectionRiskCheck.ContainsSqlInjectionRisk(deliveryMethod) ||
                SQLInjectionRiskCheck.ContainsSqlInjectionRisk(deliveryTime))
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

        private async void deliveryMethodDetailUpdateDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = deliveryMethodDetailActiveStatusCheckbox.Checked;
            decimal deliveryCost = decimal.Parse(deliveryMethodDetailDeliveryCostTextboxA.Text.TrimEnd()) + (decimal.Parse(deliveryMethodDetailDeliveryCostTextboxB.Text.TrimEnd()) / 100);
            string deliveryMethod = deliveryMethodDetailDeliveryMethodTextbox.Text.TrimEnd();
            int deliveryTime = int.Parse(deliveryMethodDetailDeliveryTimeTextbox.Text.TrimEnd());
            Guid taxProfileId = Guid.Parse(deliveryMethodDetailTaxProfileComboBox.SelectedValue.ToString());

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput())
            {
                return;
            }

            var changes = new StringBuilder("Are you sure that you want to update the following values?\n\n");

            if (deliveryMethodDetailDeliveryMethodOriginalValue != deliveryMethod)
            {
                changes.AppendLine($"Delivery Method Original Value: {deliveryMethodDetailDeliveryMethodOriginalValue}" + $"\nDelivery Method New Value: {deliveryMethod}\n");
            }

            if (deliveryMethodDetailDeliveryCostOriginalValue != deliveryCost)
            {
                changes.AppendLine($"Delivery Cost Original Value: {deliveryMethodDetailDeliveryCostOriginalValue.ToString()}" + $"\nDelivery Cost New Value: {deliveryCost.ToString()}\n");
            }

            if (deliveryMethodDetailDeliveryTimeOriginalValue != deliveryTime)
            {
                changes.AppendLine($"Delivery Time Original Value: {deliveryMethodDetailDeliveryTimeOriginalValue.ToString()}" + $"\nDelivery Time New Value: {deliveryTime.ToString()}\n");
            }

            if (deliveryMethodDetailTaxProfileIdOriginalValue != taxProfileId)
            {
                changes.AppendLine($"Tax Profile Original Value: {deliveryMethodDetailTaxProfileIdOriginalValue.ToString()}" + $"\nTax Profile New Value: {taxProfileId.ToString()}\n");
            }

            if (deliveryMethodDetailActiveStatusOriginalValue != deliveryMethodDetailActiveStatusCheckbox.Checked)
            {
                changes.AppendLine($"Active Status Original Value: {deliveryMethodDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {deliveryMethodDetailActiveStatusCheckbox.Checked}\n\n");
            }

            changes.AppendLine("This action cannot be undone.");

            var result = MessageBox.Show(changes.ToString(), "Update Delivery Method Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the customer tier details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@activeStatus", deliveryMethodDetailActiveStatusCheckbox.Checked),
                        new SqlParameter("@deliveryMethod", deliveryMethod),
                        new SqlParameter("@deliveryMethodId", _deliveryMethodId),
                        new SqlParameter("@deliveryCost", deliveryCost),
                        new SqlParameter("@deliveryTime", deliveryTime),
                        new SqlParameter("@taxProfileId", taxProfileId)
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdateDeliveryMethod]", parameters);
                    MessageBox.Show("Delivery Method details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Delivery Method details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ViewDeliveryMethodDetailDeliveryMethodInformation_Load(this, EventArgs.Empty);
        }

        private void deliveryMethodDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            deliveryMethodDetailDeliveryMethodTextbox.Enabled = !deliveryMethodDetailDeliveryMethodTextbox.Enabled;
            deliveryMethodDetailDeliveryCostTextboxA.Enabled = !deliveryMethodDetailDeliveryCostTextboxA.Enabled;
            deliveryMethodDetailDeliveryCostTextboxB.Enabled = !deliveryMethodDetailDeliveryCostTextboxB.Enabled;
            deliveryMethodDetailDeliveryTimeTextbox.Enabled = !deliveryMethodDetailDeliveryTimeTextbox.Enabled;
            deliveryMethodDetailTaxProfileComboBox.Enabled = !deliveryMethodDetailTaxProfileComboBox.Enabled;
            deliveryMethodDetailActiveStatusCheckbox.Enabled = !deliveryMethodDetailActiveStatusCheckbox.Enabled;
            deliveryMethodDetailUpdateDeliveryMethodButton.Enabled = !deliveryMethodDetailUpdateDeliveryMethodButton.Enabled;
        }
    }
}