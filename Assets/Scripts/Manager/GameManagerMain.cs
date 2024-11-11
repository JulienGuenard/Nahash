using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMain : MonoBehaviour
{
    #region References
    public static GameManagerMain instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) GameReset();
    }

    public void Lose()
    {
        GameReset();
    }

    private void GameReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
