using Microsoft.EntityFrameworkCore;

namespace GestioneAutofficina.Models
{
    public class AutofficinaContext : DbContext
    {
        public AutofficinaContext(DbContextOptions<AutofficinaContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Veicolo> Veicoli { get; set; }

        }
    }

