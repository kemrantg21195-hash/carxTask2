using UnityEngine;

public class Fighter : Unit
{
    public int armor { get; private set; }
    public Element element { get; private set; }
    public Weapon weapon { get; private set; }
    public Inventory inventory { get; private set; }

    // Конструктор должен принимать UnitType и Element
    public Fighter(UnitType unitClass, int health, int armor, Element element, Weapon weapon) 
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
        return DamageUtility.CalculateDamage(
            weapon.damage, 
            target.armor, 
            weapon.element, 
            target.element, 
            weapon.critChance, 
            out _, 
            out _); 
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