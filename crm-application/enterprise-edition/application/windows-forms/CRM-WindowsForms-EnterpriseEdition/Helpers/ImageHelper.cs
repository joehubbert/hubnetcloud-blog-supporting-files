namespace CRM_WindowsForms_EnterpriseEdition.Helpers
{
    internal class ImageHelper
    {
        public static Image? ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                return null;
            }

            using (var memoryStream = new MemoryStream(byteArray))
            {
                return Image.FromStream(memoryStream);
            }
        }

        public static bool GetDimensions(byte[] byteArray, out int width, out int height)
        {
            width = 0;
            height = 0;
            if (byteArray == null || byteArray.Length == 0)
                return false;

            try
            {
                using (var memoryStream = new MemoryStream(byteArray))
                using (var image = Image.FromStream(memoryStream))
                {
                    width = image.Width;
                    height = image.Height;
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}