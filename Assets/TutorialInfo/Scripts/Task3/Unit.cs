using UnityEngine;

public class Unit
{
    public string unitClass;
    public int minDamage;
    public int maxDamage;

    public int health;

    public Unit(string unitClass, int health, int minDamage, int maxDamage)
    {
        this.unitClass = unitClass;
        this.health = health;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }
    public int Attack()
    {
        return Random.Range(minDamage, maxDamage + 1);
    }
}