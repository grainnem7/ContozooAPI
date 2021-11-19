#nullable disable

namespace ContozooAPI.Model
{
    public partial class ContozooAnimal
    {
        public int AnimalId { get; set; }
        public string Animal { get; set; }
        public int? Number { get; set; }
        public string Location { get; set; }
        public string ActiveHours { get; set; }
        public string Notes { get; set; }
    }
}
