using UnityEngine;
using System.Collections;

class QuestItem : Item
{
    public QuestItem()
    {
    }

    public QuestItem(string name, ItemType type, ItemGrade grade, int weight, int price, string description, Texture itemIcon)
    {
        this.Description = description;
        this.Grade = grade;
        this.ItemIcon = itemIcon;
        this.Name = name;
        this.Price = price;
        this.Type = type;
        this.Weight = weight;
    }
    public override string GetToolTip()
    {
        throw new System.NotImplementedException();
    }
}
