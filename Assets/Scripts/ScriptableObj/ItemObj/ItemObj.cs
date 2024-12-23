using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableOBJ/ItemObj", order = 1)]
public class ItemObj : ScriptableObject
{
    public string itemName;
    [TextArea] public string description;
    public Sprite sprite;
}