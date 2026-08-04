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

        Vector2 tileSize = GetTileSize();

        Vector3 offset = new(
            ((width - 1) * tileSize.x) / 2f,
            ((height - 1) * tileSize.y) / 2f,
            0f
        );

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x * tileSize.x, y * tileSize.y, 0f) - offset;

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

    private Vector2 GetTileSize()
    {
        if (tilePrefab != null)
        {
            SpriteRenderer sr = tilePrefab.GetComponent<SpriteRenderer>();
            if (sr != null && sr.sprite != null)
            {
                return sr.sprite.bounds.size;
            }
        }

        return new Vector2(1f, 1f);
    }
}