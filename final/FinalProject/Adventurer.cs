using System;
using System.Collections.Generic;

// Abstract Adventurer Class
public abstract class Adventurer
{
    protected string _name;
    protected int _armor;
    protected int _health;
    protected int _maxHealth;
    protected int _stamina;
    protected int _maxStamina;
    protected string _damageType;
    protected bool _isConscious = true;

    public Adventurer(string name)
    {
        _name = name;
        _health = 100;
        _maxHealth = 100;
        _stamina = 100;
        _maxStamina = 100;
    }

    public string GetName() => _name;
    public abstract string GetSubclass();
    public abstract int CalculateDmg();

    public void Heal(int amount)
    {
        if (!_isConscious) return;
        _health = Math.Min(_health + amount, _maxHealth);
    }

    public void UseStamina(int amount)
    {
        if (amount > _stamina) return;
        _stamina -= amount;
    }

    public bool HasEnoughStamina(int amount) => _stamina >= amount;

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

    public string CheckStatus()
    {
        if (!_isConscious) return "Unconscious";
        if (_health > _maxHealth / 2) return "Healthy";
        return "Injured";
    }
}