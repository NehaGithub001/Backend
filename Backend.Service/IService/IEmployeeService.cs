using Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.IService
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployees(int page,int size);
        public Task<Employee> GetEmployeeById(int id);
        public Task<Employee> CreateEmployee(Employee employee);
        public Task<Employee> EditEmployee(int id,Employee employee);
        public Task<Employee> DeleteEmployee(int id);
    }
}
