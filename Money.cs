namespace Toolkit;

public record Money
{
    public static Money Default => new(0);
    /// <summary>
    /// TODO: This is so much more complicated!!!
    /// </summary>
    public int Gold { get; }

    private Money(int gold)
    {
        Gold = gold;
    }
}