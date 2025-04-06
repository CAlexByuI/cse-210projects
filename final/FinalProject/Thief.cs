// The Thief class is a fast, high-stamina Adventurer with a bleeding attack type
public class Thief : Adventurer
{
    // Constructor sets up the Thief's specific attributes
    public Thief(string name) : base(name)
    {
        _damageType = "Bleed";          // Thief inflicts bleeding damage
        _maxHealth = 80;                // Low health due to light build
        _maxStamina = 120;              // High stamina for frequent or rapid actions
        _armor = 2;                     // Very light armor
        _health = _maxHealth;           // Start at full health
        _stamina = _maxStamina;        // Start at full stamina
    }

    // Returns the subclass name for identification
    public override string GetSubclass() => "Thief";

    // Calculates base damage dealt by the Thief
    public override int CalculateDmg() => 11;

    // Thief's special ability, uses stamina to perform a fast strike (not implemented yet)
    public void QuickStrike(int cost)
    {
        if (HasEnoughStamina(cost)) UseStamina(cost);
    }
}
