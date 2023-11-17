using System.Data.Entity;
using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFramework;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.Concrete.Manager;
using MemberRegistration.Business.ServiceAdapters;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace MemberRegistration.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMemberService>().To<MemberManager>().InSingletonScope();
            Bind<IMemberDal>().To<EfMemberDal>().InSingletonScope();
            Bind<IKpsService>().To<KpsServiceAdapter>().InSingletonScope();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<MembershipContext>();
        }
    }
}