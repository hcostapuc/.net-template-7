using FluentValidation.Results;

namespace Application._Common.Extensions;
public static class ValidationGuardExtension
{
    public static T AgainstValidationExpression<T>(this IGuardClause guardClause,
        Func<T, bool> func,
        T input,
        IEnumerable<ValidationFailure> validationFailureCollection) where T : struct =>
         !func(input) ? throw new Exceptions.ValidationException(validationFailureCollection) : input;
    public static T AgainstValidationExpression<T>(this IGuardClause guardClause,
        Func<T, bool> func,
        T input,
        ValidationFailure validationFailure) where T : struct =>
         !func(input) ? throw new Exceptions.ValidationException(validationFailure) : input;
}
