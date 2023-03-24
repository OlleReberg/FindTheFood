using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    //  public TextMeshProUGUI labelText;

    public Material DefaultMaterial;

    public void ClearSlot()
    {
        icon.enabled = false;
       // labelText.enabled = false;
    }

    public void DrawSlot(InventoryItem item)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }

        icon.enabled = true;
       // labelText.enabled = true;
        icon.sprite = item.itemData.icon;

        icon.material = null;
        //  labelText.text = item.itemData.displayName;
    }
}
