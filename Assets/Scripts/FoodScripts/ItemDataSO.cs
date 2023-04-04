using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/FoodItems",fileName = "NewFood")]
public class ItemDataSO : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    

    public string DisplayName { get => displayName; }
    public Sprite Icon { get => icon; }
    
    
}