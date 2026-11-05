using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private Dictionary<string, int> m_items = new Dictionary<string, int>();
    private int m_maxSlots = 10;

    public void AddItem(string item, int count = 1)
    {
        if (count <= 0) return;

        if (m_items.ContainsKey(item))
        {
            m_items[item] += count;
            Debug.Log("Добавлено: " + item + " х " + count);
            return;
        }

        if (m_items.Count >= m_maxSlots)
        {
            Debug.LogWarning("Нет места для " + item + ": занято " + m_items.Count + " из " + m_maxSlots);
            return;
        }

        m_items.Add(item, count);
        Debug.Log("Добавлено: " + item + " х " + count);
    }

    public void RemoveItem(string item, int count = 1)
    {
        if (count <= 0) return;

        if (!m_items.ContainsKey(item))
        {
            Debug.Log("Нельзя убрать " + item + ": его нет в инвентаре");
            return;
        }
         
        if (m_items[item] < count)
        {
            Debug.Log("Нельзя убрать " + item + ": нужно " + count + ", а есть только " + m_items[item]);
            return;
        }

        m_items[item] -= count;
        Debug.Log("Убрано: " + item + " х " + count);

        if (m_items[item] <= 0)
        {
            m_items.Remove(item);
        }
    }

    public void Print()
    {
        Debug.Log("Всё содержимое инвентаря");
        int total = 0;

        foreach (var pair in m_items)
        {
            Debug.Log(pair.Key + " х " + pair.Value);
            total += pair.Value;
        }

        Debug.Log("Занято " + m_items.Count + " из " + m_maxSlots + " (общее кол-во: " + total + ")");
    }
}