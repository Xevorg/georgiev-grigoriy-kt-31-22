using georgiev_grigoriy_kt_31_22.Database;
using georgiev_grigoriy_kt_31_22.Models;

namespace georgiev_grigoriy_kt_31_22.Interfaces
{
    public class NagruzkaService : INagruzkaService
    {
        private readonly CafedraDbContext _context;

        public NagruzkaService(CafedraDbContext context)
        {
            _context = context;
        }

        public async Task<Result> AddNagruzka(NagruzkaRequest nagruzkaRequest)
        {
            var nagruzka = new Nagruzka
            {
                DisciplineId = nagruzkaRequest.DisciplineId,
                PrepodId = nagruzkaRequest.PrepodId,
                totalHours = nagruzkaRequest.totalHours
            };

            _context.Nagruzki.Add(nagruzka);
            await _context.SaveChangesAsync();

            return new Result { Success = true, Message = "Nagruzka was added", Id = nagruzka.Id };
        }

        public async Task<Result> UpdateNagruzka(int id, NagruzkaRequest nagruzkaRequest)
        {
            var nagruzka = await _context.Nagruzki.FindAsync(id);
            if (nagruzka == null)
                return new Result { Success = false, Message = "Nagruzka not found" };

            nagruzka.DisciplineId = nagruzkaRequest.DisciplineId;
            nagruzka.PrepodId = nagruzkaRequest.PrepodId;
            nagruzka.totalHours = nagruzkaRequest.totalHours;

            await _context.SaveChangesAsync();

            return new Result { Success = true };
        }

        public async Task<Result> DeleteNagruzka(int id)
        {
            var nagruzka = await _context.Nagruzki.FindAsync(id);
            if (nagruzka == null)
                return new Result { Success = false, Message = "Nagruzka not found" };

            _context.Nagruzki.Remove(nagruzka);
            await _context.SaveChangesAsync();

            return new Result { Success = true };
        }
    }





}
