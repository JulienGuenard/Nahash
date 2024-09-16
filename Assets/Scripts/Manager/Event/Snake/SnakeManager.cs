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
      
    #region References
    public static SnakeManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void Input_SnakeDirection(float inputX, float inputY)
    {
        if (playerSnake != null) return;

        PlayerSnake.Input_SnakeDirection(inputX, inputY);
    }
}
