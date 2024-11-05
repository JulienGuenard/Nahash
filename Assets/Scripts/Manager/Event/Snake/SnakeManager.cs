using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class SnakeManager : MonoBehaviour
{
    private Snake playerSnake; public Snake PlayerSnake
    { 
        get { return playerSnake; } 
        set { playerSnake = value; }
    }
    private GameObject snakeGameCurrent;
    public GameObject enemy;
    private SnakeStruct snakeStructCurrent;

    #region References
    public static SnakeManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void SnakeWin()
    {
        ScoreManager.instance.ScoreReset();
        EvtSceneManager.instance.StartEvtScene();
        TimerManager.instance.TimerEnd();
        Destroy(snakeGameCurrent);
    }

    public void SnakeLose()
    {

    }

    public void EvtScene_SnakeNew(SnakeStruct snakeStruct)
    {
        snakeStructCurrent = snakeStruct;
        snakeGameCurrent = Instantiate(snakeStruct.snakeMap);
        snakeGameCurrent.name = "SnakeMap";
        ArenaManager.instance.GridTransform = snakeGameCurrent.transform;

        if (snakeStruct.enemyGroup.Count == 0) return;

        foreach(EnemyGroupStruct grp in snakeStruct.enemyGroup)
        {
            for(int i = 0; i < grp.number; i++)
            {
                EnemyManager.instance.EnemyCreate(grp.enemy, grp.spawnPosMin, grp.spawnPosMax);
            }
        }
    }

    public void Input_SnakeDirection(float inputX, float inputY)
    {
        if (playerSnake == null) return;

        PlayerSnake.Input_SnakeDirection(inputX, inputY);
    }
}
