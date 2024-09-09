using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public GameObject sceneOn;

    private void OnMouseDown()
    {
        GMBSceneManager.instance.ChangeScene(sceneOn);
    }
}
