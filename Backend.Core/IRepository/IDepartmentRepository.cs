using Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.IRepository
{
    public interface IDepartmentRepository
    {
        public Task<List<Depatment>> GetDepartments();
        public Task<Depatment> GetDepartmentById(int id);
    }
}
