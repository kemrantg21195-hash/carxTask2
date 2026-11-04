using UnityEngine;

public static class DamageUtility
{
    public static int CalculateDamage(int baseDamage, int armor, Element weaponElement, Element targetElement, float critChance, out bool isCrit, out float elementMultiplier)
    {
        int damage = baseDamage - armor;
        if (damage < 1)
        {
            damage = 1;
        }

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
                damage = Mathf.FloorToInt(damage * 1.5f);
                elementMultiplier = 1.5f;
            }
        }

        isCrit = false;
        if (Random.Range(0f, 1f) < critChance)
        {
            damage *= 2;
            isCrit = true;
        }

        return damage;
    }
}