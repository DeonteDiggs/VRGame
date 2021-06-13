using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/EquipmentObject")]
public class EquipmentObject : ItemObject
{
    [SerializeField] float EquipmentBonus;
    [SerializeField] float AttackBonus;
    private void Awake()
    {
        Type = ItemType.Equipment;
    }
}
