using Microsoft.AspNetCore.Mvc;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // In-memory list of students (temporary — will be replaced with a database later)
        private static readonly List<Student> _students = new List<Student>
        {
            new Student
            {
                Id = 1,
                FirstName = "Carl Jacob",
                LastName = "Fulgar",
                Email = "jacob.fulgar@example.com",
                Course = "BSIT",
                Year = 2
            },
            new Student
            {
                Id = 2,
                FirstName = "SpongeBob",
                LastName = "SquarePants",
                Email = "spongebob.squarepants@example.com",
                Course = "BSMB",
                Year = 3
            },
            new Student
            {
                Id = 3,
                FirstName = "Patrick",
                LastName = "Star",
                Email = "patrick.star@example.com",
                Course = "BSMB",
                Year = 4
            }
        };

        // GET: api/Students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return Ok(_students);
        }

        // GET: api/Students/1
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound(new { message = $"Student with ID {id} not found." });
            }

            return Ok(student);
        }
    }
}