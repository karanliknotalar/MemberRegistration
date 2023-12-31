﻿using Ninject;

namespace MemberRegistration.Business.DependencyResolvers.Ninject
{
    public abstract class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule(), new AutoMapperModule());
            return kernel.Get<T>();
        }
    }
}