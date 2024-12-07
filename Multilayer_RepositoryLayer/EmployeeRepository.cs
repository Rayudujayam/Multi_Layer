using Multilayer_BusinessEntities;
using Multilayer_BusinessEntities.InterFaces;
using Multilayer_RepositoryLayer;
using Multilayer_DBConnectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;


namespace Multilayer_RepositoryLayer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly IConnectionFactory _connectionFactory;

        public EmployeeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddEmployes(Employee empDetail)
        {
            using (IDbConnection con = _connectionFactory.GetHotelManagementSqlConnection())
            {//Create object for DynamicParameters for storedure input parameter values binding purpose used.
                var p = new DynamicParameters();//DynamicParameters comming from Dapper package
                p.Add("@empname", empDetail.empname);
                p.Add("@empsalary", empDetail.empsalary);
                p.Add("@insertvalue", DbType.Int32, direction: ParameterDirection.Output);
                await con.ExecuteScalarAsync<int>(StoredProcedure.AddEmployee, p, commandType: CommandType.StoredProcedure);
                int inserterdid = p.Get<int>("@insertvalue");
                return inserterdid;
            }
        }

        public async Task<bool> DeleteEmployesById(int empid)
        {
            using (IDbConnection con = _connectionFactory.GetHotelManagementSqlConnection())
            {
                var p = new DynamicParameters();
                p.Add("@empid", empid);
                await con.ExecuteScalarAsync(StoredProcedure.DeleteEmployee, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<Employee> GetEmployeeById(int empId)
        {
            Employee emp;
            using (IDbConnection con = _connectionFactory.GetHotelManagementSqlConnection())
            {
                var p = new DynamicParameters();
                p.Add("@empid", empId);
                var result = await con.QueryAsync<Employee>(StoredProcedure.GetEmployeeByEmpid, p, commandType: CommandType.StoredProcedure);
                emp = result.FirstOrDefault();
                return emp;
            }
        }

        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> res;
            using (IDbConnection conn = _connectionFactory.GetHotelManagementSqlConnection())
            {
                var queryresult = await conn.QueryAsync<Employee>(StoredProcedure.GetEmployee, CommandType.StoredProcedure);
                res = queryresult.ToList();
                return res;
            }
        }

        public async Task<bool> UpdateEmploye(Employee empDetail)
        {
            using (IDbConnection con = _connectionFactory.GetHotelManagementSqlConnection())
            {
                var p = new DynamicParameters();
                p.Add("@empid", empDetail.empid);
                p.Add("@empname", empDetail.empname);
                p.Add("@empsalary", empDetail.empsalary);
                await con.ExecuteReaderAsync(StoredProcedure.UpdateEmployee, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
