using georgiev_grigoriy_kt_31_22.Interfaces;
using Moq;

namespace GeorgievGrigoriyKT_31_22.Tests
{
    public class AddNagruzkaTest
    {
        private readonly Mock<INagruzkaService> NagruzkaMock;

        public AddNagruzkaTest()
        {
            NagruzkaMock = new Mock<INagruzkaService>();
        }

        [Fact]
        public async Task AddNagruzka()
        {
            // Arrange
            var nagruzkaRequest = new NagruzkaRequest
            {
                DisciplineId = 2,
                PrepodId = 4,
                totalHours = 100
            };

            var expectedResult = new Result { Message = "Nagruzka was added" };

            NagruzkaMock.Setup(service => service.AddNagruzka
            (It.IsAny<NagruzkaRequest>())).ReturnsAsync(expectedResult);

            // Act
            var result = await NagruzkaMock.Object.AddNagruzka(nagruzkaRequest);

            // Assert
            Assert.Equal("Nagruzka was added", result.Message);
        }
    }


}

