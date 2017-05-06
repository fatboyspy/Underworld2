using UnityEngine;
using System.Collections;

class Weapon : Item
{
    TypeOfWeapon weaponType;
    WeaponAttackSpeed attackSpeed;
    int phisicalAttack;
    int magicalAttack;
    int phisicalAttackRange;
    int accuracyModifier;
    int criticalModifier;
    int attackSpeedModifier;

    #region===свойства===
    internal TypeOfWeapon WeaponType
    {
        get { return weaponType; }
        set { weaponType = value; }
    }
    internal WeaponAttackSpeed AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }
    public int PhisicalAttack
    {
        get { return phisicalAttack; }
        set { phisicalAttack = value; }
    }
    public int MagicalAttack
    {
        get { return magicalAttack; }
        set { magicalAttack = value; }
    }
    public int PhisicalAttackRange
    {
        get { return phisicalAttackRange; }
        set { phisicalAttackRange = value; }
    }
    public int AccuracyModifier
    {
        get { return accuracyModifier; }
        set { accuracyModifier = value; }
    }
    public int CriticalModifier
    {
        get { return criticalModifier; }
        set { criticalModifier = value; }
    }
    public int AttackSpeedModifier
    {
        get { return attackSpeedModifier; }
        set { attackSpeedModifier = value; }
    }
    #endregion

    public Weapon()
    {
    }

    public Weapon (string name, ItemType type, ItemGrade grade, int weight, int price, string description, Texture itemIcon,TypeOfWeapon weaponType, WeaponAttackSpeed attackSpeed,int phisicalAttack, int magicalAttack,  int phisicalAttackRange, int accuracyModifier, int criticalModifier, int attackSpeedModifier)
    {
        this.Description = description;
        this.Grade = grade;
        this.ItemIcon = itemIcon;
        this.Name = name;
        this.Price = price;
        this.Type = type;
        this.Weight = weight;
        this.WeaponType = weaponType;
        this.AttackSpeed = attackSpeed;
        this.PhisicalAttack = phisicalAttack;
        this.MagicalAttack = magicalAttack;
        this.PhisicalAttackRange = phisicalAttackRange;
        this.AccuracyModifier = accuracyModifier;
        this.CriticalModifier = criticalModifier;
        this.AttackSpeedModifier = attackSpeedModifier;
    }
    public override string GetToolTip()
    {
        throw new System.NotImplementedException();
    }
}
enum TypeOfWeapon
{
    Dagger,
    Sword,
    Blunt,
    Polearm,
    Bow,
    Crossbow
}
enum WeaponAttackSpeed
{
    Slow,
    Normal,
    Fast
}
