﻿using Business.Constants;
using Entities.Concrete;
using FluentValidation;


namespace Business.Validation
{
    public class CarValidator : AbstractValidator<Car>
    {
        private readonly ValidatorMessages _validatorMessages;

        public CarValidator(ValidatorMessages validatorMessages)
        {
            _validatorMessages = validatorMessages;
        }

        public CarValidator()
        {
            RuleFor(x => x.CarName).NotEmpty().WithName("Araba Adı").WithMessage("{PropertyName}" + _validatorMessages.NotEmpty);
            RuleFor(x => x.CarName).MinimumLength(2).WithName("Araba Adı").WithMessage("{PropertyName}" + _validatorMessages.NotShorterChars);
            RuleFor(x => x.CarName).MaximumLength(20).WithName("Araba Adı").WithMessage("{PropertyName}" + _validatorMessages.NotLongerChars);

            RuleFor(x => x.DailyPrice).GreaterThan(0).WithName("Günlük Fiyat")
                .WithMessage("{PropertyName}" + _validatorMessages.NotGreaterNums);
        }
    }
}
