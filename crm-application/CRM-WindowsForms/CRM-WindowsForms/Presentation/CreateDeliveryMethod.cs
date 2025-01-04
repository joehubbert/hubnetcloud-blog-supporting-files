using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateDeliveryMethod : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateDeliveryMethod()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            CreateDeliveryMethodLoadTaxProfileAsync();
        }

        private void InitializeCustomComponents()
        {
            createDeliveryMethodTaxProfileComboBox.DropDown += new EventHandler(CreateDeliveryMethodTaxProfileComboBox_DropDown);
        }

        private async void LoadDatabaseConnectionSettingsAsync()
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

        private async void CreateDeliveryMethodLoadTaxProfileAsync()
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
                createDeliveryMethodTaxProfileComboBox.DataSource = taxProfileList;
                createDeliveryMethodTaxProfileComboBox.DisplayMember = "DisplayText";
                createDeliveryMethodTaxProfileComboBox.ValueMember = "TaxProfileId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Tax Profile data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDeliveryMethodTaxProfileComboBox_DropDown(object sender, EventArgs e)
        {
            AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string deliveryCostA = createDeliveryMethodDeliveryCostTextboxA.Text.Trim();
            string deliveryCostB = createDeliveryMethodDeliveryCostTextboxB.Text.Trim();
            string deliveryMethod = createDeliveryMethodDeliveryMethodTextbox.Text.Trim();
            string deliveryTime = createDeliveryMethodDeliveryTimeTextbox.Text.Trim();

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

        private async void createDeliveryMethodSubmitButton_Click(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput())
            {
                return;
            }

            try
            {
                bool activeStatus = createDeliveryMethodActiveStatusCheckbox.Checked;        
                decimal deliveryCost = decimal.Parse(createDeliveryMethodDeliveryCostTextboxA.Text.Trim()) + (decimal.Parse(createDeliveryMethodDeliveryCostTextboxB.Text.Trim()) / 100);
                string deliveryMethod = createDeliveryMethodDeliveryMethodTextbox.Text.Trim();
                int deliveryTime = int.Parse(createDeliveryMethodDeliveryTimeTextbox.Text.Trim());
                Guid taxProfileId = Guid.Parse(createDeliveryMethodTaxProfileComboBox.SelectedValue.ToString());

                var parameters = new[]
                {
                        new SqlParameter("@activeStatus", activeStatus),
                        new SqlParameter("@deliveryCost", deliveryCost),
                        new SqlParameter("@deliveryMethod", deliveryMethod),
                        new SqlParameter("@deliveryTime", deliveryTime),
                        new SqlParameter("@taxProfileId", taxProfileId)
                    };

                ExecuteStoredProcedure executeor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                await executeor.ExecuteNonQueryAsync("[dbo].[spCreateDeliveryMethod]", parameters);

                MessageBox.Show("New Tax Profile added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add new Tax Profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}