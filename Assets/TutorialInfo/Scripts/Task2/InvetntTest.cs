using UnityEngine;

public class InventorTest : MonoBehaviour
{
    void Start()
    {
        Inventory inv = new Inventory();

        inv.AddItem("Меч");
        inv.AddItem("Щит");
        inv.AddItem("Меч");
        inv.AddItem("Щит");

        inv.RemoveItem("Лук");

        inv.AddItem("Зелье", 300);
        inv.RemoveItem("Зелье", 3);

        // проверяем переполнение слотов
        for (int i = 1; i <= 9; i++)
        {
            inv.AddItem("Предмет " + i);
        }

        inv.Print();
    }
}