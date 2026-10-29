using System.Collections.Generic;
using UnityEngine;

public class Colisium : MonoBehaviour
{
    public int maxRounds = 10;

    private List<Fighter> heroes = new List<Fighter>();
    private List<Fighter> enemies = new List<Fighter>();

    void Awake()
    {
        Weapon excalibur = new Weapon("Экскалибур", 100, "", 0.8f);
        Weapon fireSword = new Weapon("Огненный меч", 16, "огонь", 0.3f);
        Weapon dagger = new Weapon("Кинжал", 8, "лед", 0.2f);
        Weapon BigClub = new Weapon("Большая дубина", 22, "", 0.25f);

        heroes.Add(new Fighter("Воин", 100, 4, "лед", excalibur));
        heroes.Add(new Fighter("Маг", 90, 2, "огонь", fireSword));

        enemies.Add(new Fighter("Гоблин", 50, 1, "лед", dagger));
        enemies.Add(new Fighter("Орк", 80, 3, "лед", BigClub));
    }

    void Start()
    {
        Debug.Log("Начало боя");

        for (int round = 1; round <= maxRounds; round++)
        {
            Debug.Log("Раунд " + round);

            for (int i = 0; i < heroes.Count; i++)
            {
                Fighter hero = heroes[i];
                if (hero.health == 0) continue;

                Fighter target = GetAliveUnit(enemies);
                if (target == null) break;

                int dmg = hero.CalculateDamage(target);
                target.TakeDamage(dmg);
                Debug.Log(hero.unitClass + " бьёт " + target.unitClass + " из " + hero.weapon.name + " на " + dmg + " урона (осталось " + target.health + " HP)");

                if (target.health == 0)
                {
                    Debug.Log(target.unitClass + " погиб!");
                    hero.TryPickUpWeapon(target.weapon);
                }
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                Fighter enemy = enemies[i];
                if (enemy.health == 0) continue;

                Fighter target = GetAliveUnit(heroes);
                if (target == null) break;

                int dmg = enemy.CalculateDamage(target);
                target.TakeDamage(dmg);
                Debug.Log(enemy.unitClass + " бьёт " + target.unitClass + " из " + enemy.weapon.name + " на " + dmg + " урона (осталось " + target.health + " HP)");

                if (target.health == 0)
                {
                    Debug.Log(target.unitClass + " погиб!");
                    
                    Fighter aliveHero = GetAliveUnit(heroes);
                    if (aliveHero != null)
                    {
                        aliveHero.TryPickUpWeapon(target.weapon);
                    }
                }
            }

            if (GetAliveUnit(enemies) == null || GetAliveUnit(heroes) == null)
            {
                break;
            }
        }

        if (GetAliveUnit(enemies) == null)
        {
            Debug.Log("Победа героев!");
        }
        else if (GetAliveUnit(heroes) == null)
        {
            Debug.Log("Победа врага.");
        }
        else
        {
            Debug.Log("Ничья");
        }
    }

    Fighter GetAliveUnit(List<Fighter> team)
    {
        for (int i = 0; i < team.Count; i++)
        {
            if (team[i].health > 0)
            {
                return team[i];
            }
        }
        return null;
    }
}