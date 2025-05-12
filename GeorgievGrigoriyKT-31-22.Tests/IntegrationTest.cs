using georgiev_grigoriy_kt_31_22.Database;
using georgiev_grigoriy_kt_31_22.Interfaces;
using georgiev_grigoriy_kt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace GeorgievGrigoriyKT_31_22.Tests
{
    public class NagruzkaIntegrationTests
    {
        private readonly CafedraDbContext context;
        private readonly INagruzkaService NagruzkaService;

        public NagruzkaIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<CafedraDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            context = new CafedraDbContext(options);
            NagruzkaService = new NagruzkaService(context);
        }

        [Fact]
        public async Task AddUpdateDeleteNagruzka_ShouldPerformOperationsCorrectly()
        {
            // Arrange
            var prepod1 = new Prepods { IdPrepod = 1, FirstName = "Egor", LastName = "Sirov", MidName = "Alekseevich", DegreeId = 1, PositionId = 1 };
            var prepod2 = new Prepods { IdPrepod = 2, FirstName = "Bogdan", LastName = "Yakovled", MidName = "Pavlovich", DegreeId = 2, PositionId = 2 };

            var discipline1 = new Disciplines { DisciplineId = 1, DisciplineName = "Mathematics" };
            var discipline2 = new Disciplines { DisciplineId = 2, DisciplineName = "Physics" };


            context.Prepods.AddRange(prepod1, prepod2);
            context.Disciplines.AddRange(discipline1, discipline2);
            await context.SaveChangesAsync();


            var nagruzka1 = new NagruzkaRequest { DisciplineId = 1, PrepodId = 1, totalHours = 40 };
            var nagruzka2 = new NagruzkaRequest { DisciplineId = 1, PrepodId = 2, totalHours = 50 };
            var nagruzka3 = new NagruzkaRequest { DisciplineId = 2, PrepodId = 1, totalHours = 60 };
            var nagruzka4 = new NagruzkaRequest { DisciplineId = 2, PrepodId = 2, totalHours = 30 };

            var result1 = await NagruzkaService.AddNagruzka(nagruzka1);
            var result2 = await NagruzkaService.AddNagruzka(nagruzka2);
            var result3 = await NagruzkaService.AddNagruzka(nagruzka3);
            var result4 = await NagruzkaService.AddNagruzka(nagruzka4);

            var nagruzkarecord1 = await context.Nagruzki.FindAsync(result1.Id);
            var nagruzkarecord2 = await context.Nagruzki.FindAsync(result2.Id);
            var nagruzkarecord3 = await context.Nagruzki.FindAsync(result3.Id);
            var nagruzkarecord4 = await context.Nagruzki.FindAsync(result4.Id);

            Assert.NotNull(nagruzkarecord1);
            Assert.NotNull(nagruzkarecord2);
            Assert.NotNull(nagruzkarecord3);
            Assert.NotNull(nagruzkarecord4);

            // Act
            var updateNagruzkaRequest = new NagruzkaRequest { DisciplineId = 1, PrepodId = 1, totalHours = 100 };
            var updateResult = await NagruzkaService.UpdateNagruzka(nagruzkarecord1.Id, updateNagruzkaRequest);

            // Assert
            var updatedNagruzka = await context.Nagruzki.FindAsync(nagruzkarecord1.Id);
            Assert.NotNull(updatedNagruzka);
            Assert.Equal(100, updatedNagruzka.totalHours);


            var deleteResult = await NagruzkaService.DeleteNagruzka(updatedNagruzka.Id);


            var deletedNagruzka = await context.Nagruzki.FindAsync(updatedNagruzka.Id);
            Assert.Null(deletedNagruzka);


            var totalHoursForPrepod1 = await context.Nagruzki
                .Where(n => n.PrepodId == prepod1.IdPrepod)
                .SumAsync(n => n.totalHours);


            Assert.Equal(60, totalHoursForPrepod1);
        }
    }
}
