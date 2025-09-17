namespace CRM_WindowsForms_EnterpriseEdition.Services
{
    internal class UnitConversionService
    {
        public static decimal Convert(
            string inputUnitType,
            decimal measurement,
            string measurementType,
            string outputUnitType)
        {
            //Conversion factors
            const decimal areaConversionFactor = 0.15500031m;           // 1 cm² = 0.15500031 in²
            const decimal distanceConversionFactor = 2.54m;             // 1 in = 2.54 cm
            const decimal liquidConversionFactor = 3.78541m;            // 1 US gal = 3.78541 L
            const decimal volumeConversionFactor = 0.0610237m;          // 1 cm³ = 0.0610237 in³
            const decimal weightConversionFactor = 2.20462m;            // 1 kg = 2.20462 lbs

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
                    // cm² <-> in²
                    if (inputUnitType == "metric" && outputUnitType == "imperial")
                        return measurement * areaConversionFactor; // cm² to in²
                    if (inputUnitType == "imperial" && outputUnitType == "metric")
                        return measurement / areaConversionFactor; // in² to cm²
                    break;

                case "Distance":
                    // cm <-> in
                    if (inputUnitType == "metric" && outputUnitType == "imperial")
                        return measurement / distanceConversionFactor; // cm to in
                    if (inputUnitType == "imperial" && outputUnitType == "metric")
                        return measurement * distanceConversionFactor; // in to cm
                    break;

                case "Liquid":
                    // L <-> US gal
                    if (inputUnitType == "metric" && outputUnitType == "imperial")
                        return measurement / liquidConversionFactor; // L to gal
                    if (inputUnitType == "imperial" && outputUnitType == "metric")
                        return measurement * liquidConversionFactor; // gal to L
                    break;

                case "Temperature":
                    // °C <-> °F
                    if (inputUnitType == "metric" && outputUnitType == "imperial")
                        return (measurement * 9m / 5m) + 32m; // °C to °F
                    if (inputUnitType == "imperial" && outputUnitType == "metric")
                        return (measurement - 32m) * 5m / 9m; // °F to °C
                    break;

                case "Volume":
                    // cm³ <-> in³
                    if (inputUnitType == "metric" && outputUnitType == "imperial")
                        return measurement * volumeConversionFactor; // cm³ to in³
                    if (inputUnitType == "imperial" && outputUnitType == "metric")
                        return measurement / volumeConversionFactor; // in³ to cm³
                    break;

                case "Weight":
                    // kg <-> lbs
                    if (inputUnitType == "metric" && outputUnitType == "imperial")
                        return measurement * weightConversionFactor; // kg to lbs
                    if (inputUnitType == "imperial" && outputUnitType == "metric")
                        return measurement / weightConversionFactor; // lbs to kg
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