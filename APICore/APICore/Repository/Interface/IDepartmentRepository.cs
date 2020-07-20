using APICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICore.Repository.Interface
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> getAll();
        Department getID(int Id);
        int Create(Department department);
        int Update(Department department, int id);
        int Delete(int id);
    }
}
