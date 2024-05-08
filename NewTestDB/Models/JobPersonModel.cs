using NewTestDB.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewTestDB.Models
{
    [Table("JobPersonModel")]
    public class JobPersonModel
    {
        public int Id { get; set; }
        public string? Company {  get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Salary { get; set; }
        public Status Status { get; set; }
        public int PersonId { get; set; }

    }
}
