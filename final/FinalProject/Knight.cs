public class Knight : Adventurer
{
    public Knight(string name) : base(name)
    {
        _damageType = "Melee";
        _maxHealth = 150;
        _maxStamina = 70;
        _armor = 10;
        _health = _maxHealth;
        _stamina = _maxStamina;
    }

    public override string GetSubclass() => "Knight";
    public override int CalculateDmg() => 12;
    public void ShieldBlock(int cost)
    {
        if (HasEnoughStamina(cost)) UseStamina(cost);
    }
}