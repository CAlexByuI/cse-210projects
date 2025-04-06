// The Wizard class is a magic-based Adventurer with high damage and stamina but low health
public class Wizard : Adventurer
{
    // Constructor sets up the Wizard's specific attributes
    public Wizard(string name) : base(name)
    {
        _damageType = "Magic";          // Wizard uses magical attacks
        _maxHealth = 70;                // Lowest health among classes
        _maxStamina = 150;              // Very high stamina for spellcasting
        _armor = 5;                     // Moderate armor for a magic user
        _health = _maxHealth;           // Start at full health
        _stamina = _maxStamina;        // Start at full stamina
    }

    // Returns the subclass name for identification
    public override string GetSubclass() => "Wizard";

    // Calculates base damage dealt by the Wizard
    public override int CalculateDmg() => 15;

    // Wizard's special ability, uses stamina to cast a spell (not yet used in dungeon logic)
    public void CastSpell(int cost)
    {
        if (HasEnoughStamina(cost)) UseStamina(cost);
    }
}
