using Castle.DynamicProxy;
using System;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)] //Class ve metot bazinda coklu kullanima izin veriyoruz
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
