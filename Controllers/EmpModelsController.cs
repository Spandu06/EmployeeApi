using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee.Data;
using Employee.Model;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpModelsController : ControllerBase
    {
        private readonly EmpDbContext _context;

        public EmpModelsController(EmpDbContext context)
        {
            _context = context;
        }

        // GET: api/EmpModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpModel>>> GetempModels()
        {
          if (_context.empModels == null)
          {
              return NotFound();
          }
            return await _context.empModels.ToListAsync();
        }

        // GET: api/EmpModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpModel>> GetEmpModel(int id)
        {
          if (_context.empModels == null)
          {
              return NotFound();
          }
            var empModel = await _context.empModels.FindAsync(id);

            if (empModel == null)
            {
                return NotFound();
            }

            return empModel;
        }

        // PUT: api/EmpModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> EmpUdModel(int id, EmpModel empModel)
        {
            var emp = await _context.empModels.FindAsync(id);

            if (emp != null)
            {
                emp.Name = empModel.Name;
                emp.Description = empModel.Description;
                emp.Phone = empModel.Phone;
                emp.Email = empModel.Email;

                // Save changes to the database
                await _context.SaveChangesAsync();

                return Ok(emp);
            }

            return NotFound();
        }


        // POST: api/EmpModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpModel>> EmpAdModel(EmpModel empModel)
        {
          if (_context.empModels == null)
          {
              return Problem("Entity set 'EmpDbContext.empModels'  is null.");
          }



            var employee = new EmpModel() 
            {
                Id = empModel.Id,
                Name = empModel.Name,
                Description = empModel.Description,
                Phone = empModel.Phone,
                Email = empModel.Email,

            };

            _context.empModels.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
            
        }

        // DELETE: api/EmpModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpModel(int id)
        {
            if (_context.empModels == null)
            {
                return NotFound();
            }


            var empModel = await _context.empModels.FindAsync(id);
            if (empModel == null)
            {
                return NotFound();
            }

            _context.empModels.Remove(empModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpModelExists(int id)
        {
            return (_context.empModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
