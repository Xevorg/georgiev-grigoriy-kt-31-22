namespace georgiev_grigoriy_kt_31_22.Interfaces
{
    public interface INagruzkaService
    {
        Task<Result> AddNagruzka(NagruzkaRequest nagruzkaRequest);
        Task<Result> UpdateNagruzka(int id, NagruzkaRequest nagruzkaRequest);
        Task<Result> DeleteNagruzka(int id);
    }
}
