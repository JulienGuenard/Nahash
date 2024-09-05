using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnakeBody_Main : MonoBehaviour
{
    public void Move(Vector2 pos)
    {
        transform.position = pos;
    }
}
