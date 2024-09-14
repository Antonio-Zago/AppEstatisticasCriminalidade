using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCriminalidade.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class IndFurtoController : ControllerBase
    {

        private readonly IIndFurtoService _indFurtoService;

        public IndFurtoController(IIndFurtoService indFurtoService)
        {
            _indFurtoService = indFurtoService;
        }

        [HttpGet]
        [Authorize(Policy = "USUARIOGERAL")]
        public ActionResult<IEnumerable<IndFurtoDto>> GetAll()
        {

            return Ok(_indFurtoService.GetAll());
        }
    }
}
