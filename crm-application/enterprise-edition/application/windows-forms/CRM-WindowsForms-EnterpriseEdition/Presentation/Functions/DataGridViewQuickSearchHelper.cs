using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    internal class DataGridViewQuickSearchHelper
    {
        private readonly TextBox _filterTextBox;
        private readonly DataGridView _dataGridView;

        public DataGridViewQuickSearchHelper(TextBox filterTextBox, DataGridView dataGridView)
        {
            _filterTextBox = filterTextBox ?? throw new ArgumentNullException(nameof(filterTextBox));
            _dataGridView = dataGridView ?? throw new ArgumentNullException(nameof(dataGridView));
            _filterTextBox.TextChanged += FilterTextBox_TextChanged;
        }

        private void FilterTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (_dataGridView.DataSource is DataTable dataTable)
            {
                string filterText = _filterTextBox.Text.Replace("'", "''");
                if (string.IsNullOrWhiteSpace(filterText))
                {
                    dataTable.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    var filterConditions = dataTable.Columns
                        .Cast<DataColumn>()
                        .Where(col =>
                            col.DataType == typeof(string) ||
                            col.DataType == typeof(object) ||
                            col.DataType == typeof(Guid))
                        .Select(col =>
                            $"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{filterText}%'"
                        );
                    dataTable.DefaultView.RowFilter = string.Join(" OR ", filterConditions);
                }
            }
        }

        public void Dispose()
        {
            _filterTextBox.TextChanged -= FilterTextBox_TextChanged;
        }
    }
}