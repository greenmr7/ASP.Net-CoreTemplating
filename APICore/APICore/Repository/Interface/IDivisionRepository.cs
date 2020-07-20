using APICore.Models;
using APICore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICore.Repository.Interface
{
    public interface IDivisionRepository
    {
        Task<IEnumerable<DivisionVM>> getAll();
        DivisionVM getID(int Id);
        int Create(DivisionVM divisionVM, int id);
        int Update(DivisionVM divisionVM, int id);
        int Delete(int id);
    }
}
