using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
public class GridGenerator : MonoBehaviour
{
    public Vector2 grid;
    public GameObject square;
    public float squareSize;
    
    private Vector2 gridOld;
    public List<GameObject> squareList;
    public List<GameObject> squareListOld;

    public bool createGrid = false;

    private void OnValidate()
    {
        if (!createGrid)             return;
        if (square == null)         return;
        if (grid == gridOld)        return;
        if (Application.isPlaying)  return;

        createGrid = false;

        gridOld = grid;
        CreateGrid();

    }

    void CreateGrid()
    {
        squareListOld.AddRange(squareList);

        foreach (GameObject obj in squareList)
        {
            UnityEditor.EditorApplication.delayCall += () => DestroyImmediate(obj);
        }
        squareListOld.Clear();


        squareList.Clear();

        for (int x = 0; x < grid.x; x++) 
        {
            for (int y = 0; y < grid.y; y++)
            {
                squareList.Add(Instantiate(square, transform.position + new Vector3(x * squareSize * transform.localScale.x, y * squareSize * transform.localScale.x, 1), Quaternion.identity, transform));
            }
        }
    }
}
#endif