using AutoMapper;
using CleanArchitecture.Domain.Aggregates.EmployeeAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.EmployeeUseCases
{
    public class GetEmployeesUseCase : IGetEmployeesUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeesUseCase(IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetEmployeesUseCaseOutput>> ExecuteAsync()
        {
            var employees = await _employeeRepository.GetAsync();
            var employeesOutput = _mapper.Map<IEnumerable<Employee>, IEnumerable<GetEmployeesUseCaseOutput>>(employees);

            return employeesOutput;
        }
    }
}
