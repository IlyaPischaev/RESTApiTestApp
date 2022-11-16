using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using RESTApiTestApp.Dtos;
using RESTApiTestApp.Filters;
using RESTApiTestApp.Services;

namespace RESTApiTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAppController : ControllerBase
    {
        private readonly ITestAppService _testAppService;
        private readonly ILogger<TestAppController> _logger;

        public TestAppController(ITestAppService service, ILogger<TestAppController> logger)
        {
            _testAppService = service;
            _logger = logger;
        }

        [HttpPost("AddData")]
        public async Task<IActionResult> PostAsync(IEnumerable<TestAppModelPostDto> testModelDtos)
        {
            _logger.LogInformation($"Using {this.ControllerContext.RouteData.Values["action"]} method in {this.ControllerContext.RouteData.Values["controller"]}");

            var result = await _testAppService.PostAsync(testModelDtos);

            _logger.LogInformation($"Result of {this.ControllerContext.RouteData.Values["action"]} method in {this.ControllerContext.RouteData.Values["controller"]} is {Ok(result).StatusCode}");
            return Ok(result);
        }

        [HttpGet("GetAllData")]
        public async Task<ActionResult<IEnumerable<TestAppModelGetAllDto>>> GetAllAsync([FromQuery] TestAppModelGetAllFilter filter)
        {
            _logger.LogInformation($"Using {this.ControllerContext.RouteData.Values["action"]} method in {this.ControllerContext.RouteData.Values["controller"]}");

            var result = await _testAppService.GetAllAsync(filter);

            if (result.Count() == 0)
            {
                _logger.LogInformation($"Result of {this.ControllerContext.RouteData.Values["action"]} method in {this.ControllerContext.RouteData.Values["controller"]} is {NoContent().StatusCode}");
                return NoContent();
            }

            _logger.LogInformation($"Result of {this.ControllerContext.RouteData.Values["action"]} method in {this.ControllerContext.RouteData.Values["controller"]} is {Ok(result).StatusCode}");
            return Ok(result);
        }
    }
}
