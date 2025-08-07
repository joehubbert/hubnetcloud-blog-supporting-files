using System.Text;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    public static class CSVExportService
    {
        public static void ExportDataGridViewToCSV(DataGridView dataGridView, string dataSubject)
        {
            if (dataGridView == null || dataGridView.ColumnCount == 0)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Warning.CSVExport.NoData", dataSubject);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Export to CSV";
                saveFileDialog.FileName = $"{DateTime.UtcNow:yyyy-MM-dd-hh-mm-ss} {dataSubject} Export.csv";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, new UTF8Encoding(true)))
                        {
                            for (int i = 0; i < dataGridView.ColumnCount; i++)
                            {
                                writer.Write(EscapeForCsv(dataGridView.Columns[i].HeaderText));
                                if (i < dataGridView.ColumnCount - 1)
                                    writer.Write(",");
                            }
                            writer.WriteLine();

                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    for (int i = 0; i < dataGridView.ColumnCount; i++)
                                    {
                                        var cellValue = row.Cells[i].Value?.ToString() ?? string.Empty;
                                        writer.Write(EscapeForCsv(cellValue));
                                        if (i < dataGridView.ColumnCount - 1)
                                            writer.Write(",");
                                    }
                                    writer.WriteLine();
                                }
                            }
                        }
                        ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Information.CSVExport.ExportSuccessful", dataSubject);
                    }
                    catch (Exception ex)
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.CSVExport.ExportFailure", dataSubject, ex.Message);
                    }
                }
            }
        }

        private static string EscapeForCsv(string value)
        {
            if (value.Contains("\"") || value.Contains(",") || value.Contains("\n") || value.Contains("\r"))
            {
                value = value.Replace("\"", "\"\"");
                return $"\"{value}\"";
            }
            return value;
        }
    }
}