public class Merchant : Adventurer
{
    public Merchant(string name) : base(name)
    {
        _damageType = "Bludgeoning";
        _maxHealth = 90;
        _maxStamina = 80;
        _armor = 4;
        _health = _maxHealth;
        _stamina = _maxStamina;
    }

    public override string GetSubclass() => "Merchant";
    public override int CalculateDmg() => 8;
    public void Bargain(int cost)
    {
        if (HasEnoughStamina(cost)) UseStamina(cost);
    }
}