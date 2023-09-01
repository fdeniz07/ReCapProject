using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using Core.Aspects.Autofac.Performance;

namespace Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        //Bu class'in görevi; ilgili classlarin ve metotlarin attribute'lerini okuyor ona göre isleme tabi tutuyor.

        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
            (true).ToList();

        var methodAttributes = type.GetMethod(method.Name)
            .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

        classAttributes.AddRange(methodAttributes);
        // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); -->Loglama alt yapisi icin ekleni

        classAttributes.Add(new PerformanceAspect(5)); // Bu sekilde yapilirsa tüm metotlar icin 5ms performans yapilacatir.

        //En sonunda Priority sirasina göre islemleri siraliyoruz
        return classAttributes.OrderBy(x => x.Priority).ToArray();
    }
}