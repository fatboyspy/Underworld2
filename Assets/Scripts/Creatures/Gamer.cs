using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Класс игрока
/// </summary>

public class Gamer : Creature
{
    PlayerRace race;
    PlayerOccupation occupation;
    int strength;//сила
    int constitution;//здоровье
    int dextirity;//ловкость
    int intelligence;//интеллект
    int wisdom;//смекалка
    int mentalStrength;//мудрость
    int charisma;//привлекательность
    int maxLoad;//максимальный переносимый персонажем вес
    int currentLoad;//текущий вес инвентаря
    int expirience;//опыт персонажа
    int expirienceToLevelUp;//количество опыта для повышения уровня
    int skillPoint;//баллы для изучения умений
    double levelModifier;//модификатор уровня
    Bag inventory;
    Equipment outfit;

    #region ===свойства===
    public PlayerOccupation Occupation
    {
        get { return occupation; }
        set { occupation = value; }
    }
    internal PlayerRace Race
    {
        get { return race; }
        set { race = value; }
    }
    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }
    public int Constitution
    {
        get { return constitution; }
        set { constitution = value; }
    }
    public int Dextirity
    {
        get { return dextirity; }
        set { dextirity = value; }
    }
    public int Intelligence
    {
        get { return intelligence; }
        set { intelligence = value; }
    }
    public int Wisdom
    {
        get { return wisdom; }
        set { wisdom = value; }
    }
    public int MentalStrength
    {
        get { return mentalStrength; }
        set { mentalStrength = value; }
    }
    public int Charisma
    {
        get { return charisma; }
        set { charisma = value; }
    }
    public int MaxLoad
    {
        get { return maxLoad; }
        set { maxLoad = value; }
    }
    public int CurrentLoad
    {
        get { return currentLoad; }
        set { currentLoad = value; }
    }
    public int Expirience
    {
        get { return expirience; }
        set { expirience = value; }
    }
    public int ExpirienceToLevelUp
    {
        get { return expirienceToLevelUp; }
        set { expirienceToLevelUp = value; }
    }
    public int SkillPoint
    {
        get { return skillPoint; }
        set { skillPoint = value; }
    }
    public double LevelModifier
    {
        get { return levelModifier; }
        set { levelModifier = value; }
    }
    public Bag Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }
    public Equipment Outfit
    {
        get { return outfit; }
        set { outfit = value; }
    }
    #endregion

    /// <summary>
    /// Конструктор без параметров
    /// </summary>
    /// 
    public Gamer()
    {
    }

    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="name">Имя персонажа</param>
    /// <param name="race">Раса</param>
    /// <param name="gender">Пол</param>
    /// <param name="occupation">Специализация</param>
    /// <param name="level">Уровень</param>
    /// <param name="strength">Сила</param>
    /// <param name="constitution">Злоровье</param>
    /// <param name="dextirity">Ловкость</param>
    /// <param name="intelligence">Интеллект</param>
    /// <param name="Wisdom">Смекалка</param>
    /// <param name="mentalStrength">Мудрость</param>
    /// <param name="charisma">Харизма</param>    
    public Gamer(string name, PlayerRace race, CreatureGender gender, PlayerOccupation occupation, int level, int strength, int constitution, int dextirity, int intelligence, int wisdom, int mentalStrength, int charisma)
    {
        Name = name;
        Race = race;
        Gender = gender;
        Occupation = occupation;
        Level = level;
        Strength = strength;
        Constitution = constitution;
        Dextirity = dextirity;
        Intelligence = intelligence;
        Wisdom = wisdom;
        MentalStrength = mentalStrength;
        Charisma = charisma;
        LevelModifier = 1.58;
        ManaRegenPortion = 5;
        ManaRegenSpeed = 0.8f;
        HealthRegenPortion = 5;
        HealthRegenSpeed = 0.13f;
        Expirience = 1;
        if (Occupation == PlayerOccupation.Mystic)
        {
            Inventory = new Bag(80);
        }
        if (Occupation == PlayerOccupation.Fighter && Race != PlayerRace.Dwarf)
        {
            Inventory = new Bag(100);
        }
        else
            Inventory = new Bag(120);
        Outfit = new Equipment();
        CalculateStats();
    }

    /// <summary>
    /// Пересчет характеристик
    /// </summary>
    public void CalculateStats()
    {
        HealthPoints = (Constitution + Level) * 10;
        ManaPoints = (MentalStrength + Level) * 10;
        CurrentHealthPoints = (int)(HealthPoints * 0.5);
        CurrentManaPoints = (int)(ManaPoints * 0.5);
        PhisicalAttack = Strength * 10;
        PhisicalDefence = (int)(Constitution * 0.5 * Strength * 0.5);
        MagicalAttack = Intelligence * 10;
        MagicalDefence = (int)(MentalStrength * 0.5 * Intelligence * 0.5);
        Accuracy = (int)(Dextirity * 0.98);
        PhisicalAttackSpeed = (int)(Strength * 0.63 * Dextirity * 0.5);
        CastingSpeed = (int)(Intelligence * 0.63 * Wisdom * 0.5);
        CriticalChance = (int)(Strength * 0.21 * Dextirity * 0.72);
        CriticalAttackPower = (int)(PhisicalAttack * 1.58);
        Evasion = (int)(Dextirity * 0.85);
        RunSpeed = (int)(Strength * 0.43 * Dextirity * 0.94);
        WalkSpeed = (int)(RunSpeed * 0.33);
        ExpirienceToLevelUp = (int)(Level * 10 * LevelModifier);
        MaxLoad = (int)(Constitution * Strength * 334);
        CalculateCurrentLoad();
    }

    /// <summary>
    /// Пересчет характеристик
    /// </summary>
    /// <param name="p_attack_mod">Модификатор физической атаки</param>
    /// <param name="m_attack_mod">Модификатор магической атаки</param>
    /// <param name="p_defence_mod">Модификатор физической защиты</param>
    /// <param name="m_defence_mod">Модификатор магической защиты</param>
    /// <param name="accuracy_mod">Модификатор точности</param>
    /// <param name="p_attack_spd_mod">Модификатор скорости атаки</param>
    /// <param name="casting_spd_mod">Модификатор скорости каста</param>
    /// <param name="critical_chance_mod">Модификатор шанса критического урона</param>
    /// <param name="evasion_mod">Модификатор уворота</param>
    /// <param name="hp_mod">Модификатор уровня жизненной энергии</param>
    /// <param name="mp_mod">Модификатор уровня маны</param>
    public void CalculateStats(int p_attack_mod, int m_attack_mod, int p_defence_mod, int m_defence_mod, int accuracy_mod, int p_attack_spd_mod, int casting_spd_mod, int critical_chance_mod, int evasion_mod, int hp_mod, int mp_mod)
    {
        HealthPoints = (Constitution + Level) * 10 + hp_mod;
        ManaPoints = (MentalStrength + Level) * 10 + mp_mod;
        PhisicalAttack = Strength * 10 + p_attack_mod;
        PhisicalDefence = (int)(Constitution * 0.5 * Strength * 0.5) + p_defence_mod;
        MagicalAttack = Intelligence * 10 + m_attack_mod;
        MagicalDefence = (int)(MentalStrength * 0.5 * Intelligence * 0.5) + m_defence_mod;
        Accuracy = (int)(Dextirity * 0.98) + accuracy_mod;
        PhisicalAttackSpeed = (int)(Strength * 0.63 * Dextirity * 0.5) + p_attack_spd_mod;
        CastingSpeed = (int)(Intelligence * 0.63 * Wisdom * 0.5) + casting_spd_mod;
        CriticalChance = (int)(Strength * 0.21 * Dextirity * 0.72) + critical_chance_mod;
        CriticalAttackPower = (int)(PhisicalAttack * 1.58);
        Evasion = (int)(Dextirity * 0.85) + evasion_mod;
        RunSpeed = (int)(Strength * 0.43 * Dextirity * 0.94);
        WalkSpeed = (int)(RunSpeed * 0.33);
        ExpirienceToLevelUp = (int)(Level * 10 * LevelModifier);
        MaxLoad = (int)(Constitution * Strength * 334);
        CalculateCurrentLoad();
    }

    /// <summary>
    /// Использовать вещь
    /// </summary>
    /// <param name="item"></param>
    public void UseItem(Item item)
    {
    }

    /// <summary>
    /// Подсчет текущего веса инвентаря
    /// </summary>
    public void CalculateCurrentLoad()
    {
        foreach (EquipmentSlot es in Outfit.EquipmentList)
        {
            if (!es.IsEmpty)
                CurrentLoad += es.EquipedItem.Weight;
        }
        foreach (DictionaryEntry de in Inventory.Items)
        {
            CurrentLoad += ((Item)de.Key).Weight;
        }
    }

    /// <summary>
    /// Атака цели
    /// </summary>
    /// <param name="target">Цель</param>
    public void Attack(Creature target)
    {
        System.Random rand = new System.Random();
        if (rand.Next(1, 1001) > (target.Evasion - Accuracy) * 10)
        {
            if (rand.Next(1, 1001) <= CriticalChance * 10)
                target.CurrentHealthPoints += target.PhisicalDefence - CriticalAttackPower;
            else
                target.CurrentHealthPoints += target.PhisicalDefence - PhisicalAttack;
        }
    }
}
/// <summary>
/// Раса игрока
/// </summary>
public enum PlayerRace
{
    Human,
    DarkElf,
    Elf,
    Dwarf,
    Ork
}
/// <summary>
/// Профессия игрока
/// </summary>
public enum PlayerOccupation
{
    Fighter,
    Mystic
}
