using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Aggregates.EmployeeAggregate
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAsync();
        Task<Employee> GetAsync(string id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
    }
}
