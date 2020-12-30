using Microsoft.AspNetCore.Mvc;

namespace MyAPICore.Controllers
{
    // Criação de uma Controller base para criar responses customizados
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = ObterErros()
            });
        }

        protected bool OperacaoValida()
        {
            return true;
        }

        protected string ObterErros()
        {
            return string.Empty;
        }
    }
}
