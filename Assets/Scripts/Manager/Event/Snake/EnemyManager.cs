using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region References
    public static EnemyManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void EnemyCreate(GameObject enemy, Vector2 gridMin, Vector2 gridMax)
    {
        EnemyCreateAtPos(enemy, RandomPosOnGrid(gridMin, gridMax));
    }

    private Vector2 RandomPosOnGrid(Vector2 gridMin, Vector2 gridMax)
    {
        int randX = Random.Range(Mathf.FloorToInt(gridMin.x), Mathf.FloorToInt(gridMax.x));
        int randY = Random.Range(Mathf.FloorToInt(gridMin.y), Mathf.FloorToInt(gridMax.y));

        Vector2 pos = new Vector2(randX, randY);

        return new Vector2(randX, randY);
    }
    private void EnemyCreateAtPos(GameObject enemy, Vector2 pos)
    {
        GameObject obj = Instantiate(enemy, pos, Quaternion.identity, ArenaManager.instance.GridTransform);
        obj.transform.SetParent(ArenaManager.instance.GridTransform);
    }
}
