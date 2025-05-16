using georgiev_grigoriy_kt_31_22.Interfaces;
using Moq;

namespace GeorgievGrigoriyKT_31_22.Tests
{
    public class GetDisciplinesTest
    {
        private readonly Mock<IDisciplineService> _disciplineMock;

        public GetDisciplinesTest()
        {
            _disciplineMock = new Mock<IDisciplineService>();
        }

        [Fact]
        public async Task GetDisciplines_ReturnsExpectedCollection()
        {
            //Arrange 
            var filter = new DisciplineFilterRequest
            {
                PrepodId = 4,
                MinHours = 20,
                MaxHours = 30
            };

            var expected = new List<DisciplineDto>
            {
                new DisciplineDto(1, "Physics",     24),
                new DisciplineDto(2, "Mathematics", 28)
            };

            _disciplineMock
                .Setup(s => s.GetAsync(It.IsAny<DisciplineFilterRequest>()))
                .ReturnsAsync(expected);

            //Act
            var result = (await _disciplineMock.Object.GetAsync(filter)).ToList();

            //Assert
            Assert.Equal(expected.Count, result.Count);
            Assert.Equal(expected[0].Name, result[0].Name);
            Assert.Equal(expected[0].TotalHours, result[0].TotalHours);
        }
    }
}