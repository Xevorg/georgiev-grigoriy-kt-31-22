using georgiev_grigoriy_kt_31_22.Interfaces;
using georgiev_grigoriy_kt_31_22.Models;
using Moq;

namespace GeorgievGrigoriyKT_31_22.Tests
{
    public class UpdateNagruzkaTest
    {
        private readonly Mock<INagruzkaService> NagruzkaMock;

        public UpdateNagruzkaTest()
        {
            NagruzkaMock = new Mock<INagruzkaService>();
        }

        [Fact]
        public async Task UpdateNagruzka()
        {
            // Arrange
            var existingNagruzka = new Nagruzka
            {
                DisciplineId = 3,
                PrepodId = 4,
                totalHours = 50
            };

            var nagruzkaRequest = new NagruzkaRequest
            {
                DisciplineId = 1,
                PrepodId = 2,
                totalHours = 60
            };

            var expectedResult = new Result { Message = "Nagruzka was updated" };

            NagruzkaMock.Setup(service => service.UpdateNagruzka
            (It.IsAny<int>(), It.IsAny<NagruzkaRequest>())).ReturnsAsync(expectedResult);

            // Act
            var result = await NagruzkaMock.Object.UpdateNagruzka(existingNagruzka.Id, nagruzkaRequest);

            // Assert
            Assert.Equal("Nagruzka was updated", result.Message);
        }
    }
}
