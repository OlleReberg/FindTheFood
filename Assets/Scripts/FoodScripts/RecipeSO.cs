using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;
using UnityEngine.UI;


namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Recipes",fileName = "NewRecipe")]
    public class RecipeSO: ScriptableObject
    {
        public Sprite recipeSprite;
        public ItemDataSO[] foodItems;
        private Object[] recipes;
        public bool recipeUnlocked = false;
        public string recipeName;

        public string recipeInstructions;
        public string recipeIngredients;

    }
}