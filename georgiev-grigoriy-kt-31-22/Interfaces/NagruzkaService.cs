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

        public Result AddNagruzka(NagruzkaRequest nagruzkaRequest)
        {
            var nagruzka = new Nagruzka
            {
                DisciplineId = nagruzkaRequest.DisciplineId,
                PrepodId = nagruzkaRequest.PrepodId,
                totalHours = nagruzkaRequest.totalHours
            };

            _context.Nagruzki.Add(nagruzka);
            _context.SaveChanges();

            return new Result { Success = true };
        }

        public Result UpdateNagruzka(int id, NagruzkaRequest nagruzkaRequest)
        {
            var nagruzka = _context.Nagruzki.Find(id);
            if (nagruzka == null)
                return new Result { Success = false, Message = "Nagruzka not found." };

            nagruzka.DisciplineId = nagruzkaRequest.DisciplineId;
            nagruzka.PrepodId = nagruzkaRequest.PrepodId;
            nagruzka.totalHours = nagruzkaRequest.totalHours;

            _context.SaveChanges();

            return new Result { Success = true };
        }

        public Result DeleteNagruzka(int id)
        {
            var nagruzka = _context.Nagruzki.Find(id);
            if (nagruzka == null)
                return new Result { Success = false, Message = "Nagruzka not found." };

            _context.Nagruzki.Remove(nagruzka);
            _context.SaveChanges();

            return new Result { Success = true };
        }
    }

}
