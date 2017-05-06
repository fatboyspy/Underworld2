using UnityEngine;
using System.Collections;
/// <summary>
/// ���� ����� ���������
/// </summary>
class Drop
{
    Item dropItem;//�������    
    int dropCount;//������������ ���������� �����
    double dropChance;//���� �����

    #region ===��������===
    public Item DropItem
    {
        get { return dropItem; }
        set { dropItem = value; }
    }
    public int DropCount
    {
        get { return dropCount; }
        set { dropCount = value; }
    }
    public double DropChance
    {
        get { return dropChance; }
        set { dropChance = value; }
    } 
    #endregion
    /// <summary>
    /// ����������� ��� ����������
    /// </summary>
    public Drop()
    {
    }
    /// <summary>
    /// ����������� � �����������
    /// </summary>
    /// <param name="dropItem">�������</param>
    /// <param name="dropCount">������������ ���������� �����</param>
    /// <param name="dropChance">���� �����</param>
    public Drop(Item dropItem, int dropCount, double dropChance)
    {
        this.dropItem = dropItem;
        this.dropCount = dropCount;
        this.dropChance = dropChance;
    }
}
