using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multilayer_BusinessEntities;

namespace Multilayer_RepositoryLayer
{
    public interface IEmployeeRepository
    {
        Task<int> AddEmployes(Employee empDetail);
        Task<bool> DeleteEmployesById(int empId);
        Task<bool> UpdateEmploye(Employee empDetail);
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int empId);
    }
}
