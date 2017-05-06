using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ItemsLibrary {
	static public Item[] items=new Item[]
	{
		new Consumable("Gold",ItemType.Consumable,ItemGrade.NoGrade,0,0,"Game money",(Texture)Resources.Load("Textures/ItemsTextures/adena")),
		new Weapon("DragonSlayer",ItemType.Weapon,ItemGrade.HightGrade,3200,234190,"Two handed sword",(Texture)Resources.Load("Textures/ItemsTextures/DragonSlayer"),TypeOfWeapon.Polearm,WeaponAttackSpeed.Normal,15,12,2,3,2,2),
        new Weapon("Katana",ItemType.Weapon,ItemGrade.MiddleGrade,1760,127200,"Samurai sword",(Texture)Resources.Load("Textures/ItemsTextures/Katana"),TypeOfWeapon.Sword,WeaponAttackSpeed.Fast,14,11,2,3,2,2)
	};
}
