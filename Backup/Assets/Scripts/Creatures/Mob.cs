using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class Mob : Creature
{
    MobRace race;    
    MobOccupation occupation;    
    int expirienceForKill;
    DropList loot;  

    public Mob(string name,MobRace race,CreatureGender gender,MobOccupation occupation,int level, int healthPoints,int manaPoints,int currentHealthPoints,int currentManaPoints, int phisicalAttack,int phisicalDefence,int magicalAttack,int magicalDefence,int accuracy,int phisicalAttackSpeed,int castingSpeed,int criticalChance,int criticalAttackPower,int evasion, int runSpeed, int walkSpeed, int expirienceForKill,DropList loot)
    {
        Name = name;
        Race = race;
        Gender = gender;
        Occupation = occupation;
        Level = level;
        HealthPoints = healthPoints;
        ManaPoints = manaPoints;
        CurrentHealthPoints = currentHealthPoints;
        CurrentManaPoints = currentManaPoints;
        PhisicalAttack = phisicalAttack;
        PhisicalDefence = phisicalDefence;
        MagicalAttack = magicalAttack;
        MagicalDefence = magicalDefence;
        Accuracy = accuracy;
        PhisicalAttackSpeed = phisicalAttackSpeed;
        CastingSpeed = castingSpeed;
        CriticalChance = criticalChance;
        CriticalAttackPower = criticalAttackPower;
        Evasion = evasion;
        RunSpeed = runSpeed;
        WalkSpeed = walkSpeed;
        ManaRegenPortion = 5;
        ManaRegenSpeed = 0.8f;
        HealthRegenPortion = 5;
        HealthRegenSpeed = 0.8f;
        this.expirienceForKill=expirienceForKill;
        this.loot = loot;     
    }
    public MobOccupation Occupation
    {
        get { return occupation; }
        set { occupation = value; }
    }
    internal MobRace Race
    {
        get { return race; }
        set { race = value; }
    }
    public int ExpirienceForKill
    {
        get { return expirienceForKill; }
        set { expirienceForKill = value; }
    } 

    public DropList Loot
    {
        get { return loot; }
        set { loot = value; }
    }
}
/// <summary>
/// Раса моба
/// </summary>
enum MobRace
{
    Animal,
    Undead,
    Plant
}
/// <summary>
/// Профессия моба
/// </summary>
public enum MobOccupation
{
    Fighter,
    Mystic
}
