using System.Reflection;
using AutoMapper;
using Ninject.Modules;

namespace MemberRegistration.Business.DependencyResolvers.Ninject
{
    public class AutoMapperModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToConstant(CreateConfiguration().CreateMapper()).InSingletonScope();
        }

        private static MapperConfiguration CreateConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                var assembly = Assembly.GetAssembly(typeof(AutoMapperModule));

                cfg.AddMaps(assembly);
                
            });
        }
    }
}