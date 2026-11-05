using UnityEngine;

public class Arena : MonoBehaviour
{
    [SerializeField] private UnitType m_heroClass = UnitType.Warrior;
    [SerializeField] private int m_maxRounds = 10;

    private Unit m_hero;
    private Unit m_enemy;

    private void Awake()
    {
        if (m_heroClass == UnitType.Mage)
        {
            m_hero = new Unit(UnitType.Mage, 130, 6, 12);
        }
        else
        {
            m_hero = new Unit(UnitType.Warrior, 100, 10, 16);
        }

        int randEnemy = Random.Range(0, 3);
        if (randEnemy == 0)
        {
            m_enemy = new Unit(UnitType.Goblin, 50, 4, 8);
        }
        else if (randEnemy == 1)
        {
            m_enemy = new Unit(UnitType.Orc, 80, 5, 10);
        }
        else
        {
            m_enemy = new Unit(UnitType.Troll, 250, 20, 40);
        }
    }

    private void Start()
    {
        Debug.Log(m_hero.unitClass.ToString() + " (" + m_hero.health + " HP) против " + m_enemy.unitClass.ToString() + " (" + m_enemy.health + " HP)");

        for (int round = 1; round <= m_maxRounds; round++)
        {
            int heroDmg = m_hero.Attack();
            m_enemy.TakeDamage(heroDmg);

            string roundText = "Раунд " + round + ": " + m_hero.unitClass.ToString() + " наносит " + heroDmg + ", у противника " + m_enemy.health + " HP";

            if (m_enemy.health > 0)
            {
                int enemyDmg = m_enemy.Attack();
                m_hero.TakeDamage(enemyDmg);
                roundText += "; " + m_enemy.unitClass.ToString() + " наносит " + enemyDmg + ", у героя " + m_hero.health + " HP";
            }

            Debug.Log(roundText);

            if (m_hero.health == 0 || m_enemy.health == 0) break;
        }

        if (m_enemy.health == 0)
        {
            Debug.Log("Победил герой, здоровье " + m_hero.health + " HP");
        }
        else if (m_hero.health == 0)
        {
            Debug.Log("Победил противник, здоровье " + m_enemy.health + " HP");
        }
        else
        {
            Debug.Log("Ничья!");
        }
    }
}
