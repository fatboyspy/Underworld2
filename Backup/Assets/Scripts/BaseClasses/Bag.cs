using UnityEngine;
using System.Collections;
/// <summary>
/// ��������� ���������
/// </summary>
class Bag
{
    /// <summary>
    /// ���-������� � ������
    /// </summary>
    Hashtable items;

    #region===��������===
    public Hashtable Items
    {
        get { return items; }
        set { items = value; }
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
        items = new Hashtable(capacity);
    }
    /// <summary>
    /// �������� ���� � ���������
    /// </summary>
    /// <param name="item">����</param>
    public void AddItem(Item item)
    {
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
