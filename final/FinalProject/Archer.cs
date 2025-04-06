// The Archer class is a ranged-type Adventurer with balanced stats and a precision skill
public class Archer : Adventurer
{
    // Constructor sets up the Archer's specific attributes
    public Archer(string name) : base(name)
    {
        _damageType = "Range";          // Archer uses ranged attacks
        _maxHealth = 100;               // Standard health
        _maxStamina = 100;              // Balanced stamina
        _armor = 3;                     // Light armor
        _health = _maxHealth;           // Start at full health
        _stamina = _maxStamina;        // Start at full stamina
    }

    // Returns the subclass name for identification
    public override string GetSubclass() => "Archer";

    // Calculates base damage dealt by the Archer
    public override int CalculateDmg() => 13;

    // Archer's special ability, consumes stamina to fire a precision shot
    public void PrecisionShot(int cost)
    {
        if (HasEnoughStamina(cost)) UseStamina(cost);
    }
}
