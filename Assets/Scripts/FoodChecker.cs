using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Healthy"))
        {
            Debug.Log("Healthy Food");
        }
        else
        {
            Debug.Log("Shit food");
        }
    }
}
