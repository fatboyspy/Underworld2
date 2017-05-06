using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// ����� ������ ����� ���������
/// </summary>
public class DropList
{
    Drop[] items;//������ �����

    #region ===��������===
    internal Drop[] Items
    {
        get { return items; }
        set { items = value; }
    } 
    #endregion
    /// <summary>
    /// ����������� ��� ����������
    /// </summary>
    public DropList()
    {
    }
    /// <summary>
    /// ����������� � �����������
    /// </summary>
    /// <param name="items">������ �����</param>
    public DropList(Drop[] items)
    {
        this.items = items;
    }
}
