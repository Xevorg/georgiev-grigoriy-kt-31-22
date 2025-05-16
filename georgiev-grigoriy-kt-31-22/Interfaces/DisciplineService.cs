using georgiev_grigoriy_kt_31_22.Database;
using georgiev_grigoriy_kt_31_22.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace georgiev_grigoriy_kt_31_22.Interfaces
{
    public class DisciplineService : IDisciplineService
    {
        private readonly CafedraDbContext _db;
        public DisciplineService(CafedraDbContext db) => _db = db;

        public async Task<IEnumerable<DisciplineDto>> GetAsync(DisciplineFilterRequest f)
        {
            if (f.MinHours is { } min && f.MaxHours is { } max && min > max)
                throw new ApiException("MinHours больше MaxHours", HttpStatusCode.BadRequest);

            if (f.PrepodId.HasValue &&
                !await _db.Prepods.AnyAsync(p => p.IdPrepod == f.PrepodId))
                throw new ApiException("Преподаватель не найден", HttpStatusCode.NotFound);

            var baseQuery = _db.Nagruzki
                               .Include(n => n.Disciplines)
                               .AsQueryable();

            if (f.PrepodId is { } pid)
                baseQuery = baseQuery.Where(n => n.PrepodId == pid);

            var grouped = await baseQuery
                .GroupBy(n => new { n.DisciplineId, n.Disciplines.DisciplineName })
                .Select(g => new
                {
                    g.Key.DisciplineId,
                    g.Key.DisciplineName,
                    Total = g.Sum(x => x.totalHours)
                })
                .ToListAsync();

            if (f.MinHours.HasValue)
                grouped = grouped.Where(x => x.Total >= f.MinHours).ToList();
            if (f.MaxHours.HasValue)
                grouped = grouped.Where(x => x.Total <= f.MaxHours).ToList();

            if (grouped.Count == 0)
                throw new ApiException("Дисциплины по заданному фильтру не найдены",
                                       HttpStatusCode.NotFound);

            return grouped.Select(x => new DisciplineDto(x.DisciplineId,
                                                         x.DisciplineName,
                                                         x.Total));
        }
    }
}