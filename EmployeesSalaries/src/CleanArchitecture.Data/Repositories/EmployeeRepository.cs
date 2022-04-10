using CleanArchitecture.Domain.Aggregates.EmployeeAggregate;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IMongoDatabase database) 
            : base(database, "employees")
        {
        }

        public async Task<IEnumerable<Employee>> GetAsync()
        {
            var employees = await Collection.Find(_ => true).ToListAsync();
            return employees;
        }

        public async Task<Employee> GetAsync(string id)
        {
            var employee = await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return employee;
        }

        public async Task AddAsync(Employee employee)
        {
            await Collection.InsertOneAsync(employee);
        }

        public async Task UpdateAsync(Employee employee)
        {
            await Collection.ReplaceOneAsync(x => x.Id == employee.Id, employee, new ReplaceOptions { IsUpsert = true });
        }
    }
}
