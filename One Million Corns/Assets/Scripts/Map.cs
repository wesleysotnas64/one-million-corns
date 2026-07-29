using UnityEngine;

public class Map : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject tilePrefab;
    public GameObject[,] tiles;

    void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        tiles = new GameObject[width, height];

        // Offset para centralizar a matriz na origem (0,0,0)
        Vector3 offset = new Vector3((width - 1) / 2f, (height - 1) / 2f, 0f);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x, y, 0) - offset;

                GameObject tileObject = Instantiate(tilePrefab, position, Quaternion.identity);
                tileObject.transform.parent = transform;
                tiles[x, y] = tileObject;

                tileObject.name = $"Tile_{x}_{y}";

                Tile tileScript = tileObject.GetComponent<Tile>();
                if (tileScript != null)
                {
                    tileScript.Setup(x, y);
                }
            }
        }
    }
}