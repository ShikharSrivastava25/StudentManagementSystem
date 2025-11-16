using AutoMapper;
using StudentManagementSystem.DTO;
using StudentManagementSystem.Models;

namespace StudentManagementSystem {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentDto, Student>();

            CreateMap<Mark, MarkDto>();
            CreateMap<CreateMarkDto, Mark>();

            CreateMap<UpdateStudentDto, Student>();
            CreateMap<UpdateMarkDto, Mark>();
        }
    }
}
