using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableOBJ/CharacterObj", order = 1)]
public class CharacterObj : ScriptableObject
{
    public string characterName;
    public Sprite sprite;
}