using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTApiTestApp.Data;
using RESTApiTestApp.Dtos;
using RESTApiTestApp.Filters;
using RESTApiTestApp.Models;

namespace RESTApiTestApp.Services
{
    public class TestAppService : ITestAppService
    {
        private readonly TestAppDbContext _context;
        private readonly IMapper _mapper;

        public TestAppService(TestAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> PostAsync(IEnumerable<TestAppModelPostDto> models)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.TestAppModels.RemoveRange(await _context.TestAppModels.ToListAsync());

                var testModels = _mapper.Map<IEnumerable<TestAppModelPostDto>, IEnumerable<TestAppModel>>(models);

                _context.TestAppModels.AddRange(testModels.OrderBy(x => x.Code));
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }

            return new OkResult();
        }

        public async Task<IEnumerable<TestAppModelGetAllDto>> GetAllAsync(TestAppModelGetAllFilter filter)
        {
            var queriable = _context.TestAppModels.AsQueryable();

            if (!(filter?.Code == null))
            {
                queriable = queriable.Where(x => x.Code == filter.Code);
            }

            if (!string.IsNullOrEmpty(filter?.Value))
            {
                queriable = queriable.Where(x => x.Value == filter.Value);
            }

            var testModelDtos = _mapper.Map<IEnumerable<TestAppModel>, IEnumerable<TestAppModelGetAllDto>>(await queriable.ToListAsync());

            return testModelDtos;
        }
    }
}
