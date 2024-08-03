using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiCriminalidade.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService _service;

        public CidadeController(ICidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CidadeDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<CidadeDto> GetById(int id)
        {
            var dto = _service.GetById(id);

            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<CidadeDto> Post(CidadeForm form)
        {
            return Ok(_service.Post(form));
        }

        [HttpPut("{id:int}")]
        public ActionResult<CidadeDto> Update(CidadeForm form, int id)
        {
            var dto = _service.Update(id, form);

            if (dto == null)
            {
                return NotFound();
            }


            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<CidadeDto> Delete(int id)
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
