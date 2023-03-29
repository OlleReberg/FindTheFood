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

        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            Inventory.OnInventoryChange += DrawInventory;
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
                CreateInventorySlot(recipe.foodItems[i]);
                
               // Debug.Log("slot attached " + recipe.foodItems[i]);

            }

            for (int i = 0; i < inventory.Count; i++)
            {
               
                for (int u = 0; u < recipe.foodItems.Length; u++)
                {
                    if (inventorySlots[u].itemData == inventory[i].itemData)
                    {
                        inventorySlots[u].DrawSlot(inventory[i]);
                    }
                    
                }
            }
        }

        void CreateInventorySlot(ItemDataSO aFoodItem)
        {
            GameObject newSlot = Instantiate(slotPrefab);
            newSlot.transform.SetParent(transform, false);

            InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
            //newSlotComponent.ClearSlot();

            newSlotComponent.icon.sprite = aFoodItem.icon;
            newSlotComponent.itemData = aFoodItem;
            //newSlotComponent.displayName = aFoodItem.displayName;
            //spriteRenderer.material.shader = Shader.Find("Grayscale");

            //newSlotComponent.icon.material.shader = Shader.Find("Grayscale");


            inventorySlots.Add(newSlotComponent);
        }
    }
}