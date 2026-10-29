
public class Weapon
{
    public string name;
    public int damage;
    public string element;
    public float critChance;

    public Weapon(string name, int damage, string element, float critChance)
    {
        this.name = name;
        this.damage = damage;
        this.element = element;
        this.critChance = critChance;
    }
}