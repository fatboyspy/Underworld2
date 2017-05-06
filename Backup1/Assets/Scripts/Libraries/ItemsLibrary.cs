using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ItemsLibrary {
	static public Item[] items=new Item[]
	{
		new Consumable("Gold",ItemType.Consumable,ItemGrade.NoGrade,0,0,"Game money",new Texture()),
		new Armor("DarkAdmor",ItemType.Armor,ItemGrade.LowGrade,13000,234190,"Armor of dark age",new Texture(),TypeOfArmor.Havy,PartOfArmor.BreastPlate,23,19,2,0,0)
	};
}
