using UnityEngine;
using System.Collections;

class Recipe : Item
{
    Hashtable components;

    #region ===свойства===
    public Hashtable Components
    {
        get { return components; }
        set { components = value; }
    }
    #endregion

    public Recipe()
    {
    }

    public Recipe(string name, ItemType type, ItemGrade grade, int weight, int price, string description, Texture itemIcon, Hashtable components)
    {
        this.Description = description;
        this.Grade = grade;
        this.ItemIcon = itemIcon;
        this.Name = name;
        this.Price = price;
        this.Type = type;
        this.Weight = weight;
        this.Components = components;
    }
    public override string GetToolTip()
    {
        throw new System.NotImplementedException();
    }
}
