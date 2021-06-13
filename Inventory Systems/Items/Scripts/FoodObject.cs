using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Items/FoodObject")]
public class FoodObject : ItemObject
{
    [SerializeField] int _restorHealthValue;
    private void Awake()
    {
        Type = ItemType.Food;
    }
}
