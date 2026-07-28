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

        // Offset para centralizar a matriz (considerando tamanho dos tiles como 1 unidade)
        Vector3 offset = new ((width - 1) / 2f, (height - 1) / 2f, 0f);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Posiciona o tile subtraindo o offset
                Vector3 position = new Vector3(x, y, 0) - offset;

                GameObject tileObject = Instantiate(tilePrefab, position, Quaternion.identity);
                tileObject.transform.parent = transform;
                tiles[x, y] = tileObject;

                // Ajusta o nome do objeto para facilitar a organização na Hierarchy
                tileObject.name = $"Tile_{x}_{y}";

                // Aplica o tom xadrez de acordo com as posições par/ímpar
                Tile tileScript = tileObject.GetComponent<Tile>();
                if (tileScript != null)
                {
                    if ((x + y) % 2 == 0)
                    {
                        tileScript.SetColorLight();
                    }
                    else
                    {
                        tileScript.SetColorDark();
                    }
                }
            }
        }
    }
}