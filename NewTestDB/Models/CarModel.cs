using System.ComponentModel.DataAnnotations.Schema;

namespace NewTestDB.Models
{
    [Table("CarModel")]
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LicensePlate { get; set; }
        public int? PersonId { get; set; }
    }
}
