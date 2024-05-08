using NewTestDB.Models.Dto.Car;
using NewTestDB.Models.Dto.JobPerson;

namespace NewTestDB.Models.Dto.Person
{
    public class PersonDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public List<CarDetailDto> Cars { get; set; }
        public JobPersonDetailDto Job { get; set; }
    }
}
