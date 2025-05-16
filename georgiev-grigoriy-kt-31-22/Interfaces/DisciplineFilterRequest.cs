namespace georgiev_grigoriy_kt_31_22.Interfaces
{
    public class DisciplineFilterRequest
    {
        public int? PrepodId { get; init; }
        public int? MinHours { get; init; }
        public int? MaxHours { get; init; }
    }
}
