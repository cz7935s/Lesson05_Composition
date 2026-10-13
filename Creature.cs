// What mistake can't happen in Creature now that could happen before?
// Now, you can't put invalid values as the inputs of creature
// because there are checks that specifically check against that;
// if you do, then the creature won't be able to build. For example,
// if you put in an XP reward as the input for abilities, then it
// wouldn't work because these variables are now of different types
// (i.e. abilities being an AbilityScore, not just being ints). 


namespace Toolkit;

/// <summary>
/// Anything the players fight.  A goblin, a wolf, a dragon.
///
/// Same rules as <see cref="Player"/>:  a private constructor, and one door in
/// that checks every number.
/// </summary>
public record Creature
{
    public string Name { get; }

    //CHANGE TO HEALTHPOINTS
    public HealthPoints HealthPoints { get; }
    // public int CurrentHealth { get; }
    // public int MaxHealth { get; }

    public AbilityScore Abilities { get; }


    /// <summary>Experience the party earns for defeating it.</summary>
    // TODO : this is probably an object in its own right 
    public int ExperienceReward { get; }

    private Creature(string name,
        HealthPoints healthPoints, AbilityScore abilities,
        int experienceReward)
    {
        Name = name;
        HealthPoints = healthPoints;
        Abilities = abilities;
        ExperienceReward = experienceReward;
    }

    /// <summary>
    /// Builds a creature, or refuses to.  Every creature in the program comes
    /// through here.
    /// </summary>
    public static Creature Create(string name,
        int currentHealth, int maxHealth,
        int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma,
        int experienceReward)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("A creature needs a name.", nameof(name));

        if (maxHealth < 1)
            throw new ArgumentOutOfRangeException(
                nameof(maxHealth), maxHealth, "Max health is at least 1.");

        if (currentHealth < 0 || currentHealth > maxHealth)
            throw new ArgumentOutOfRangeException(
                nameof(currentHealth), currentHealth,
                $"Current health runs from 0 to max health ({maxHealth}).");
        
        if (experienceReward < 0)
            throw new ArgumentOutOfRangeException(
                nameof(experienceReward), experienceReward,
                "Experience reward can't be negative.");

        var healthPoints = Toolkit.HealthPoints.Create(maxHealth);
        var creatureStats =
            Toolkit.AbilityScore.Create(strength, dexterity, constitution, intelligence, wisdom, charisma)
               ?? Toolkit.AbilityScore.Create(10, 10, 10, 10, 10, 10)!;

        return new Creature(name, healthPoints, creatureStats, experienceReward);
    }
}
