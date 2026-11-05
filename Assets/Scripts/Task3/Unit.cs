using UnityEngine;

public class Unit
{
    public UnitType unitClass { get; private set; }
    public int minDamage { get; private set; }
    public int maxDamage { get; private set; }
    public int health { get; private set; }
    
    public Unit(UnitType unitClass, int health, int minDamage, int maxDamage)
    {
        this.unitClass = unitClass;
        this.health = health;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
    }

    public int Attack()
    {
        return Random.Range(minDamage, maxDamage + 1);
    }
}