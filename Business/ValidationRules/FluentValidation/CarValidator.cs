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
            RuleFor(x => x.CarName).NotEmpty();
            RuleFor(x => x.CarName).MinimumLength(2);
            RuleFor(x => x.CarName).MaximumLength(20);

            RuleFor(x => x.DailyPrice).GreaterThan(0);
        }
    }
}
