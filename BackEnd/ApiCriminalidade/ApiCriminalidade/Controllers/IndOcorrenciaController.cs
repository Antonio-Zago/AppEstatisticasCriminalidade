using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCriminalidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndOcorrenciaController : ControllerBase
    {
        private readonly IIndOcorrenciaService _indOcorrenciaService;

        public IndOcorrenciaController(IIndOcorrenciaService indOcorrenciaService)
        {
            _indOcorrenciaService = indOcorrenciaService;
        }

        [HttpPost]
        [Authorize(Policy = "ADMINEXCLUSIVO")]
        public ActionResult<IEnumerable<IndOcorrencia>> Add(IFormFile file)
        {
            
            return Ok(_indOcorrenciaService.Add(file));
        }

        [HttpGet]
        [Authorize(Policy = "USUARIOGERAL")]
        public ActionResult<IEnumerable<IndOcorrencia>> GetAll()
        {

            return Ok(_indOcorrenciaService.GetAll());
        }

    }
}
