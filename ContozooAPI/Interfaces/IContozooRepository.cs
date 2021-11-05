using ContozooAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContozooAPI.Interfaces
{
     public interface IContozooRepository
    {
       public Task<IEnumerable<ContozooAnimal>> GetAnimals();

       public Task<ContozooAnimal> GetAnimal(int id);

       public Task<bool> UpdateAnimal(ContozooAnimal contozooAnimal);
       
    }
}
