using GestioneAutofficina.Models;
using GestioneAutofficina.Repository;

namespace GestioneAutofficina.Service
{
    public class ServiceVeicolo
    {
        private readonly RepoVeicolo _repository;
        public ServiceVeicolo(RepoVeicolo repository)
        {
            _repository = repository;
        }

        public List<VeicoloGetDTO> CercaVeicoliByClienteId(int id)
        {
            List<VeicoloGetDTO> risultato = new List<VeicoloGetDTO>();

            List<Veicolo> veicoli = _repository.GetByRepartoRif(id);
            foreach (Veicolo v in veicoli)
            {
                VeicoloGetDTO temp = new VeicoloGetDTO()
                {
                    CodVeicolo = v.CodVeicolo,
                    Targa = v.Targa,
                    Marca = v.Marca,
                    AnnoImm = v.AnnoImm,
                    PIntervento = v.PIntervento,
                    Stato = v.Stato,
                    DataIni = v.DataIni
                };

                risultato.Add(temp);
            }

            return risultato;
        }

        public bool EliminaVeicoloService(int varId)
        {
            bool risultato = false;

            Veicolo? rep = _repository.GetById(varId);
            if (rep is not null)

                risultato = _repository.Delete(varId);


            return risultato;
        }

        public bool InserisciVeicoloService(VeicoloPostDTO veicoloDTO)
        {

            Veicolo prodotto = new Veicolo()
            {

                CodVeicolo = Guid.NewGuid().ToString(),
                Targa = veicoloDTO.Targa,
                Marca = veicoloDTO.Marca,
                AnnoImm = veicoloDTO.AnnoImm,
                PIntervento = veicoloDTO.PIntervento,
                Stato = veicoloDTO.Stato,
                DataIni= veicoloDTO.DataIni,
                ClienteRif = veicoloDTO.ClienteRif,
            };

            return _repository.Insert(prodotto);
        }

        public bool AggiornaVeicoloService(int varId, VeicoloPutDTO veicoloDTO)
        {
            Veicolo? veicolo = _repository.GetById(varId);


            if (veicolo is not null)
            {
                string codice = veicolo.CodVeicolo;
                string targa = veicolo.Targa;
                string marca = veicolo.Marca;
                DateOnly? annoImm = veicolo.AnnoImm;
                string? stato = veicolo.Stato;
                DateOnly? dataIni = veicolo.DataIni;
                int? ClienteRif = veicolo.ClienteRif;
                decimal? pIntervento = veicolo.PIntervento;

                if (veicolo.CodVeicolo is not null)
                {
                    veicolo.CodVeicolo = codice;
                }
                if (veicoloDTO.Targa is null)
                    veicolo.Targa = targa;
                else
                    veicolo.Targa = veicoloDTO.Targa;

                if (veicoloDTO.Marca is null)
                    veicolo.Marca = marca;
                else
                    veicolo.Marca = veicoloDTO.Marca;

                if (veicoloDTO.AnnoImm is null)
                    veicolo.AnnoImm = annoImm;
                else
                    veicolo.AnnoImm = veicoloDTO.AnnoImm;

                if (veicoloDTO.Stato is null)
                    veicolo.Stato = stato;
                else
                    veicolo.Stato = veicoloDTO.Stato;

                if (veicoloDTO.PIntervento is null)
                    veicolo.PIntervento = pIntervento;
                else
                    veicolo.PIntervento = veicoloDTO.PIntervento;

                if (veicoloDTO.DataIni is null)
                    veicolo.DataIni = dataIni;
                else
                    veicolo.DataIni = veicoloDTO.DataIni;

                if (veicoloDTO.ClienteRif is null)
                    veicolo.ClienteRif = ClienteRif;
                else
                    veicolo.ClienteRif = veicoloDTO.ClienteRif;
            }

            bool risultato = _repository.Update(veicolo);

            return risultato;
        }

    }
}
