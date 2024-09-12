using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextInput : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (EvtSceneManager.instance.CanPlayerGoNext) EvtSceneManager.instance.Next();
    }
}
