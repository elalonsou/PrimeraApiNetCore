using Microsoft.AspNetCore.Mvc;

namespace PrimeraApiNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class holaController
    {
        private readonly DAL.IHola _hola;

        public holaController(DAL.IHola hola){
            _hola = hola;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return _hola.llamarHola();
        }
    }
}