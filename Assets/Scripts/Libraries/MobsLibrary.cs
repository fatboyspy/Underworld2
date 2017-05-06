using UnityEngine;
using System.Collections;

public static class MobsLibrary {
	public static Mob[] mobs=new Mob[]
	{
		new Mob("Ant",MobRace.Bug,CreatureGender.Male,MobOccupation.Fighter,1,150,100,150,100,10,20,8,16,11,8,6,5,20,3,10,6,2,DropListLibrary.dropItems[0]),
        new Mob("Centaurus",MobRace.Humanoid,CreatureGender.Male,MobOccupation.Fighter,2,200,120,200,120,13,24,12,18,15,8,6,13,36,15,15,8,1,DropListLibrary.dropItems[0]),
        new Mob("DarkFencer",MobRace.Animal,CreatureGender.Male,MobOccupation.Fighter,1,150,100,150,100,10,20,8,16,11,8,6,5,20,3,10,6,2,DropListLibrary.dropItems[0]),
        new Mob("Lich",MobRace.Monster,CreatureGender.Male,MobOccupation.Fighter,2,200,120,200,120,13,24,12,18,15,8,6,13,36,15,15,8,4,DropListLibrary.dropItems[0]),
        new Mob("Lizardmen",MobRace.Humanoid,CreatureGender.Male,MobOccupation.Fighter,3,200,120,200,120,13,24,12,18,15,8,6,13,36,15,15,8,3,DropListLibrary.dropItems[0])
	};
    public static Mob GetMobByName(string mobName)
    {
        foreach(Mob m in mobs)
        {
            if (m.Name == mobName)
                return m;
        }
        return null;
    }
}
