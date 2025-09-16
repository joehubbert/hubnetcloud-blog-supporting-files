namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    internal class MeasurementLabelHelper
    {
        public static async Task SetUnitLabelAsync(Label label, string measurementType, bool mandatoryFlag, string unitType)
        {
            if (label == null)
                throw new ArgumentNullException(nameof(label));

            switch (measurementType)
            {
                case "Area":
                    if (unitType == "metric")
                        label.Text += " (cm²)";
                    else
                        label.Text += " (in²)";
                    break;
                case "Volume":
                    if (unitType == "metric")
                        label.Text += " (cm³)";
                    else
                        label.Text += " (in³)";
                    break;
                case "Distance":
                    if (unitType == "metric")
                        label.Text += " (cm)";
                    else
                        label.Text += " (in)";
                    break;
                case "Temperature":
                    if (unitType == "metric")
                        label.Text += " (°C)";
                    else
                        label.Text += " (°F)";
                    break;
                case "Liquid":
                    if (unitType == "metric")
                        label.Text += " (l)";
                    else
                        label.Text += " (gal)";
                    break;
                case "Weight":
                    if (unitType == "metric")
                        label.Text += " (kg)";
                    else
                        label.Text += " (lbs)";
                    break;
                default:
                    new ErrorMessageService("Error.Measurement.Type.NotImplemented", measurementType);
                    break;
            }

            if (mandatoryFlag)
            {
                label.Text += "*";
            }
        }
    }
}