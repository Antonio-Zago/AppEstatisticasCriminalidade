using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;
using ApiCriminalidade.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiCriminalidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OcorrenciaController : ControllerBase
    {
        private readonly IOcorrenciaService _ocorrenciaService;

        public OcorrenciaController(IOcorrenciaService ocorrenciaService)
        {
            _ocorrenciaService = ocorrenciaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OcorrenciaDto>> GetAll()
        {
            return Ok(_ocorrenciaService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<OcorrenciaDto> GetById(int id)
        {
            var ocorrenciaDto = _ocorrenciaService.GetById(id);

            if (ocorrenciaDto == null)
            {
                return NotFound();
            }

            return Ok(ocorrenciaDto);
        }

        [HttpPost]
        public ActionResult<OcorrenciaDto> Post(OcorrenciaForm form)
        {
            return Ok(_ocorrenciaService.Post(form));
        }

        [HttpPut("{id:int}")]
        public ActionResult<OcorrenciaDto> Update(OcorrenciaForm form, int id)
        {
            var ocorrenciaDto = _ocorrenciaService.Update(id, form);

            if(ocorrenciaDto == null)
            {
                return NotFound();
            }


            return Ok(ocorrenciaDto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<OcorrenciaDto> Delete(int id)
        {
            var ocorrenciaDto = _ocorrenciaService.Delete(id);

            if (ocorrenciaDto == null)
            {
                return NotFound();
            }

            return Ok(ocorrenciaDto);
        }
        
    }
}
