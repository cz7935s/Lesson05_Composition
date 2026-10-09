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

    public int CurrentHealth { get; }
    public int MaxHealth { get; }

    public AbilityScore Abilities { get; }


    /// <summary>Experience the party earns for defeating it.</summary>
    public int ExperienceReward { get; }

    private Creature(string name,
        int currentHealth, int maxHealth, AbilityScore abilities,
        int experienceReward)
    {
        Name = name;
        CurrentHealth = currentHealth;
        MaxHealth = maxHealth;
        Abilities = abilities;
        ExperienceReward = experienceReward;
    }

    /// <summary>
    /// Builds a creature, or refuses to.  Every creature in the program comes
    /// through here.
    /// </summary>
    public static Creature Create(string name,
        int currentHealth, int maxHealth,
        int strength, int dexterity, int constitution,
        int intelligence, int wisdom, int charisma,
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

        
        var stats = AbilityScore.Create(strength, dexterity, constitution, intelligence, wisdom, charisma);
        if (stats == null)
            throw new ArgumentOutOfRangeException("Ability scores run from 3 to 18.");
        
        if (experienceReward < 0)
            throw new ArgumentOutOfRangeException(
                nameof(experienceReward), experienceReward,
                "Experience reward can't be negative.");

        return new Creature(name,
            currentHealth, maxHealth, stats,
            experienceReward);
    }
}
