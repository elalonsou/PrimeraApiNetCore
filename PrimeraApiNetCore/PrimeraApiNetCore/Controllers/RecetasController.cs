using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using DAL.Models; 
using DAL.Services.Interfaces;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using PrimeraApiNetCore.ViewModels.RecipeModels;

using AutoMapper;


namespace PrimeraApiNetCore.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IMapper _mapper;
            
        public RecetasController(IUnitOfWork unitOfWork, ILogger<RecetasController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

         //Produces Response type es para ayudar a herramientas como Swagger.
        [HttpGet("usuario/{Id}")]
        [ProducesResponseType(typeof(IEnumerable<Receta>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<RecetaGet>>> GetRecipeByUserId(int id)
        {
            //Primero obtenemos el listado de recetas
            IEnumerable<Receta> recetas;
            recetas = await _unitOfWork.Recetas.GetAllByUserIdAsync(id);

            //Ahora realizamos el mapeo
            return Ok (_mapper.Map<IEnumerable<RecetaGet>>(recetas));
        }


        [HttpGet("{Id}", Name = "GetRecipe")]
        [ProducesResponseType(typeof(Receta), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RecetaGet>> GetRecipe(int id)
        {
            Receta recetaDAL;
            recetaDAL = await _unitOfWork.Recetas.GetByIdAsync(id);

           return Ok (_mapper.Map<RecetaGet>(recetaDAL) );
        }


        [HttpPost]
        public ActionResult<RecetaGet> InsertRecipe([FromBody] RecetaInsert receta)
        {
            Receta recetaDAL;
            recetaDAL = _mapper.Map<Receta>(receta);

            _unitOfWork.Recetas.Insert(recetaDAL);
            _unitOfWork.SaveChangesAsync();
            RecetaGet recetaGet;
            recetaGet = _mapper.Map<RecetaGet>(recetaDAL);

            return new CreatedAtRouteResult("GetRecipe", new { id = recetaGet.Id }, recetaGet);
        }

    }
}