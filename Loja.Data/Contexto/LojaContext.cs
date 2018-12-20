using System.Data.Entity;
using System.Data.Entity.SqlServer;
using Loja.Data.Models.Mapping;
using Loja.Domain.Entities;

namespace Loja.Data.Contexto
{
    public class LojaContext : DbContext
    {
        static LojaContext()
        {

            var ensureDllIsCopied = SqlProviderServices.Instance;

            Database.SetInitializer<LojaContext>(null);
        }

        public LojaContext()
            : base("Name=LojaContext")
        {
            
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

       
        public DbSet<Produto> Produto { get; set; }
   
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
            modelBuilder.Configurations.Add(new ProdutoMap());
        
            //modelBuilder.Entity<ServicoUsuarioPerfil>().HasIndex("IX_ServicoUsuarioPerfil_name",
            //    configuration => configuration.Property(map => map.UsuarioPerfilId),configuration => configuration.Property(perfil => perfil));
        }
    }
}
