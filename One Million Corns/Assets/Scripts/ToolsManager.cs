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
        if (Input.GetKeyDown(KeyCode.E)) SetCurrentTool(ToolType.Seed);
        if (Input.GetKeyDown(KeyCode.R)) SetCurrentTool(ToolType.WateringCan);
        if (Input.GetKeyDown(KeyCode.A)) SetCurrentTool(ToolType.Glove);
        if (Input.GetKeyDown(KeyCode.S)) SetCurrentTool(ToolType.Sickle);
    }

    public void SetCurrentTool(ToolType newTool)
    {
        currentTool = newTool;
    }

}