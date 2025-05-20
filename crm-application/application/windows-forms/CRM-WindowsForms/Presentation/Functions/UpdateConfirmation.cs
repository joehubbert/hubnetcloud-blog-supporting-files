using System.Text;

namespace CRM_WindowsForms.Presentation.Functions
{
    public class ChangeDetail
    {
        public string VariableName { get; set; } = string.Empty;
        public string VariableType { get; set; } = string.Empty;
        public object? OriginalValue { get; set; }
        public object? NewValue { get; set; }
    }

    public static class UpdateConfirmation
    {
        public static bool ConfirmChanges(List<ChangeDetail> changesList, string dataSubject)
        {
            var changes = new StringBuilder($"Are you sure that you want to update the following values for {dataSubject}?\n\n");
            bool hasChanges = false;

            foreach (var change in changesList)
            {
                if (!Equals(change.OriginalValue, change.NewValue))
                {
                    hasChanges = true;
                    changes.AppendLine($"{change.VariableName}\nOriginal Value: {change.OriginalValue}\nNew Value: {change.NewValue}\n");
                }
            }

            if (!hasChanges)
            {
                MessageBox.Show("No changes detected. No updates to be made.", "No Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            changes.AppendLine("This action cannot be undone.");

            var result = MessageBox.Show(changes.ToString(), $"Update {dataSubject} Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.Yes;
        }
    }
}