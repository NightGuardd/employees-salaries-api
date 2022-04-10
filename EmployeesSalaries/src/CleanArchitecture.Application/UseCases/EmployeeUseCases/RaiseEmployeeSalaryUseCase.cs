using CleanArchitecture.Domain.Aggregates.EmployeeAggregate;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.EmployeeUseCases
{
    public class RaiseEmployeeSalaryUseCase : IRaiseEmployeeSalaryUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public RaiseEmployeeSalaryUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task ExecuteAsync(RaiseEmployeeSalaryUseCaseInput input)
        {
            var employee = await _employeeRepository.GetAsync(input.Id);
            if (employee == null)
            {
                throw new InvalidOperationException("Employee not found");
            }

            employee.RaiseSalary(input.Salary);

            await _employeeRepository.UpdateAsync(employee);
        }
    }
}
