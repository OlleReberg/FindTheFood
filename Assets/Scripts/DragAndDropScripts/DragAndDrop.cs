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
    private Image image;

    public static event HandleFoodCollected OnFoodCollected;
    public delegate void HandleFoodCollected(ItemDataSO itemData);
    public ItemDataSO foodData;
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

        if (Physics.Raycast(ray, out rayHit)) 
        {
            if (CompareTag("Unhealthy"))
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
