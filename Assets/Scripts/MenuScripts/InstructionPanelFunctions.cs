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
        public TextMeshPro IngredientText;
        public Text wawa; 

        public RecipeSO recipe;


        public void SetInstructions(RecipeSO recipeSO)
        {
            recipe = recipeSO;

            RecipeImage.sprite = recipeSO.recipeSprite;

           InstructionText.GetComponent<TextMeshPro>().text = recipeSO.recipeInstructions;

            IngredientText.text = recipeSO.recipeIngredients;

        }

    }

}