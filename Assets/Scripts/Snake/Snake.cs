using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject bodyPrefab;
    public List<SnakeBody> bodyList;
    public float moveSpeed, hitDelay;

    private Vector2 moveDirection, moveNextDirection, bodyLastPosition;
    private bool isHit;

    void Start()
    {
        Input_SnakeDirection(1, 0);
        StartCoroutine(Move());
        TimeManager.instance.TimeStart();
    }
    private void Update()
    {
        Update_PlayerInput();
    }

    private void Update_PlayerInput()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Input_SnakeDirection(inputX, inputY);
    }
    public void Input_SnakeDirection(float inputX, float inputY)
    {
        if (inputX != 0 && moveDirection.x == 0) moveNextDirection = new Vector2(inputX, 0);
        if (inputY != 0 && moveDirection.y == 0) moveNextDirection = new Vector2(0, inputY);
    }

    private IEnumerator Move()
    {
        Move_CheckIn();
        yield return new WaitForSeconds(0.05f);
        Move_CheckOut();

        if (isHit) yield break;

        Move_Body();
        Move_Head();
        yield return new WaitForSeconds(moveSpeed);
        StartCoroutine(Move());
    }
    private void        Move_CheckIn()
    {
        GetComponent<BoxCollider2D>().offset += moveNextDirection;
    }
    private void        Move_CheckOut()
    {
        GetComponent<BoxCollider2D>().offset = Vector2.zero;
    }
    private void        Move_Body()
    {
        bodyLastPosition = bodyList[bodyList.Count - 1].transform.position;

        for (int i = bodyList.Count - 1; i >= 0; i--)
        {
            if (i == 0) { bodyList[i].Move(transform.position); continue; }
            bodyList[i].Move(bodyList[i - 1].transform.position);
        }
    }
    private void        Move_Head()
    {
        moveDirection = moveNextDirection;
        transform.position += (Vector3)moveDirection;
    }

    private void Eat(GameObject food)
    {
        Destroy(food);
        Eat_BodyGrow();
        ScoreManager.instance.Score += 1;
        FoodManager.instance.FoodNew(transform.position);
    }
    private void Eat_BodyGrow()
    {
        Transform grid = ArenaManager.instance.GridTransform;
        bodyList.Add(Instantiate(bodyPrefab, bodyLastPosition, Quaternion.identity, grid).GetComponent<SnakeBody>());
    }

    private void Hit()
    {
        if (isHit) return;

        PlayerManager.instance.LifeCurrent--;
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
        if (collision.tag == "Food") { Eat(collision.gameObject); return; }
        if (collision.tag == "Wall" 
         || collision.tag == "Body") { Hit(); return; }
    }
}
