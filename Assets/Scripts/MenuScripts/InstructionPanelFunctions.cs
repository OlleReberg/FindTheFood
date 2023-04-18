using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;
using TMPro;
using UnityEngine.UI;

namespace MenuScripts
{
    public class InstructionPanelFunctions : MonoBehaviour
    {
        public Image RecipeImage;
        public GameObject InstructionText;
        public GameObject IngredientText;
        public RecipeSO recipe;


        public void SetInstructions(RecipeSO recipeSO)
        {
            recipe = recipeSO;

            RecipeImage.sprite = recipe.recipeSprite;

            InstructionText.GetComponent<TextMeshPro>().text = recipe.recipeInstructions;

            IngredientText.GetComponentInChildren<TextMeshPro>().text = recipe.recipeIngredients;

        }

    }

}