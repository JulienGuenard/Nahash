using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public void Move(Vector2 pos)
    {
        transform.position = pos;
    }
}
