using UnityEngine;
using System.Collections;

class Jewelry:Item
{
    int magicalDefence;
    int manaBonus;
    TypeOfJewelry jewelryType;   

    #region ===свойства===
    public int MagicalDefence
    {
        get { return magicalDefence; }
        set { magicalDefence = value; }
    }
    public int ManaBonus
    {
        get { return manaBonus; }
        set { manaBonus = value; }
    }
    internal TypeOfJewelry JewelryType
    {
        get { return jewelryType; }
        set { jewelryType = value; }
    }
    #endregion

    public override string GetToolTip()
    {
        throw new System.NotImplementedException();
    }
}
enum TypeOfJewelry
{
    Necklace,
    Earring,
    Ring
}
