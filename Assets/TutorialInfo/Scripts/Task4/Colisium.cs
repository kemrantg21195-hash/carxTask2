using System.Collections.Generic;
using UnityEngine;

public class Colisium : MonoBehaviour
{
    [SerializeField, Min(1)] private int m_maxRounds = 10;

    private List<Fighter> m_heroes = new List<Fighter>();
    private List<Fighter> m_enemies = new List<Fighter>();

    private void Awake()
    {
        Weapon excalibur = new Weapon("Экскалибур", 100, Element.None, 0.8f);
        Weapon fireSword = new Weapon("Огненный меч", 16, Element.Fire, 0.3f);
        Weapon dagger = new Weapon("Кинжал", 8, Element.Ice, 0.2f);
        Weapon bigClub = new Weapon("Большая дубина", 22, Element.None, 0.25f);

        m_heroes.Add(new Fighter(UnitType.Warrior, 100, 4, Element.Ice, excalibur));
        m_heroes.Add(new Fighter(UnitType.Mage, 90, 2, Element.Fire, fireSword));

        m_enemies.Add(new Fighter(UnitType.Goblin, 50, 1, Element.Ice, dagger));
        m_enemies.Add(new Fighter(UnitType.Orc, 80, 3, Element.Ice, bigClub));
    }

    private void Start()
    {
        Debug.Log("Начало боя");

        for (int round = 1; round <= m_maxRounds; round++)
        {
            Debug.Log($"Раунд {round}");

            ProcessTeamTurn(m_heroes, m_enemies);
            if (GetAliveUnit(m_enemies) == null) break;

            ProcessTeamTurn(m_enemies, m_heroes);
            if (GetAliveUnit(m_heroes) == null) break;
        }

        if (GetAliveUnit(m_enemies) == null)
        {
            Debug.Log("Победа героев!");
        }
        else if (GetAliveUnit(m_heroes) == null)
        {
            Debug.Log("Победа врага.");
        }
        else
        {
            Debug.Log("Ничья");
        }
    }

    private void ProcessTeamTurn(List<Fighter> attackers, List<Fighter> defenders)
    {
        for (int i = 0; i < attackers.Count; i++)
        {
            Fighter attacker = attackers[i];
            if (attacker.health == 0) continue;

            Fighter target = GetAliveUnit(defenders);
            if (target == null) break;

            int dmg = attacker.CalculateDamage(target);
            target.TakeDamage(dmg);
            
            Debug.Log($"{attacker.unitClass} бьёт {target.unitClass} из {attacker.weapon.name} на {dmg} урона (осталось {target.health} HP)");

            if (target.health == 0)
            {
                Debug.Log($"{target.unitClass} погиб!");
                
                Fighter aliveAttacker = GetAliveUnit(attackers);
                if (aliveAttacker != null)
                {
                    aliveAttacker.TryPickUpWeapon(target.weapon);
                }
            }
        }
    }

    private Fighter GetAliveUnit(List<Fighter> team)
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