using UnityEngine;
using System.Collections;

class Potion : Item
{
    int healthEffect;
    int manaEffect;

    #region===свойства===
    public int HealthEffect
    {
        get { return healthEffect; }
        set { healthEffect = value; }
    }
    public int ManaEffect
    {
        get { return manaEffect; }
        set { manaEffect = value; }
    }
    #endregion

    public Potion()
    {
    }

    public Potion(string name, ItemType type, ItemGrade grade, int weight, int price, string description, Texture itemIcon,int healthEffect, int manaEffect)
    {
        this.Description = description;
        this.Grade = grade;
        this.ItemIcon = itemIcon;
        this.Name = name;
        this.Price = price;
        this.Type = type;
        this.Weight = weight;
        this.HealthEffect = healthEffect;
        this.ManaEffect = manaEffect;
    }
    public override string GetToolTip()
    {
        throw new System.NotImplementedException();
    }
}
