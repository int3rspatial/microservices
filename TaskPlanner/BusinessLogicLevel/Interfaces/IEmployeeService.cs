using BusinessLogicLevel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLevel.Interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(EmployeeModel employeeModel);
        void EditEmployee(EmployeeModel employeeModel);
        EmployeeModel GetEmployeeById(int employeeId);
        EmployeeModel GetEmployeeByName(string name);
        IEnumerable<EmployeeModel> GetEmployees();
        void RemoveEmployee(int employeeId);
        void AddTaskToEmployee(int employeeId, int taskId);
    }
}
