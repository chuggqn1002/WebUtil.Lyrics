using static System.Net.Mime.MediaTypeNames;

namespace WebUtil.Lyrics.Api.Helpers
{
    public class ImageProcessor
    {
        //public byte[] ResizeImage(byte[] imageBytes, int width, int height)
        //{
        //    using (var imageStream = new MemoryStream(imageBytes))
        //    using (var image = Image.FromStream(imageStream))
        //    using (var resizedImage = new Bitmap(width, height))
        //    using (var graphics = Graphics.FromImage(resizedImage))
        //    {
        //        // Configure the graphics object for resizing
        //        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        //        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

        //        // Resize the image
        //        graphics.DrawImage(image, 0, 0, width, height);

        //        // Save the resized image to a memory stream
        //        using (var resizedStream = new MemoryStream())
        //        {
        //            resizedImage.Save(resizedStream, System.Drawing.Imaging.ImageFormat.Jpeg); // You can adjust the format
        //            return resizedStream.ToArray();
        //        }
        //    }
        //}
    }
}
