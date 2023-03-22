using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FoodItems",fileName = "NewFood")]
public class ItemDataSO : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    public Sprite greyedOutIcon;

    public string DisplayName { get => displayName; }
    public Sprite Icon { get => icon; }
    public Sprite GreyedOutIcon { get => greyedOutIcon; }
    
}