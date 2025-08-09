namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
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
    }
}