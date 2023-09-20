
using System.Drawing;
using System.Drawing.Imaging;

namespace WebUtil.Lyrics.Api.Helpers
{
    public class ImageUploader
    {
        private readonly string uploadDirectory = "images/profile/avatars"; // Adjust the directory path

        public string UploadImage(byte[] imageBytes, string fileName)
        {
            // Ensure the upload directory exists
            Directory.CreateDirectory(uploadDirectory);

            // Generate a unique file name or use the provided one
            string uniqueFileName = $"{Guid.NewGuid()}-{fileName}";

            // Combine the directory and file name to create the full path
            string filePath = Path.Combine(uploadDirectory, uniqueFileName);

            // Save the image bytes to the file
            File.WriteAllBytes(filePath, imageBytes);

            // Return the URL or path to the uploaded image
            return $"{uploadDirectory}/{uniqueFileName}"; // Adjust the URL format as needed
        }

        //public bool ValidateImage(byte[] imageBytes)
        //{
        //    try
        //    {
        //        using (var imageStream = new MemoryStream(imageBytes))
        //        using (var image = Image.FromStream(imageStream))
        //        {
        //            // Perform image validation here, e.g., check dimensions, file type, etc.
        //            // If validation succeeds, return true; otherwise, return false.
        //            return true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        // Image validation failed
        //        return false;
        //    }
        //}
    }
}
