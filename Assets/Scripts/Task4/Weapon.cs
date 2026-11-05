public class Weapon
{
    public string name { get; private set; }
    public int damage { get; private set; }
    public Element element { get; private set; } 
    public float critChance { get; private set; }

    public Weapon(string name, int damage, Element element, float critChance)
    {
        this.name = name;
        this.damage = damage;
        this.element = element;
        this.critChance = critChance;
    }
}