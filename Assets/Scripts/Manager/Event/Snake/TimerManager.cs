using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private float timerTimeLeft; public float TimerTimeLeft
    {
        get { return timerTimeLeft; }
        set 
        {
            timerTimeLeft = value;
            if (timerTimeLeft <= 950)    TimerTimeleft_Update();
            if (timerTimeLeft <= 0)      TimerTimeleft_Over();
        }
    }

    #region References
    public static TimerManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void TimerStart()
    {
        StartCoroutine(TimerStart_Decreasing());
    }
    public void TimerEnd()
    {
        timerTimeLeft = 999;
    }

    private void TimerTimeleft_Update()
    {
        UIManager.instance.TimeTxt.text = "Time : " + timerTimeLeft;
    }
    private void TimerTimeleft_Over()
    {   
        TimerEnd();
        SnakeManager.instance.SnakeWin();
    }     

    private IEnumerator TimerStart_Decreasing()
    {
        yield return new WaitForSeconds(1f);
        TimerTimeLeft--;

        if (TimerTimeLeft > 950) yield break;

        StartCoroutine(TimerStart_Decreasing());
    }
}
