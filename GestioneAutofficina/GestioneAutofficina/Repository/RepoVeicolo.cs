
using GestioneAutofficina.Models;
using Microsoft.EntityFrameworkCore;

namespace GestioneAutofficina.Repository
{
    public class RepoVeicolo : IRepository<Veicolo>
    {
        private readonly AutofficinaContext _context;

        public RepoVeicolo(AutofficinaContext context)
        {
            this._context = context;
        }

        public bool Delete(int id)
        {
            bool risultato = false;

            try
            {
                Veicolo lib = _context.Veicoli.Single(l => l.VeicoloID == id);
                _context.Veicoli.Remove(lib);
                _context.SaveChanges();

                risultato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return risultato;
        }

        public List<Veicolo> GetAll()
        {
            List<Veicolo> elenco = new List<Veicolo>();

            elenco = _context.Veicoli.ToList();

            return elenco;
        }

        public Veicolo? GetById(int id)
        {
            Veicolo? risultato = null;

            risultato = _context.Veicoli.FirstOrDefault(l => l.VeicoloID == id);

            return risultato;
        }

        public List<Veicolo> GetByRepartoRif(int rif)
        {
            List<Veicolo> risultato = new List<Veicolo>();


            risultato = _context.Veicoli.Where(l => l.ClienteRif == rif).ToList();

            return risultato;
        }

        public bool Insert(Veicolo t)
        {
            bool risultato = false;

            try
            {
                _context.Veicoli.Add(t);
                _context.SaveChanges();

                risultato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return risultato;
        }

        public bool Update(Veicolo t)
        {
            bool risultato = false;
            try
            {

                _context.Update(t);
                _context.SaveChanges();
                risultato = true;
                return risultato;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return risultato;
            }
        }
    }
}
