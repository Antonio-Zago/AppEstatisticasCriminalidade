using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCriminalidade.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize(Policy = "USUARIOGERAL")]
    public class RouboController : ControllerBase
    {
        private readonly IRouboService _service;

        public RouboController(IRouboService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RouboDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<RouboDto> GetById(int id)
        {
            var dto = _service.GetById(id);

            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<RouboDto> Post(RouboForm form)
        {
            return Ok(_service.Post(form));
        }

        [HttpPut("{id:int}")]
        public ActionResult<RouboDto> Update(RouboForm form, int id)
        {
            var dto = _service.Update(id, form);

            if (dto == null)
            {
                return NotFound();
            }


            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<RouboDto> Delete(int id)
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
