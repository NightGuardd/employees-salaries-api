using AutoMapper;
using CleanArchitecture.Application.UseCases.EmployeeUseCases;
using CleanArchitecture.Domain.Aggregates.EmployeeAggregate;

namespace CleanArchitecture.Application.AutoMapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, GetEmployeesUseCaseOutput>();
        }
    }
}
