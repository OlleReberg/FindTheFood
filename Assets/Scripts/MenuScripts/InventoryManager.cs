using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

namespace MenuScripts
{
    public class InventoryManager: MonoBehaviour
    {
        public GameObject slotPrefab;
        public List<InventorySlot> inventorySlots = new List<InventorySlot>(6);
        private InventorySlot invSlot;
        public RecipeSO recipe;
        

        private void Start()
        {
            Inventory.OnInventoryChange += DrawInventory;

        }

        private void OnDisable()
        {
            Inventory.OnInventoryChange -= DrawInventory;
        }

        private void ResetInventory()
        {
            foreach (Transform childTransform in transform)
            {
                Destroy(childTransform.gameObject);
            }
            inventorySlots = new List<InventorySlot>(6);
        }

        void DrawInventory(List<InventoryItem> inventory)
        {
            ResetInventory();

            for (int i = 0; i < recipe.foodItems.Length; i++)
            {
                CreateInventorySlot();
            }
            
            for (int i = 0; i < inventory.Count; i++)
            {
                //TODO: Figure out why icons aren't changing when using the commented out code below
                //inventorySlots[i].icon.sprite = recipe.foodItems[i].icon;
                inventorySlots[i].DrawSlot(inventory[i]);
            }
            
        }

        void CreateInventorySlot()
        {
            GameObject newSlot = Instantiate(slotPrefab);
            newSlot.transform.SetParent(transform, false);

            InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
            newSlotComponent.ClearSlot();
            
            inventorySlots.Add(newSlotComponent);
        }
    }
}