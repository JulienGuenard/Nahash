using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float lifeMax; public float LifeMax
    {
        get { return lifeMax; }
        set
        {
            lifeMax = value;
        }
    }
    [SerializeField] private float lifeCurrent; public float LifeCurrent
    {
        get { return lifeCurrent; }
        set
        {
            lifeCurrent = value;
            UIManager.instance.LifeTxt.text = "Life : " + lifeCurrent.ToString() + "/" + lifeMax.ToString();
            if (lifeCurrent <= 0) Death();
        }
    }

    #region References
    public static PlayerManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Death()
    {
        GameManagerMain.instance.Lose();
    }
}
