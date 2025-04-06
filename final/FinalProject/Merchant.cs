// The Merchant class is a specific type of Adventurer with moderate stats and a unique skill
public class Merchant : Adventurer
{
    // Constructor sets up the Merchant's specific attributes
    public Merchant(string name) : base(name)
    {
        _damageType = "Bludgeoning";    // Type of damage the Merchant deals
        _maxHealth = 90;                // Slightly lower health than average
        _maxStamina = 80;              // Moderate stamina pool
        _armor = 4;                     // Light armor
        _health = _maxHealth;          // Start at full health
        _stamina = _maxStamina;        // Start at full stamina
    }

    // Returns the subclass name for identification
    public override string GetSubclass() => "Merchant";

    // Calculates base damage dealt by the Merchant
    public override int CalculateDmg() => 8;

    // A unique Merchant ability (not yet used in gameplay logic)
    // Uses stamina to perform a bargaining action
    public void Bargain(int cost)
    {
        if (HasEnoughStamina(cost)) UseStamina(cost);
    }
}
