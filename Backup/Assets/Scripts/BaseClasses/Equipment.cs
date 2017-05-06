using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Класс екипировки персонажа
/// </summary>
class Equipment
{
    EquipmentSlot[] equipmentList;//массив слотов екипировки

    #region ===свойства===
    internal EquipmentSlot[] EquipmentList
    {
        get { return equipmentList; }
        set { equipmentList = value; }
    } 
    #endregion
    /// <summary>
    /// Конструктор без параметров
    /// </summary>
    public Equipment()
    {
        equipmentList = new EquipmentSlot[12];
        equipmentList[0] = new EquipmentSlot(true, null, TypeOfEquipmentSlot.HeadSlot);
        equipmentList[1] = new EquipmentSlot(true, null, TypeOfEquipmentSlot.BreastSlot);
        equipmentList[2] = new EquipmentSlot(true, null, TypeOfEquipmentSlot.LegginsSlot);
        equipmentList[3] = new EquipmentSlot(true, null, TypeOfEquipmentSlot.FootSlot);
        equipmentList[4] = new EquipmentSlot(true, null, TypeOfEquipmentSlot.ArmSlot);
        equipmentList[5] = new EquipmentSlot(true, null, TypeOfEquipmentSlot.WeaponSlot);
        equipmentList[6] = new EquipmentSlot(true, null, TypeOfEquipmentSlot.ShieldSlot);
        equipmentList[7] = new EquipmentSlot(true, null, TypeOfEquipmentSlot.NecklaceSlot);
        equipmentList[8] = new EquipmentSlot(true, null, TypeOfEquipmentSlot.LeftRingSlot);
        equipmentList[9] = new EquipmentSlot(true, null, TypeOfEquipmentSlot.RightRingSlot);
        equipmentList[10] = new EquipmentSlot(true, null, TypeOfEquipmentSlot.LeftEarringSlot);
        equipmentList[11] = new EquipmentSlot(true, null, TypeOfEquipmentSlot.RightEarringSlot);
    }
    /// <summary>
    /// Функция добавления предмета в екипировку
    /// </summary>
    /// <param name="gamer">Игрок</param>
    /// <param name="item">Предмет</param>
    public void AddItem(Gamer gamer, Item item)
    {
        switch (item.Type)
        {
            case ItemType.Armor:
                AddArmor(gamer, item);
                break;
            case ItemType.Jewelry:
                AddJewelry(gamer, item);
                break;
            case ItemType.Weapon:
                AddWeapon(gamer, item);
                break;
        }
        int p_attack_mod = 0;
        int m_attack_mod = 0;
        int p_defence_mod = 0;
        int m_defence_mod = 0;
        int accuracy_mod = 0;
        int p_attack_spd_mod = 0;
        int casting_spd_mod = 0;
        int critical_chance_mod = 0;
        int evasion_mod = 0;
        int hp_mod = 0;
        int mp_mod = 0;
        foreach(EquipmentSlot eqSlot in equipmentList)
        {
            switch (eqSlot.SlotType)
            {
                case TypeOfEquipmentSlot.ArmSlot:
                case TypeOfEquipmentSlot.BreastSlot:
                case TypeOfEquipmentSlot.FootSlot:
                case TypeOfEquipmentSlot.HeadSlot:
                case TypeOfEquipmentSlot.LegginsSlot:
                case TypeOfEquipmentSlot.ShieldSlot:
                    p_defence_mod += ((Armor)item).PhisicalDefence;
                    m_defence_mod += ((Armor)item).MagicalDefence;
                    evasion_mod += ((Armor)item).EvasionModifier;
                    hp_mod += ((Armor)item).HpBonus;
                    mp_mod += ((Armor)item).ManaBonus;
                    casting_spd_mod += ((Armor)item).CastingSpeedModifier;
                    break;
                case TypeOfEquipmentSlot.WeaponSlot:
                    p_attack_mod+=((Weapon)item).PhisicalAttack;
                    m_attack_mod+=((Weapon)item).MagicalAttack;
                    accuracy_mod += ((Weapon)item).AccuracyModifier;
                    p_attack_spd_mod += ((Weapon)item).AttackSpeedModifier;
                    critical_chance_mod += ((Weapon)item).CriticalModifier;
                    break;
                case TypeOfEquipmentSlot.LeftEarringSlot:
                case TypeOfEquipmentSlot.LeftRingSlot:
                case TypeOfEquipmentSlot.NecklaceSlot:
                case TypeOfEquipmentSlot.RightEarringSlot:
                case TypeOfEquipmentSlot.RightRingSlot:
                    m_defence_mod += ((Jewelry)item).MagicalDefence;
                    mp_mod += ((Jewelry)item).ManaBonus;
                    break;
            }
        }
        gamer.CalculateStats(p_attack_mod, m_attack_mod, p_defence_mod, m_defence_mod, accuracy_mod, p_attack_spd_mod, casting_spd_mod, critical_chance_mod, evasion_mod, hp_mod, mp_mod);
    }
    /// <summary>
    /// Функция добавления элементов брони
    /// </summary>
    /// <param name="gamer">Игрок</param>
    /// <param name="item">Предмет</param>
    private void AddArmor(Gamer gamer, Item item)
    {
        gamer.PhisicalDefence += ((Armor)item).PhisicalDefence;
        switch (((Armor)item).ArmorPart)
        {
            case PartOfArmor.Boots:
                RemoveItem(gamer, 3);
                equipmentList[3].EquipedItem = item;
                equipmentList[3].IsEmpty = false;
                break;
            case PartOfArmor.BreastPlate:
                RemoveItem(gamer, 1);
                equipmentList[1].EquipedItem = item;
                equipmentList[1].IsEmpty = false;
                break;
            case PartOfArmor.Gaiters:
                RemoveItem(gamer, 2);
                equipmentList[2].EquipedItem = item;
                equipmentList[2].IsEmpty = false;
                break;
            case PartOfArmor.Guntlets:
                RemoveItem(gamer, 4);
                equipmentList[4].EquipedItem = item;
                equipmentList[4].IsEmpty = false;
                break;
            case PartOfArmor.Helmet:
                RemoveItem(gamer, 0);
                equipmentList[0].EquipedItem = item;
                equipmentList[0].IsEmpty = false;
                break;
            case PartOfArmor.Shield:
                RemoveItem(gamer, 6);
                equipmentList[6].EquipedItem = item;
                equipmentList[6].IsEmpty = false;
                break;
        }
    }
    /// <summary>
    /// Функция добавления бижутерии
    /// </summary>
    /// <param name="gamer">Игрок</param>
    /// <param name="item">Предмет</param>
    private void AddJewelry(Gamer gamer, Item item)
    {
        switch (((Jewelry)item).JewelryType)
        {
            case TypeOfJewelry.Earring:
                if (equipmentList[10].IsEmpty)
                {
                    equipmentList[10].EquipedItem = item;
                    equipmentList[10].IsEmpty = false;
                }
                else
                {
                    RemoveItem(gamer, 11);
                    equipmentList[11].EquipedItem = item;
                    equipmentList[11].IsEmpty = false;
                }
                break;
            case TypeOfJewelry.Necklace:
                RemoveItem(gamer, 7);
                equipmentList[7].EquipedItem = item;
                equipmentList[7].IsEmpty = false;
                break;
            case TypeOfJewelry.Ring:
                if (equipmentList[8].IsEmpty)
                {
                    equipmentList[8].EquipedItem = item;
                    equipmentList[8].IsEmpty = false;
                }
                else
                {
                    RemoveItem(gamer, 9);
                    equipmentList[9].EquipedItem = item;
                    equipmentList[9].IsEmpty = false;
                }
                break;
        }
    }
    /// <summary>
    /// Функция добавления Оружия
    /// </summary>
    /// <param name="gamer">Игрок</param>
    /// <param name="item">Предмет</param>
    private void AddWeapon(Gamer gamer, Item item)
    {
        RemoveItem(gamer, 11);
        equipmentList[5].EquipedItem = item;
        equipmentList[5].IsEmpty = false;
    }
    /// <summary>
    /// Функция удаления предмета из экипировки
    /// </summary>
    /// <param name="gamer">Игрок</param>
    /// <param name="item">Предмет</param>
    public void RemoveItem(Gamer gamer, Item item)
    {
        foreach (EquipmentSlot es in equipmentList)
        {
            if (es.EquipedItem == item)
            {
                gamer.Inventory.AddItem(item);
                es.IsEmpty = true;
                es.EquipedItem = null;
                break;
            }
        }
    }
    /// <summary>
    /// Функция удаления предмета из экипировки
    /// </summary>
    /// <param name="gamer">Игрок</param>
    /// <param name="slotIndex">Индекс слота экипировки</param>
    public void RemoveItem(Gamer gamer, int slotIndex)
    {
        if (!equipmentList[slotIndex].IsEmpty)
        {
            Item item=equipmentList[slotIndex].EquipedItem;
            equipmentList[slotIndex].IsEmpty = true;
            equipmentList[slotIndex].EquipedItem = null;
            gamer.Inventory.AddItem(item);
        }
    }
}