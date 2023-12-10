namespace Domain.ValueObjects;

public sealed class Colour : ValueObject
{
    static Colour()
    {
    }

    private Colour()
    {
    }

    private Colour(string code) =>
        Code = code;

    //TODO add validation of supported colours
    public static Colour From(string code) =>
         new Colour { Code = code };

    public string Code { get; private set; } = "#000000";

    public static implicit operator string(Colour colour) => colour.ToString();

    public static explicit operator Colour(string code) => From(code);

    public override string ToString() => Code;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}