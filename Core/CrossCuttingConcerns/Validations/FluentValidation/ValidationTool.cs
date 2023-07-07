using FluentValidation;

namespace Core.CrossCuttingConcerns.Validations.FluentValidation
{
    public class ValidationTool
    {
        #region Kötü kodun daha okunur ve kullanisli hale getirilmesi
        //var context = new ValidationContext<Car>(car);
        //CarValidator carValidator = new CarValidator();

        //var result = carValidator.Validate(context);
        //    if (!result.IsValid)
        //{
        //    throw new ValidationException(result.Errors);
        //}
        #endregion

        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
