using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Data;
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
        private Guid ?deliveryMethodDetailTaxProfileOriginalValue;

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

        private void AdjustComboBoxDropDownWidth(ComboBox comboBox)
        {
            int comboBoxWidth = comboBox.DropDownWidth;
            Graphics comboBoxGraphics = comboBox.CreateGraphics();
            Font comboBoxFont = comboBox.Font;

            int verticalScrollBarWidth = (comboBox.Items.Count > comboBox.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;
            int dynamicComboBoxWidth;

            foreach (var item in comboBox.Items)
            {
                dynamicComboBoxWidth = (int)comboBoxGraphics.MeasureString(comboBox.GetItemText(item), comboBoxFont).Width + verticalScrollBarWidth;
                if (comboBoxWidth < dynamicComboBoxWidth)
                {
                    comboBoxWidth = dynamicComboBoxWidth;
                }
            }
            comboBox.DropDownWidth = comboBoxWidth;
        }

        private void SplitDecimal(decimal decimalValue, out string partA, out string partB)
        {
            string[] parts = decimalValue.ToString().Split('.');
            partA = parts[0];
            partB = parts.Length > 1 ? parts[1] : "0";
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
            AdjustComboBoxDropDownWidth(sender as ComboBox);
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

                    SplitDecimal((decimal)deliveryMethodDataRow["Delivery Cost"], out deliveryCostPartA, out deliveryCostPartB);

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
                    deliveryMethodDetailTaxProfileOriginalValue = (Guid)deliveryMethodDataRow["Tax Profile Id"];
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

            string deliveryCostA = deliveryMethodDetailDeliveryCostTextboxA.Text.Trim();
            string deliveryCostB = deliveryMethodDetailDeliveryCostTextboxB.Text.Trim();
            string deliveryMethod = deliveryMethodDetailDeliveryMethodTextbox.Text.Trim();
            string deliveryTime = deliveryMethodDetailDeliveryTimeTextbox.Text.Trim();

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

            if (ContainsSqlInjectionRisk(deliveryCostA) ||
                ContainsSqlInjectionRisk(deliveryCostB) ||
                ContainsSqlInjectionRisk(deliveryMethod) ||
                ContainsSqlInjectionRisk(deliveryTime))
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


        private async void deliveryMethodDetailUpdateDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = deliveryMethodDetailActiveStatusCheckbox.Checked;
            decimal deliveryCost = decimal.Parse(deliveryMethodDetailDeliveryCostTextboxA.Text.Trim()) + (decimal.Parse(deliveryMethodDetailDeliveryCostTextboxB.Text.Trim()) / 100);
            string deliveryMethod = deliveryMethodDetailDeliveryMethodTextbox.Text.Trim();
            int deliveryTime = int.Parse(deliveryMethodDetailDeliveryTimeTextbox.Text.Trim());
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

            var result = MessageBox.Show("Are you sure that you want to update the following values?\n\n" +
                $"Delivery Method Original Value: {deliveryMethodDetailDeliveryMethodOriginalValue}" + $"\nDelivery Method New Value: {deliveryMethod}\n" +
                $"Delivery Cost Original Value: {deliveryMethodDetailDeliveryCostOriginalValue.ToString()}" + $"\nDelivery Cost New Value: {deliveryCost.ToString()}\n" +
                $"Delivery Time Original Value: {deliveryMethodDetailDeliveryTimeOriginalValue.ToString()}" + $"\nDelivery Time New Value: {deliveryTime.ToString()}\n" +
                $"Tax Profile Original Value: {deliveryMethodDetailTaxProfileOriginalValue.ToString()}" + $"\nTax Profile New Value: {taxProfileId.ToString()}\n" +
                $"Active Status Original Value: {deliveryMethodDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {deliveryMethodDetailActiveStatusCheckbox.Checked}\n\n" +
                "This action cannot be undone.", "Update Delivery Method Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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