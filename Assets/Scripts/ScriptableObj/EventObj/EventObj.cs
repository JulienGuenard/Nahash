using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableOBJ/EventObj", order = 1)]
public class EventObj : ScriptableObject
{
    public List<NarrativeObj> narrativeList;
    public EventObj eventNext;
    public SceneName sceneNext;
}