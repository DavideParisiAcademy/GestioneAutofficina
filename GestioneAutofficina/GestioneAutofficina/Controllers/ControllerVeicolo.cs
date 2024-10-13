using GestioneAutofficina.Models;
using GestioneAutofficina.Service;
using Microsoft.AspNetCore.Mvc;

namespace GestioneAutofficina.Controllers
{
    [ApiController]
    [Route("api/veicolo")]
    public class ControllerVeicolo : Controller
    {
        private readonly ServiceVeicolo _service;
        private readonly ServiceClienteVeicolo _clienteVeicolo;
        public ControllerVeicolo(ServiceVeicolo service, ServiceClienteVeicolo clienteVeicolo)
        {
            _service = service;
            _clienteVeicolo = clienteVeicolo;
        }

        [HttpDelete("{varId}")]

        public ActionResult<bool> EliminaVeicolo(int varId)
        {
            if (int.IsNegative(varId) || varId == 0)
                return BadRequest();

            if (_service.EliminaVeicoloService(varId))
                return Ok();

            return NotFound();
        }

        [HttpPost]
        
        public ActionResult<bool> InserisciVeicolo(VeicoloPostDTO veicoloPost)
        {
            if (string.IsNullOrWhiteSpace(veicoloPost.Targa) || string.IsNullOrWhiteSpace(veicoloPost.Marca) || string.IsNullOrWhiteSpace(veicoloPost.Stato)
                                          || decimal.IsNegative(veicoloPost.PIntervento) || int.IsNegative(veicoloPost.ClienteRif) || veicoloPost.ClienteRif == 0
                                          || veicoloPost.PIntervento == 0)
                                          
                return BadRequest();

            bool risultato = _service.InserisciVeicoloService(veicoloPost);

            if (risultato)
                return Ok();

            return BadRequest();
        }

        [HttpPut("{varId}")]

        public ActionResult<bool> AggiornaVeicolo(int varId, VeicoloPutDTO veicoloDTO)
        {
            if (int.IsNegative(varId))
                return BadRequest();

            bool risultato = _service.AggiornaVeicoloService(varId, veicoloDTO);

            return risultato;
        }
    }
}
