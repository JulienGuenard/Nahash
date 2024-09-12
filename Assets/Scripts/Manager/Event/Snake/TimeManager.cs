using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float timeLeft; public float TimeLeft
    {
        get { return timeLeft; }
        set 
        {
            timeLeft = value;
            if (timeLeft <= 950)    Timeleft_Update();
            if (timeLeft <= 0)      Timeleft_Over();
        }
    }

    #region References
    public static TimeManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void TimeStart()
    {
        StartCoroutine(TimeStart_Decreasing());
    }
    public void TimeEnd()
    {
        timeLeft = 999;
    }

    private void Timeleft_Update()
    {
        UIManager.instance.TimeTxt.text = "Time : " + timeLeft;
    }
    private void Timeleft_Over()
    {
        TimeEnd();
        EvtSceneManager.instance.StartEvtScene();
        ScoreManager.instance.ScoreReset();
    }

    private IEnumerator TimeStart_Decreasing()
    {
        yield return new WaitForSeconds(1f);
        TimeLeft--;

        if (TimeLeft > 950) yield break;

        StartCoroutine(TimeStart_Decreasing());
    }
}
