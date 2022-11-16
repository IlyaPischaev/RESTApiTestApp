using Microsoft.AspNetCore.Mvc;
using RESTApiTestApp.Dtos;
using RESTApiTestApp.Filters;

namespace RESTApiTestApp.Services
{
    public interface ITestAppService
    {
        Task<IActionResult> PostAsync(IEnumerable<TestAppModelPostDto> models);
        Task<IEnumerable<TestAppModelGetAllDto>> GetAllAsync(TestAppModelGetAllFilter filter);
    }
}
