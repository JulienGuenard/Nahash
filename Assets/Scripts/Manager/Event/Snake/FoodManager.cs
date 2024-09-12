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

    public void     FoodNew(Vector2 forbiddenPos)
    {
        Vector2 randomPos =             FoodNew_RandomPos(ArenaManager.instance.gridX, ArenaManager.instance.gridY);
        if (randomPos == forbiddenPos)  FoodNew(forbiddenPos);
        else                            FoodNew_Create(randomPos);

    }

    private Vector2 FoodNew_RandomPos(Vector2 gridX, Vector2 gridY)
    {
        int randX = Random.Range(Mathf.FloorToInt(gridX.x), Mathf.FloorToInt(gridX.y));
        int randY = Random.Range(Mathf.FloorToInt(gridY.x), Mathf.FloorToInt(gridY.y));

        return new Vector2(randX, randY);
    }
    private void    FoodNew_Create(Vector2 randomPos)
    {
        Transform gridTransform = ArenaManager.instance.GridTransform;
        Instantiate(foodPrefab, randomPos, Quaternion.identity, gridTransform);
    }
}
