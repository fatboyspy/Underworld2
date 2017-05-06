using UnityEngine;
using System.Collections;
/// <summary>
/// ��������� ���������
/// </summary>
public class Bag
{
    /// <summary>
    /// ���-������� � ������
    /// </summary>
    Hashtable items;
    int capacity;   

    #region===��������===
    public Hashtable Items
    {
        get { return items; }
        set { items = value; }
    } 
    public int Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }
    #endregion

    /// <summary>
    /// ����������� ��� ����������
    /// </summary>
    public Bag()
    {
        items = new Hashtable();
    }
    /// <summary>
    /// ����������� � �����������
    /// </summary>
    /// <param name="capacity">����������� ���������</param>
    public Bag(int capacity)
    {
        this.capacity = capacity;
        items = new Hashtable(capacity);
    }
    /// <summary>
    /// �������� ���� � ���������
    /// </summary>
    /// <param name="item">����</param>
    public void AddItem(Item item)
    {
        items.Add(item, 1);
    }
    /// <summary>
    /// ������ ���� �� ���������
    /// </summary>
    /// <param name="item">����</param>
    public void RemoveItem(Item item)
    {
    }
    /// <summary>
    /// ���������� ����
    /// </summary>
    /// <param name="item">����</param>
    public void DestroyItem(Item item)
    {
    }
    /// <summary>
    /// ��������� ����
    /// </summary>
    /// <param name="item">����</param>
    public void DropItem(Item item)
    {
    }
}
