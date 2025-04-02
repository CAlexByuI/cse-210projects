public class Thief : Adventurer
{
    public Thief(string name) : base(name)
    {
        _damageType = "Bleed";
        _maxHealth = 80;
        _maxStamina = 120;
        _armor = 2;
        _health = _maxHealth;
        _stamina = _maxStamina;
    }

    public override string GetSubclass() => "Thief";
    public override int CalculateDmg() => 11;
    public void QuickStrike(int cost)
    {
        if (HasEnoughStamina(cost)) UseStamina(cost);
    }
}