using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Vector2 moveNextDirection = Vector2.zero;
    private bool isHit;
    public float moveSpeed, hitDelay;

    private void Start()
    {
        if (moveSpeed != 0) StartCoroutine(MoveCD());
    }

    private IEnumerator Move()
    {
        Move_TryNextPosition();
        Move_CheckIn();
        yield return new WaitForSeconds(0.05f);
        Move_CheckOut();

        if (isHit) yield break;

        Move_Head();
        StartCoroutine(MoveCD());
    }

    private void Move_TryNextPosition()
    {
        switch (Random.Range(1, 5))
        {
            case 1: moveNextDirection = new Vector2(1, 0);  break;
            case 2: moveNextDirection = new Vector2(-1, 0); break;
            case 3: moveNextDirection = new Vector2(0, 1);  break;
            case 4: moveNextDirection = new Vector2(0, -1); break;
        }
    }

    private void Move_Head()
    {
        transform.position += (Vector3)moveNextDirection;
    }

    private void Move_CheckIn()
    {
        GetComponent<BoxCollider2D>().offset += moveNextDirection;
    }
    private void Move_CheckOut()
    {
        GetComponent<BoxCollider2D>().offset = Vector2.zero;
    }

    private IEnumerator MoveCD()
    {
        yield return new WaitForSeconds(moveSpeed);
        StartCoroutine(Move());
    }

    private void Hit()
    {
        isHit = true;
        StartCoroutine(HitDelay());
    }

    private IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(hitDelay);
        isHit = false;
        StartCoroutine(Move());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall"
         || collision.tag == "Body"
         || collision.tag == "Exit"
         || collision.tag == "Enemy") { Hit(); return; }
    }
}
