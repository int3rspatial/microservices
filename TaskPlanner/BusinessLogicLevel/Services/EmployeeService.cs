using AutoMapper;
using BusinessLogicLevel.Interfaces;
using BusinessLogicLevel.Models;
using DataAccessLayer.Repository.IRepository;
using DataAccessLayer.Entities;
using Task = DataAccessLayer.Entities.Task;
using SharedTypes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLevel.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _database;
        private IMapper _mapper;
        public EmployeeService(IUnitOfWork database, IMapper mapper)
        {
            _mapper = mapper;
            _database = database;
        }
        public void AddEmployee(EmployeeModel employeeModel)
        {
            if(employeeModel.Name != String.Empty)
            {
                _database.Employees.Add(_mapper.Map<Employee>(employeeModel));
                _database.SaveChanges();
            }
        }

        public void AddTaskToEmployee(int employeeId, int taskId)
        {
            Task task = _database.Tasks.GetFirstOrDefault(x => x.Id == taskId);
            Employee employee = _database.Employees.GetFirstOrDefault(x => x.Id == employeeId);
            if(employee.FreeHours >= task.EstimatedTime)
            {
                employee.Tasks.Add(task);
                employee.FreeHours -= task.EstimatedTime;
                _database.Employees.Update(employee);
                _database.SaveChanges();
            }
        }

        public void EditEmployee(EmployeeModel employeeModel)
        {
            _database.Employees.Update(_mapper.Map<Employee>(employeeModel));
            _database.SaveChanges();
        }

        public EmployeeModel GetEmployeeById(int employeeId)
        {
            Employee employee = _database.Employees.GetFirstOrDefault(x => x.Id == employeeId);
            return _mapper.Map<EmployeeModel>(employee);
        }

        public EmployeeModel GetEmployeeByName(string name)
        {
            Employee employee = _database.Employees.GetFirstOrDefault(x => x.Name == name);
            return _mapper.Map<EmployeeModel>(employee);
        }

        public IEnumerable<EmployeeModel> GetEmployees()
        {
            IEnumerable<Employee> employees = _database.Employees.GetAll();
            return _mapper.Map<IEnumerable<EmployeeModel>>(employees);
        }

        public void RemoveEmployee(int employeeId)
        {
            Employee employee = _database.Employees.GetFirstOrDefault(x => x.Id == employeeId);
            foreach (var item in employee.Tasks)
            {
                if(item.TaskStatus == SharedTypes.Enums.TaskStatus.InProgress)
                {
                    item.TaskStatus = SharedTypes.Enums.TaskStatus.ToDo;
                }
            }
            _database.Employees.Remove(employee);
            _database.SaveChanges();
        }
    }
}
