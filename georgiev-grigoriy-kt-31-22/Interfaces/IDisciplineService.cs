namespace georgiev_grigoriy_kt_31_22.Interfaces
{
    public interface IDisciplineService
    {
        Task<IEnumerable<DisciplineDto>> GetAsync(DisciplineFilterRequest filter);
    }
}