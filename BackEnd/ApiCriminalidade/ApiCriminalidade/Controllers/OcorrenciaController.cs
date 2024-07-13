using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;
using ApiCriminalidade.Pagination;
using ApiCriminalidade.Pagination.Filtros;
using ApiCriminalidade.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiCriminalidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "USUARIOGERAL")]
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

        [HttpGet("pagination")]
        public ActionResult<IEnumerable<OcorrenciaDto>> GetWithPaginationParameters([FromQuery] GenericParameters parameters)
        {
            var dtos = _ocorrenciaService.GetWithPaginationParameters(parameters);

            var metadata = new 
            {
                dtos.TotalCount,
                dtos.PageSize,
                dtos.CurrentPage,
                dtos.TotalPages,
                dtos.HasNext,
                dtos.HasPrevious
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(dtos);
        }

        [HttpGet("pagination/filter/data")]
        public ActionResult<IEnumerable<OcorrenciaDto>> GetFiltroData([FromQuery] OcorrenciaFiltroData filtros)
        {
            var dtos = _ocorrenciaService.GetFiltroData(filtros);

            var metadata = new
            {
                dtos.TotalCount,
                dtos.PageSize,
                dtos.CurrentPage,
                dtos.TotalPages,
                dtos.HasNext,
                dtos.HasPrevious
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(dtos);
        }

    }
}
