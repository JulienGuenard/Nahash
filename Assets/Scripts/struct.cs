using UnityEngine;

[System.Serializable] public struct DialogStruct
{
    public string txt;
    public VoiceObj dialogVoicePreset;
    public AudioClip sfx;
    public float speed, pitch, pitchRand, spaceDelay, virguleDelay, pointDelay, bubbleDelay;
    public int hideNumber;
}