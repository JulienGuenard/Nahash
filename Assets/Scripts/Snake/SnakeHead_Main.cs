using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead_Main : MonoBehaviour
{
    [SerializeField] private GameObject bodyPrefab;

    [SerializeField] private float moveSpeed;
    private Vector2 moveDirection;

    [SerializeField] private List<SnakeBody_Main> bodyList;
    private Vector2 bodyLastPosition;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Move", moveSpeed);
        moveDirection = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && moveDirection.x == 0)    moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        if (Input.GetAxisRaw("Vertical") != 0 && moveDirection.y == 0)      moveDirection = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }

    void Move()
    {
        MoveBody();
        transform.position += (Vector3)moveDirection;
        Invoke("Move", moveSpeed);
    }

    void MoveBody()
    {
        bodyLastPosition = bodyList[bodyList.Count - 1].transform.position;

        for (int i = bodyList.Count-1; i >= 0; i--)
        {
            if (i == 0) { bodyList[i].Move(transform.position); continue; }
            bodyList[i].Move(bodyList[i - 1].transform.position);
        }
    }

    void BodyCreate()
    {
        Transform grid = ArenaManager.instance.gridTransform;
        bodyList.Add(Instantiate(bodyPrefab, bodyLastPosition, Quaternion.identity, grid).GetComponent<SnakeBody_Main>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Destroy(collision.gameObject);
            BodyCreate();
            ScoreManager.instance.Score += 1;
            FoodManager.instance.FoodCreate(transform.position);
        }

        if (collision.tag == "Wall" || collision.tag == "Body")
        {
            GameManager.instance.Lose();
            Destroy(this.gameObject);
        }
    }
}
