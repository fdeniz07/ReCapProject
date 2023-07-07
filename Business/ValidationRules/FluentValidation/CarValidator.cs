using System;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;


namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.CarName).NotEmpty().WithName("Araba Adı").WithMessage("{PropertyName}" + ValidatorMessages.NotEmpty);

            RuleFor(x => x.CarName).MinimumLength(2).WithName("Araba Adı").WithMessage("{PropertyName}" + String.Format(ValidatorMessages.NotShorterChar, "{PropertyValue}"));

            RuleFor(x => x.CarName).MaximumLength(20).WithName("Araba Adı").WithMessage("{PropertyName}" + String.Format(ValidatorMessages.NotLongerChar, "{PropertyValue}"));

            RuleFor(x => x.DailyPrice).GreaterThan(0).WithName("Günlük Fiyat")
                .WithMessage("{PropertyName}" + String.Format(ValidatorMessages.NotGreaterNum, "{PropertyValue}"));
        }
    }
}
