using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayer_DBConnectivity
{
    public class StoredProcedure
    {
        #region EmployeeStoredProcedure Details
        public static readonly string AddEmployee = "Usp_AddEmployeeReturn";
        public static readonly string UpdateEmployee = "Usp_UpdateEmployee";
        public static readonly string DeleteEmployee = "Usp_DeleteEmployee";
        public static readonly string GetEmployee = "Usp_GetEmployee";
        public static readonly string GetEmployeeByEmpid = "Usp_GetEmployeeId";
        #endregion
    }
}
