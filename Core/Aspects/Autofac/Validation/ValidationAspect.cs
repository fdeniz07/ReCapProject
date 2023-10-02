using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validations.FluentValidation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Linq;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType; //Bu bir attribute

        //Burada ilgili attribute'ü aliyoruz. Yani hangi sinifa ait attribute olacak.
        public ValidationAspect(Type validatorType) // Attribute'ler Type yapisi ile kullanilirlar!
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))  // Gelen tipin dogrulama (IValidator) türünden olup olmadigini kontrol ediyoruz
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Reflextion --> Calisma aninda birseyleri calistirabilmemizi saglar.
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // ProcductValidator'un instance'ini olustur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //ProcductValidator'un base type'ini (calisma türünü) bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //Ilgili Type'in da parametrelerini bul (ProductManager'in Add metodunun)

            foreach (var entity in entities) //Parametreleri gez, ValidationTool'u kullanarak dogrula diyoruz.
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
