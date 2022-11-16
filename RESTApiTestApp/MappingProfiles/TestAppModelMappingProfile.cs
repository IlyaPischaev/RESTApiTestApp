using AutoMapper;
using RESTApiTestApp.Dtos;
using RESTApiTestApp.Models;

namespace RESTApiTestApp.MappingProfiles
{
    public class TestAppModelMappingProfile : Profile
    {
        public TestAppModelMappingProfile()
        {
            CreateMap<TestAppModelPostDto, TestAppModel>();
            CreateMap<TestAppModel, TestAppModelGetAllDto>();
        }
    }
}
