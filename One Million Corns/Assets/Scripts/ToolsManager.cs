using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    public static ToolsManager Instance { get; private set; }

    [SerializeField] private ToolType currentTool = ToolType.Selection;
    public ToolType CurrentTool => currentTool;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) SetCurrentTool(ToolType.Selection);
        if (Input.GetKeyDown(KeyCode.W)) SetCurrentTool(ToolType.Hoe);
    }

    public void SetCurrentTool(ToolType newTool)
    {
        currentTool = newTool;
    }

    public void TileInteraction(Tile tile)
    {
        switch (currentTool)
        {
            case ToolType.Selection:
                // Implementar lógica de seleção, se necessário
                break;

            case ToolType.Hoe:
                if (tile.currentState == TileState.Raw)
                {
                    tile.SetState(TileState.Plowed);
                }
                break;
            
            default:
                break;
        }
    }
}