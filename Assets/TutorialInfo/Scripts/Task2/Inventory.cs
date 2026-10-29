using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private Dictionary<string, int> items = new Dictionary<string, int>();
    private int maxSlots = 10;

    public void AddItem(string item, int count = 1)
    {
        if (items.ContainsKey(item))
        {
            items[item] += count;
            Debug.Log("Добавлено: " + item + " х " + count);
            return;
        }

        if (items.Count >= maxSlots)
        {
            Debug.LogWarning("Нет места для " + item + ": занято " + items.Count + " из " + maxSlots);
            return;
        }

        items.Add(item, count);
        Debug.Log("Добавлено: " + item + " х " + count);
    }

    public void RemoveItem(string item, int count = 1)
    {
        if (!items.ContainsKey(item))
        {
            Debug.Log("Нельзя убрать " + item + ": его нет в инвентаре");
            return;
        }
        //пытаемся удалить больше чем есть 
        if (items[item] < count)
        {
            Debug.Log("Нельзя убрать " + item + ": нужно " + count + ", а есть только " + items[item]);
            return;
        }

        items[item] -= count;
        Debug.Log("Убрано: " + item + " х " + count);

        // удаляем слот, если предметов не осталось
        if (items[item] <= 0)
        {
            items.Remove(item);
        }
    }

    public void Print()
    {
        Debug.Log("Всё содержимое инвентаря");
        int total = 0;

        foreach (var pair in items)
        {
            Debug.Log(pair.Key + " х " + pair.Value);
            total += pair.Value;
        }

        Debug.Log("Занято " + items.Count + " из " + maxSlots + " (общее кол-во: " + total + ")");
    }
}