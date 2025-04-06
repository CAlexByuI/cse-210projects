// Abstract base class representing a general adventurer
public abstract class Adventurer
{
    // Protected fields accessible to derived classes
    protected string _name;
    protected int _armor;
    protected int _health;
    protected int _maxHealth;
    protected int _stamina;
    protected int _maxStamina;
    protected string _damageType;
    protected bool _isConscious = true;

    // Constructor to initialize default stats
    public Adventurer(string name)
    {
        _name = name;
        _health = 100;
        _maxHealth = 100;
        _stamina = 100;
        _maxStamina = 100;
    }

    // Returns the name of the adventurer
    public string GetName() => _name;

    // Must be implemented by derived classes to return subclass type
    public abstract string GetSubclass();

    // Must be implemented by derived classes to calculate damage
    public abstract int CalculateDmg();

    // Restores health up to the maximum value
    public void Heal(int amount)
    {
        if (!_isConscious) return; // Can't heal if unconscious
        _health = Math.Min(_health + amount, _maxHealth);
    }

    // Reduces stamina by a specified amount, if enough is available
    public void UseStamina(int amount)
    {
        if (amount > _stamina) return; // Not enough stamina
        _stamina -= amount;
    }

    // Checks if the adventurer has enough stamina for an action
    public bool HasEnoughStamina(int amount) => _stamina >= amount;

    // Applies damage after accounting for armor, sets unconscious if health drops to 0
    public void TakeDamage(int amount)
    {
        int effectiveDamage = Math.Max(amount - _armor, 0);
        _health -= effectiveDamage;
        if (_health <= 0)
        {
            _health = 0;
            _isConscious = false;
        }
    }

    // Returns a string describing the adventurer’s condition
    public string CheckStatus()
    {
        if (!_isConscious) return "Unconscious";
        if (_health > _maxHealth / 2) return "Healthy";
        return "Injured";
    }

    // Returns the armor value
    public int GetArmor() => _armor;

    // Returns current health
    public int GetHealth() => _health;

    // Returns whether the adventurer is conscious
    public bool IsConscious() => _isConscious;
}
