using UnityEngine;

public static class DamageUtility
{
    public const float ElementBonus = 1.5f;
    private const int CritBonus = 2;

    public static int CalculateDamage(int baseDamage, int armor, Element weaponElement, Element targetElement, float critChance, out bool isCrit, out float elementMultiplier)
    {
        int damage = Mathf.Max(1, baseDamage - armor);

        elementMultiplier = 1f;
        if (weaponElement != Element.None && targetElement != Element.None)
        {
            if (weaponElement == targetElement)
            {
                damage = 0;
                elementMultiplier = 0f;
            }
            else if ((weaponElement == Element.Fire && targetElement == Element.Ice) || 
                     (weaponElement == Element.Ice && targetElement == Element.Fire))
            {
                damage = Mathf.FloorToInt(damage * ElementBonus);
                elementMultiplier = ElementBonus;
            }
        }

        isCrit = false;
        if (Random.Range(0f, 1f) < critChance)
        {
            damage *= CritBonus;
            isCrit = true;
        }

        return damage;
    }
}