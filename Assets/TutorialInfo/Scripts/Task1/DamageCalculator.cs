using UnityEngine;

public class DamageCalculator : MonoBehaviour
{
    [SerializeField] private int m_baseDamage = 10;
    [SerializeField] private int m_armor = 3;
    [SerializeField] private Element m_weaponElement = Element.Fire; 
    [SerializeField] private Element m_targetElement = Element.Ice;  
    [SerializeField] private float m_critChance = 0.3f;

    private int m_hitCount = 0; 

    private void Start()
    {
        Debug.Log("Нажмите F, чтобы нанести удар");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            m_hitCount++;

            int dmg = DamageUtility.CalculateDamage(
                m_baseDamage, 
                m_armor, 
                m_weaponElement, 
                m_targetElement, 
                m_critChance, 
                out bool isCrit, 
                out float elemMult);

            string elemInfo = elemMult == 1.5f ? "стихия х1,5" : (elemMult == 0f ? "стихии совпали" : "без стихии");
            string critInfo = isCrit ? "крит х2" : "без крита";

            Debug.Log("Удар " + m_hitCount + ": " + dmg + " урона (" + elemInfo + ", " + critInfo + ")");
        }
    }
}