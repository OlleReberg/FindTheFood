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

    public ItemDataSO itemData;


    public void ClearSlot()
    {
        icon.enabled = false;
    }

    public void DrawSlot(InventoryItem item)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }

        icon.enabled = true;
        icon.sprite = item.itemData.icon;
        icon.material = null;
    }
}
