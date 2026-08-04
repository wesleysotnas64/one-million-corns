using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isOccupied = false;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] _sprites;
    private int xIndex;
    private int yIndex;
    public TileState currentState { get; private set; } = TileState.Raw0;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Setup(int x, int y)
    {
        xIndex = x;
        yIndex = y;

        bool isEven = (xIndex + yIndex) % 2 == 0;
        currentState = isEven ? TileState.Raw0 : TileState.Raw1;

        UpdateVisual();
    }

    // Método para Arar o terreno (preserva a variação xadrez)
    public void Plow()
    {
        if (currentState == TileState.Raw0)
            SetState(TileState.Plowed0);
        else if (currentState == TileState.Raw1)
            SetState(TileState.Plowed1);
    }

    // Método para Limpar/Resetar o terreno de volta para a Grama (preserva a variação xadrez)
    public void ResetToRaw()
    {
        if (currentState == TileState.Plowed0)
            SetState(TileState.Raw0);
        else if (currentState == TileState.Plowed1)
            SetState(TileState.Raw1);
    }

    // Altera o estado diretamente se necessário
    public void SetState(TileState newState)
    {
        currentState = newState;
        UpdateVisual();
    }

    // Atualiza o sprite atribuído ao SpriteRenderer com base no enum
    private void UpdateVisual()
    {
        if (_sprites == null || _sprites.Length < 4)
        {
            Debug.LogWarning($"[Tile] Array _sprites não está configurado corretamente em {gameObject.name}");
            return;
        }

        // Mapeia o enum diretamente para o índice do array de sprites
        int spriteIndex = (int)currentState;
        spriteRenderer.sprite = _sprites[spriteIndex];
    }

    // Helper para verificar se o terreno está arado
    public bool IsPlowed => currentState == TileState.Plowed0 || currentState == TileState.Plowed1;

    // Getters e Setters de ocupação
    public bool IsOccupied => isOccupied;

    public void SetOccupied(bool occupied)
    {
        isOccupied = occupied;
    }

    void OnMouseDown()
    {
        if (ToolsManager.Instance != null)
        {
            switch (ToolsManager.Instance.CurrentTool)
            {
                case ToolType.Hoe:
                    if (!isOccupied)
                    {
                        Plow();
                    }
                    break;
                case ToolType.Selection:
                    // Implementar lógica de seleção, se necessário
                    break;
                default:
                    break;
                
            }
        }
    }
}