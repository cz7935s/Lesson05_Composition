namespace Toolkit;

public record HealthPoints
{
    public static HealthPoints Create(int maxHealth) => new(maxHealth);
        
    public int CurrentHealth { get; }
    public int MaxHealth { get; }

    private HealthPoints(int MaxHealth)
    {
        this.MaxHealth = MaxHealth;
        this.CurrentHealth = MaxHealth; 
    }
}