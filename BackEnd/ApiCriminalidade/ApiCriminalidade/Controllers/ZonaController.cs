using ApiCriminalidade.Dtos;
using ApiCriminalidade.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiCriminalidade.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ZonaController : ControllerBase
    {
        private readonly IZonaService _service;

        public ZonaController(IZonaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoArmaDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<ZonaDto> GetById(int id)
        {
            var dto = _service.GetById(id);

            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<ZonaDto> Post(ZonaForm form)
        {
            return Ok(_service.Post(form));
        }

        [HttpPut("{id:int}")]
        public ActionResult<ZonaDto> Update(ZonaForm form, int id)
        {
            var dto = _service.Update(id, form);

            if (dto == null)
            {
                return NotFound();
            }


            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ZonaDto> Delete(int id)
        {
            var dto = _service.Delete(id);

            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }
    }
}
