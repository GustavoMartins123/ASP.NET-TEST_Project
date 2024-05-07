using System.ComponentModel.DataAnnotations.Schema;

namespace NewTestDB.Models
{
    [Table("PersonModel")]
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public int? CarId { get; set; }
        public virtual List<CarModel>? Cars { get; set; }
        public int JobId { get; set; }
        public virtual JobPersonModel Job { get; set; }
    }
}
