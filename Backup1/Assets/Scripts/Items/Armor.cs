using UnityEngine;
using System.Collections;
/// <summary>
/// ������� ����� �����
/// </summary>
class Armor : Item
{
    TypeOfArmor armorType;//��� �����
    PartOfArmor armorPart;//����� �����
    int phisicalDefence;//���� ���������� ������    
    int magicalDefence;//���� ���������� ������    
    int evasionModifier;//����������� �������
    int manaBonus;//����� ����
    int hpBonus;//����� ��������� �������
    int castingSpeedModifier;//����������� �������� �����
    
    #region ===��������===
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
    /// ������������ ��� ����������
    /// </summary>
    public Armor()
    {
    }
    /// <summary>
    /// ����������� � �����������
    /// </summary>
    /// <param name="name">�������� ����</param>
    /// <param name="type">��� ����</param>
    /// <param name="grade">����� ����</param>
    /// <param name="weight">���</param>
    /// <param name="price">����</param>
    /// <param name="description">��������</param>
    /// <param name="itemIcon">������ ����</param>
    /// <param name="armorType">��� �����</param>
    /// <param name="armorPart">����� �����</param>
    /// <param name="phisicalDefence">���� ���������� ������</param>
    /// <param name="magicalDefence">���� ���������� ������</param>
    /// <param name="evasionModifier">����������� �������</param>
    /// <param name="manaBonus">����� ����</param>
    /// <param name="hpBonus">����� ��������� �������</param>
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
    /// ������� ������� �������� ��������
    /// </summary>
    /// <returns></returns>
    public override string GetToolTip()
    {
        throw new System.NotImplementedException();
    }
}
/// <summary>
/// ��� �����
/// </summary>
enum TypeOfArmor
{
    Havy,
    Light,
    Robe
}
/// <summary>
/// ����� �����
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