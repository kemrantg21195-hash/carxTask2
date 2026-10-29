using UnityEngine;

public class DamageCalculator : MonoBehaviour
{
    public int baseDamage = 10;
    public int armor = 3;
    public string weaponElement = "огонь";
    public string targetElement = "лед";
    public float critChance = 0.3f;

    private int hitCount = 0;
    void Start()
    {
        Debug.Log("Нажмите F, чтобы нанести удар");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            hitCount++;

            int dmg = baseDamage - armor;
            if (dmg < 1) dmg = 1;

            string elemInfo = "без стихии";

            if (weaponElement != "" && targetElement != "")
            {
                if (weaponElement == targetElement)
                {
                    dmg = 0;
                    elemInfo = "стихии совпали";
                }
                else if ((weaponElement == "огонь" && targetElement == "лед") || (weaponElement == "лед" && targetElement == "огонь"))
                {
                    dmg = Mathf.FloorToInt(dmg * 1.5f);
                    elemInfo = "стихия х1,5";
                }
            }

            string critInfo = "без крита";
            if (Random.Range(0f, 1f) < critChance)
            {
                dmg *= 2;
                critInfo = "крит х2";
            }

            Debug.Log("Удар " + hitCount + ": " + dmg + " урона (" + elemInfo + ", " + critInfo + ")");
        }
    }
}