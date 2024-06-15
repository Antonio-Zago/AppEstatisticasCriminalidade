using ApiCriminalidade.Models;
using ApiCriminalidade.Services.Interfaces;
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
        public ActionResult<IEnumerable<IndOcorrencia>> Add(IFormFile file)
        {
            
            return Ok(_indOcorrenciaService.Add(file));
        }

        [HttpGet]
        public ActionResult<IEnumerable<IndOcorrencia>> GetAll()
        {

            return Ok(_indOcorrenciaService.GetAll());
        }

    }
}
