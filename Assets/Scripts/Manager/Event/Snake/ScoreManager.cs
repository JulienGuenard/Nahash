using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score; public int Score
    {
        get { return score; }
        set {
                score = value;
                UIManager.instance.ScoreTxt.text = "Score : " + score.ToString();
                ScoreCheck();
            }
    }
    private int scoreGoal; public int ScoreGoal
    {
        get { return scoreGoal; }
        set
        {
            scoreGoal = value;
        }
    }
    #region References
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void ScoreReset()
    {
        Score = 0;
    }

    private void ScoreCheck()
    {
        if (score < scoreGoal) return;

        ScoreReset();
        EvtSceneManager.instance.StartEvtScene();
        TimeManager.instance.TimeEnd();
    }

}
