using UnityEngine;
using System.Collections;
/// <summary>
/// Базовый класс для всех игровых созданий
/// </summary>

abstract class Creature
{
    string name;//имя существа
    CreatureGender gender;//пол
    int level;//уровень
    int healthPoints;//количество жизненной энергии
    int manaPoints;//количество маны
    int currentHealthPoints;//текущий уровень жизненной энергии
    int currentManaPoints;//текущий уровень маны
    int phisicalAttack;//физическая атака
    int phisicalDefence;//физическая защита
    int magicalAttack;//магическая атака
    int magicalDefence;//магическая защита
    int accuracy;//меткость
    int phisicalAttackSpeed;//скорость физической атаки
    int castingSpeed;//скорость колдовства(каст)
    int criticalChance;//шанс критической атаки
    int criticalAttackPower;//мощность критической атаки
    int evasion;//уворот
    int runSpeed;//скорость бега
    int walkSpeed;//скорость ходьбы
    int healthRegenPortion;//порция регенерации жизненной энергии    
    int manaRegenPortion;//порция регенерации маны
    float healthRegenSpeed;//скорость регенерации жизненной энергии
    float manaRegenSpeed;//скорость регенерации маны
   
    #region ===свойства===
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    internal CreatureGender Gender
    {
        get { return gender; }
        set { gender = value; }
    }
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    public int HealthPoints
    {
        get { return healthPoints; }
        set { healthPoints = value; }
    }
    public int ManaPoints
    {
        get { return manaPoints; }
        set { manaPoints = value; }
    }
    public int CurrentHealthPoints
    {
        get { return currentHealthPoints; }
        set { currentHealthPoints = value; }
    }
    public int CurrentManaPoints
    {
        get { return currentManaPoints; }
        set { currentManaPoints = value; }
    }
    public int PhisicalAttack
    {
        get { return phisicalAttack; }
        set { phisicalAttack = value; }
    }
    public int PhisicalDefence
    {
        get { return phisicalDefence; }
        set { phisicalDefence = value; }
    }
    public int MagicalAttack
    {
        get { return magicalAttack; }
        set { magicalAttack = value; }
    }
    public int MagicalDefence
    {
        get { return magicalDefence; }
        set { magicalDefence = value; }
    }
    public int Accuracy
    {
        get { return accuracy; }
        set { accuracy = value; }
    }
    public int PhisicalAttackSpeed
    {
        get { return phisicalAttackSpeed; }
        set { phisicalAttackSpeed = value; }
    }
    public int CastingSpeed
    {
        get { return castingSpeed; }
        set { castingSpeed = value; }
    }
    public int CriticalChance
    {
        get { return criticalChance; }
        set { criticalChance = value; }
    }
    public int CriticalAttackPower
    {
        get { return criticalAttackPower; }
        set { criticalAttackPower = value; }
    }
    public int Evasion
    {
        get { return evasion; }
        set { evasion = value; }
    }
    public int RunSpeed
    {
        get { return runSpeed; }
        set { runSpeed = value; }
    }
    public int WalkSpeed
    {
        get { return walkSpeed; }
        set { walkSpeed = value; }
    }
    public int HealthRegenPortion
    {
        get { return healthRegenPortion; }
        set { healthRegenPortion = value; }
    }
    public int ManaRegenPortion
    {
        get { return manaRegenPortion; }
        set { manaRegenPortion = value; }
    }
    public float HealthRegenSpeed
    {
        get { return healthRegenSpeed; }
        set { healthRegenSpeed = value; }
    }
    public float ManaRegenSpeed
    {
        get { return manaRegenSpeed; }
        set { manaRegenSpeed = value; }
    }

    #endregion
}
/// <summary>
/// Пол создания
/// </summary>
public enum CreatureGender
{
    Female,
    Male
    
}
