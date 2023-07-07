using System;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors;

public abstract class MethodInterception : MethodInterceptionBaseAttribute
{

    //Burada kendimize göre bir try-catch-finally blogu olusturup tüm kontroller icin reflextion ve delegate ler ile buraya cagirip, duruma göre kontrol edecegiz.
    //Bu sayede tek bir yapi ile benzer isleri yapan class ve metotlari kontrol etmis olup, yapimizi merkeziyetci konuma cekecegiz.
    protected virtual void OnBefore(IInvocation invocation) { }
    protected virtual void OnAfter(IInvocation invocation) { }
    protected virtual void OnException(IInvocation invocation, System.Exception e) { }
    protected virtual void OnSuccess(IInvocation invocation) { }
    public override void Intercept(IInvocation invocation)
    {
        //MethodInterception class’i ile base class’dan miras aliyor ve duruma göre try-catch blogunu Intercept metodunu ezerek gerçekleştiriyoruz

        var isSuccess = true;
        OnBefore(invocation);
        try
        {
            invocation.Proceed();
        }
        catch (Exception e)
        {
            isSuccess = false;
            OnException(invocation, e);
            throw;
        }
        finally
        {
            if (isSuccess)
            {
                OnSuccess(invocation);
            }
        }
        OnAfter(invocation);
    }
}