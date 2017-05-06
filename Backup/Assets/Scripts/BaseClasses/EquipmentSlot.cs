using UnityEngine;
using System.Collections;
/// <summary>
/// ����� ����� ����������
/// </summary>
class EquipmentSlot
{
    bool isEmpty;//������ �� ����
    Item equipedItem;//������� � �����
    TypeOfEquipmentSlot slotType;//��� �����
    /// <summary>
    /// ����������� �����
    /// </summary>
    /// <param name="isEmpty">������ �� ����</param>
    /// <param name="equipedItem">������� � �����</param>
    /// <param name="slotType">��� �����</param>
    public EquipmentSlot(bool isEmpty, Item equipedItem, TypeOfEquipmentSlot slotType)
    {
        this.isEmpty = isEmpty;
        this.equipedItem = equipedItem;
        this.slotType = slotType;
    }

    #region ===��������===
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
/// ���� ������ ����������
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

