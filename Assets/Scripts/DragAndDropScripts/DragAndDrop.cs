using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, ICollectible
{
    Vector3 mousPosition;
    public Image image;

    public static event HandleFoodCollected OnFoodCollected;
    public delegate void HandleFoodCollected(ItemData itemData);
    public ItemData foodData;
    public Vector3 startPosition;
    public Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousPosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition - mousPosition).x, transform.position.y,
            Camera.main.ScreenToWorldPoint(Input.mousePosition - mousPosition).z);
    }

    private void OnMouseUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        
        if (Physics.Raycast(ray, out rayHit)) 
        {
            if (rayHit.collider.CompareTag("DropArea") && CompareTag("Healthy"))
            {
                    transform.SetParent(rayHit.transform);
                    transform.position = (rayHit.transform.position);
            }
            else if (CompareTag("Unhealthy"))
            {
                transform.position = startPosition;
                transform.rotation = startRotation;
            }
        }
        
        
    }
    public void Collect()
    {
        Destroy(gameObject);
        OnFoodCollected?.Invoke(foodData);
    }
}
