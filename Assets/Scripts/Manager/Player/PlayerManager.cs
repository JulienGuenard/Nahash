using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float life; public float Life
    { 
        get { return life; } 
        set 
        { 
            life = value;
            UIManager.instance.LifeTxt.text = "Life : " + life.ToString();
            if (life <= 0) SnakeDeath();
        }
    }

    #region References
    public static PlayerManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void SnakeDeath()
    {

    }
}
