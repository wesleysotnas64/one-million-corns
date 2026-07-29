using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isOccupied = false;
    private SpriteRenderer spriteRenderer;

    private int xIndex;
    private int yIndex;

    public TileState currentState { get; private set; } = TileState.Plowed; // Estado inicial do Tile

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Setup(int x, int y)
    {
        xIndex = x;
        yIndex = y;
        UpdateVisual();
    }

    // Altera o estado do solo (ex: quando o jogador usa o Ciscador)
    public void SetState(TileState newState)
    {
        currentState = newState;
        UpdateVisual();
    }

    // Atualiza a cor dependendo do estado atual e da posição no padrão xadrez
    private void UpdateVisual()
    {
        bool isEven = (xIndex + yIndex) % 2 == 0;

        switch (currentState)
        {
            case TileState.Raw:
                if (isEven) SetColorRawLight();
                else SetColorRawDark();
                break;

            case TileState.Plowed:
                if (isEven) SetColorPlowedLight();
                else SetColorPlowedDark();
                break;
        }
    }

    // Cores de Terreno (Grama)
    public void SetColorRawLight()
    {
        spriteRenderer.color = new Color(0.25f, 0.80f, 0.35f);
    }

    public void SetColorRawDark()
    {
        spriteRenderer.color = new Color(0.15f, 0.60f, 0.25f);
    }

    // Cores de Terreno (Arado)
    public void SetColorPlowedLight()
    {
        spriteRenderer.color = new Color(0.55f, 0.35f, 0.18f);
    }

    public void SetColorPlowedDark()
    {
        spriteRenderer.color = new Color(0.42f, 0.25f, 0.10f);
    }

    // Getters e Setters
    public bool IsOccupied => isOccupied;

    public void SetOccupied(bool occupied)
    {
        isOccupied = occupied;
    }
}