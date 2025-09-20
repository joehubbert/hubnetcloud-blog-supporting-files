using CRM.Model;
using CRM.Services;

namespace CRM.Helpers
{
    internal class MeasurementLabelHelper
    {
        public static async Task SetUnitLabelAsync(Label label, MeasurementType measurementType, bool mandatoryFlag, UnitType unitType)
        {
            if (label == null)
                throw new ArgumentNullException(nameof(label));

            switch (measurementType)
            {
                case MeasurementType.Area:
                    if (unitType == UnitType.Metric)
                        label.Text += " (cm²)";
                    else
                        label.Text += " (in²)";
                    break;
                case MeasurementType.Volume:
                    if (unitType == UnitType.Metric)
                        label.Text += " (cm³)";
                    else
                        label.Text += " (in³)";
                    break;
                case MeasurementType.Distance:
                    if (unitType == UnitType.Metric)
                        label.Text += " (cm)";
                    else
                        label.Text += " (in)";
                    break;
                case MeasurementType.Temperature:
                    if (unitType == UnitType.Metric)
                        label.Text += " (°C)";
                    else
                        label.Text += " (°F)";
                    break;
                case MeasurementType.Liquid:
                    if (unitType == UnitType.Metric)
                        label.Text += " (l)";
                    else
                        label.Text += " (gal)";
                    break;
                case MeasurementType.Weight:
                    if (unitType == UnitType.Metric)
                        label.Text += " (kg)";
                    else
                        label.Text += " (lbs)";
                    break;
                default:
                    new ErrorMessageService("Error.Measurement.Type.NotImplemented", measurementType.ToString());
                    break;
            }

            if (mandatoryFlag)
            {
                label.Text += "*";
            }
        }
    }
}