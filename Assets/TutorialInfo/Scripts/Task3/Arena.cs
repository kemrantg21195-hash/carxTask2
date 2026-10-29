using UnityEngine;

public class Arena : MonoBehaviour
{
    public string heroClass = "Воин";
    public int maxRounds = 10;

    private Unit hero;
    private Unit enemy;

    void Awake()
    {
        if (heroClass == "Маг")
        {
            hero = new Unit("Маг", 130, 6, 12);
        }
        else
        {
            hero = new Unit("Воин", 100, 10, 16);
        }

        int randEnemy = Random.Range(0, 3);
        if (randEnemy == 0)
        {
            enemy = new Unit("Гоблин", 50, 4, 8);
        }
        else if (randEnemy == 1)
        {
            enemy = new Unit("Орк", 80, 5, 10);
        }
        else
        {
            enemy = new Unit("Тролль", 250, 20, 40);
        }
    }

    void Start()
    {
        Debug.Log(hero.unitClass + " (" + hero.health + " HP) против " + enemy.unitClass + " (" + enemy.health + " HP)");

        for (int round = 1; round <= maxRounds; round++)
        {
            int heroDmg = hero.Attack();
            enemy.TakeDamage(heroDmg);

            string roundText = "Раунд " + round + ": " + hero.unitClass + " наносит " + heroDmg + ", у противника " + enemy.health + " HP";

            if (enemy.health > 0)
            {
                int enemyDmg = enemy.Attack();
                hero.TakeDamage(enemyDmg);
                roundText += "; " + enemy.unitClass + " наносит " + enemyDmg + ", у героя " + hero.health + " HP";
            }

            Debug.Log(roundText);

            if (hero.health == 0 || enemy.health == 0) break;
        }

        if (enemy.health == 0)
        {
            Debug.Log("Победил герой, здоровье " + hero.health + " HP");
        }
        else if (hero.health == 0)
        {
            Debug.Log("Победил противник, здоровье " + enemy.health + " HP");
        }
        else
        {
            Debug.Log("Ничья!");
        }
    }
}