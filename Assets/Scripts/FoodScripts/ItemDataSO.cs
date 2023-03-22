using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FoodItems",fileName = "NewFood")]
public class ItemDataSO : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    public Sprite greyedOutIcon;
    public int iD;
}