using GestioneAutofficina.Models;
using GestioneAutofficina.Repository;
using GestioneAutofficina.Service;
using Microsoft.AspNetCore.Mvc;

namespace GestioneAutofficina.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ControllerCliente : Controller
    {
        private readonly ServiceCliente _service;
        private readonly ServiceClienteVeicolo _serviceClienteVeicolo;

        public ControllerCliente(ServiceCliente service, ServiceClienteVeicolo serviceClienteVeicolo)
        {
            _service = service;
            _serviceClienteVeicolo = serviceClienteVeicolo;
        }

        [HttpDelete("elimina/{varId}")]
        public ActionResult<bool> EliminaCliente(int varId)
        {
            if (int.IsNegative(varId) || varId == 0)
                return BadRequest();

            if (_service.EliminaClienteService(varId))
                return Ok();

            return NotFound();
        }

        [HttpGet("{varId}")]
        public ActionResult<List<Cliente>> CercaClienteById(int varId)
        {
            if (varId < 0 || varId == 0)
                return BadRequest();

            CliVeiGetDTO? risultato = _serviceClienteVeicolo.CercaClienteById(varId);

            if(risultato == null)
                return NotFound();
            else
                return Ok(risultato);
        }

        [HttpPost]
        public ActionResult<bool> InserisciCliente(ClientePostDTO cliente)
        {

            if (string.IsNullOrWhiteSpace(cliente.Nome) || string.IsNullOrWhiteSpace(cliente.Cognome) || string.IsNullOrWhiteSpace(cliente.Indirizzo)
                                                        || string.IsNullOrWhiteSpace(cliente.Telefono) || string.IsNullOrWhiteSpace(cliente.Email))
                return BadRequest();

            bool risultato = _service.InserisciClienteService(cliente);

            if (risultato)
                return Ok();

            return BadRequest();
        }

        [HttpPut("{VarId}")]

        public ActionResult<bool> AggiornaCliente(int VarId, ClientePutDTO clienteDTO)
        {
            if (int.IsNegative(VarId))
                return BadRequest();

            bool risultato = _service.AggiornaClienteService(clienteDTO, VarId);

            return risultato;
        }


    }
}
