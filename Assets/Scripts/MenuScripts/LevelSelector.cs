using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour
{
   public GameObject levelHolder;
   public GameObject levelIcon;
   public GameObject thisCanvas;
   public int numberOfLevels = 4;
   public Vector2 iconSpacing;
   private Rect panelDimensions;
   private Rect iconDimensions;
   private int amountPerPage;
   private int currentLevelCount;
   private void Start()
   {
      panelDimensions = levelHolder.GetComponent<RectTransform>().rect;
      iconDimensions = levelIcon.GetComponent<RectTransform>().rect;
      int maxRow = Mathf.FloorToInt((panelDimensions.width + iconSpacing.x) / (iconDimensions.width + iconSpacing.x));
      int maxColumn = Mathf.FloorToInt((panelDimensions.height + iconSpacing.y) / (iconDimensions.height + iconSpacing.y));
      amountPerPage = maxRow * maxColumn;
      int totalPages = Mathf.CeilToInt((float)numberOfLevels / amountPerPage);
      LoadPanels(totalPages);
   }

   private void LoadPanels(int numberOfPanels)
   {
      Debug.Log(numberOfPanels);
      GameObject panelClone = Instantiate(levelHolder) as GameObject;

      for (int i = 1; i <= numberOfPanels; i++)
      {
         GameObject panel = Instantiate(panelClone) as GameObject;
         panel.transform.SetParent(thisCanvas.transform, false);
         panel.transform.SetParent(levelHolder.transform);
         panel.name = "Page-" + i;
         panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i-1), 0);
         SetUpGrid(panel);
         int numberOfIcons = i == numberOfPanels ? numberOfLevels - currentLevelCount : amountPerPage;
         LoadIcons(numberOfIcons, panel);
      }
      Destroy(panelClone);
   }

   void SetUpGrid(GameObject panel)
   {
      GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
      grid.cellSize = new Vector2(iconDimensions.width, iconDimensions.height);
      grid.childAlignment = TextAnchor.MiddleCenter;
      grid.spacing = iconSpacing;
   }
   void LoadIcons(int numberOfIcons, GameObject parentObject)
   {
      for (int i = 1; i <= numberOfIcons; i++)
      {
         currentLevelCount++;
         GameObject icon = Instantiate(levelIcon) as GameObject;
         icon.transform.SetParent(thisCanvas.transform, false);
         icon.transform.SetParent(parentObject.transform);
         icon.name = "Level " + i;
         icon.GetComponentInChildren<TextMeshProUGUI>().SetText("Level " + currentLevelCount);
      }
   }
}
