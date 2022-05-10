using Microsoft.AspNetCore.Mvc;

namespace TestArtem.Controllers
{
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(
            ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> Add(IFormFile file)
        {
            try
            {
                if (file == null)
                {
                    return BadRequest();
                }
                if (file.Length > 0)
                {
                    string filePath = "D:\\MyVideo.mp4";
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }

                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500);
            }
        }

    }
}