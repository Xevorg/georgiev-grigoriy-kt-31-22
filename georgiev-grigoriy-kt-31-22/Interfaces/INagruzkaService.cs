namespace georgiev_grigoriy_kt_31_22.Interfaces
{
    public interface INagruzkaService
    {
        Result AddNagruzka(NagruzkaRequest nagruzkaRequest);
        Result UpdateNagruzka(int id, NagruzkaRequest nagruzkaRequest);
        Result DeleteNagruzka(int id);
    }
}
