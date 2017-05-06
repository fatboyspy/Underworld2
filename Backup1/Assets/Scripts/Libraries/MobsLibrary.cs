using UnityEngine;
using System.Collections;

public static class MobsLibrary {
	public static Mob[] mobs=new Mob[]
	{
		new Mob("Ant",MobRace.Bug,CreatureGender.Male,MobOccupation.Fighter,1,150,100,150,100,10,20,8,16,11,8,6,5,20,3,10,6,8,DropListLibrary.dropItems[0])
	};
	
}
