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
    public class DepartmentRepository : IDepartmentRepository
    {
        SqlPracticeContext _context;
        public DepartmentRepository(SqlPracticeContext context)
        {
            _context = context;
        }
        public async Task<Depatment> GetDepartmentById(int id)
        {
            var depatment = await _context.Depatments.FirstOrDefaultAsync(q => q.DeptId == id);
            return depatment;

        }

        public async Task<List<Depatment>> GetDepartments()
        {
            var depatments = await _context.Depatments
               .OrderByDescending(q => q.DeptName)
               .ToListAsync();
            return depatments;
        }
    }
}
