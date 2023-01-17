using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousPosition;
    
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
}
