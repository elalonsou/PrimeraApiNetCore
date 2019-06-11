using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using DAL.Models; 
using DAL.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PrimeraApiNetCore.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ILogger _logger;

        public RecetasController(IUnitOfWork unitOfWork, ILogger<RecetasController> logger){
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        //////////Produces Response type es para ayudar a herramientas como Swagger.
        ////////[HttpGet("user/{Id}")]
        ////////[ProducesResponseType(typeof(IEnumerable<Receta>), StatusCodes.Status200OK)]
        ////////[ProducesResponseType(StatusCodes.Status404NotFound)]
        ////////public ActionResult<IEnumerable<Receta>> GetRecetaByUserId(int id){
        ////////    //TODO Faltaria hacer el mapeo para devolver un viewModel en vez del objeto de BBDD
        ////////    //TODO hacer asincrona la respuesta https://docs.microsoft.com/es-es/aspnet/core/web-api/action-return-types?view=aspnetcore-2.2
        ////////    //tambien hay que cambier la capa de BBDD.
        ////////    return Ok(_unitOfWork.Recetas.GetAllByUserId(id));
        ////////}


        //Produces Response type es para ayudar a herramientas como Swagger.
        [HttpGet("usuario/{Id}")]
        [ProducesResponseType(typeof(IEnumerable<Receta>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Receta>>> GetRecipeByUserId(int id)
        {
            //TODO Faltaria hacer el mapeo para devolver un viewModel en vez del objeto de BBDD
            //tambien hay que cambier la capa de BBDD.
            return Ok (await _unitOfWork.Recetas.GetAllByUserIdAsync(id));
        }


        [HttpGet("{Id}", Name = "GetRecipe")]
        [ProducesResponseType(typeof(Receta), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Receta>> GetRecipe(int id)
        {
            return Ok (await _unitOfWork.Recetas.GetByIdAsync(id));
        }

        [HttpPost]
        public ActionResult<Receta> InsertRecipe([FromBody] Receta receta)
        {

            return new CreatedAtRouteResult("GetRecipe", new { id = modelo.id }, modelo)
        }

    }
}