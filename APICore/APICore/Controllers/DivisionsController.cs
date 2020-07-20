using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Models;
using APICore.Repository.Interface;
using APICore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : ControllerBase
    {
        private IDivisionRepository _divisionRepository;
        public DivisionsController(IDivisionRepository divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<DivisionVM>> GetDivision()
        {
            return await _divisionRepository.getAll();
        }

        //[HttpGet("{id}")]
        //public async Task<IEnumerable<DivisionVM>> GetIdDivision(int id)
        //{
        //    return await _divisionRepository.getID(id);
        //}
        [HttpGet("{id}")]
        public DivisionVM GetIdDivision(int id)
        {
            return _divisionRepository.getID(id);
        }

        [HttpPost]
        public IActionResult CreateDivision(DivisionVM divisionVM, int id)
        {
            var create = _divisionRepository.Create(divisionVM, id);
            if (create > 0)
            {
                return Ok(create);
            }
            return BadRequest("Not Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult EditDivision(int id, DivisionVM divisionVM)
        {
            var edit = _divisionRepository.Update(divisionVM, id);
            if (edit > 0)
            {
                return Ok(edit);
            }
            return BadRequest("Not Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDivision(int id)
        {
            var delete = _divisionRepository.Delete(id);
            if (delete > 0)
            {
                return Ok(delete);
            }
            return BadRequest("Not Successfully");
        }
    }
}
