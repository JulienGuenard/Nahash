using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TimeManager : MonoBehaviour
{
    public float timeMax;

    private float timeLeft; public float TimeLeft
    {
        get { return timeLeft; }
        set 
        { 
            timeLeft = value;
            UIManager.instance.TimeTxt.text = "Time : " + timeLeft;
            if (timeLeft < 0) TimeEnd();
        }
    }

    #region References
    public static TimeManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void TimerStart()
    {
        TimeLeft = timeMax;
        StartCoroutine(TimeDecrease());
    }

    private IEnumerator TimeDecrease()
    {
        yield return new WaitForSeconds(1f);
        TimeLeft--;

        if (TimeLeft > 950) yield break;

        StartCoroutine(TimeDecrease());
    }
    private void        TimeEnd()
    {
        DialogManager.instance.DialogNext();
        timeLeft = 999;
    }
}
