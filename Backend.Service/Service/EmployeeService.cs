using Backend.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.IRepository;
using Backend.Data.Models;

namespace Backend.Service.Service
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetEmployees(int page,int size)
        {
           return  await _employeeRepository.GetEmployees(page,size);
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetEmployeeById(id);
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
           return  await _employeeRepository.CreateEmployee(employee);
        }

        public async Task<Employee> EditEmployee(int id,Employee employee)
        {
            return await _employeeRepository.EditEmployee(id,employee);
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
             return await  _employeeRepository.DeleteEmployee(id);
        }
    }
}
