using Lib;
using Ninject.Modules;
using Repositorios;

public class Modulo : NinjectModule
{
    public override void Load()
    {
        base.Bind<IUnidadeDeTrabalho>().To<UnidadeDeTrabalho>();
        base.Bind<IRepositorioDePessoas>().To<RepositorioDePessoas>();  
    }
}