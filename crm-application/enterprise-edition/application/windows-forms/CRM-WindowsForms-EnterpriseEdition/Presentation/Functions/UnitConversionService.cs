namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    internal class UnitConversionService
    {
        public static decimal Convert(
            string inputUnitType,
            decimal measurement,
            string measurementType,
            string outputUnitType)
        {
            const decimal areaConversionFactor = 10.7639m;
            const decimal distanceConversionFactor = 2.54m;
            const decimal liquidConversionFactor = 3.78541m;
            const decimal volumeConversionFactor = 35.3147m;
            const decimal weightConversionFactor = 2.20462m;

            if (string.IsNullOrWhiteSpace(inputUnitType))
                throw new ArgumentNullException(nameof(inputUnitType));
            if (string.IsNullOrWhiteSpace(measurementType))
                throw new ArgumentNullException(nameof(measurementType));
            if (string.IsNullOrWhiteSpace(outputUnitType))
                throw new ArgumentNullException(nameof(outputUnitType));

            if (inputUnitType == outputUnitType)
                return measurement;

            switch (measurementType)
            {
                case "Area":
                    // m² <-> ft²
                    if (inputUnitType == "metric" && outputUnitType == "imperial")
                        return measurement * areaConversionFactor; // m² to ft²
                    if (inputUnitType == "imperial" && outputUnitType == "metric")
                        return measurement / areaConversionFactor; // ft² to m²
                    break;

                case "Distance":
                    // cm <-> in
                    if (inputUnitType == "metric" && outputUnitType == "imperial")
                        return measurement / distanceConversionFactor; // cm to in
                    if (inputUnitType == "imperial" && outputUnitType == "metric")
                        return measurement * distanceConversionFactor; // in to cm
                    break;
                case "Liquid":
                    // l <-> gal (US liquid gallon)
                    if (inputUnitType == "metric" && outputUnitType == "imperial")
                        return measurement / liquidConversionFactor; // l to gal
                    if (inputUnitType == "imperial" && outputUnitType == "metric")
                        return measurement * liquidConversionFactor; // gal to l
                    break;
                case "Temperature":
                    // °C <-> °F
                    if (inputUnitType == "metric" && outputUnitType == "imperial")
                        return (measurement * 9m / 5m) + 32m; // °C to °F
                    if (inputUnitType == "imperial" && outputUnitType == "metric")
                        return (measurement - 32m) * 5m / 9m; // °F to °C
                    break;
                case "Weight":
                    // kg <-> lb
                    if (inputUnitType == "metric" && outputUnitType == "imperial")
                        return measurement * weightConversionFactor; // kg to lb
                    if (inputUnitType == "imperial" && outputUnitType == "metric")
                        return measurement / weightConversionFactor; // lb to kg
                    break;
                case "Volume":
                    // m³ <-> ft³
                    if (inputUnitType == "metric" && outputUnitType == "imperial")
                        return measurement * volumeConversionFactor; // m³ to ft³
                    if (inputUnitType == "imperial" && outputUnitType == "metric")
                        return measurement / volumeConversionFactor; // ft³ to m³
                    break;
                default:
                    new ErrorMessageService("Error.Measurement.Type.NotImplemented", measurementType);
                    break;
            }

            new ErrorMessageService("Error.UnitConversion.Generic");
            throw new InvalidOperationException("Unit conversion failed.");
        }
    }
}