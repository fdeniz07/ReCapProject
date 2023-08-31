using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Business.BusinessAspects.Autofac
{
    //JWT
    //Bu class’in amaci AOP olarak ilgili operasyonlarin tanimlanabilmesini saglamaktir.
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
                foreach (var role in _roles)
                {
                    if (roleClaims != null && roleClaims.Contains(role))
                    {
                        return;
                    }
                }
            }

            throw new Exception(Messages.AUTHORIZATION_DENIED);
        }
    }
}
