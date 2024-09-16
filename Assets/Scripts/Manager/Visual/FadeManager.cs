using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public Animator fade;
    #region References
    public static FadeManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
