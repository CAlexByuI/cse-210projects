// The Knight class is a melee-focused Adventurer with high defense and durability
public class Knight : Adventurer
{
    // Constructor sets up the Knight's specific attributes
    public Knight(string name) : base(name)
    {
        _damageType = "Melee";          // Knight uses close-combat melee attacks
        _maxHealth = 150;               // High health for tanking damage
        _maxStamina = 70;               // Lower stamina pool due to heavy armor
        _armor = 10;                    // Strong armor for damage reduction
        _health = _maxHealth;           // Start at full health
        _stamina = _maxStamina;        // Start at full stamina
    }

    // Returns the subclass name for identification
    public override string GetSubclass() => "Knight";

    // Calculates base damage dealt by the Knight
    public override int CalculateDmg() => 12;

    // Knight's special ability, uses stamina to block incoming damage (not implemented yet)
    public void ShieldBlock(int cost)
    {
        if (HasEnoughStamina(cost)) UseStamina(cost);
    }
}
