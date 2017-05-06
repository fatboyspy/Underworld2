using UnityEngine;
using System.Collections;
/// <summary>
/// Клас дропа предметов
/// </summary>
class Drop
{
    Item dropItem;//предмет    
    int dropCount;//максимальное количество дропа
    double dropChance;//шанс дропа

    #region ===свойства===
    public Item DropItem
    {
        get { return dropItem; }
        set { dropItem = value; }
    }
    public int DropCount
    {
        get { return dropCount; }
        set { dropCount = value; }
    }
    public double DropChance
    {
        get { return dropChance; }
        set { dropChance = value; }
    } 
    #endregion
    /// <summary>
    /// Конструктор без параметров
    /// </summary>
    public Drop()
    {
    }
    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="dropItem">Предмет</param>
    /// <param name="dropCount">Максимальное количество дропа</param>
    /// <param name="dropChance">Шанс дропа</param>
    public Drop(Item dropItem, int dropCount, double dropChance)
    {
        this.dropItem = dropItem;
        this.dropCount = dropCount;
        this.dropChance = dropChance;
    }
}
