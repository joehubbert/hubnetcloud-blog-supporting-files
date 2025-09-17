namespace CRM.Helpers
{
    internal class CalculateDimensionsHelper
    {
        // Area of a rectangular container
        public static decimal GetArea(decimal height, decimal width)
        {
            return height * width;
        }

        // Rectangular container (height × width × depth)
        public static decimal GetVolume(decimal height, decimal width, decimal depth)
        {
            return height * width * depth;
        }

        // Cylindrical container (π × radius² × height)
        public static decimal GetCylindricalVolume(decimal radius, decimal height)
        {
            return (decimal)Math.PI * radius * radius * height;
        }
    }
}
