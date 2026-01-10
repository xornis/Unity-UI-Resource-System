using UnityEngine;

[CreateAssetMenu(fileName = "ResourcePopupVisualSettings", menuName = "Scriptable Objects/UnityUIResourceSystem/ResourcePopupVisualSettings")]
public class ResourcePopupVisualSettings : ScriptableObject
{
    [Header("Popup Prefab")]
    [SerializeField] private GameObject popupPrefab;

    [Header("Animation")]
    [SerializeField] private float duration = 0.8f;
    [SerializeField] private float speed = 40f;
    [SerializeField] private float startScaleMultiplier = 1.25f;
    [SerializeField] private float endScaleDivider = 3f;

    [Header("Randomness")]
    [SerializeField] private float spawnRadius = 30f;
    [SerializeField] private float turn = 15f;

    [Header("Colors")]
    [SerializeField] private Color positiveColor = new Color(0.35f, 1f, 0.3f);
    [SerializeField] private Color negativeLight = new Color(1f, 0.4f, 0.4f);
    [SerializeField] private Color negativeDark = new Color(0.5f, 0f, 0f);

    public GameObject PopupPrefab => popupPrefab;

    public float Duration => duration;
    public float Speed => speed;
    public float StartScaleMultiplier => startScaleMultiplier;
    public float EndScaleDivider => endScaleDivider;

    public float SpawnRadius => spawnRadius;
    public float Turn => turn;
    
    public Color PositiveColor => positiveColor;
    public Color NegativeLight => negativeLight;
    public Color NegativeDark => negativeDark;
}
