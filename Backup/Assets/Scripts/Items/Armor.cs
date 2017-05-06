using UnityEngine;
using System.Collections;
/// <summary>
/// Базовый класс брони
/// </summary>
class Armor : Item
{
    TypeOfArmor armorType;//тип брони
    PartOfArmor armorPart;//часть брони
    int phisicalDefence;//очки физической защиты    
    int magicalDefence;//очки магической защиты    
    int evasionModifier;//модификатор уворота
    int manaBonus;//бонус маны
    int hpBonus;//бонус жизненной енергии
    int castingSpeedModifier;//модификатор скорости каста
    
    #region ===свойства===
    internal TypeOfArmor ArmorType
    {
        get { return armorType; }
        set { armorType = value; }
    }
    internal PartOfArmor ArmorPart
    {
        get { return armorPart; }
        set { armorPart = value; }
    }
    public int PhisicalDefence
    {
        get { return phisicalDefence; }
        set { phisicalDefence = value; }
    }
    public int MagicalDefence
    {
        get { return magicalDefence; }
        set { magicalDefence = value; }
    }
    public int EvasionModifier
    {
        get { return evasionModifier; }
        set { evasionModifier = value; }
    }
    public int ManaBonus
    {
        get { return manaBonus; }
        set { manaBonus = value; }
    }
    public int HpBonus
    {
        get { return hpBonus; }
        set { hpBonus = value; }
    }
    public int CastingSpeedModifier
    {
        get { return castingSpeedModifier; }
        set { castingSpeedModifier = value; }
    }
    #endregion

    /// <summary>
    /// Констрруктор без параметров
    /// </summary>
    public Armor()
    {
    }
    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="name">Название вещи</param>
    /// <param name="type">Тип вещи</param>
    /// <param name="grade">Грейд вещи</param>
    /// <param name="weight">Вес</param>
    /// <param name="price">Цена</param>
    /// <param name="description">Описание</param>
    /// <param name="itemIcon">Иконка вещи</param>
    /// <param name="armorType">Тип брони</param>
    /// <param name="armorPart">Часть брони</param>
    /// <param name="phisicalDefence">Очки физической защиты</param>
    /// <param name="magicalDefence">Очки магической защиты</param>
    /// <param name="evasionModifier">Модификатор уворота</param>
    /// <param name="manaBonus">Бонус маны</param>
    /// <param name="hpBonus">Бонус жизненной энергии</param>
    public Armor(string name, ItemType type, ItemGrade grade, int weight, int price, string description, Texture itemIcon, TypeOfArmor armorType, PartOfArmor armorPart, int phisicalDefence, int magicalDefence, int evasionModifier, int manaBonus, int hpBonus)
    {
        this.ArmorPart = armorPart;
        this.ArmorType = armorType;
        this.Description = description;
        this.EvasionModifier = evasionModifier;
        this.Grade = grade;
        this.ItemIcon = itemIcon;
        this.MagicalDefence = magicalDefence;
        this.Name = name;
        this.PhisicalDefence = phisicalDefence;
        this.Price = price;
        this.Type = type;
        this.Weight = weight;
        this.ManaBonus = manaBonus;
        this.HpBonus = hpBonus;
    }
    /// <summary>
    /// Функция задания описания предмета
    /// </summary>
    /// <returns></returns>
    public override string GetToolTip()
    {
        throw new System.NotImplementedException();
    }
}
/// <summary>
/// Тип брони
/// </summary>
enum TypeOfArmor
{
    Havy,
    Light,
    Robe
}
/// <summary>
/// Часть брони
/// </summary>
enum PartOfArmor
{
    Helmet,
    BreastPlate,
    Gaiters,
    Guntlets,
    Boots,
    Shield
}