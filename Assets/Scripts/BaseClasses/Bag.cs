using UnityEngine;
using System.Collections;
/// <summary>
/// Инвентарь персонажа
/// </summary>
public class Bag
{
    /// <summary>
    /// Хеш-таблица с вещами
    /// </summary>
    Hashtable items;
    int capacity;   

    #region===свойства===
    public Hashtable Items
    {
        get { return items; }
        set { items = value; }
    } 
    public int Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }
    #endregion

    /// <summary>
    /// Конструктор без параметров
    /// </summary>
    public Bag()
    {
        items = new Hashtable();
    }
    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="capacity">Вмистимость инвентаря</param>
    public Bag(int capacity)
    {
        this.capacity = capacity;
        items = new Hashtable(capacity);
    }
    /// <summary>
    /// Добавить вещь в инвентарь
    /// </summary>
    /// <param name="item">Вещь</param>
    public void AddItem(Item item)
    {
        items.Add(item, 1);
    }
    /// <summary>
    /// Убрать вещь из инвентаря
    /// </summary>
    /// <param name="item">Вещь</param>
    public void RemoveItem(Item item)
    {
    }
    /// <summary>
    /// Уничтожить вещь
    /// </summary>
    /// <param name="item">Вещь</param>
    public void DestroyItem(Item item)
    {
    }
    /// <summary>
    /// Выбросить вещь
    /// </summary>
    /// <param name="item">Вещь</param>
    public void DropItem(Item item)
    {
    }
}
