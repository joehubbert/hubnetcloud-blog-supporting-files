using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Helpers
{
    internal class ThreadSafeComboBoxLoader
    {
        public static async Task LoadComboBoxDataAsync(Control control, ComboBox comboBox, string storedProcedureName,
            Guid? companyConfigurationId = null, bool suppressExceptions = false)
        {
            if (comboBox == null)
                return;

            try
            {
                // Create a helper that doesn't have a direct reference to the ComboBox
                var helper = new DataAccessLookupHelper(
                    storedProcedureName,
                    companyConfigurationId);

                // Fetch data on background thread
                DataTable? dataTable = await helper.GetFilteredDataTableAsync();

                // Update the UI on the UI thread
                if (control.InvokeRequired)
                {
                    control.Invoke(new Action(() => UpdateComboBox(comboBox, dataTable)));
                }
                else
                {
                    UpdateComboBox(comboBox, dataTable);
                }
            }
            catch (Exception ex)
            {
                if (!suppressExceptions)
                {
                    var errorMessage = $"Error loading ComboBox data: {ex.Message}";
                    if (control.InvokeRequired)
                    {
                        control.Invoke(new Action(() => MessageBox.Show(errorMessage)));
                    }
                    else
                    {
                        MessageBox.Show(errorMessage);
                    }
                }
            }
        }

        private static void UpdateComboBox(ComboBox comboBox, DataTable? dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                comboBox.DataSource = null;
                return;
            }

            comboBox.DataSource = dataTable;

            // Set display and value members if the columns exist
            if (dataTable.Columns.Contains("Display Text"))
                comboBox.DisplayMember = "Display Text";

            // Check for common ID column patterns
            string[] possibleIdColumns = {
                "Id", "ID",
                comboBox.Name.Replace("ComboBox", "") + "Id",
                dataTable.TableName + " Id"
            };

            foreach (var colName in dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName))
            {
                if (colName.EndsWith(" Id") || colName.EndsWith("Id") ||
                    possibleIdColumns.Contains(colName))
                {
                    comboBox.ValueMember = colName;
                    break;
                }
            }
        }
    }
}