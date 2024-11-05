using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class EvtSceneStruct
{
    public string evtSceneName;
    public GameObject gmb;
    public List<Sprite> spriteChangeList;
    public List<FadeStruct> fadeList;
    public List<DialogStruct> dialogList;
    public List<SnakeStruct> snakeList;
    public List<ItemObj> itemList;
}
[System.Serializable]
public class FadeStruct
{
    public FadeType fadeType;
    public float time;
}
[System.Serializable] public class DialogStruct
{
    public string dialogName;
    [TextArea] public string txt;
    public CharacterObj character;
    public VoiceObj voice;
}
[System.Serializable] public struct VoiceStruct
{
    public AudioClip sfx;
    public float speed, pitch, pitchRand, spaceDelay, virguleDelay, pointDelay;
}
[System.Serializable] public struct SnakeStruct
{
    public GameObject snakeMap;
    public int scoreGoal;
    public GameObject scoreObj;
    public int timeToWait;
    public int timeToLose;
    public bool playerNotHere;
    public List<EnemyGroupStruct> enemyGroup;
}
[System.Serializable]
public struct EnemyGroupStruct
{
    public GameObject enemy;
    public int number;
    public Vector2 spawnPosMin;
    public Vector2 spawnPosMax;
}