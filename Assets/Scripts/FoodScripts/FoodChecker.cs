using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.UI;

public class FoodChecker : MonoBehaviour
{
    public Image uiImage;
    private void OnTriggerEnter(Collider other)
    {
        ICollectible collectible = other.GetComponent<ICollectible>();
        if (other.CompareTag("Healthy"))
        {
            Debug.Log("Healthy Food");
            if (collectible != null)
            {
                Debug.Log("Collected " + other.gameObject);
                collectible.Collect();
            }
            
        }
        else
        {
            Debug.Log("Shit food");
        }
    }
}
