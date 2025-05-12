using georgiev_grigoriy_kt_31_22.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace georgiev_grigoriy_kt_31_22.Controllers
{
    public class NagruzkaController : ControllerBase
    {
        private readonly INagruzkaService _nagruzkaService;

        public NagruzkaController(INagruzkaService nagruzkaService)
        {
            _nagruzkaService = nagruzkaService;
        }

        // POST api/nagruzka/add
        [HttpPost("add")]
        public IActionResult AddNagruzka([FromBody] NagruzkaRequest nagruzkaRequest)
        {
            var result = _nagruzkaService.AddNagruzka(nagruzkaRequest);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        // PUT api/nagruzka/update/5
        [HttpPut("update")]
        public IActionResult UpdateNagruzka(int id, [FromBody] NagruzkaRequest nagruzkaRequest)
        {
            var result = _nagruzkaService.UpdateNagruzka(id, nagruzkaRequest);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        // DELETE api/nagruzka/delete/5
        [HttpDelete("delete")]
        public IActionResult DeleteNagruzka(int id)
        {
            var result = _nagruzkaService.DeleteNagruzka(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
