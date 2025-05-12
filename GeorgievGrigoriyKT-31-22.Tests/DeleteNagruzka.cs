using georgiev_grigoriy_kt_31_22.Interfaces;
using georgiev_grigoriy_kt_31_22.Models;
using Moq;

namespace GeorgievGrigoriyKT_31_22.Tests
{
    public class DeleteNagruzkaTest
    {
        private readonly Mock<INagruzkaService> NagruzkaMock;

        public DeleteNagruzkaTest()
        {
            NagruzkaMock = new Mock<INagruzkaService>();
        }

        [Fact]
        public async Task DeleteNagruzka()
        {
            // Arrange
            var existingNagruzka = new Nagruzka
            {
                DisciplineId = 4,
                PrepodId = 3,
                totalHours = 20
            };

            var expectedResult = new Result { Message = "Nagruzka was deleted" };

            NagruzkaMock.Setup(service => service.DeleteNagruzka(It.IsAny<int>()))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await NagruzkaMock.Object.DeleteNagruzka(existingNagruzka.Id);

            // Assert
            Assert.Equal("Nagruzka was deleted", result.Message);
        }
    }
}
