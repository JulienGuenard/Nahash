using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableOBJ/TooltipObj", order = 1)]
public class TooltipObj : ScriptableObject
{
    public string title;
    [TextArea] public string text;
}