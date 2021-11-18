using ContozooAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContozooAPI.Data
{
    public class MockData
    {
        public static Task<IEnumerable<ContozooAnimal>>GetTestAnimals()
        {
            var animals = new List<ContozooAnimal>()
            {
               new ContozooAnimal()
                {
                    AnimalId = 1,
                    Animal ="Shark",
                    Number=5,
                    Location= "Ocean park",
                    ActiveHours= "8am - 1pm",
                    Notes="Du du du du"
                },
                  new ContozooAnimal()
                {
                    AnimalId = 2,
                    Animal ="Flamingo",
                    Number=20,
                    Location= "Pink Palace",
                    ActiveHours= "12am - 1pm",
                    Notes="Pretty in pink"
                }
            };

            IEnumerable<ContozooAnimal> result = animals;
            return Task.FromResult(result);

        }
    }
}
