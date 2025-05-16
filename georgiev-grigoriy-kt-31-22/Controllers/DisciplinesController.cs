using georgiev_grigoriy_kt_31_22.Interfaces;
using georgiev_grigoriy_kt_31_22.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace georgiev_grigoriy_kt_31_22.Controllers
{
    public class DisciplinesController : ControllerBase
    {
        private readonly IDisciplineService _svc;
        public DisciplinesController(IDisciplineService svc) => _svc = svc;

        [HttpPost("filter")]
        public async Task<IActionResult> Filter([FromBody] DisciplineFilterRequest f)
        {
            var data = await _svc.GetAsync(f);
            return Ok(new ResponseModel<IEnumerable<DisciplineDto>>(data));
        }
    }
}
