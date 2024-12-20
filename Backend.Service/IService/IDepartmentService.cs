using Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.IService
{
    public interface IDepartmentService
    {
        public Task<List<Depatment>> GetDepartments();
        public Task<Depatment> GetDepartmentById(int id);
    }
}
