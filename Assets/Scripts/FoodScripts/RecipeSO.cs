﻿using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Recipes",fileName = "NewRecipe")]
    public class RecipeSO: ScriptableObject
    {
        public ItemDataSO[] foodItems;
        private Object[] recipes;
        //public InventoryItem[] items;
    }
}