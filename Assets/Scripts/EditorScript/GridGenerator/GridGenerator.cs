using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[ExecuteInEditMode]
public class GridGenerator : MonoBehaviour
{
    public Vector2 grid;
    public GameObject square;
    public float squareSize;
    
    private Vector2 gridOld;
    private List<GameObject> squareList = new List<GameObject>();
    private List<GameObject> squareListOld = new List<GameObject>();

    private void OnValidate()
    {
        if (square == null)     return;
        if (grid == gridOld)    return;

        gridOld = grid;
        CreateGrid();
    }

    void CreateGrid()
    {
        squareListOld.AddRange(squareList);
#if UNITY_EDITOR
        foreach (GameObject obj in squareList)
        {
            UnityEditor.EditorApplication.delayCall += () => DestroyImmediate(obj);
        }
        squareListOld.Clear();
#endif

        squareList.Clear();

        for (int x = 0; x < grid.x; x++) 
        {
            for (int y = 0; y < grid.y; y++)
            {
                squareList.Add(Instantiate(square, transform.position + new Vector3(x * squareSize, y * squareSize, 0), Quaternion.identity, transform));
            }
        }
    }
}
