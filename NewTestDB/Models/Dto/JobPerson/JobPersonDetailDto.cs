using NewTestDB.Models.Enums;

namespace NewTestDB.Models.Dto.JobPerson
{
    public class JobPersonDetailDto
    {
        public int Id { get; set; }
        public string Company {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
        public string Status { get; set; }

    }
}
