using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application._Common.Exceptions;
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
