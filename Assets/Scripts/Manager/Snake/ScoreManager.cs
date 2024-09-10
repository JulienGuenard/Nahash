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
            }
    }

    #region References
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Update()
    {
        Update_CheckScore();
    }
    private void Update_CheckScore()
    {
        if (score < 6) return;

        Score = 0;
        DialogManager.instance.DialogNext();
    }
}
