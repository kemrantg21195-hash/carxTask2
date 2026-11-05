using UnityEngine;

public class DamageCalculator : MonoBehaviour
{
    [SerializeField, Min(0)] private int m_baseDamage = 10;
    [SerializeField, Min(0)] private int m_armor = 3;
    [SerializeField] private Element m_weaponElement = Element.Fire;
    [SerializeField] private Element m_targetElement = Element.Ice;
    [SerializeField, Range(0f, 1f)] private float m_critChance = 0.3f;

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

            string elemInfo = elemMult == DamageUtility.ElementBonus 
                ? "стихия х1,5" 
                : (elemMult == 0f ? "стихии совпали" : "без стихии");
            
            string critInfo = isCrit ? "крит х2" : "без крита";

            Debug.Log($"Удар {m_hitCount}: {dmg} урона ({elemInfo}, {critInfo})");
        }
    }
}