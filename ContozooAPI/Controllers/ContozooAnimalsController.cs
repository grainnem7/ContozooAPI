using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContozooAPI.Model;
using ContozooAPI.Interfaces;
using Ardalis.GuardClauses;

namespace ContozooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContozooAnimalsController : ControllerBase
    {
        //remove _context
        private readonly animalsContext _context;
        private readonly IContozooRepository _repository;
        private IContozooRepository service;

        public ContozooAnimalsController(animalsContext context, IContozooRepository repository)
        {
            _context = context;
            _repository = Guard.Against.Null(repository, nameof(repository));
        }

        public object GetAnimals()
        {
            throw new NotImplementedException();
        }

        //public ContozooAnimalsController(IContozooRepository service)
        //{
        //    this.service = service;
        //}

        // GET: api/ContozooAnimals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContozooAnimal>>> GetContozooAnimals()
        {
            var items = await _repository.GetAnimals();
            return Ok(items);
            
        }

        // GET: api/ContozooAnimals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContozooAnimal>> GetContozooAnimal(int id)
        {
            var contozooAnimal = await _repository.GetAnimal(id);

            if (contozooAnimal == null)
            {
                return NotFound();
            }

            return contozooAnimal;
        }

        // PUT: api/ContozooAnimals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContozooAnimal(int id, ContozooAnimal contozooAnimal)
        {
            var result = await _repository.UpdateAnimal(contozooAnimal);          

            if (result == false)
            {
                return BadRequest();
            }
            else
            {
                return NoContent();
            }
          
        }

        // POST: api/ContozooAnimals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContozooAnimal>> PostContozooAnimal(ContozooAnimal contozooAnimal)
        {
            _context.ContozooAnimals.Add(contozooAnimal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContozooAnimal", new { id = contozooAnimal.AnimalId }, contozooAnimal);
        }

        // DELETE: api/ContozooAnimals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContozooAnimal(int id)
        {
            var contozooAnimal = await _context.ContozooAnimals.FindAsync(id);
            if (contozooAnimal == null)
            {
                return NotFound();
            }

            _context.ContozooAnimals.Remove(contozooAnimal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContozooAnimalExists(int id)
        {
            return _context.ContozooAnimals.Any(e => e.AnimalId == id);
        }
    }
}
