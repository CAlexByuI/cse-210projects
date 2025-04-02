public class Wizard : Adventurer
{
    public Wizard(string name) : base(name)
    {
        _damageType = "Magic";
        _maxHealth = 70;
        _maxStamina = 150;
        _armor = 5;
        _health = _maxHealth;
        _stamina = _maxStamina;
    }

    public override string GetSubclass() => "Wizard";
    public override int CalculateDmg() => 15;
    public void CastSpell(int cost)
    {
        if (HasEnoughStamina(cost)) UseStamina(cost);
    }
}