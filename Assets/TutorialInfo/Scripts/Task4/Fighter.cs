using UnityEngine;

public class Fighter : Unit
{
    public int armor;
    public string element;
    public Weapon weapon;
    public Inventory inventory;

    public Fighter(string unitClass, int health, int armor, string element, Weapon weapon) 
        : base(unitClass, health, 0, 0)
    {
        this.armor = armor;
        this.element = element;
        this.weapon = weapon;

        inventory = new Inventory();
        inventory.AddItem(weapon.name, 1);
    }

    public int CalculateDamage(Fighter target)
    {
        int damage = weapon.damage - target.armor;
        if (damage < 1) damage = 1;

        if (weapon.element != "" && target.element != "")
        {
            if (weapon.element == target.element)
            {
                damage = 0;
            }
            else if ((weapon.element == "огонь" && target.element == "лед") ||
                     (weapon.element == "лед" && target.element == "огонь"))
            {
                damage = Mathf.FloorToInt(damage * 1.5f);
            }
        }

        if (Random.Range(0f, 1f) < weapon.critChance)
        {
            damage *= 2;
        }

        return damage;
    }

    public void TryPickUpWeapon(Weapon droppedWeapon)
    {
        if (droppedWeapon.damage > weapon.damage)
        {
            inventory.AddItem(droppedWeapon.name, 1);
            weapon = droppedWeapon;
        }
    }
}