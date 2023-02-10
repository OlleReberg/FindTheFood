using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousPosition;
    public Image image;
    public Sprite sprite;
    
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

        if (screenPos.x > image.transform.position.x && screenPos.x < image.transform.position.x + image.rectTransform.sizeDelta.x &&
            screenPos.y > image.transform.position.y && screenPos.y < image.transform.position.y + image.rectTransform.sizeDelta.y)
        {
            if (Physics.Raycast(ray, out rayHit))
            {
                if (rayHit.collider.CompareTag("DropArea"))
                {
                    transform.SetParent(rayHit.transform);
                    transform.position = (rayHit.transform.position);
                   // image.sprite = sprite;
                    Debug.Log("Sprite Changed");
                }
            }
        }
        
    }
}
