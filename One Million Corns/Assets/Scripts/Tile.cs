using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetColorLight()
    {
        spriteRenderer.color = new Color(0.25f, 0.80f, 0.35f);
    }

    public void SetColorDark()
    {
        spriteRenderer.color = new Color(0.15f, 0.60f, 0.25f);
    }

}
