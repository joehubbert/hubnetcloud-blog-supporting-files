namespace CRM.Helpers
{
    internal static class ResizeComboBoxDropDownHelper
    {
        public static void ComboBoxDropDownResizeHandler(object? sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                int comboBoxWidth = comboBox.DropDownWidth;
                using Graphics comboBoxGraphics = comboBox.CreateGraphics();
                Font comboBoxFont = comboBox.Font;

                int verticalScrollBarWidth = comboBox.Items.Count > comboBox.MaxDropDownItems ? SystemInformation.VerticalScrollBarWidth : 0;
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
        }
    }
}