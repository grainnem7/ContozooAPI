using Ardalis.GuardClauses;
using ContozooAPI.Interfaces;
using ContozooAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContozooAPI.Repositories
{
    public class ContozooRepository : IContozooRepository
    {
        private readonly animalsContext _dbContext;

        public ContozooRepository()
        {
        }

        public ContozooRepository(animalsContext dbContext) 
        {
            _dbContext = Guard.Against.Null(dbContext, nameof(dbContext));        
        }

        public async Task<ContozooAnimal> GetAnimal(int id)
        {
            return  await _dbContext.ContozooAnimals.FindAsync(id);
        }

        public async Task<IEnumerable<ContozooAnimal>> GetAnimals()
        {
            return await _dbContext.ContozooAnimals.ToListAsync();
        }

        public async Task<bool> UpdateAnimal(ContozooAnimal contozooAnimal)
        {
            var existingAnimal = await _dbContext.ContozooAnimals.FindAsync(contozooAnimal.AnimalId);
            if (existingAnimal == null)
            {
                return false;
            }

            try
            {
                existingAnimal.Animal = contozooAnimal.Animal;
                existingAnimal.Number = contozooAnimal.Number;
                existingAnimal.Location = contozooAnimal.Location;
                existingAnimal.ActiveHours = contozooAnimal.ActiveHours;
                existingAnimal.Notes = contozooAnimal.Notes;
                await _dbContext.SaveChangesAsync();
            }

            catch (Exception)
            {

                return false;
            }

            return true;
        }
       
    }
}
