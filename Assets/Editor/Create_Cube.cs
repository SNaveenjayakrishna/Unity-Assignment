using UnityEditor;
using UnityEngine;

public class CubeGridEditor : EditorWindow
{
    public int rows = 10;
    public int columns = 10;
    public GameObject cubePrefab; // Variable to hold the cube prefab

    [MenuItem("Tools/Create Cube Grid")]
    public static void ShowWindow()
    {
        GetWindow<CubeGridEditor>("Cube Grid Creator");
    }

    void OnGUI()
    {
        GUILayout.Label("Create Custom Grid of Cubes", EditorStyles.boldLabel);

        // Input fields for specifying the number of rows and columns
        rows = EditorGUILayout.IntField("Rows", rows);
        columns = EditorGUILayout.IntField("Columns", columns);

        // Field for specifying the cube prefab
        cubePrefab = EditorGUILayout.ObjectField("Cube Prefab", cubePrefab, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Generate Grid"))
        {
            GenerateGrid();
        }
    }

    void GenerateGrid()
    {
        // Destroy previously generated cubes
        GameObject oldGrid = GameObject.Find("CubeGrid");
        if (oldGrid != null)
        {
            DestroyImmediate(oldGrid);
        }

        // Create a new parent GameObject to hold the cubes
        GameObject parent = new GameObject("CubeGrid");

        // Generate the grid of cubes
        for (int x = 0; x < rows; x++)
        {
            for (int z = 0; z < columns; z++)
            {
                GameObject cube = Instantiate(cubePrefab, new Vector3(x, 0, z), Quaternion.identity);
                cube.transform.parent = parent.transform;
                cube.AddComponent<ToggleButton>();

                // Attach TileInfo script and set the tile position
                TileInfo tileInfo = cube.GetComponent<TileInfo>();
                if (tileInfo == null)
                {
                    tileInfo = cube.AddComponent<TileInfo>();
                }
                tileInfo.x = x;
                tileInfo.z = z;
            }
        }
    }
}
