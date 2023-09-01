using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheManager;

        public CacheAspect(int duration = 60) //eger cacheleme icin süre verilmezse default 60dk
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>(); //DI yi ServiceTool ile IoC den alip,yapiyoruz
        }

        public override void Intercept(IInvocation invocation)
        {
            #region Old Codes

            //Reflextion olarak sinifin adi + metodun adi alinip, methodName degiskenine ataniyor.
            //var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//invocation=method
            //var arguments = invocation.Arguments.ToList(); //metod parametrelerini listeye aliyoruz
            //var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//linq ile metod parametreleri aralarinda "," olacak sekilde key'in icine atiliyor, parametre yoksa null geciyor
            //if (_cacheManager.IsAdd(key)) //ilgili key daha önceden cache de var mi kontrolü yapiliyor
            //{
            //    invocation.ReturnValue = _cacheManager.Get(key); //cache de varsa, dogrudan metodun cache deki degeri geri dönülüyor
            //    return;
            //}
            //invocation.Proceed(); //cache de yoksa metod calismaya devam ediyor
            //_cacheManager.Add(key, invocation.ReturnValue, _duration); //yeni gelen deger cache atiliyor ve duration süresi kadar saklaniyor

            #endregion

            //Reflextion olarak sinifin adi + metodun adi alinip, methodName degiskenine ataniyor.
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments; //invocation=method
            var key = $"{methodName}({BuildKey(arguments)})";
            var returnType = invocation.Method.ReturnType.GenericTypeArguments.FirstOrDefault();
            if (_cacheManager.IsAdd(key)) //ilgili key daha önceden cache de var mi kontrolü yapiliyor
            {
                invocation.ReturnValue = _cacheManager.Get(key); //cache de varsa, dogrudan metodun cache deki degeri geri dönülüyor
                return;
            }

            invocation.Proceed(); //cache de yoksa metod calismaya devam ediyor
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //yeni gelen deger cache atiliyor ve duration süresi kadar saklaniyor
        }

        string BuildKey(object[] args) //Ilgili key bilgilmizi alip, string format ile anlamli hale getiriyoruz
        {
            var sb = new StringBuilder();
            foreach (var arg in args)
            {
                var paramValues = arg.GetType().GetProperties()
                    .Select(p => p.GetValue(arg)?.ToString() ?? string.Empty);//linq ile metod parametreleri aralarinda "," olacak sekilde key'in icine                                                                         atiliyor, parametre yoksa null geciyor
                sb.Append(string.Join('_', paramValues));
            }

            return sb.ToString();
        }
    }
}
