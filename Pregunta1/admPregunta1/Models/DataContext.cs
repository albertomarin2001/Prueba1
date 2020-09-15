using System.Data.Entity;

namespace admPregunta1.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<admPregunta1.Models.Marin> Marins { get; set; }
    }

}