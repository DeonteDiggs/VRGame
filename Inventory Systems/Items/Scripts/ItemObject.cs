using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Equipment,
    Materials,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public GameObject prefab;
    public ItemType Type;
    [TextArea(15,20)]
    public string description;
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public Item(ItemObject itemObject)
    {
        Name = itemObject.name;
        Id = itemObject.Id;
    }
}