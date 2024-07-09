using ApiCriminalidade.Dtos;
using ApiCriminalidade.Services.Interfaces;
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
        public ActionResult<IEnumerable<AssaltoDto>> GetAll()
        {
            return Ok(_assaltoService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<AssaltoDto> GetById(int id)
        {
            var assaltoDto = _assaltoService.GetById(id);

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
        public ActionResult<AssaltoDto> Update(AssaltoForm form, int id)
        {
            var assaltoDto = _assaltoService.Update(id, form);

            if (assaltoDto == null)
            {
                return NotFound();
            }


            return Ok(assaltoDto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<AssaltoDto> Delete(int id)
        {
            var assaltoDto = _assaltoService.Delete(id);

            if (assaltoDto == null)
            {
                return NotFound();
            }

            return Ok(assaltoDto);
        }
    }
}
