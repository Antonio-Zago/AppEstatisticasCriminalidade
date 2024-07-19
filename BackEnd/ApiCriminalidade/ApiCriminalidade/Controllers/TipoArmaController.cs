using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCriminalidade.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize(Policy = "USUARIOGERAL")]
    public class TipoArmaController : ControllerBase
    {
        private readonly ITipoArmaService _service;

        public TipoArmaController(ITipoArmaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoArmaDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<TipoArmaDto> GetById(int id)
        {
            var dto = _service.GetById(id);

            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<TipoArmaDto> Post(TipoArmaForm form)
        {
            return Ok(_service.Post(form));
        }

        [HttpPut("{id:int}")]
        public ActionResult<TipoArmaDto> Update(TipoArmaForm form, int id)
        {
            var dto = _service.Update(id, form);

            if (dto == null)
            {
                return NotFound();
            }


            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<TipoArmaDto> Delete(int id)
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
