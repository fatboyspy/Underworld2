using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ����� ������
/// </summary>

public class Gamer : Creature
{
    PlayerRace race;
    PlayerOccupation occupation;
    int strength;//����
    int constitution;//��������
    int dextirity;//��������
    int intelligence;//���������
    int wisdom;//��������
    int mentalStrength;//��������
    int charisma;//�����������������
    int maxLoad;//������������ ����������� ���������� ���
    int currentLoad;//������� ��� ���������
    int expirience;//���� ���������
    int expirienceToLevelUp;//���������� ����� ��� ��������� ������
    int skillPoint;//����� ��� �������� ������
    double levelModifier;//����������� ������
    Bag inventory;
    Equipment outfit;

    #region ===��������===
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
    /// ����������� ��� ����������
    /// </summary>
    /// 
    public Gamer()
    {
    }

    /// <summary>
    /// ����������� � �����������
    /// </summary>
    /// <param name="name">��� ���������</param>
    /// <param name="race">����</param>
    /// <param name="gender">���</param>
    /// <param name="occupation">�������������</param>
    /// <param name="level">�������</param>
    /// <param name="strength">����</param>
    /// <param name="constitution">��������</param>
    /// <param name="dextirity">��������</param>
    /// <param name="intelligence">���������</param>
    /// <param name="Wisdom">��������</param>
    /// <param name="mentalStrength">��������</param>
    /// <param name="charisma">�������</param>    
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
    /// �������� �������������
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
    /// �������� �������������
    /// </summary>
    /// <param name="p_attack_mod">����������� ���������� �����</param>
    /// <param name="m_attack_mod">����������� ���������� �����</param>
    /// <param name="p_defence_mod">����������� ���������� ������</param>
    /// <param name="m_defence_mod">����������� ���������� ������</param>
    /// <param name="accuracy_mod">����������� ��������</param>
    /// <param name="p_attack_spd_mod">����������� �������� �����</param>
    /// <param name="casting_spd_mod">����������� �������� �����</param>
    /// <param name="critical_chance_mod">����������� ����� ������������ �����</param>
    /// <param name="evasion_mod">����������� �������</param>
    /// <param name="hp_mod">����������� ������ ��������� �������</param>
    /// <param name="mp_mod">����������� ������ ����</param>
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
    /// ������������ ����
    /// </summary>
    /// <param name="item"></param>
    public void UseItem(Item item)
    {
    }

    /// <summary>
    /// ������� �������� ���� ���������
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
    /// ����� ����
    /// </summary>
    /// <param name="target">����</param>
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
/// ���� ������
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
/// ��������� ������
/// </summary>
public enum PlayerOccupation
{
    Fighter,
    Mystic
}
