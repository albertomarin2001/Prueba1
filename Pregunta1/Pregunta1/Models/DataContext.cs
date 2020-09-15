using System.Data.Entity;

namespace Pregunta1.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Pregunta1.Models.Marin> Marins { get; set; }
    }
}