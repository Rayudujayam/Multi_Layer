using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multilayer_BusinessEntities;
using Multilayer_RepositoryLayer;

namespace MultiLayer_ServiceLayer
{
    public class EmployeeServices : IEmployeeService
    {
        IEmployeeRepository _EmployeeRepository;

        public EmployeeServices(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        public async Task<int> AddEmployes(EmployeeDto empDetail)
        {
            Employee employee = new Employee();
            employee.empid= empDetail.empid;
            employee.empname= empDetail.empname;
            employee.empsalary= empDetail.empsalary;
            var res = await _EmployeeRepository.AddEmployes(employee);
            return res;
        }

       
        public async Task<bool> DeleteEmployesById(int empId)
        {
            var res=await _EmployeeRepository.DeleteEmployesById(empId);
            return res;
        }

        public async Task<EmployeeDto> GetEmployeeById(int empId)
        {
            var res = await _EmployeeRepository.GetEmployeeById(empId);
            EmployeeDto empdto = new EmployeeDto();
            empdto.empid = res.empid;
            empdto.empname = res.empname;
            empdto.empsalary = res.empsalary;
            return empdto;
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            List<EmployeeDto> lstempdto = new List<EmployeeDto>();
            var res = await _EmployeeRepository.GetEmployees();
            foreach (Employee emp in res)
            {
                EmployeeDto empdto = new EmployeeDto();
                empdto.empid = emp.empid;
                empdto.empsalary = emp.empsalary;
                empdto.empname = emp.empname;
                lstempdto.Add(empdto);

            }
            return lstempdto;

        }

        public async Task<bool> UpdateEmploye(EmployeeDto empDetail)
        {
            Employee emp = new Employee();
            emp.empid = empDetail.empid;
            emp.empname = empDetail.empname;
            emp.empsalary = empDetail.empsalary;
            var res = await _EmployeeRepository.UpdateEmploye(emp);
            return res;
        }
    }
}
