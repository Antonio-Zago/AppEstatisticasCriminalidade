using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCriminalidade.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    [Authorize(Policy = "USUARIOGERAL")]
    public class TipoBemController : ControllerBase
    {
        private readonly ITipoBemService _service;

        public TipoBemController(ITipoBemService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoBemDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<TipoBemDto> GetById(int id)
        {
            var dto = _service.GetById(id);

            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<TipoBemDto> Post(TipoBemForm form)
        {
            return Ok(_service.Post(form));
        }

        [HttpPut("{id:int}")]
        public ActionResult<TipoBemDto> Update(TipoBemForm form, int id)
        {
            var dto = _service.Update(id, form);

            if (dto == null)
            {
                return NotFound();
            }


            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<TipoBemDto> Delete(int id)
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
