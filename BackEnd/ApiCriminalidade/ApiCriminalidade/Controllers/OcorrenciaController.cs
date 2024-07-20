using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Application.Pagination;
using ApiCriminalidade.Application.Pagination.Filtros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Newtonsoft.Json;

namespace ApiCriminalidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "USUARIOGERAL")]
    [EnableRateLimiting("fixedWindow")]
    public class OcorrenciaController : ControllerBase
    {
        private readonly IOcorrenciaService _ocorrenciaService;

        public OcorrenciaController(IOcorrenciaService ocorrenciaService)
        {
            _ocorrenciaService = ocorrenciaService;
        }

        [HttpGet]   
        public async Task<ActionResult<IEnumerable<OcorrenciaDto>>> GetAll()
        {
            return Ok(await _ocorrenciaService.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OcorrenciaDto>> GetById(int id)
        {
            var ocorrenciaDto = await _ocorrenciaService.GetById(id);

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
        public async Task<ActionResult<OcorrenciaDto>> Update(OcorrenciaForm form, int id)
        {
            var ocorrenciaDto = await _ocorrenciaService.Update(id, form);

            if(ocorrenciaDto == null)
            {
                return NotFound();
            }


            return Ok(ocorrenciaDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<OcorrenciaDto>> Delete(int id)
        {
            var ocorrenciaDto = await _ocorrenciaService.Delete(id);

            if (ocorrenciaDto == null)
            {
                return NotFound();
            }

            return Ok(ocorrenciaDto);
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<OcorrenciaDto>>> GetWithPaginationParameters([FromQuery] GenericParameters parameters)
        {
            var dtos = await _ocorrenciaService.GetWithPaginationParameters(parameters);

            var metadata = new 
            {
                dtos.Count,
                dtos.PageSize,
                dtos.PageCount,
                dtos.TotalItemCount,
                dtos.HasNextPage,
                dtos.HasPreviousPage
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(dtos);
        }

        [HttpGet("pagination/filter/data")]
        public async Task<ActionResult<IEnumerable<OcorrenciaDto>>> GetFiltroData([FromQuery] OcorrenciaFiltroData filtros)
        {
            var dtos = await _ocorrenciaService.GetFiltroData(filtros);

            var metadata = new
            {
                dtos.Count,
                dtos.PageSize,
                dtos.PageCount,
                dtos.TotalItemCount,
                dtos.HasNextPage,
                dtos.HasPreviousPage
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(dtos);
        }

    }
}
