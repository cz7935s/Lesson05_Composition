namespace Toolkit;

public record AbilityScore
{
    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }

    private AbilityScore(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
    }

    public static AbilityScore? Create(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
        if (strength < 3 || strength > 18)
            return null;

        if (dexterity < 3 || dexterity > 18)
            return null;

        if (constitution < 3 || constitution > 18)
            return null;

        if (intelligence < 3 || intelligence > 18)
            return null;

        if (wisdom < 3 || wisdom > 18)
            return null;

        if (charisma < 3 || charisma > 18)
            return null;

        return new(strength, dexterity, constitution, intelligence, wisdom, charisma);
    }
    
}