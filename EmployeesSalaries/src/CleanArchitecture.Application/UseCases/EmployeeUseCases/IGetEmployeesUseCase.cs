using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.EmployeeUseCases
{
    public interface IGetEmployeesUseCase
    {
        Task<IEnumerable<GetEmployeesUseCaseOutput>> ExecuteAsync();
    }
}
