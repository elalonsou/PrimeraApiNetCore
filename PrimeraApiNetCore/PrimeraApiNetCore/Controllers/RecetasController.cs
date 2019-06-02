using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using DAL.Models; 
using DAL.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PrimeraApiNetCore.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        public RecetasController(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
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
        public async Task<ActionResult<IEnumerable<Receta>>> GetRecetaByUserId(int id)
        {
            //TODO Faltaria hacer el mapeo para devolver un viewModel en vez del objeto de BBDD
            //TODO hacer asincrona la respuesta https://docs.microsoft.com/es-es/aspnet/core/web-api/action-return-types?view=aspnetcore-2.2
            //tambien hay que cambier la capa de BBDD.
            return Ok (await _unitOfWork.Recetas.GetAllByUserIdAsync(id));
        }



        [HttpGet("{Id}")]
        public Receta GetReceta(int id)
        {
            return _unitOfWork.Recetas.GetById(id);
        }
    }
}