using CleanArchitecture.Domain.Aggregates.EmployeeAggregate;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.EmployeeUseCases
{
    public class RegisterEmployeeUseCase : IRegisterEmployeeUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public RegisterEmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task ExecuteAsync(RegisterEmployeeUseCaseInput input)
        {
            var employee = new Employee(input.Name, input.Salary);
            await _employeeRepository.AddAsync(employee);
        }
    }
}
