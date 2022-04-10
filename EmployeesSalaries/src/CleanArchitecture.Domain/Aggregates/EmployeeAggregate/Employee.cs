using CleanArchitecture.Domain.SeedWork;
using System;

namespace CleanArchitecture.Domain.Aggregates.EmployeeAggregate
{
    public class Employee : Entity, IAggregateRoot
    {
        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        private string Name { get; set; }
        private decimal Salary { get; set; }

        public void RaiseSalary(decimal salary)
        {
            if(salary <= Salary)
            {
                throw new InvalidOperationException("Salary must be greater than current salary.");
            }

            Salary = salary;
        }
    }
}
