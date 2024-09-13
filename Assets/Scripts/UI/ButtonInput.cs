using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public ButtonObj buttonObj;
    public SceneName sceneToGo;
    public SceneHeroName sceneHeroToGo;
    public EventObj eventNext;

    private TextMeshPro txtMesh;

    private void OnEnable()
    {
        txtMesh = GetComponentInChildren<TextMeshPro>();
        Rename();
    }

    public void Rename()
    {
        if (buttonObj == null) return;

        txtMesh.text = buttonObj.btnName;
    }

    private void OnMouseDown()
    {
        InputManager.instance.ButtonInput(sceneToGo, sceneHeroToGo, eventNext);
    }
}
