using CRM.Model;

namespace CRM.Services
{
    public class UnitConversionService
    {
        public static decimal ConvertMeasurement(
            UnitType inputUnitType,
            decimal measurement,
            MeasurementType measurementType,
            UnitType outputUnitType)
        {
            //Conversion factors
            const decimal areaConversionFactor = 0.15500031m;           // 1 cm² = 0.15500031 in²
            const decimal distanceConversionFactor = 2.54m;             // 1 in = 2.54 cm
            const decimal liquidConversionFactor = 3.78541m;            // 1 US gal = 3.78541 L
            const decimal volumeConversionFactor = 0.0610237m;          // 1 cm³ = 0.0610237 in³
            const decimal weightConversionFactor = 2.20462m;            // 1 kg = 2.20462 lbs

            if (inputUnitType == outputUnitType)
                return measurement;

            switch (measurementType)
            {
                case MeasurementType.Area:
                    // cm² <-> in²
                    if (inputUnitType == UnitType.Metric && outputUnitType == UnitType.Imperial)
                        return measurement * areaConversionFactor; // cm² to in²
                    if (inputUnitType == UnitType.Imperial && outputUnitType == UnitType.Metric)
                        return measurement / areaConversionFactor; // in² to cm²
                    break;

                case MeasurementType.Distance:
                    // cm <-> in
                    if (inputUnitType == UnitType.Metric && outputUnitType == UnitType.Imperial)
                        return measurement / distanceConversionFactor; // cm to in
                    if (inputUnitType == UnitType.Imperial && outputUnitType == UnitType.Metric)
                        return measurement * distanceConversionFactor; // in to cm
                    break;

                case MeasurementType.Liquid:
                    // L <-> US gal
                    if (inputUnitType == UnitType.Metric && outputUnitType == UnitType.Imperial)
                        return measurement / liquidConversionFactor; // L to gal
                    if (inputUnitType == UnitType.Imperial && outputUnitType == UnitType.Metric)
                        return measurement * liquidConversionFactor; // gal to L
                    break;

                case MeasurementType.Temperature:
                    // °C <-> °F
                    if (inputUnitType == UnitType.Metric && outputUnitType == UnitType.Imperial)
                        return (measurement * 9m / 5m) + 32m; // °C to °F
                    if (inputUnitType == UnitType.Imperial && outputUnitType == UnitType.Metric)
                        return (measurement - 32m) * 5m / 9m; // °F to °C
                    break;

                case MeasurementType.Volume:
                    // cm³ <-> in³
                    if (inputUnitType == UnitType.Metric && outputUnitType == UnitType.Imperial)
                        return measurement * volumeConversionFactor; // cm³ to in³
                    if (inputUnitType == UnitType.Imperial && outputUnitType == UnitType.Metric)
                        return measurement / volumeConversionFactor; // in³ to cm³
                    break;

                case MeasurementType.Weight:
                    // kg <-> lbs
                    if (inputUnitType == UnitType.Metric && outputUnitType == UnitType.Imperial)
                        return measurement * weightConversionFactor; // kg to lbs
                    if (inputUnitType == UnitType.Imperial && outputUnitType == UnitType.Metric)
                        return measurement / weightConversionFactor; // lbs to kg
                    break;

                default:
                    ErrorMessageService errorMessageServiceNotImplemented = new ErrorMessageService("Error.Measurement.Type.NotImplemented", measurementType.ToString());
                    break;
            }

            ErrorMessageService errorMessageServiceConversionError = new ErrorMessageService("Error.UnitConversion.Generic");
            throw new InvalidOperationException("Unit conversion failed.");
        }
    }
}