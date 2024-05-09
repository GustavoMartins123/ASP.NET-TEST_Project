using AutoMapper;
using NewTestDB.Models.Dto.Car;
using NewTestDB.Models;
using NewTestDB.Models.Dto;
using NewTestDB.Models.Dto.JobPerson;
using NewTestDB.Models.Dto.Person;

namespace NewTestDB.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CarModel, CarReturnDto>();
            CreateMap<CarModel, CarDetailDto>();
            CreateMap<PersonModel, PersonReturnDto>();
            CreateMap<PersonModel, PersonDetailDto>();
            CreateMap<JobPersonModel, JobPersonReturnDto>();
            CreateMap<JobPersonModel, JobPersonDetailDto>();
        }
    }
}
