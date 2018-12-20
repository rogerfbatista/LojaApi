using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Startup
{
   public  class SimpleInjectConfig
    {

        public static Container CriarInjecaoDependencia()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<Application.Interfaces.IProdutoAppService, Application.ProdutoAppService>(Lifestyle.Scoped);
            container.Register<Domain.Interfaces.Services.IProdutoService, Domain.Services.ProdutoService>(Lifestyle.Scoped);
            container.Register<Domain.Interfaces.Repositorys.IProdutoRepository, Data.Repositorys.ProdutoRepository>(Lifestyle.Scoped);

            return container;
        }
    }
}
