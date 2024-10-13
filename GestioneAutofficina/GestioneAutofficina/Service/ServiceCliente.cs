using GestioneAutofficina.Models;
using GestioneAutofficina.Repository;

namespace GestioneAutofficina.Service
{
    public class ServiceCliente
    {
        private readonly RepoCliente _repository;
        public ServiceCliente(RepoCliente repository)
        {
            _repository = repository;
        }

        public bool EliminaClienteService(int varId)
        {
            bool risultato = false;

            Cliente? rep = _repository.GetById(varId);
            if (rep is not null)

                risultato = _repository.Delete(varId);


            return risultato;
        }

        public bool InserisciClienteService(ClientePostDTO clienteDTO)
        {
            Cliente cliente = new Cliente()
            {
                CodCliente = Guid.NewGuid().ToString(),
                Nome = clienteDTO.Nome,
                Cognome = clienteDTO.Cognome,
                Indirizzo = clienteDTO.Indirizzo,
                Telefono = clienteDTO.Telefono,
                Email = clienteDTO.Email
            };

            return _repository.Insert(cliente);
           
        }
        public bool AggiornaClienteService(ClientePutDTO clienteDTO, int varId)
        {
            Cliente? cliente = _repository.GetById(varId);


            if (cliente is not null)
            {
                string codice = cliente.CodCliente;
                string nome = cliente.Nome;
                string cognome = cliente.Cognome;
                string indirizzo = cliente.Indirizzo;
                string? email = cliente.Email;
                string telefono = cliente.Telefono;

                if (cliente.CodCliente is not null)
                {
                    cliente.CodCliente = codice;
                }
                if(clienteDTO.Nome is null)
                     cliente.Nome = nome;
                else
                    cliente.Nome = clienteDTO.Nome;

                if (clienteDTO.Cognome is null)
                    cliente.Cognome = cognome;
                else
                    cliente.Cognome = clienteDTO.Cognome;

                if (clienteDTO.Indirizzo is null)
                    cliente.Indirizzo = indirizzo;
                else
                    cliente.Indirizzo = clienteDTO.Indirizzo;

                if (clienteDTO.Telefono is null)
                    cliente.Telefono = telefono;
                else
                    cliente.Telefono = clienteDTO.Telefono;

                if (clienteDTO.Email is null)
                    cliente.Email = email;
                else
                    cliente.Email = clienteDTO.Email;
            }

            bool risultato = _repository.Update(cliente);

            return risultato;
        }

    }
}
