public class Archer : Adventurer
{
    public Archer(string name) : base(name)
    {
        _damageType = "Range";
        _maxHealth = 100;
        _maxStamina = 100;
        _armor = 3;
        _health = _maxHealth;
        _stamina = _maxStamina;
    }

    public override string GetSubclass() => "Archer";
    public override int CalculateDmg() => 13;
    public void PrecisionShot(int cost)
    {
        if (HasEnoughStamina(cost)) UseStamina(cost);
    }
}
