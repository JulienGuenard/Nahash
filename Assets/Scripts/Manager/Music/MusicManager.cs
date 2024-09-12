using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource sfxAudio;

    #region References
    public static MusicManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
