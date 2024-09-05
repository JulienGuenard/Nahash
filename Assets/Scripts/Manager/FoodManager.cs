using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FoodManager : MonoBehaviour
{
    public InputAction inputAction;
    [SerializeField] GameObject foodPrefab;

    public int foodRemaining;

    #region References
    public static FoodManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void FoodCreate(Vector2 forbiddenPos)
    {
        Vector3 grid = ArenaManager.instance.grid;
        Vector2 pos = new Vector2(Random.Range(1, Mathf.FloorToInt(grid.x) - 1) + 30f, Random.Range(1, Mathf.FloorToInt(grid.y) - 1) - 6f);
        if (pos == forbiddenPos) { FoodCreate(forbiddenPos); return; }
        Instantiate(foodPrefab, pos, Quaternion.identity);
    }

    IEnumerator aaaeazea()
    {
        yield return new WaitForSeconds(5f);
        
    }
}
