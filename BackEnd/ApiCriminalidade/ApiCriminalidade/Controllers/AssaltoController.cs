
using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCriminalidade.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "USUARIOGERAL")]
    public class AssaltoController : ControllerBase
    {
        private readonly IAssaltoService _assaltoService;

        public AssaltoController(IAssaltoService assaltoService)
        {
            _assaltoService = assaltoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssaltoDto>>> GetAll()
        {
            return Ok(await _assaltoService.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AssaltoDto>> GetById(int id)
        {
            var assaltoDto = await _assaltoService.GetById(id);

            if (assaltoDto == null)
            {
                return NotFound();
            }

            return Ok(assaltoDto);
        }

        [HttpPost]
        public ActionResult<AssaltoDto> Post(AssaltoForm form)
        {
            return Ok(_assaltoService.Post(form));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AssaltoDto>> Update(AssaltoForm form, int id)
        {
            var assaltoDto = await _assaltoService.Update(id, form);

            if (assaltoDto == null)
            {
                return NotFound();
            }


            return Ok(assaltoDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AssaltoDto>> Delete(int id)
        {
            var assaltoDto = await _assaltoService.Delete(id);

            if (assaltoDto == null)
            {
                return NotFound();
            }

            return Ok(assaltoDto);
        }
    }
}
