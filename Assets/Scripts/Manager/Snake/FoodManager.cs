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

    public void FoodCreate(Vector2 forbiddenPos)
    {
        Vector2 gridX = ArenaManager.instance.gridX;
        Vector2 gridY = ArenaManager.instance.gridY;
        Transform gridTransform = ArenaManager.instance.GridTransform;

        int randX = Random.Range(Mathf.FloorToInt(gridX.x), Mathf.FloorToInt(gridX.y));
        int randY = Random.Range(Mathf.FloorToInt(gridY.x), Mathf.FloorToInt(gridY.y));

        Vector2 pos = new Vector2(randX, randY);
        if (pos == forbiddenPos) { FoodCreate(forbiddenPos); return; }
        Instantiate(foodPrefab, pos, Quaternion.identity, gridTransform);
    }
}
