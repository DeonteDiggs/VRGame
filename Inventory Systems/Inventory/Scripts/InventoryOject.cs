using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveSystem;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public ItemDatabaseObject database;
    public Inventory container;
    public void AddItem(Item _item, int _amount)
    {
        //for(int i = 0; i < container.Count; i++)
        //{
        //    if(container[i].item == _item)
        //    {
        //        container[i].AddAmount(_amount);
        //        return;
        //    }
        //}
        //container.Add(new Slot(_item, _amount));  
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        container = new Inventory();
    }

}
[System.Serializable]
public class Inventory
{
    public Slot[] items = new Slot[24];
}
[System.Serializable]
public class Slot
{
    public int Id;
    public Item item;
    public int amount;
    public Slot(Item _item , int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int _value)
    {
        amount += _value;
    }
}
