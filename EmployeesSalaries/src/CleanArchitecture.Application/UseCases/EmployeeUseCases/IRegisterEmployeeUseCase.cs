using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.EmployeeUseCases
{
    public interface IRegisterEmployeeUseCase
    {
        Task ExecuteAsync(RegisterEmployeeUseCaseInput input);
    }
}
