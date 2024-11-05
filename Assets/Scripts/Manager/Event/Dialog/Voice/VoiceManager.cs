using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    AudioClip sfx;
    float speed;
    float spaceDelay;
    float virguleDelay;
    float pointDelay;

    #region References
    public static VoiceManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void VoicePlay(DialogStruct dialog)
    {
        StartCoroutine(VoicePlay_Running(dialog));
    }
    public void VoiceSpeedUp()
    {
        sfx = null;
        speed = 0f;
        spaceDelay = 0f;
        virguleDelay = 0f;
        pointDelay = 0f;
    }

    IEnumerator VoicePlay_Running(DialogStruct dialog)
    {
        VoiceStruct voice = dialog.voice.voiceStruct;

        string txt = dialog.txt;
        sfx = voice.sfx;
        float pitch = voice.pitch;
        float pitchRand = voice.pitchRand;
        speed = voice.speed;
        spaceDelay = voice.spaceDelay;
        virguleDelay = voice.virguleDelay;
        pointDelay = voice.pointDelay;

        for (int x = 1; x < txt.Length + 1; x++)
        {
            if (speed != 0) yield return new WaitForSeconds(speed);

            if (txt.Substring(x).StartsWith("<"))
            {
                x += 4;
                yield return new WaitForSeconds(0.1f);
                continue;
            }

            UIManager.instance.DialogTxt.text = txt.Insert(x, "<color=#00000000>");
            MusicManager.instance.sfxAudio.pitch = Random.Range(pitch - pitchRand, pitch + pitchRand);

            if (txt.Substring(x - 1).StartsWith(" "))
            {
                if (spaceDelay != 0) yield return new WaitForSeconds(spaceDelay);
                continue;
            }
            if (txt.Substring(x - 1).StartsWith(","))
            {
                if (virguleDelay != 0) yield return new WaitForSeconds(virguleDelay);
                continue;
            }
            if (txt.Substring(x - 1).StartsWith("."))
            {
                if (pointDelay != 0) yield return new WaitForSeconds(pointDelay);
                continue;
            }
            if (x >= txt.Length) continue;

            MusicManager.instance.sfxAudio.PlayOneShot(sfx);
        }
        EvtSceneManager.instance.EvtSceneEnable();
    }
}
