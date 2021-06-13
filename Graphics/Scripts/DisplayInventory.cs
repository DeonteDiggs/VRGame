using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    [AddComponentMenu("UI/Display Inventory")]
    [DisallowMultipleComponent]
    [HelpURL("https://www.youtube.com/watch?v=_IqTeruf3-s")]
    public class DisplayInventory : MonoBehaviour
    {
        [Tooltip("Set the inventory prefab")]
        public GameObject inventoryPrefab;

        [Tooltip("The inventory to display")]
        public InventoryObject inventory;

        [Header("Item Transform")]
        [Tooltip("Set the x orgin for the inventory items")]
        public float xOrigin;

        [Tooltip("Set the y orgin for the inventory items")]
        public float yOrigin;

        [Tooltip("Set the horizontal spacing of the UI item in the inventory panel")]
        public float xOffset;

        [Tooltip("Set the virtical spacing of the UI item in the inventory panel")]
        public float yOffset;
       
        [Tooltip("Set column count")]
        public int numberOfColumns;

        private Dictionary<GameObject, Slot> itemsDisplayed = new Dictionary<GameObject, Slot>();
        // Start is called before the first frame update
        void Start()
        {
            CreateSlots();
        }

        // Update is called once per frame
        void Update()
        {
           
        }

        /*private void UpdateDisplay()
        {
            for(int i = 0; i < inventory.container.Count; i++)
            {
                if(itemsDisplayed.ContainsKey(inventory.container[i]))
                {
                    itemsDisplayed[inventory.container[i]].GetComponentInChildren<Text>().text = inventory.container[i].amount.ToString("n0");
                }
                else
                {
                    InstantiateItem(i);
                }
            }
        }*/
        public void CreateSlots()
        {
            itemsDisplayed = new Dictionary<GameObject , Slot>();
            for (int i = 0; i < inventory.container.items.Length; i++)
            {
                InstantiateItems(i);
            }
        }

        public Vector3 GetPosition(int i)
        {
            return new Vector3(xOrigin + (xOffset * (i % numberOfColumns)), yOrigin + (-yOffset * (i / numberOfColumns)), 0f);
        }

        private void InstantiateItems(int i)
        {
            var _object = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            _object.GetComponent<RectTransform>().localPosition = GetPosition(i);
            //_object.GetComponentInChildren<Text>().text = inventory.container[i].amount.ToString("n0");
            itemsDisplayed.Add(_object ,inventory.container.items[i]);
        }
    }
}

