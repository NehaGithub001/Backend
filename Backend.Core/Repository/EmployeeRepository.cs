using Backend.Core.IRepository;
using Backend.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        SqlPracticeContext _context;
        public EmployeeRepository(SqlPracticeContext context) 
        {
           _context = context;
        }

        public async Task<List<Employee>> GetEmployees(int page, int size)
        {

            var employees = await _context.Employees
                .OrderByDescending(q => q.EmpName)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return employees;

        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(q => q.Id == id);
            return employee;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> EditEmployee(int id, Employee dto)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(q => q.Id == id);
            if (employee != null)
            {
                employee.Email = dto.Email;
                employee.City = dto.City;
                employee.Status = dto.Status;
                employee.EmpName = dto.EmpName;
                employee.Age = dto.Age;
                employee.Mobile = dto.Mobile;
                employee.DeptId = dto.DeptId;
                _context.Employees.Update(employee);
            }
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(q => q.Id == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }
    }
}
