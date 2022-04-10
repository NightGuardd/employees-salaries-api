using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.EmployeeUseCases
{
    public interface IRaiseEmployeeSalaryUseCase
    {
        Task ExecuteAsync(RaiseEmployeeSalaryUseCaseInput input);
    }
}
