using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Класс списка дропа предметов
/// </summary>
public class DropList
{
    Drop[] items;//массив дропа

    #region ===свойства===
    internal Drop[] Items
    {
        get { return items; }
        set { items = value; }
    } 
    #endregion
    /// <summary>
    /// Конструктор без параметров
    /// </summary>
    public DropList()
    {
    }
    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="items">Массив дропа</param>
    public DropList(Drop[] items)
    {
        this.items = items;
    }
}
