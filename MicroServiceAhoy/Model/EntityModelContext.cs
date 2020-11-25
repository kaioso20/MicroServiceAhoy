using System.Data.Entity;

namespace MicroServiceAhoy.Model
{
    public class EntityModelContext : DbContext
    {
        public EntityModelContext() : base("AhoyTeste")
        {
        }

        public DbSet<Usuario.Usuario> Usuario { get; set; }
    }
}
