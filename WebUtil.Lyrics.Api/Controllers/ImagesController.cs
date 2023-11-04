using Microsoft.AspNetCore.Mvc;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;

namespace WebUtil.Lyrics.Api.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImagesController : Controller
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            try
            {
                var imageStream = _imageService.GetImageStream(imageName);

                if (imageStream == null)
                {
                    return NotFound();
                }

                // Determine the content type based on the file extension (you may need to adjust this)
                string contentType = "image/jpeg"; // Adjust based on your image types
                

                // Return the image as a FileResult
                return File(imageStream, contentType);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                return StatusCode(500, ex.Message);
            }
        }

        private void testgitcommand()
        {

        }
    }



}
