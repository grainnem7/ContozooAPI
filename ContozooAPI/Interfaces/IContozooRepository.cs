using ContozooAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContozooAPI.Interfaces
{
    public interface IContozooRepository
    {
       public Task<IEnumerable<ContozooAnimal>> GetAnimalsAsync();

       public Task<ContozooAnimal> GetAnimal(int id);

       public Task<bool> UpdateAnimal(ContozooAnimal contozooAnimal);
       
    }
}
