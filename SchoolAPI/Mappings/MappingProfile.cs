using AutoMapper;
using SchoolAPI.DTOs;
using SchoolAPI.Models;

namespace SchoolAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to Dto
            CreateMap<Student, StudentReadDto>()
                .ForMember(dto => dto.FullName, opt => opt.MapFrom(stud => $"{stud.FirstName} {stud.LastName}"));

            // DTO to Entity
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();

        }
    }
}
