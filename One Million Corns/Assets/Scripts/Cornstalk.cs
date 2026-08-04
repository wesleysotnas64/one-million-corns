using UnityEngine;

public class Cornstalk : MonoBehaviour
{
    [SerializeField] private CornstalkState _state = CornstalkState.Seed;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _baseGrowthTime = 2.0f;
    [SerializeField] private float _growthTimer = 0.0f;

    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Growth();
    }

    private void Growth()
    {
        _growthTimer += Time.deltaTime;
        if ((_state != CornstalkState.Mature) && _growthTimer >= _baseGrowthTime)
        {
            _growthTimer = 0.0f;
            AdvanceState();
        }
    }

    public void AdvanceState()
    {
        switch (_state)
        {
            case CornstalkState.Seed:
                SetState(CornstalkState.Germination);
                break;
            case CornstalkState.Germination:
                SetState(CornstalkState.Sprout);
                break;
            case CornstalkState.Sprout:
                SetState(CornstalkState.Young);
                break;
            case CornstalkState.Young:
                SetState(CornstalkState.Mature);
                break;
            case CornstalkState.Mature:
                SetState(CornstalkState.Harvested);
                _growthTimer = 0.0f;
                break;
            case CornstalkState.Harvested:
                SetState(CornstalkState.Dry);
                break;
            case CornstalkState.Dry:
                break;
        }
    }

    public void SetState(CornstalkState newState)
    {
        _state = newState;
        UpdateSprite();
    }

    public void UpdateSprite()
    {
        switch (_state)
        {
            case CornstalkState.Seed:
                _spriteRenderer.sprite = _sprites[0]; // Example sprite for Seed
                break;
            case CornstalkState.Germination:
                _spriteRenderer.sprite = _sprites[1]; // Example sprite for Germination
                break;
            case CornstalkState.Sprout:
                _spriteRenderer.sprite = _sprites[2]; // Example sprite for Sprout
                break;
            case CornstalkState.Young:
                _spriteRenderer.sprite = _sprites[3]; // Example sprite for Young
                break;
            case CornstalkState.Mature:
                _spriteRenderer.sprite = _sprites[4]; // Example sprite for Mature
                break;
            case CornstalkState.Harvested:
                _spriteRenderer.sprite = _sprites[5]; // Example sprite for Harvested
                break;
            case CornstalkState.Dry:
                _spriteRenderer.sprite = _sprites[6]; // Example sprite for Dry
                break;
        }
    }
    
}
