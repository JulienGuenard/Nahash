using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region References
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.R)) ResetGame();
    }

    public void Lose()
    {

    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void SceneChangeManager(string sceneName, bool state)
    {
        if (sceneName == "SceneWorldmap" && state) WorldmapManager.instance.WorldmapEnable();
        if (sceneName == "SceneWorldmap" && !state) WorldmapManager.instance.WorldmapDisable();

        /*if (sceneName == "SceneEvent" && state) WorldmapManager.instance.WorldmapEnable();
        if (sceneName == "SceneEvent" && !state) WorldmapManager.instance.WorldmapDisable();*/
    }
}
