using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockedRecipes : MonoBehaviour
{
    public RecipeSO recipe;
    public GameObject button;
    public Image buttonImage;
    public TextMeshProUGUI buttonText;

    void FillSlot()
    {
        buttonImage.sprite = recipe.recipeSprite;
        buttonText.text = recipe.recipeName;

        if (recipe.recipeUnlocked == true)
        {
            //resurrect gandalf the grey to gandalf the rainbow
        }
    }

    private void OnEnable()
    {
        FillSlot();
    }
}
