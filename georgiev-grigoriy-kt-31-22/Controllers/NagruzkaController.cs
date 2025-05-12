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

        // POST
        [HttpPost("add")]
        public async Task<IActionResult> AddNagruzka([FromBody] NagruzkaRequest nagruzkaRequest)
        {
            var result = await _nagruzkaService.AddNagruzka(nagruzkaRequest);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        // PUT
        [HttpPut("update")]
        public async Task<IActionResult> UpdateNagruzka(int id, [FromBody] NagruzkaRequest nagruzkaRequest)
        {
            var result = await _nagruzkaService.UpdateNagruzka(id, nagruzkaRequest);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        // DELETE
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteNagruzka(int id)
        {
            var result = await _nagruzkaService.DeleteNagruzka(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
