using UnityEngine;
using System.Collections;
/// <summary>
/// ������� ����� ��� ���� ������� ��������
/// </summary>

abstract class Creature
{
    string name;//��� ��������
    CreatureGender gender;//���
    int level;//�������
    int healthPoints;//���������� ��������� �������
    int manaPoints;//���������� ����
    int currentHealthPoints;//������� ������� ��������� �������
    int currentManaPoints;//������� ������� ����
    int phisicalAttack;//���������� �����
    int phisicalDefence;//���������� ������
    int magicalAttack;//���������� �����
    int magicalDefence;//���������� ������
    int accuracy;//��������
    int phisicalAttackSpeed;//�������� ���������� �����
    int castingSpeed;//�������� ����������(����)
    int criticalChance;//���� ����������� �����
    int criticalAttackPower;//�������� ����������� �����
    int evasion;//������
    int runSpeed;//�������� ����
    int walkSpeed;//�������� ������
    int healthRegenPortion;//������ ����������� ��������� �������    
    int manaRegenPortion;//������ ����������� ����
    float healthRegenSpeed;//�������� ����������� ��������� �������
    float manaRegenSpeed;//�������� ����������� ����
   
    #region ===��������===
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
/// ��� ��������
/// </summary>
public enum CreatureGender
{
    Female,
    Male
    
}
