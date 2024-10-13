using GestioneAutofficina.Models;
using GestioneAutofficina.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GestioneAutofficina.Service
{
    public class ServiceClienteVeicolo
    {
        private readonly RepoCliente _repoCliente;
        private readonly RepoVeicolo _repoVeicolo;
        private readonly ServiceCliente _serviceCliente;
        private readonly ServiceVeicolo _serviceVeicolo;

        public ServiceClienteVeicolo(RepoCliente repoCliente, RepoVeicolo repoVeicolo, ServiceCliente serviceCliente, ServiceVeicolo serviceVeicolo)
        {
            _repoCliente = repoCliente;
            _repoVeicolo = repoVeicolo;
            _serviceCliente = serviceCliente;
            _serviceVeicolo = serviceVeicolo;
        }

        public CliVeiGetDTO? CercaClienteById(int varId)
        {
            CliVeiGetDTO? risultato = null;
            Cliente? cliente = _repoCliente.GetById(varId);
            if (cliente is not null)
            {
                risultato = new CliVeiGetDTO()
                {
                    CodCliente = cliente.CodCliente,
                    Nome = cliente.Nome,
                    Cognome = cliente.Cognome,
                    Indirizzo = cliente.Indirizzo,
                    Telefono = cliente.Telefono,
                    Email = cliente.Email,
                    VeicoliList = _serviceVeicolo.CercaVeicoliByClienteId(varId)
                };
                return risultato;
            }

            else
            return null;
        }
    }
}
