using UnityEngine;
using System.Collections;
/// <summary>
/// Класс слота экипировки
/// </summary>
class EquipmentSlot
{
    bool isEmpty;//пустой ли слот
    Item equipedItem;//предмет в слоте
    TypeOfEquipmentSlot slotType;//тип слота
    /// <summary>
    /// Конструктор слота
    /// </summary>
    /// <param name="isEmpty">Пустой ли слот</param>
    /// <param name="equipedItem">Предмет в слоте</param>
    /// <param name="slotType">Тип слота</param>
    public EquipmentSlot(bool isEmpty, Item equipedItem, TypeOfEquipmentSlot slotType)
    {
        this.isEmpty = isEmpty;
        this.equipedItem = equipedItem;
        this.slotType = slotType;
    }

    #region ===свойства===
    public bool IsEmpty
    {
        get { return isEmpty; }
        set { isEmpty = value; }
    }
    public Item EquipedItem
    {
        get { return equipedItem; }
        set { equipedItem = value; }
    }
    internal TypeOfEquipmentSlot SlotType
    {
        get { return slotType; }
    } 
    #endregion
}
/// <summary>
/// Типы слотов экипировки
/// </summary>
enum TypeOfEquipmentSlot
{
    HeadSlot,
    BreastSlot,
    LegginsSlot,
    FootSlot,
    ArmSlot,
    WeaponSlot,
    ShieldSlot,
    NecklaceSlot,
    LeftRingSlot,
    RightRingSlot,
    LeftEarringSlot,
    RightEarringSlot
}

