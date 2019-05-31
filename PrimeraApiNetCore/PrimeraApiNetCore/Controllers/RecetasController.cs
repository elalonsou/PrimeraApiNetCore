using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using DAL.Models; 
using DAL.Services.Interfaces;
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

        [HttpGet]
        public IEnumerable<Receta> GetRecetaByUserId(){
            return _unitOfWork.Recetas.GetAllByUserId(1);
        }
    }
}