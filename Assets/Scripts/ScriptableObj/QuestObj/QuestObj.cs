using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableOBJ/QuestObj", order = 1)]
public class QuestObj : ScriptableObject
{
    public string questName;
    [TextArea] public string description;
    [TextArea] public string descriptionSub;
    public TownObj townNext;
    public List<ItemObj> itemNeededList;
    public List<EventObj> eventNeededList;
    public List<QuestObj> nextQuestList;
}