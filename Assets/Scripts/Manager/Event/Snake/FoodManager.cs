using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject foodPrefab;

    #region References
    public static FoodManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void FoodCreate()
    {
        FoodCreateAtPos(RandomPosOnGrid());
    }

    private Vector2 RandomPosOnGrid()
    {
        Vector2 gridX = ArenaManager.instance.gridX;
        Vector2 gridY = ArenaManager.instance.gridY;

        int randX = Random.Range(0, Mathf.FloorToInt(gridX.x));
        int randY = Random.Range(0, Mathf.FloorToInt(gridY.y));

        Vector2 pos = new Vector2(randX, randY);

        if (SnakeManager.instance.PlayerSnake.transform.position == (Vector3)pos) RandomPosOnGrid();

        return new Vector2(randX, randY);
    }
    private void    FoodCreateAtPos(Vector2 pos)
    {
        Instantiate(foodPrefab, pos, Quaternion.identity, ArenaManager.instance.GridTransform);
    }
}
