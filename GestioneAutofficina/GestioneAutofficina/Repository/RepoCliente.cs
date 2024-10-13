using GestioneAutofficina.Models;

namespace GestioneAutofficina.Repository
{
    public class RepoCliente : IRepository<Cliente>
    {
        private readonly AutofficinaContext _context;

        public RepoCliente(AutofficinaContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            bool risultato = false;

            try
            {
                Cliente lib = _context.Clienti.Single(l => l.ClienteID == id);
                _context.Clienti.Remove(lib);
                _context.SaveChanges();

                risultato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return risultato;
        }

        public List<Cliente> GetAll()
        {
            List<Cliente> elenco = new List<Cliente>();

            elenco = _context.Clienti.ToList();

            return elenco;
        }

        public Cliente? GetById(int id)
        {
             
         Cliente? risultato = _context.Clienti.FirstOrDefault(l => l.ClienteID == id);

            return risultato;
        }

        public bool Insert(Cliente t)
        {
            bool risultato = false;

            try
            {
                _context.Clienti.Add(t);
                _context.SaveChanges();

                risultato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return risultato;
        }

        public bool Update(Cliente t)
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
            };
        }
    }
}
