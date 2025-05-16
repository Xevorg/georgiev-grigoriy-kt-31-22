using georgiev_grigoriy_kt_31_22.Database;
using georgiev_grigoriy_kt_31_22.Interfaces;
using georgiev_grigoriy_kt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace GeorgievGrigoriyKT_31_22.Tests
{
    public class DisciplinesIntegrationTests
    {
        private readonly CafedraDbContext _context;
        private readonly IDisciplineService _service;

        public DisciplinesIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<CafedraDbContext>()

                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new CafedraDbContext(options);
            _service = new DisciplineService(_context);
        }

        [Fact]
        public async Task Filter_ByTeacherAndRange_ReturnsPhysicsAndMath()
        {

            var degree = new Degrees { DegreeId = 1, DegreeName = "Master" };
            var position = new Positions { PositionId = 1, PositionName = "Professor" };
            _context.AddRange(degree, position);

            var teacher = new Prepods
            {
                IdPrepod = 4,
                FirstName = "Ivan",
                LastName = "Ivanov",
                MidName = "Ivanovich",
                DegreeId = 1,
                PositionId = 1
            };
            var otherTeacher = new Prepods
            {
                IdPrepod = 5,
                FirstName = "Alexey",
                LastName = "Petrov",
                MidName = "Sidorovich",
                DegreeId = 1,
                PositionId = 1
            };
            _context.Prepods.AddRange(teacher, otherTeacher);

            var physics = new Disciplines { DisciplineId = 1, DisciplineName = "Physics" };
            var math = new Disciplines { DisciplineId = 2, DisciplineName = "Mathematics" };
            var chemistry = new Disciplines { DisciplineId = 3, DisciplineName = "Chemistry" };
            _context.Disciplines.AddRange(physics, math, chemistry);


            _context.Nagruzki.AddRange(
                new Nagruzka { DisciplineId = 1, PrepodId = 4, totalHours = 10 },
                new Nagruzka { DisciplineId = 1, PrepodId = 4, totalHours = 14 },
                new Nagruzka { DisciplineId = 2, PrepodId = 4, totalHours = 28 },
                new Nagruzka { DisciplineId = 3, PrepodId = 4, totalHours = 40 },
                new Nagruzka { DisciplineId = 2, PrepodId = 5, totalHours = 25 }
            );
            await _context.SaveChangesAsync();


            var filter = new DisciplineFilterRequest
            {
                PrepodId = 4,
                MinHours = 20,
                MaxHours = 30
            };


            var result = (await _service.GetAsync(filter)).ToList();


            Assert.Equal(2, result.Count);
            Assert.Contains(result, d => d.Name == "Physics" && d.TotalHours == 24);
            Assert.Contains(result, d => d.Name == "Mathematics" && d.TotalHours == 28);
        }
    }
}