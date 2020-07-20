using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Models;
using APICore.Repository;
using APICore.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IDepartmentRepository _departmentRepository;
        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _departmentRepository.getAll();
        }

        [HttpPost]
        public IActionResult CreateDepartment(Department department)
        {
            var create = _departmentRepository.Create(department);
            if (create > 0)
            {
                return Ok(create);
            }
            return BadRequest("Not Successfully");
        }

        [HttpGet ("{id}")]
        public Department GetIdDepartments(int id)
        {
            return _departmentRepository.getID(id);
        }

        [HttpPut ("{id}")]
        public IActionResult EditDepartment (int id, Department department)
        {
            var edit = _departmentRepository.Update(department, id);
            if (edit > 0)
            {
                return Ok(edit);
            }
            return BadRequest("Not Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var delete = _departmentRepository.Delete(id);
            if (delete > 0)
            {
                return Ok(delete);
            }
            return BadRequest("Not Successfully");
        }
    }
}
