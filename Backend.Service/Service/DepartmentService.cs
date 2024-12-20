using Azure;
using Backend.Core.IRepository;
using Backend.Core.Repository;
using Backend.Data.Models;
using Backend.Service.IService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<Depatment> GetDepartmentById(int id)
        {
            return await _departmentRepository.GetDepartmentById(id);
        }

        public async Task<List<Depatment>> GetDepartments()
        {
            return await _departmentRepository.GetDepartments();
        }
    }
}
