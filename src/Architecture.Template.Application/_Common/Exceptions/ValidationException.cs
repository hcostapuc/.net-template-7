using FluentValidation.Results;

namespace Application._Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }
    public ValidationException(ValidationFailure failure)
        : this()
    {
        Errors.Add(failure.PropertyName, new string[1] { failure.ErrorMessage });
    }

    public IDictionary<string, string[]> Errors { get; }
}
