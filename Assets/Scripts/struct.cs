using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public struct EvtSceneStruct
{
    public string evtSceneName;
    public GameObject gmb;
    public List<Sprite> spriteChangeList;
    public List<DialogStruct> dialogList;
    public List<SnakeStruct> snakeList;
}
[System.Serializable] public struct DialogStruct
{
    public string dialogName;
    [TextArea] public string txt;
    public VoiceObj voice;
}
[System.Serializable] public struct VoiceStruct
{
    public AudioClip sfx;
    public float speed, pitch, pitchRand, spaceDelay, virguleDelay, pointDelay;
}
[System.Serializable] public struct SnakeStruct
{
    public int scoreGoal;
    public int timeToWait;
}