using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multilayer_BusinessEntities;

namespace Multilayer_RepositoryLayer
{
    public interface IEmployeeService
    {
        Task<int> AddEmployes(EmployeeDto empDetail);
        Task<bool> DeleteEmployesById(int empId);
        Task<bool> UpdateEmploye(EmployeeDto empDetail);
        Task<List<EmployeeDto>> GetEmployees();
        Task<EmployeeDto> GetEmployeeById(int empId);
       
    }
}
