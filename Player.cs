namespace Toolkit;

/// <summary>
/// A player character.  Everything a character sheet says, one property per
/// line.
///
/// Built the Lesson 2 way:  the constructor is private, and the only way in is
/// the factory method below, which checks every number before it lets one
/// through.
/// </summary>
public record Player
{
    public string Name { get; }
    public PlayerLevel Level { get; }
    
    public HealthPoints HealthPoints { get; }

    public AbilityScore Abilities { get; }
    
    public Money MyWallet { get; }
    

    private Player(string name, PlayerLevel level, HealthPoints healthPoints, AbilityScore abilities, Money myWallet)
    {
        Name = name;
        Level = level;
        HealthPoints = healthPoints;
        Abilities = abilities;
        MyWallet = myWallet; 
    }

    /// <summary>
    /// Builds a player, or refuses to.  Every player in the program comes
    /// through here.
    /// </summary>
    public static Player Create(string name,
        int strength, int dexterity, int constitution,
        int intelligence, int wisdom, int charisma)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("A player needs a name.", nameof(name));

        var level = PlayerLevel.Level1;

        var healthPoints = HealthPoints.Create(20);

        var stats = AbilityScore.Create(strength, dexterity, constitution, intelligence, wisdom, charisma);

        var gold = Money.Default();

        return new Player(name, level, healthPoints, stats, gold);
    }
}
