using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    TextMeshPro scoreTxt; public TextMeshPro ScoreTxt
    {
        get { return scoreTxt; }
        set 
        { 
            scoreTxt = value;
            scoreTxt.text = "Score : " + ScoreManager.instance.Score.ToString();
        }
    } // AutoEnabler
    TextMeshPro timeTxt; public TextMeshPro TimeTxt
    {
        get { return timeTxt; }
        set 
        { 
            timeTxt = value;
            timeTxt.text = "Time : " + TimeManager.instance.TimeLeft.ToString();
        }
    } // AutoEnabler
    TextMeshPro lifeTxt; public TextMeshPro LifeTxt
    {
        get { return lifeTxt; }
        set 
        { 
            lifeTxt = value;
            PlayerManager.instance.LifeCurrent += 0;
        }
    } // AutoEnabler

    TextMeshPro dialogTxt; public TextMeshPro DialogTxt
    {
        get { return dialogTxt; }
        set
        {
            dialogTxt = value;
            dialogTxt.text = " ";
        }
    } // AutoEnabler

    [SerializeField] GameObject enterTownBtn; public GameObject EnterTownBtn
    {
        get { return enterTownBtn; }
        set { enterTownBtn = value; }
    }

    #region References
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
