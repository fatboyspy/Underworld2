using UnityEngine;
using System.Collections;

/// <summary>
/// Базовый класс предметов
/// </summary>
abstract class Item
{
    string name;    
    ItemType type;    
    ItemGrade grade;    
    int weight;    
    int price;    
    string description;
    Texture itemIcon;
    
    #region ===свойства===
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    internal ItemType Type
    {
        get { return type; }
        set { type = value; }
    }
    internal ItemGrade Grade
    {
        get { return grade; }
        set { grade = value; }
    }
    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }
    public int Price
    {
        get { return price; }
        set { price = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public Texture ItemIcon
    {
        get { return itemIcon; }
        set { itemIcon = value; }
    }
    #endregion
    /// <summary>
    /// Функция возвращает описание предмета
    /// </summary>
    /// <returns></returns>
    public abstract string GetToolTip();
    /// <summary>
    /// Перегрузка оператора "=="
    /// </summary>
    /// <param name="source"></param>
    /// <param name="example"></param>
    /// <returns></returns>    
    public static bool operator ==(Item source, Item example)
    {
        return (source.Name==example.Name);
    }
    /// <summary>
    /// Перегрузка оператора "!="
    /// </summary>
    /// <param name="source"></param>
    /// <param name="example"></param>
    /// <returns></returns>
    public static bool operator !=(Item source, Item example)
    {
        return (source.Name != example.Name);
    } 
    /// <summary>
    /// Перегрузка оператора "Equals"
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (this.Name == ((Item)obj).Name)
            return true;
        else
            return false;
    }
}
/// <summary>
/// Тип предмета
/// </summary>
enum ItemType
{    
    Armor,
    Consumable,
    Jewelry,
    Recipe,
    Weapon,    
    Potion,
    QuestItem
}
/// <summary>
/// Уровень предмета
/// </summary>
enum ItemGrade
{
    NoGrade,
    LowGrade,
    MiddleGrade,
    HightGrade,
    HigestGrade
}
